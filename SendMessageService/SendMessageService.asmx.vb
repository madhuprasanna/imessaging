Imports System.Web.Services
Imports System.Data.OleDb
Imports System.Math
Imports System.Data
Imports Microsoft.VisualBasic

<WebService(Namespace:="http://www20.brinkster.com/madhuprasanna/SendMessageService/")> _
Public Class SendMessageService
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


    <WebMethod()> Public Function SendMessage(ByVal SenderId As String, ByVal ChallengePass As String, ByVal ReceiverId As String, ByVal Message As String) As String
        Dim ReturnString As String

        ReturnString = "MESAG-02: MESSAGE SENT"

        'Receiver Id OK?
        If Not ValidateUserId(ReceiverId) Then
            ReturnString = "ERROR-04: INVALID RECEIVERID"
            Return ReturnString
        End If

        'Sender Id OK?
        If Not ValidateUserId(SenderId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'Sender currently on Session?
        If CheckSession(SenderId, ChallengePass) Then
            UpdateMessage(SenderId, Message, ReceiverId)
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
            Return ReturnString
        End If

        Return ReturnString
    End Function

    <WebMethod()> Public Function SendTimedMessage(ByVal SenderId As String, ByVal ChallengePass As String, ByVal ReceiverId As String, ByVal Message As String, ByVal DT As String) As String
        Dim ReturnString As String

        ReturnString = "MESAG-03: TIMED MESSAGE SENT"

        'Receiver Id OK?
        If Not ValidateUserId(ReceiverId) Then
            ReturnString = "ERROR-04: INVALID RECEIVERID"
            Return ReturnString
        End If

        'Sender Id OK?
        If Not ValidateUserId(SenderId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'Sender currently on Session?
        If CheckSession(SenderId, ChallengePass) Then
            'Change Message format
            Message = "TIMED:" & DT & "§" & Message
            UpdateMessage(SenderId, Message, ReceiverId)
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
            Return ReturnString
        End If

        Return ReturnString
    End Function

    <WebMethod()> Public Function SendGroupMessage(ByVal SenderId As String, ByVal ChallengePass As String, ByVal GroupId As String, ByVal Message As String) As String
        Dim ReturnString As String
        Dim GroupMembersList As String
        Dim arrayMembersList() As String
        Dim MessageBuffer As String
        Dim MembersCount As Integer = 0
        ReturnString = "MESAG-11: GROUP MESSAGES SENT"

        'Group Id OK?
        MessageBuffer = ValidateGroup(SenderId, GroupId)
        If MessageBuffer <> "GroupOk" Then
            ReturnString = MessageBuffer
            Return ReturnString
        End If

        'Sender Id OK?
        If Not ValidateUserId(SenderId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'Sender currently on Session?
        If CheckSession(SenderId, ChallengePass) Then
            GroupMembersList = GetMembers(SenderId, GroupId)
            arrayMembersList = GroupMembersList.Split(",")

            'Send Messages
            For MembersCount = 0 To arrayMembersList.Length - 1
                UpdateMessage(SenderId, Message, arrayMembersList(MembersCount))
            Next
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
            Return ReturnString
        End If

        Return ReturnString
    End Function

    <WebMethod()> Public Function SendGroupTimedMessage(ByVal SenderId As String, ByVal ChallengePass As String, ByVal GroupId As String, ByVal Message As String, ByVal DT As String) As String
        Dim ReturnString As String
        Dim GroupMembersList As String
        Dim arrayMembersList() As String
        Dim MessageBuffer As String
        Dim MembersCount As Integer = 0

        ReturnString = "MESAG-12: GROUP TIMED MESSAGES SENT"

        'Group Id OK?
        MessageBuffer = ValidateGroup(SenderId, GroupId)
        If MessageBuffer <> "GroupOk" Then
            ReturnString = MessageBuffer
            Return ReturnString
        End If

        'Sender Id OK?
        If Not ValidateUserId(SenderId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        MessageBuffer = Message

        'Sender currently on Session?
        If CheckSession(SenderId, ChallengePass) Then
            GroupMembersList = GetMembers(SenderId, GroupId)
            arrayMembersList = GroupMembersList.Split(",")

            'Change Message format and Send message to all Users
            For MembersCount = 0 To arrayMembersList.Length - 1
                Message = "TIMED:" & DT & "§" & MessageBuffer
                UpdateMessage(SenderId, Message, arrayMembersList(MembersCount))
            Next
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
            Return ReturnString
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
    Private Sub UpdateMessage(ByVal SenderId As String, ByVal Message As String, ByVal ReceiverId As String)
        Dim DateString As String
        Dim UniversalNow As Date

        ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\ProjectCode\ServerDB.mdb"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()

        UniversalNow = Now.ToUniversalTime()
        DateString = UniversalNow.ToFileTime

        SqlCommand = "Insert into MessageDB values('" & ReceiverId & "','" & SenderId & "','" & Message & "','" & DateString & "')"
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()
    End Sub
    Private Function ValidateGroup(ByVal SenderId As String, ByVal GroupId As String) As String
        Dim I As Integer
        Dim GroupAddressString, MemberString, GroupArray(), MemberArray() As String
        Dim ReturnValue As String = "GroupOk"
        Dim IsGroupFound As Boolean = False
        Dim IsAllUsersValid As Boolean = True

        SqlCommand = "select * from AddressBookDB where UserId = '" & SenderId & "'"
        TheDataSet = New DataSet()
        TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
        TheDataAdapter.Fill(TheDataSet, "ValidateGroupTable")
        GroupAddressString = TheDataSet.Tables("ValidateGroupTable").Rows(0).Item("GroupAddressString")
        GroupArray = GroupAddressString.Split(";")

        'Check for existence of group
        For I = 0 To GroupArray.Length - 1
            If GroupArray(I).Split(":")(0) = GroupId Then
                IsGroupFound = True
                MemberString = GroupArray(I)
                Exit For
            End If
        Next
        If Not IsGroupFound Then
            ReturnValue = "ERROR-08: INVALID GROUPID"
            Return ReturnValue
        End If

        'Check existence of group memebers
        MemberArray = MemberString.Split(":")
        For I = 1 To MemberArray.Length - 1 'First element is group name
            If Not ValidateUserId(MemberArray(I)) Then
                IsAllUsersValid = False
                Exit For
            End If
        Next

        'Return
        If IsAllUsersValid Then
            Return ReturnValue
        Else
            ReturnValue = "ERROR-09: INVALID USERID IN GROUP"
            Return ReturnValue
        End If
    End Function
    Private Function GetMembers(ByVal SenderId As String, ByVal GroupId As String) As String
        Dim I As Integer
        Dim GroupAddressString, MemberString, GroupArray(), MemberArray() As String
        Dim ReturnValue As String = ""

        SqlCommand = "select * from AddressBookDB where UserId = '" & SenderId & "'"
        TheDataSet = New DataSet()
        TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
        TheDataAdapter.Fill(TheDataSet, "ValidateGroupTable")
        GroupAddressString = TheDataSet.Tables("ValidateGroupTable").Rows(0).Item("GroupAddressString")
        GroupArray = GroupAddressString.Split(";")

        'Get the memberlist of the Group
        For I = 0 To GroupArray.Length - 1
            If GroupArray(I).Split(":")(0) = GroupId Then
                MemberString = GroupArray(I)
                Exit For
            End If
        Next

        MemberArray = MemberString.Split(":")
        'Form return string 
        For I = 1 To MemberArray.Length - 1 'First element is group name
            ReturnValue &= MemberArray(I) & ","
        Next
        ReturnValue = ReturnValue.Substring(0, ReturnValue.Length - 1)
        Return ReturnValue
    End Function
End Class
