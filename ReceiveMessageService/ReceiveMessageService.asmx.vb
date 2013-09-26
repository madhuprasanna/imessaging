Imports System.Web.Services
Imports System.Data.OleDb
Imports System.Math
Imports System.Data
Imports Microsoft.VisualBasic

<WebService(Namespace:="http://www20.brinkster.com/madhuprasanna/ReceiveMessageService/")> _
Public Class ReceiveMessageService
    Inherits System.Web.Services.WebService

    Dim TheDataSet As DataSet
    Dim TheDataAdapter As OleDbDataAdapter
    Dim TheConnection As OleDbConnection
    Dim TheCommand As OleDbCommand
    Dim ConnectionString As String
    Dim SqlCommand As String

    Dim TimerVariable As Boolean
    'Web Services Designer Generated Code Modified
#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()
        ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\ProjectCode\ServerDB.mdb"
        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents tmrService As System.Timers.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tmrService = New System.Timers.Timer()
        CType(Me.tmrService, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'tmrService
        '
        Me.tmrService.Interval = 5000
        CType(Me.tmrService, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    '*******************************************************************************'
    'Name               :   AsyncMessageRequest                                     
    'Modified on        :   6 Feb 2004                                              
    'Purpose            :   Used to retrive message asynchronously by the client. Re
    '                       -triving messages will delete them in MessageDB.        
    '*******************************************************************************'
    <WebMethod()> Public Function AsyncMessageRequest(ByVal UserId As String, ByVal PasswordChallenge As String) As String
        Dim ReturnString As String
        Dim IsUserAuthorized As Boolean
        Dim RowsCount As Integer
        Dim I As Integer

        Dim SenderId As String
        Dim Message As String
        Dim GMTTime As String

        IsUserAuthorized = False
        TimerVariable = False
        RowsCount = 0

        'UserId OK?
        If Not ValidateUserId(UserId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'Receiver currently on Session?
        If CheckSession(UserId, PasswordChallenge) Then
            IsUserAuthorized = True
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
            Return ReturnString
        End If

        tmrService.Start()     'Start Timer
        SqlCommand = "Select * from MessageDB where ReceiverId = '" & UserId & "'"
        TheDataSet = New DataSet()

        While IsUserAuthorized And RowsCount = 0

            'Wait for Messages and out the loop if messages arrives : 5 Secs
            If TimerVariable Then
                TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
                TheDataAdapter.Fill(TheDataSet, "MessagesRequestTable")
                RowsCount = TheDataSet.Tables("MessagesRequestTable").Rows.Count()
                'TimerVariable = False
            End If
        End While

        'Message Protocol - 1
        ReturnString = RowsCount & "»"

        For I = 0 To RowsCount - 1
            'Store current message 
            SenderId = TheDataSet.Tables("MessagesRequestTable").Rows(I).Item("SenderId")
            GMTTime = TheDataSet.Tables("MessagesRequestTable").Rows(I).Item("GMTTime")
            Message = TheDataSet.Tables("MessagesRequestTable").Rows(I).Item("Message")

            'Message Protocol - 2
            ReturnString &= SenderId & "ï"
            ReturnString &= GMTTime & "ï"
            ReturnString &= Message & "î"
        Next

        'Delete all extracted messages from the MessageDB
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        SqlCommand = "Delete * from MessageDB where ReceiverId = '" & UserId & "'"
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        Return ReturnString
    End Function


    '*******************************************************************************'
    'Name               :   SyncMessageRequest                                     
    'Modified on        :   6 Feb 2004                                              
    'Purpose            :   Used to retrive message synchronously by the client. Retr
    '                           -iving messages will delete them in MessageDB.        
    '*******************************************************************************'
    <WebMethod()> Public Function SyncMessageRequest(ByVal UserId As String, ByVal PasswordChallenge As String) As String
        Dim ReturnString As String
        Dim IsUserAuthorized As Boolean
        Dim RowsCount As Integer
        Dim I As Integer

        Dim SenderId As String
        Dim Message As String
        Dim GMTTime As String

        IsUserAuthorized = False
        TimerVariable = False
        RowsCount = 0

        'UserId OK?
        If Not ValidateUserId(UserId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'Receiver currently on Session?
        If CheckSession(UserId, PasswordChallenge) Then
            IsUserAuthorized = True
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
            Return ReturnString
        End If


        SqlCommand = "Select * from MessageDB where ReceiverId = '" & UserId & "'"
        TheDataSet = New DataSet()

        TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
        TheDataAdapter.Fill(TheDataSet, "MessagesRequestTable")
        RowsCount = TheDataSet.Tables("MessagesRequestTable").Rows.Count()

        If RowsCount = 0 Then
            ReturnString = "MESAG-15: NO MESSAGES"
        Else
            'Message Protocol - 1
            ReturnString = RowsCount & "»"

            For I = 0 To RowsCount - 1
                'Store current message 
                SenderId = TheDataSet.Tables("MessagesRequestTable").Rows(I).Item("SenderId")
                GMTTime = TheDataSet.Tables("MessagesRequestTable").Rows(I).Item("GMTTime")
                Message = TheDataSet.Tables("MessagesRequestTable").Rows(I).Item("Message")

                'Message Protocol - 2
                ReturnString &= SenderId & "ï"
                ReturnString &= GMTTime & "ï"
                ReturnString &= Message & "î"
            Next

            'Delete all extracted messages from the MessageDB
            TheConnection = New OleDb.OleDbConnection(ConnectionString)
            TheConnection.Open()
            SqlCommand = "Delete * from MessageDB where ReceiverId = '" & UserId & "'"
            TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
            TheCommand.ExecuteNonQuery()
            TheConnection.Close()
        End If

        Return ReturnString
    End Function

    Private Function ValidateUserId(ByVal UserId As String) As Boolean
        Dim RowsCount As Integer
        Dim ReturnValue As Boolean

        SqlCommand = "select UserId from AuthServiceTable where UserId = '" & UserId & "'"
        TheDataSet = New DataSet()
        TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
        TheDataAdapter.Fill(TheDataSet, "ValidateUserTable")

        RowsCount = TheDataSet.Tables("ValidateUserTable").Rows.Count
        If RowsCount = 0 Then
            ReturnValue = False
        Else
            ReturnValue = True
        End If

        Return ReturnValue
    End Function
    Private Function CheckSession(ByVal UserId As String, ByVal ChallengePass As String) As Boolean
        Dim RowsCount As Integer
        Dim ReturnValue As Boolean
        Dim DBPassword As String
        Dim DBChallenge As String

        SqlCommand = "select * from AuthServiceTable where (UserId = '" & UserId & "' and SessionState = 'LOGGED')"
        TheDataSet = New DataSet()
        TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
        TheDataAdapter.Fill(TheDataSet, "SessionCheckTable")

        RowsCount = TheDataSet.Tables("SessionCheckTable").Rows.Count
        If RowsCount = 0 Then
            ReturnValue = False
        Else
            DBPassword = TheDataSet.Tables("SessionCheckTable").Rows(0).Item("UserPassword")
            DBChallenge = TheDataSet.Tables("SessionCheckTable").Rows(0).Item("Challenge")
            If (GenerateChallengeValue(DBPassword, DBChallenge) = ChallengePass) Then
                ReturnValue = True
            Else
                ReturnValue = False
            End If
        End If
        Return ReturnValue
    End Function
    Private Function GenerateChallengeValue(ByVal Password As String, ByVal Challenge As String)
        Dim i As Integer
        Dim ChallengeValue As String

        For i = 0 To Password.Length - 1
            ChallengeValue = ChallengeValue & Chr(Asc(Password.Substring(i, 1)) + Val(Challenge))
        Next

        Return ChallengeValue
    End Function
    Private Sub tmrService_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles tmrService.Elapsed
        TimerVariable = True
    End Sub

End Class

