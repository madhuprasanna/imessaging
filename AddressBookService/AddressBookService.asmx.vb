Imports System.Web.Services
Imports System.Data.OleDb
Imports System.Math
Imports System.Data
Imports Microsoft.VisualBasic

<WebService(Namespace:="http://tempuri.org/")> _
Public Class AddressBookService
    Inherits System.Web.Services.WebService

    Dim TheDataSet As DataSet
    Dim TheDataAdapter As OleDbDataAdapter
    Dim TheConnection As OleDbConnection
    Dim TheCommand As OleDbCommand
    Dim ConnectionString As String
    Dim SqlCommand As String
    Dim TempCount As Integer

    'AddressBook UserString format: UserId1:<B>or<N>;UserId2:<B>or<N>
    'AddressBook GroupString format: GroupId1:UserId1:UserId2;GroupId2:UserId3:UserId4
    'These two strings are connected by UserString|GroupString called AddressBookString
    'Empty AddressBook is indiacted by NONE

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


    'Returns AddressString
    <WebMethod()> Public Function LoadAddressBook(ByVal UserId As String, ByVal PasswordChallenge As String) As String
        Dim AddressBookString As String
        Dim ReturnString As String

        'UserId OK?
        If Not ValidateUserId(UserId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'User currently on Session?
        If CheckSession(UserId, PasswordChallenge) Then
            SqlCommand = "select * from AddressBookDB where UserId = '" & UserId & "'"
            TheDataSet = New DataSet()
            TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
            TheDataAdapter.Fill(TheDataSet, "LoadAddressBookDB")

            AddressBookString = TheDataSet.Tables("LoadAddressBookDB").Rows(0).Item("UserAddressString") & "|"
            AddressBookString &= TheDataSet.Tables("LoadAddressBookDB").Rows(0).Item("GroupAddressString")
            ReturnString = AddressBookString
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
            Return ReturnString
        End If

        Return ReturnString
    End Function

    'Returns Success message
    <WebMethod()> Public Function StoreAddressBook(ByVal UserID As String, ByVal PasswordChallenge As String, ByVal AddressBookString As String) As String
        Dim UserString As String
        Dim GroupString As String
        Dim ReturnString As String = "MESAG-22: ADDRESSBOOK STORED"

        'UserId OK?
        If Not ValidateUserId(UserID) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'User currently on Session?
        If CheckSession(UserID, PasswordChallenge) Then

            UserString = AddressBookString.Split("|")(0)
            GroupString = AddressBookString.Split("|")(1)
            TheConnection = New OleDb.OleDbConnection(ConnectionString)
            TheConnection.Open()
            SqlCommand = "Update AddressBookDB Set UserAddressString = '" & UserString & "',GroupAddressString = '" & GroupString & "' where UserId = '" & UserID & "'"
            TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
            TheCommand.ExecuteNonQuery()
            TheConnection.Close()
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
            Return ReturnString
        End If

        Return ReturnString
    End Function

    'Takes AddressString as Input Returns AddressString with correct Addresses
    '<WebMethod()> Public Function CheckAddressBook(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal AddressBookString As String) As String
    '    Dim ReturnString As String

    '    'UserId OK?
    '    If Not ValidateUserId(UserId) Then
    '        ReturnString = "ERROR-01: INVALID USERID"
    '        Return ReturnString
    '    End If

    '    'User currently on Session?
    '    If CheckSession(UserId, PasswordChallenge) Then
    '        ReturnString = CheckAddressString(AddressBookString)
    '    Else
    '        ReturnString = "ERROR-03: INVALID SESSION"
    '        Return ReturnString
    '    End If

    '    Return ReturnString
    'End Function

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
    Private Function GenerateChallengeValue(ByVal Password As String, ByVal Challenge As String)
        Dim i As Integer
        Dim ChallengeValue As String

        For i = 0 To Password.Length - 1
            ChallengeValue = ChallengeValue & Chr(Asc(Password.Substring(i, 1)) + Val(Challenge))
        Next

        Return ChallengeValue
    End Function
    Private Function CheckAddressString(ByVal AddressString As String) As String
        Dim UserString, GroupString As String
        Dim UserStringArray(), GroupStringArray() As String
        Dim UserDestString, GroupAddressString As String
        Dim I As Integer

        'Check UserIds
        'Split
        UserString = AddressString.Split("|")(0)
        UserStringArray = UserString.Split(";")

        'Check and Assemble
        For I = 0 To UserStringArray.Length - 1
            If Not ValidateUserId(UserStringArray(I).Split(":")(0)) Then
                UserDestString &= UserStringArray(I) & ";"
            End If
        Next
        UserDestString = UserDestString.Substring(0, UserDestString.Length - 1)

        'Check GroupIds
        'Split
        GroupString = AddressString.Split("|")(1)
        GroupStringArray = GroupString.Split(";")

    End Function

End Class

