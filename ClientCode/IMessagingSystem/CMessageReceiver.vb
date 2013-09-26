Imports System.Data.OleDb
Imports System.Web.Services.Protocols

Public Class CMessageReceiver

    Dim ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ClientDB.mdb"

    'For Internetless operation
    Dim MessageBuffer As String
    Dim tmrReceiveMessage As New System.Windows.Forms.Timer()

    'This System don't use conneciton object
    Dim ReqMsgServiceStub As New ReqMsgService.ReceiveMessageService()
    'Asynchronous call objects-declared global to enable recursive call
    Dim ReceiveMessageServiceStub As New ReqMsgService.ReceiveMessageService()
    Dim AsyncCallback As New AsyncCallback(AddressOf MyCallBack)


    Public Sub StartReceive()
        If modInternetConnection Then
            ReqMsgServiceStub.BeginAsyncMessageRequest(modUserId, modPasswordChallenge, AsyncCallback, ReceiveMessageServiceStub)
        Else
            AddHandler tmrReceiveMessage.Tick, AddressOf tmrReceiveMessage_Elapsed
            tmrReceiveMessage.Interval = 1000 * 10
            tmrReceiveMessage.Enabled = True
        End If
    End Sub

    Public Sub StopReceive()
        If modInternetConnection Then
            modServiceObject.SendMessage("ClientsAccount", "ClientsAccount", modUserId, "Logout Message")
        Else
            tmrReceiveMessage.Stop()
            tmrReceiveMessage.Enabled = False
        End If
    End Sub

    Private Sub tmrReceiveMessage_Elapsed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBuffer = modServiceObject.RequestMessage(modUserId, modPasswordChallenge)
        If MessageBuffer <> "MESAG-15: NO MESSAGES" Then
            UpdateMessagetoClientDB(MessageBuffer)
        End If
    End Sub

    Public Sub MyCallBack(ByVal ar As System.IAsyncResult)
        Dim ReceiveMessageServiceStub As ReqMsgService.ReceiveMessageService
        Dim RawMessage As String

        'Get Message from AsyncResult
        ReceiveMessageServiceStub = ar.AsyncState
        RawMessage = ReceiveMessageServiceStub.EndAsyncMessageRequest(ar)

        UpdateMessagetoClientDB(RawMessage)

        'Next request to maintain continuity
        ReqMsgServiceStub.BeginAsyncMessageRequest(modUserId, modPasswordChallenge, AsyncCallback, ReceiveMessageServiceStub)
    End Sub

    'Split Message and Store it to Database ClientDB
    Private Sub UpdateMessagetoClientDB(ByVal MessageString As String)
        'String handling identifiers
        Dim SplitArray() As String
        Dim SecSplitArray() As String
        Dim TerSplitArray() As String
        Dim NoOfMessages As Integer
        Dim ForCnt As Integer

        'Database field variables
        Dim ReceiverId As String   'To differentiate different users on same system
        Dim SenderId As String
        Dim Message As String
        Dim GMTTime As String
        Dim DeliveryDate As String

        'Data handling ADO variables
        Dim TheDataSet As DataSet
        Dim TheDataAdapter As OleDbDataAdapter
        Dim TheConnection As OleDbConnection
        Dim TheCommand As OleDbCommand
        Dim SqlCommand As String

        ReceiverId = modUserId
        'Get number of messages in this slot
        SplitArray = MessageString.Split("»")
        NoOfMessages = CType(SplitArray(0), Integer)
        MessageString = SplitArray(1)

        'Individual messages in split array
        SplitArray = MessageString.Split("î")
        For ForCnt = 0 To NoOfMessages - 1
            SecSplitArray = SplitArray(ForCnt).Split("ï")
            SenderId = SecSplitArray(0)
            GMTTime = SecSplitArray(1)

            If (SecSplitArray(2).Length > 6) Then
                If (SecSplitArray(2).Substring(0, 6) = "TIMED:") Then
                    SecSplitArray(2) = SecSplitArray(2).Substring(6)
                    TerSplitArray = SecSplitArray(2).Split("§")

                    DeliveryDate = TerSplitArray(0)
                    Message = TerSplitArray(1)
                Else
                    DeliveryDate = CType(Date.FromFileTime(modUniversalServerTime).Add(New TimeSpan(0, 0, 5)).ToFileTime, String)
                    Message = SecSplitArray(2)
                End If
            Else
                DeliveryDate = CType(Date.FromFileTime(modUniversalServerTime).Add(New TimeSpan(0, 0, 5)).ToFileTime, String)
                Message = SecSplitArray(2)
            End If
            If Not modAddressBook.IsUserBlocked(SenderId) Then
                'Store the message in Database ClientDB-Table MessageDB
                TheConnection = New OleDb.OleDbConnection(ConnectionString)
                TheConnection.Open()
                SqlCommand = "Insert into MessageDB values('" & ReceiverId & "','" & SenderId & "','" & Message & "','" & GMTTime & "','" & DeliveryDate & "')"
                TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
                TheCommand.ExecuteNonQuery()
                TheConnection.Close()
            End If
        Next
    End Sub
End Class
