Imports System.Web.Services
Imports System.Data.OleDb
Imports System.Math
Imports System.Data
Imports Microsoft.VisualBasic

'Session Service contains all the Services for which the user need not to login
<WebService(Namespace:="http://tempuri.org/")> _
Public Class SessionService
    Inherits System.Web.Services.WebService

    Dim TheDataSet As DataSet
    Dim TheDataAdapter As OleDbDataAdapter
    Dim TheConnection As OleDbConnection
    Dim TheCommand As OleDbCommand
    Dim ConnectionString As String
    Dim SqlCommand As String

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
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



    <WebMethod()> Public Function ClearSession(ByVal UserId As String, ByVal Password As String, ByVal DOB As String, ByVal SchoolName As String) As String
        Dim ReturnString As String
        Dim RowsCount As Integer

        'UserId OK?
        If Not ValidateUserId(UserId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'Check for correctness of Data
        If Not CheckUserData(UserId, Password, DOB, SchoolName) Then
            ReturnString = "ERROR-06: DATA INVALID"
            Return ReturnString
        End If

        'If Data provided is correct then clear session
        SqlCommand = "update AuthServiceTable set SessionState = 'NOTLOGGED' , Challenge = '-1' where UserId='" & UserId & "'"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        ReturnString = "MESAG-05: SESSION CLEARED"
        Return ReturnString
    End Function

    <WebMethod()> Public Function ClearPassword(ByVal UserId As String, ByVal DOB As String, ByVal SchoolName As String) As String
        Dim ReturnString As String
        Dim RowsCount As Integer

        'UserId OK?
        If Not ValidateUserId(UserId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'If Data provided is correct then change password
        If Not (CheckUserData(UserId, DOB, SchoolName)) Then
            ReturnString = "ERROR-06: DATA INVALID"
            Return ReturnString
        End If

        'Change in AuthServiceTable
        SqlCommand = "update AuthServiceTable set UserPassword = '" & UserId & "' , SessionState = 'NOTLOGGED' , Challenge = '-1' where UserId='" & UserId & "'"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        'Change in UserAccountsDB
        SqlCommand = "update UserAccountsDB set UserPassword = '" & UserId & "' where UserId='" & UserId & "'"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        ReturnString = "MESAG-06: PASSWORD CLEARED"
        Return ReturnString
    End Function

    <WebMethod()> Public Function ChangePassword(ByVal UserId As String, ByVal OldPassword As String, ByVal NewPassword As String) As String
        Dim ReturnString As String
        Dim RowsCount As Integer

        'UserId OK?
        If Not ValidateUserId(UserId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'If OldPassword provided is correct then change password
        SqlCommand = "Select * from UserAccountsDB where UserId = '" & UserId & "' and UserPassword = '" & OldPassword & "'"
        TheDataSet = New DataSet()

        TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
        TheDataAdapter.Fill(TheDataSet, "ClearPasswordTable")
        RowsCount = TheDataSet.Tables("ClearPasswordTable").Rows.Count

        If RowsCount = 0 Then
            ReturnString = "ERROR-06: DATA INVALID"
            Return ReturnString
        End If

        'Change in AuthServiceTable
        SqlCommand = "update AuthServiceTable set UserPassword = '" & NewPassword & "' , SessionState = 'NOTLOGGED' , Challenge = '-1' where UserId='" & UserId & "'"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        'Change in UserAccountsDB
        SqlCommand = "update UserAccountsDB set UserPassword = '" & NewPassword & "' where UserId='" & UserId & "'"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        ReturnString = "MESAG-14: PASSWORD CHANGED"
        Return ReturnString
    End Function

    <WebMethod()> Public Function GetServerTime() As String
        Return Now.ToUniversalTime.ToFileTime.ToString
    End Function

    <WebMethod()> Public Function StoreSettings(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal Settings As String) As String
        Dim ReturnString As String
        ReturnString = "MESAG-16: SETTINGS STORED"

        'UserId OK?
        If Not ValidateUserId(UserId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'Sender currently on Session?
        If CheckSession(UserId, PasswordChallenge) Then

            'Update Settings
            SqlCommand = "update UserSettingsDB set SettingString = '" & Settings & "' where UserId='" & UserId & "'"
            TheConnection = New OleDb.OleDbConnection(ConnectionString)
            TheConnection.Open()
            TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
            TheCommand.ExecuteNonQuery()
            TheConnection.Close()
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
            Return ReturnString
        End If

        Return ReturnString
    End Function

    <WebMethod()> Public Function LoadSettings(ByVal UserId As String, ByVal PasswordChallenge As String) As String
        Dim ReturnString As String

        'UserId OK?
        If Not ValidateUserId(UserId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'Sender currently on Session?
        If CheckSession(UserId, PasswordChallenge) Then

            'Load Settings
            SqlCommand = "Select * from UserSettingsDB where UserId = '" & UserId & "'"
            TheDataSet = New DataSet()
            TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
            TheDataAdapter.Fill(TheDataSet, "SettingsTable")
            ReturnString = TheDataSet.Tables("SettingsTable").Rows(0).Item("SettingString")
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
            Return ReturnString
        End If

        Return ReturnString
    End Function

    <WebMethod()> Public Function StoreIPAddress(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal IpAddress As String) As String
        Dim ReturnString As String
        ReturnString = "MESAG-17: IPADDRESS STORED"

        'UserId OK?
        If Not ValidateUserId(UserId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'Sender currently on Session?
        If CheckSession(UserId, PasswordChallenge) Then

            'Update Settings
            SqlCommand = "update UserSettingsDB set IpAddress = '" & IpAddress & "' where UserId='" & UserId & "'"
            TheConnection = New OleDb.OleDbConnection(ConnectionString)
            TheConnection.Open()
            TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
            TheCommand.ExecuteNonQuery()
            TheConnection.Close()
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
            Return ReturnString
        End If

        Return ReturnString
    End Function

    <WebMethod()> Public Function StoreBackMessage(ByVal Messages As String) As String
        UpdateMessagetoMessageDB(Messages)
        Return "MESAG-02: MESSAGE SENT"
    End Function

    Private Function CheckUserData(ByVal UserId As String, ByVal DOB As String, ByVal SchoolName As String) As Boolean
        Dim RowsCount As Integer

        SqlCommand = "Select * from UserAccountsDB where UserId = '" & UserId & "' and DateOfBirth = '" & DOB & "' and FirstSchool = '" & SchoolName & "'"
        TheDataSet = New DataSet()

        TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
        TheDataAdapter.Fill(TheDataSet, "ClearPasswordTable")
        RowsCount = TheDataSet.Tables("ClearPasswordTable").Rows.Count

        'Check for correctness of Data
        If RowsCount = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function CheckUserData(ByVal UserId As String, ByVal Password As String, ByVal DOB As String, ByVal SchoolName As String) As Boolean
        Dim RowsCount As Integer

        SqlCommand = "Select * from UserAccountsDB where UserId = '" & UserId & "' and UserPassword = '" & Password & "' and DateOfBirth = '" & DOB & "' and FirstSchool = '" & SchoolName & "'"
        TheDataSet = New DataSet()

        TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
        TheDataAdapter.Fill(TheDataSet, "ClearSessionTable")
        RowsCount = TheDataSet.Tables("ClearSessionTable").Rows.Count

        If RowsCount = 0 Then
            Return False
        Else
            Return True
        End If
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
    Private Function CheckSession(ByVal UserId As String, ByVal PasswordChallenge As String) As Boolean
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
            If (GenerateChallengeValue(DBPassword, DBChallenge) = PasswordChallenge) Then
                ReturnValue = True
            Else
                ReturnValue = False
            End If
        End If
        Return ReturnValue
    End Function
    Private Function GenerateChallengeValue(ByVal Password As String, ByVal Challenge As String) As String
        Dim i As Integer
        Dim ChallengeValue As String

        For i = 0 To Password.Length - 1
            ChallengeValue = ChallengeValue & Chr(Asc(Password.Substring(i, 1)) + Val(Challenge))
        Next

        Return ChallengeValue
    End Function

    'Split Message and Store it to Database ClientDB
    Private Sub UpdateMessagetoMessageDB(ByVal MessageString As String)
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

        ReceiverId = MessageString.Split("-")(0)
        MessageString = MessageString.Split("-")(1)
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
            Message = SecSplitArray(2)

            'Store the message in Database ClientDB-Table MessageDB
            TheConnection = New OleDb.OleDbConnection(ConnectionString)
            TheConnection.Open()
            SqlCommand = "Insert into MessageDB values('" & ReceiverId & "','" & SenderId & "','" & Message & "','" & GMTTime & "')"
            TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
            TheCommand.ExecuteNonQuery()
            TheConnection.Close()
        Next
    End Sub
End Class


