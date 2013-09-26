Imports System.Web.Services
Imports System.Data.OleDb
Imports System.Math
Imports System.Data
Imports Microsoft.VisualBasic

<WebService(Namespace:="http://tempuri.org/")> _
Public Class SearchService
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

    <WebMethod()> Public Function Search(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal SearchId As String) As String
        Dim ReturnString As String

        'Sender Id OK?
        If Not ValidateUserId(UserId) Then
            ReturnString = "ERROR-01: INVALID USERID"
            Return ReturnString
        End If

        'Sender currently on Session?
        If CheckSession(UserId, PasswordChallenge) Then
            ReturnString = SearchUser(SearchId)
            Return ReturnString
        Else
            ReturnString = "ERROR-03: INVALID SESSION"
            Return ReturnString
        End If
    End Function

    Private Function SearchUser(ByVal SearchString As String) As String
        Dim RowsCount, I As Integer
        Dim RUserID, RFirstName, RLastName, RStatus, RIpAddress As String
        Dim ReturnString As String = ""

        'Database  Variables
        Dim DataSet1, DataSet2, DataSet3 As DataSet
        Dim DataAdapter1, DataAdapter2, DataAdapter3 As OleDbDataAdapter
        Dim Connection1, Connection2, Connection3 As OleDbConnection
        Dim SqlCommand As String

        'Return UserId:FirstName:LastName:Online:IpAddress
        Try

            'Select Data from UserAccountsDB(UserId,FirstName,LastName)
            SqlCommand = "Select * from UserAccountsDB where UserId like '%" & SearchString & "%'"
            DataSet1 = New DataSet()
            DataAdapter1 = New OleDbDataAdapter(SqlCommand, ConnectionString)
            DataAdapter1.Fill(DataSet1, "SearchUserAccountsDB")
            RowsCount = DataSet1.Tables("SearchUserAccountsDB").Rows.Count()

            'SearchId not found
            If RowsCount = 0 Then
                ReturnString = "MESAG-18: SEARCHID NOT FOUND"
                Return ReturnString
            End If

            For I = 0 To RowsCount - 1
                RUserID = DataSet1.Tables("SearchUserAccountsDB").Rows(I).Item("UserId")
                RFirstName = DataSet1.Tables("SearchUserAccountsDB").Rows(I).Item("FirstName")
                RLastName = DataSet1.Tables("SearchUserAccountsDB").Rows(I).Item("LastName")

                'Select Data from AuthServiceTable(Status)
                SqlCommand = "Select * from AuthServiceTable where UserId like '" & RUserID & "'"
                DataSet2 = New DataSet()
                DataAdapter2 = New OleDbDataAdapter(SqlCommand, ConnectionString)
                DataAdapter2.Fill(DataSet2, "SearchAuthServiceTable")

                'Select Data from UserSettingsDB(IpAddress)
                SqlCommand = "Select * from UserSettingsDB where UserId like '" & RUserID & "'"
                DataSet3 = New DataSet()
                DataAdapter3 = New OleDbDataAdapter(SqlCommand, ConnectionString)
                DataAdapter3.Fill(DataSet3, "SearchUserSettingsDB")

                RStatus = DataSet2.Tables("SearchAuthServiceTable").Rows(0).Item("SessionState")
                If ShowIp(RUserID) Then
                    RIpAddress = DataSet3.Tables("SearchUserSettingsDB").Rows(0).Item("IpAddress")
                Else
                    RIpAddress = "HIDEIP"
                End If
                If RUserID <> "ClientsAccount" Then
                    ReturnString &= RUserID & ":" & RFirstName & ":" & RLastName & ":" & RStatus & ":" & RIpAddress & ";"
                End If
            Next
        Catch Ex As Exception
            ReturnString = Ex.ToString
            Return ReturnString
        End Try

        Return ReturnString
    End Function
    Private Function ShowIp(ByVal UserId As String) As Boolean
        Dim TempString As String
        SqlCommand = "Select * from UserSettingsDB where UserId = '" & UserId & "'"
        TheDataSet = New DataSet()
        TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
        TheDataAdapter.Fill(TheDataSet, "ShowIpDB")

        TempString = TheDataSet.Tables("ShowIpDB").Rows(0).Item("SettingString")
        If TempString.Split(";")(0) = "SHOWIP" Then
            Return True
        Else
            Return False
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

End Class
