Imports System.Data.OleDb

'Internal Documentation
'No of messages displayed control techniques employed

'1)Delete the messages as soon as they are read into Datasets
'2)Use TimeHolder variable to prevent Select and Delete have different values
'3)

Public Class CMessageDisplayer

    Dim tmrDisplayMessage As New System.Windows.Forms.Timer()
    Dim SilentIcon As New NotifyIcon()
    Dim ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ClientDB.mdb"

    Dim TheDataSet As DataSet
    Dim TheDataAdapter As OleDbDataAdapter
    Dim TheConnection As OleDbConnection
    Dim TheCommand As OleDbCommand
    Dim SqlCommand As String
    Dim ShownUpCommand, LogDelCommand, SilentInsertCommand As String

    Dim RowsCount As Integer
    Dim i As Integer
    Dim CurTime As Date
    Dim TheArray() As String

    Dim ObjfrmMessageBox() As Form
    Dim MessageId As String 'For handling vote messages
    Dim SenderId As String
    Dim Message As String
    Dim SentTime As Date
    Dim TimeHolder As Long

    Private Sub tmrDisplayMessage_Elapsed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If modSessionStatus = "LOGGED" Then
            'Delete Logout Messages first
            LogDelCommand = "Delete * from MessageDB where Message = 'Logout Message'"
            TheCommand = New OleDb.OleDbCommand(LogDelCommand, TheConnection)
            TheCommand.ExecuteNonQuery()

            'Select messages from database
            TimeHolder = modUniversalServerTime
            SqlCommand = "Select * from MessageDB Where (DeliveryDate < '" & TimeHolder & "' and ReceiverId = '" & modUserId & "' and SenderId <> 'ClientsAccount')"
            TheDataSet = New DataSet()
            TheDataAdapter = New OleDb.OleDbDataAdapter(SqlCommand, ConnectionString)
            TheDataAdapter.Fill(TheDataSet, "TTable")
            RowsCount = TheDataSet.Tables("TTable").Rows.Count

            'Delete messages from databases ShownUpCommand
            ShownUpCommand = "Delete * from MessageDB where DeliveryDate < " & "'" & TimeHolder & "'" & "and ReceiverId=" & "'" & modUserId & "'"
            TheCommand = New OleDb.OleDbCommand(ShownUpCommand, TheConnection)
            TheCommand.ExecuteNonQuery()

            tmrDisplayMessage.Enabled = False
            If (RowsCount <> 0) Then
                ReDim ObjfrmMessageBox(RowsCount)
                For i = 0 To RowsCount - 1

                    SenderId = TheDataSet.Tables("TTable").Rows(i).Item("SenderId")
                    Message = TheDataSet.Tables("TTable").Rows(i).Item("Message")
                    SentTime = Date.FromFileTime(CType(TheDataSet.Tables("TTable").Rows(i).Item("SentDate"), Long))

                    'Silent or NotSilent Mode
                    If modOperationMode = "SILENT" Then
                        'Write into SilentModeDB
                        SilentInsertCommand = "Insert into SilentModeDB values('" & modUserId & "','" & SenderId & "','" & Message & "','" & SentTime & "')"
                        TheCommand = New OleDb.OleDbCommand(SilentInsertCommand, TheConnection)
                        TheCommand.ExecuteNonQuery()

                        'Display Icon
                        If Not modIsSilentIconSet Then
                            SilentIcon.Visible = True
                            modIsSilentIconSet = True
                        End If
                    Else
                        'If Message is a vote message
                        If Message.Split(":")(0) = "VOTEM" Then
                            TheArray = Message.Split(":")
                            MessageId = TheArray(1) & ":" & TheArray(2) & ":" & TheArray(3)
                            Message = TheArray(4)

                            ObjfrmMessageBox(i) = New frmVotingMessage(SenderId)
                            CType(ObjfrmMessageBox(i), frmVotingMessage).rtbHeader.Text = modUserId & ",You got a vote request from " & SenderId & " sent on " & SentTime.ToLocalTime
                            CType(ObjfrmMessageBox(i), frmVotingMessage).rtbMessage.Text = Message
                            CType(ObjfrmMessageBox(i), frmVotingMessage).MessageId = MessageId
                            ObjfrmMessageBox(i).Text = "Vote Request from " & SenderId
                            ObjfrmMessageBox(i).Show()
                            ObjfrmMessageBox(i).Refresh()
                        Else
                            ObjfrmMessageBox(i) = New frmMessageBox(SenderId)
                            CType(ObjfrmMessageBox(i), frmMessageBox).rtbHeader.Text = modUserId & ",You got a message from " & SenderId & " sent on " & SentTime.ToLocalTime
                            CType(ObjfrmMessageBox(i), frmMessageBox).rtbMessage.Text = Message
                            ObjfrmMessageBox(i).Text = "Message from " & SenderId
                            ObjfrmMessageBox(i).Show()
                        End If
                    End If
                Next
            End If
            tmrDisplayMessage.Enabled = True
        End If
    End Sub

    Public Sub StartDisplay()
        AddHandler tmrDisplayMessage.Tick, AddressOf tmrDisplayMessage_Elapsed
        tmrDisplayMessage.Interval = 1000
        tmrDisplayMessage.Enabled = True
        tmrDisplayMessage.Start()


        SilentIcon.Text = "You have got Instant Message(s)"
        SilentIcon.Icon = New Icon("SilentIcon.ico")
        AddHandler SilentIcon.Click, AddressOf SilentIcon_Click

        'Open database connections
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
    End Sub

    Public Sub StopDisplay()
        tmrDisplayMessage.Enabled = False
        tmrDisplayMessage.Stop()

        'Close database connection
        TheConnection.Close()
    End Sub

    Private Sub SilentIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TheCommand, DeleteCommand As String
        Dim SilentDataSet As DataSet
        Dim SilentDataAdapter As OleDbDataAdapter
        Dim SilentConnection As OleDbConnection
        Dim SilentCommand As OleDbCommand

        Dim I, SilentCount As Integer
        Dim SilentMessageBox() As Form
        Dim SenderId, Message, TheArray(), MessageId As String
        Dim SentTime As Date

        SilentIcon.Visible = False
        modIsSilentIconSet = False

        'Select the data from the database
        TheCommand = "Select * from SilentModeDB where ReceiverId = '" & modUserId & "'"
        SilentDataSet = New DataSet()
        SilentDataAdapter = New OleDb.OleDbDataAdapter(TheCommand, ConnectionString)
        SilentDataAdapter.Fill(SilentDataSet, "SilentTable")
        SilentCount = SilentDataSet.Tables("SilentTable").Rows.Count

        'Delete messages from databases DeleteCommand
        DeleteCommand = "Delete * from SilentModeDB where ReceiverId=" & "'" & modUserId & "'"
        SilentConnection = New OleDb.OleDbConnection(ConnectionString)
        SilentConnection.Open()
        SilentCommand = New OleDb.OleDbCommand(DeleteCommand, SilentConnection)
        SilentCommand.ExecuteNonQuery()
        SilentConnection.Close()

        ReDim SilentMessageBox(SilentCount)

        For I = 0 To SilentCount - 1
            SenderId = SilentDataSet.Tables("SilentTable").Rows(I).Item("SenderId")
            Message = SilentDataSet.Tables("SilentTable").Rows(I).Item("Message")
            SentTime = SilentDataSet.Tables("SilentTable").Rows(I).Item("SentDate")

            'If Message is a vote message
            If Message.Split(":")(0) = "VOTEM" Then
                TheArray = Message.Split(":")
                MessageId = TheArray(1) & ":" & TheArray(2) & ":" & TheArray(3)
                Message = TheArray(4)

                SilentMessageBox(I) = New frmVotingMessage(SenderId)
                CType(SilentMessageBox(I), frmVotingMessage).rtbHeader.Text = modUserId & ",You got a vote request from " & SenderId & " sent on " & SentTime.ToLocalTime
                CType(SilentMessageBox(I), frmVotingMessage).rtbMessage.Text = Message
                CType(SilentMessageBox(I), frmVotingMessage).MessageId = MessageId
                SilentMessageBox(I).Text = "Vote Request from " & SenderId
                SilentMessageBox(I).Show()
                SilentMessageBox(I).Refresh()
            Else
                SilentMessageBox(I) = New frmMessageBox(SenderId)
                CType(SilentMessageBox(I), frmMessageBox).rtbHeader.Text = modUserId & ",You got a message from " & SenderId & " sent on " & SentTime.ToLocalTime
                CType(SilentMessageBox(I), frmMessageBox).rtbMessage.Text = Message
                SilentMessageBox(I).Text = "Message from " & SenderId
                SilentMessageBox(I).Show()
                SilentMessageBox(I).Refresh()
            End If
        Next
    End Sub
End Class
