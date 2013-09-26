Imports System.Web.Services
Imports System.Data.OleDb
Imports System.Data
Imports System.Math
Imports Microsoft.VisualBasic

<WebService(Namespace:="http://tempuri.org/")> _
Public Class VoteService
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

    'MessageId Format: <SenderId>:<Receiving Group>:<DateTimeString>

    <WebMethod()> Public Function SendVoteMessage(ByVal SenderId As String, ByVal PasswordChallenge As String, ByVal GroupId As String, ByVal Message As String) As String
        Dim ReturnString As String
        Dim GroupMembersList As String
        Dim arrayMembersList() As String
        Dim MessageBuffer, MessageId As String
        Dim MembersCount As Integer = 0
        ReturnString = "MESAG-23: VOTE MESSAGE SENT"

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
        If CheckSession(SenderId, PasswordChallenge) Then
            GroupMembersList = GetMembers(SenderId, GroupId)
            arrayMembersList = GroupMembersList.Split(",")

            MessageId = SenderId & ":" & GroupId & ":" & Now.ToUniversalTime.ToFileTime
            'Update VoteDB
            TheConnection = New OleDb.OleDbConnection(ConnectionString)
            TheConnection.Open()
            SqlCommand = "Insert into VoteDB values('" & MessageId & "','" & SenderId & "','" & Message & "','0','0','NONE')"
            TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
            TheCommand.ExecuteNonQuery()
            TheConnection.Close()

            'Send Messages
            Message = "VOTEM:" & MessageId & ":" & Message
            For MembersCount = 0 To arrayMembersList.Length - 1
                UpdateMessage(SenderId, Message, arrayMembersList(MembersCount))
            Next
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
            Return ReturnString
        End If

        Return ReturnString
    End Function

    <WebMethod()> Public Function MyVote(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal MessageId As String, ByVal VoteString As String) As String
        Dim ReturnString As String = "MESAG-24: VOTE CASTED"
        Dim MemberArray(), VotedString, VotedArray() As String
        Dim IsUserAutherized As Boolean = False
        Dim IsUserAlreadyVoted As Boolean = False
        Dim RowsCount, I, YesOrNoCount As Integer

        'Sender Id OK?
        If Not ValidateUserId(UserId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'Sender currently on Session?
        If CheckSession(UserId, PasswordChallenge) Then

            'Select the details corresponding to MessageId
            SqlCommand = "select * from VoteDB where MessageId = '" & MessageId & "'"
            TheDataSet = New DataSet()
            TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
            TheDataAdapter.Fill(TheDataSet, "ValidateVote")
            RowsCount = TheDataSet.Tables("ValidateVote").Rows.Count

            VotedString = TheDataSet.Tables("ValidateVote").Rows(0).Item("VotedList")
            YesOrNoCount = CType(TheDataSet.Tables("ValidateVote").Rows(0).Item(VoteString), Integer)

            'Check whether the MessageId is valid
            If RowsCount = 0 Then
                ReturnString = "ERROR-13: INVALID MESSAGEID"
                Return ReturnString
            End If

            'Check whether this User is from the target group specified
            MemberArray = GetMembers(MessageId.Split(":")(0), MessageId.Split(":")(1)).Split(",")
            For I = 0 To MemberArray.Length - 1
                If MemberArray(I) = UserId Then
                    IsUserAutherized = True
                    Exit For
                End If
            Next
            If Not IsUserAutherized Then
                ReturnString = "ERROR-11: USER NOT AUTHERIZED"
                Return ReturnString
            End If

            Try
                'Check whether the User already voted 
                VotedArray = VotedString.Split(":")
                If VotedString = "NONE" Then
                    IsUserAlreadyVoted = False
                Else
                    For I = 0 To VotedArray.Length - 1
                        If VotedArray(I) = UserId Then
                            IsUserAlreadyVoted = True
                            Exit For
                        End If
                    Next
                End If
                If IsUserAlreadyVoted Then
                    ReturnString = "ERROR-12: ALREADY VOTED"
                    Return ReturnString
                End If


                'Cast vote
                YesOrNoCount += 1
                'Add this user to voted list
                If VotedString = "NONE" Then
                    VotedString = UserId
                Else
                    VotedString &= ":" & UserId
                End If
                'Update with new count   
                TheConnection = New OleDb.OleDbConnection(ConnectionString)
                TheConnection.Open()
                SqlCommand = "Update VoteDB Set " & VoteString & " = '" & YesOrNoCount & "', VotedList = '" & VotedString & "' where MessageId = '" & MessageId & "'"
                TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
                TheCommand.ExecuteNonQuery()
                TheConnection.Close()
            Catch ex As Exception
                ReturnString = ex.ToString
                Return ReturnString
            End Try
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
            Return ReturnString
        End If

        Return ReturnString
    End Function

    <WebMethod()> Public Function GetVoteDetails(ByVal UserId As String, ByVal PasswordChallenge As String) As String
        Dim ReturnString As String
        Dim RowsCount As Integer
        Dim I As Integer
        Dim MessageId, Message, Agree, Oppose As String

        'UserId OK?
        If Not ValidateUserId(UserId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'Receiver currently on Session?
        If CheckSession(UserId, PasswordChallenge) Then

            SqlCommand = "Select * from VoteDB where SenderId = '" & UserId & "'"
            TheDataSet = New DataSet()
            TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
            TheDataAdapter.Fill(TheDataSet, "VoteStatusDB")
            RowsCount = TheDataSet.Tables("VoteStatusDB").Rows.Count()

            If RowsCount = 0 Then
                ReturnString = "MESAG-25: NO PENDING VOTE MESSAGES"
                Return ReturnString
            Else
                'Message Protocol - 1
                ReturnString = RowsCount & "»"
                For I = 0 To RowsCount - 1
                    'Store current message 
                    MessageId = TheDataSet.Tables("VoteStatusDB").Rows(I).Item("MessageId")
                    Message = TheDataSet.Tables("VoteStatusDB").Rows(I).Item("Message")
                    Agree = TheDataSet.Tables("VoteStatusDB").Rows(I).Item("Agree")
                    Oppose = TheDataSet.Tables("VoteStatusDB").Rows(I).Item("Oppose")

                    'Message Protocol - 2
                    ReturnString &= MessageId & "ï"
                    ReturnString &= Message & "ï"
                    ReturnString &= Agree & "ï"
                    ReturnString &= Oppose & "î"
                Next
            End If
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
            Return ReturnString
        End If

        Return ReturnString
    End Function

    <WebMethod()> Public Function DeleteVote(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal MessageId As String) As String
        Dim ReturnString As String = "MESAG-26: VOTE MESSAGE DELETED"
        Dim RowsCount As Integer

        'UserId OK?
        If Not ValidateUserId(UserId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'Receiver currently on Session?
        If CheckSession(UserId, PasswordChallenge) Then
            SqlCommand = "Select * from VoteDB where MessageId = '" & MessageId & "'"
            TheDataSet = New DataSet()
            TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
            TheDataAdapter.Fill(TheDataSet, "DeleteVoteDB")
            RowsCount = TheDataSet.Tables("DeleteVoteDB").Rows.Count()

            If RowsCount = 0 Then
                ReturnString = "ERROR-13: INVALID MESSAGEID"
            Else
                'Check whether this user is authorized to delete vote req.
                If MessageId.Split(":")(0) = UserId Then
                    'Delete the Message
                    TheConnection = New OleDb.OleDbConnection(ConnectionString)
                    TheConnection.Open()
                    SqlCommand = "Delete * from VoteDB where MessageId = '" & MessageId & "'"
                    TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
                    TheCommand.ExecuteNonQuery()
                    TheConnection.Close()
                Else
                    ReturnString = "ERROR-11: USER NOT AUTHERIZED"
                    Return ReturnString
                End If
            End If
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
            Return ReturnString
        End If

        Return ReturnString
    End Function

#Region "Support Codes"

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

#End Region

End Class
