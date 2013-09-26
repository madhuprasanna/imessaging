Imports System.Web.Services
Imports System.Data.OleDb
Imports System.Data
Imports System.Math
Imports Microsoft.VisualBasic

<WebService(Namespace:="http://www20.brinkster.com/madhuprasanna/AuthService/")> _
Public Class AuthService
    Inherits System.Web.Services.WebService

    Dim TheDataSet As DataSet
    Dim TheDataAdapter As OleDbDataAdapter
    Dim TheConnection As OleDbConnection
    Dim TheCommand As OleDbCommand
    Dim ConnectionString As String
    Dim SqlCommand As String
    Dim TempCount As Integer

    'Web Services Designer Generated Code Modified
#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()
        ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\ProjectCode\ServerDB.mdb"
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


    <WebMethod()> Public Function TestConnection(ByVal TestString As String) As String
        Return TestString
    End Function

    <WebMethod()> Public Function ChallengeRequest(ByVal UserId As String) As String
        Dim ReturnString As String
        Dim RowsCount As String
        Dim Session As String

        Randomize(Timer) 'Used to generate seed for random numbers

        SqlCommand = "select UserId,SessionState from AuthServiceTable where UserId = '" & UserId & "'"
        TheDataSet = New DataSet()
        TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
        TheDataAdapter.Fill(TheDataSet, "ChallengeRequestTable")

        RowsCount = TheDataSet.Tables("ChallengeRequestTable").Rows.Count

        'If no such UserId exists return error code 01
        If RowsCount = 0 Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        Else
            'If userid exists then take the Session state information from Database
            Session = TheDataSet.Tables("ChallengeRequestTable").Rows(0).Item("SessionState")
        End If

        'Is user already logged
        If Session = "LOGGED" Then
            ReturnString = "ERROR-05: ALREADY LOGGED"
            Return ReturnString
        End If

        'Generate random numbers within 10
        ReturnString = Str(Int((Rnd() * 100)) Mod 10)

        'Update Challenge value.
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        SqlCommand = "Update AuthServiceTable Set Challenge='" & ReturnString & "' Where UserId='" & UserId & "'"
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        Return ReturnString
    End Function

    <WebMethod()> Public Function Authenticate(ByVal UserId As String, ByVal PasswordChallenge As String) As String
        Dim ReturnString As String
        Dim RowsCount As String
        Dim DBPassword As String
        Dim DBChallenge As String

        SqlCommand = "select UserId,UserPassword,Challenge from AuthServiceTable where UserId = '" & UserId & "'"
        TheDataSet = New DataSet()
        TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
        TheDataAdapter.Fill(TheDataSet, "AuthenticateTable")

        RowsCount = TheDataSet.Tables("AuthenticateTable").Rows.Count
        If RowsCount = 0 Then       'If no such UserId exists return error code 01
            ReturnString = "ERROR-01: INVALID USERID"
        Else
            DBPassword = TheDataSet.Tables("AuthenticateTable").Rows(0).Item("UserPassword")
            DBChallenge = TheDataSet.Tables("AuthenticateTable").Rows(0).Item("Challenge")

            If GenerateChallengeValue(DBPassword, DBChallenge) = PasswordChallenge Then     'If User issues correct passwordchallenge
                'Update Session information in Database
                TheConnection = New OleDb.OleDbConnection(ConnectionString)
                TheConnection.Open()

                SqlCommand = "update AuthServiceTable set SessionState = 'LOGGED' where UserId='" & UserId & "'"

                TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
                TheCommand.ExecuteNonQuery()
                TheConnection.Close()
                ReturnString = "MESAG-01: AUTHENTICATION SUCCESS"
            Else
                ReturnString = "ERROR-02: AUTHENTICATION FAILURE"
            End If
        End If

        Return ReturnString
    End Function

    <WebMethod()> Public Function CloseSession(ByVal UserId As String, ByVal PasswordChallenge As String) As String
        Dim ReturnString As String

        'Sender Id OK?
        If Not ValidateUserId(UserId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'Sender currently on Session?
        If CheckSession(UserId, PasswordChallenge) Then
            'Close the Session
            SqlCommand = "update AuthServiceTable set SessionState = 'NOTLOGGED' , Challenge = '-1' where UserId='" & UserId & "'"
            TheConnection = New OleDb.OleDbConnection(ConnectionString)
            TheConnection.Open()
            TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
            TheCommand.ExecuteNonQuery()
            TheConnection.Close()

            ReturnString = "MESAG-04: SESSION CLOSED"
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
        End If

        Return ReturnString
    End Function

    Private Function ValidateUserId(ByVal UserId As String) As Boolean
        Dim RowsCount As Integer
        Dim ReturnValue As Boolean

        SqlCommand = "select UserId from AuthServiceTable where UserId = '" & UserId & "'"
        TheDataSet = New DataSet()
        TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
        TheDataAdapter.Fill(TheDataSet, "ValidateUserIdTable")

        RowsCount = TheDataSet.Tables("ValidateUserIdTable").Rows.Count
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
End Class
