Imports System.Web.Services
Imports System.Data
Imports System.Data.OleDb

<WebService(Namespace:="http://tempuri.org/")> _
Public Class RegistrationService
    Inherits System.Web.Services.WebService

    Dim TheDataSet As DataSet
    Dim TheDataAdapter As OleDb.OleDbDataAdapter
    Dim TheConnection As OleDb.OleDbConnection
    Dim TheCommand As OleDb.OleDbCommand
    Dim ConnectionString As String
    Dim SqlCommand As String
    Dim RowsCount As Integer

    'Connection string inside
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


    <WebMethod()> Public Function Register(ByVal FN As String, ByVal LN As String, ByVal UserId As String, ByVal SN As String, ByVal DOB As String, ByVal Email As String, ByVal Password As String) As String
        Dim ReturnString As String = "ERROR-14: USERID ALREADY EXISTS"

        'Check Uniqueness of UserID
        SqlCommand = "select UserId from AuthServiceTable where UserId = '" & UserId & "'"
        TheDataSet = New DataSet()
        TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
        TheDataAdapter.Fill(TheDataSet, "ChallengeRequestTable")
        RowsCount = TheDataSet.Tables("ChallengeRequestTable").Rows.Count

        If RowsCount <> 0 Then
            Return ReturnString
        End If

        'Store in DB
        SqlCommand = "Insert into UserAccountsDB values('" & UserId & "','" & FN & "','" & LN & "','" & Password & "','" & SN & "','" & DOB & "','" & Email & "')"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        SqlCommand = "Insert into AuthServiceTable values('" & UserId & "','" & Password & "','" & "-1" & "','" & "0" & "','" & "NOTLOGGED" & "')"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        SqlCommand = "Insert into UserSettingsDB values('" & UserId & "','SHOWIP;NOTSILENT:0','0.0.0.0')"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        SqlCommand = "Insert into AddressBookDB values('" & UserId & "','NONE','NONE')"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        'Return String
        ReturnString = "MESAG-26: USER REGISTERED"
        Return ReturnString
    End Function

    <WebMethod()> Public Function Remove(ByVal UserId As String) As String
        Dim ReturnString As String = "ERROR-01: INVALID USERID"

        'Check whether UserId is valid
        SqlCommand = "select UserId from AuthServiceTable where UserId = '" & UserId & "'"
        TheDataSet = New DataSet()
        TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
        TheDataAdapter.Fill(TheDataSet, "ChallengeRequestTable")
        RowsCount = TheDataSet.Tables("ChallengeRequestTable").Rows.Count

        If RowsCount = 0 Then
            Return ReturnString
        End If

        'Store in DB
        SqlCommand = "Delete from UserAccountsDB where UserId = '" & UserId & "'"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        SqlCommand = "Delete from AuthServiceTable where UserId = '" & UserId & "'"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        SqlCommand = "Delete from UserSettingsDB where UserId = '" & UserId & "'"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        SqlCommand = "Delete from AddressBookDB where UserId = '" & UserId & "'"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        'Return String
        ReturnString = "MESAG-27: USER REMOVED"
        Return ReturnString
    End Function

End Class
