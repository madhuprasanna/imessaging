Imports System.Data.OleDb

Public Class webfrmRegister
    Inherits System.Web.UI.Page

    Dim TheDataSet As DataSet
    Dim TheDataAdapter As OleDb.OleDbDataAdapter
    Dim TheConnection As OleDb.OleDbConnection
    Dim TheCommand As OleDb.OleDbCommand
    Dim ConnectionString As String
    Dim SqlCommand As String
    Dim RowsCount As Integer

#Region "Web Control Elements"
    Protected WithEvents lblFirstName As System.Web.UI.WebControls.Label
    Protected WithEvents lblLastName As System.Web.UI.WebControls.Label
    Protected WithEvents lblUserId As System.Web.UI.WebControls.Label
    Protected WithEvents lblPassword As System.Web.UI.WebControls.Label
    Protected WithEvents lblSecurityQuestion As System.Web.UI.WebControls.Label
    Protected WithEvents lblDOB As System.Web.UI.WebControls.Label
    Protected WithEvents lbleMail As System.Web.UI.WebControls.Label
    Protected WithEvents lblMsg1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMsg2 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtFirstName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLastName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUserId As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReTypePassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFirstSchool As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtYear As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblChangeUserId As System.Web.UI.WebControls.Label
    Protected WithEvents lblSixChar As System.Web.UI.WebControls.Label
    Protected WithEvents cmdSubmit As System.Web.UI.WebControls.Button
    Protected WithEvents lblCopyright As System.Web.UI.WebControls.Label
    Protected WithEvents imgHeading As System.Web.UI.WebControls.Image
    Protected WithEvents lblMonthDDYYYY As System.Web.UI.WebControls.Label
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents valFirstName As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents valLastName As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents valUserId As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents valPassword As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents valReTypePassword As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents valSchoolName As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents valEmailId As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblValidateDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblValidatePassword As System.Web.UI.WebControls.Label
    Protected WithEvents lblValidateRetypePassword As System.Web.UI.WebControls.Label
    Protected WithEvents lblValidateeMail As System.Web.UI.WebControls.Label
    Protected WithEvents hlHome As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hlDownload As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lblReTypePassword As System.Web.UI.WebControls.Label
#End Region

    'Connection string inside
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
        ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\ProjectCode\ServerDB.mdb"
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Private Sub cmdSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubmit.Click
        Dim TheDate As String

        'Exit sub if there is validation erros
        If Not ValidatePage() Then
            '    lblResult.Text = "Registration form incomplete. Fill the specified fields"
            '    lblResult.BackColor = System.Drawing.Color.Red
            '    lblResult.ForeColor = System.Drawing.Color.Yellow
            '    lblResult.Visible = True
            '    Exit Sub
            Response.Redirect("webfrmResult.aspx")
        End If
        TheDate = ddlMonth.SelectedItem.Value & "/" & txtDate.Text.Trim("0") & "/" & txtYear.Text

        SqlCommand = "Insert into UserAccountsDB values('" & txtUserId.Text & "','" & txtFirstName.Text & "','" & txtLastName.Text & "','" & txtPassword.Text & "','" & txtFirstSchool.Text & "','" & TheDate & "','" & txtEmail.Text & "')"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        SqlCommand = "Insert into AuthServiceTable values('" & txtUserId.Text & "','" & txtPassword.Text & "','" & "-1" & "','" & "0" & "','" & "NOTLOGGED" & "')"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        SqlCommand = "Insert into UserSettingsDB values('" & txtUserId.Text & "','SHOWIP;NOTSILENT:0','0.0.0.0')"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        SqlCommand = "Insert into AddressBookDB values('" & txtUserId.Text & "','NONE','NONE')"
        TheConnection = New OleDb.OleDbConnection(ConnectionString)
        TheConnection.Open()
        TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
        TheCommand.ExecuteNonQuery()
        TheConnection.Close()

        'lblResult.Text = "Registration successfull. Click here to download client program ->"
        'lblResult.BackColor = System.Drawing.Color.Blue
        'lblResult.ForeColor = System.Drawing.Color.White
        'lblResult.Visible = True
        'txtDate.Text = ""
        'txtEmail.Text = ""
        'txtFirstName.Text = ""
        'txtFirstSchool.Text = ""
        'txtLastName.Text = ""
        'txtUserId.Text = ""
        'txtYear.Text = ""
        'ddlMonth.SelectedIndex = 0

        Response.Redirect("webfrmResult.aspx")

    End Sub

    Private Function ValidatePage() As Boolean
        Dim TheDate As String
        Dim IsValidationError As Boolean = False
        Dim IsDateError As Boolean = False


        'Validate the date field
        Try
            TheDate = ddlMonth.SelectedItem.Value & "/" & txtDate.Text.Trim("0") & "/" & txtYear.Text
            TheDate = CType(TheDate, Date)
        Catch ex As Exception
            IsDateError = True
        End Try
        If IsDateError Then
            lblValidateDate.Visible = True
            lblDOB.BackColor = System.Drawing.Color.Red
            lblDOB.ForeColor = System.Drawing.Color.White
            IsValidationError = True
        Else
            lblValidateDate.Visible = False
            lblDOB.BackColor = System.Drawing.Color.White
            lblDOB.ForeColor = System.Drawing.Color.Black
        End If


        'Validate Password length
        If txtPassword.Text.Length < 6 Then
            lblValidatePassword.Visible = True
            lblPassword.BackColor = System.Drawing.Color.Red
            lblPassword.ForeColor = System.Drawing.Color.White
            IsValidationError = True
        Else
            lblValidatePassword.Visible = False
            lblPassword.BackColor = System.Drawing.Color.White
            lblPassword.ForeColor = System.Drawing.Color.Black
        End If


        'Validate Password match
        If txtPassword.Text <> txtReTypePassword.Text Then
            lblValidateRetypePassword.Visible = True
            lblReTypePassword.BackColor = System.Drawing.Color.Red
            lblReTypePassword.ForeColor = System.Drawing.Color.White
            IsValidationError = True
        Else
            lblValidateRetypePassword.Visible = False
            lblReTypePassword.BackColor = System.Drawing.Color.White
            lblReTypePassword.ForeColor = System.Drawing.Color.Black
        End If


        'Validate e-MailId
        If txtEmail.Text.IndexOf("@") = -1 Then
            lblValidateeMail.Visible = True
            lbleMail.BackColor = System.Drawing.Color.Red
            lbleMail.ForeColor = System.Drawing.Color.White
            IsValidationError = True
        Else
            lblValidateeMail.Visible = False
            lbleMail.BackColor = System.Drawing.Color.White
            lbleMail.ForeColor = System.Drawing.Color.Black
        End If


        'Check Uniqueness of UserID
        SqlCommand = "select UserId from AuthServiceTable where UserId = '" & txtUserId.Text & "'"
        TheDataSet = New DataSet()
        TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
        TheDataAdapter.Fill(TheDataSet, "ChallengeRequestTable")
        RowsCount = TheDataSet.Tables("ChallengeRequestTable").Rows.Count
        If RowsCount <> 0 Then
            lblChangeUserId.Visible = True
            lblUserId.BackColor = System.Drawing.Color.Red
            lblUserId.ForeColor = System.Drawing.Color.White
            IsValidationError = True
        Else
            lblChangeUserId.Visible = False
            lblUserId.BackColor = System.Drawing.Color.White
            lblUserId.ForeColor = System.Drawing.Color.Black
        End If

        Return Not IsValidationError
    End Function

End Class
