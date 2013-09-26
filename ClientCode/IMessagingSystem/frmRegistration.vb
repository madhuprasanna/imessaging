Public Class frmRegistration
    Inherits System.Windows.Forms.Form

    'Directly uses the Web Service and hence in it not accessible to netless systems
    Dim RegistrationServiceStub As RegistrationService.RegistrationService

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents lblUserId As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtUserId As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDOB As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblEmailAddress As System.Windows.Forms.Label
    Friend WithEvents cmdRegister As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmbDate As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRePassword As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtRePassword As System.Windows.Forms.TextBox
    Friend WithEvents txtSchoolName As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRegistration))
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblUserId = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtUserId = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbDate = New System.Windows.Forms.ComboBox()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.lblDOB = New System.Windows.Forms.Label()
        Me.txtSchoolName = New System.Windows.Forms.TextBox()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.lblEmailAddress = New System.Windows.Forms.Label()
        Me.cmdRegister = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtRePassword = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblRePassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblFirstName
        '
        Me.lblFirstName.Location = New System.Drawing.Point(32, 42)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(64, 15)
        Me.lblFirstName.TabIndex = 0
        Me.lblFirstName.Text = "&First Name"
        '
        'lblLastName
        '
        Me.lblLastName.Location = New System.Drawing.Point(32, 70)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(64, 16)
        Me.lblLastName.TabIndex = 1
        Me.lblLastName.Text = "&Last Name"
        '
        'lblUserId
        '
        Me.lblUserId.Location = New System.Drawing.Point(30, 97)
        Me.lblUserId.Name = "lblUserId"
        Me.lblUserId.Size = New System.Drawing.Size(98, 16)
        Me.lblUserId.TabIndex = 2
        Me.lblUserId.Text = "iMessaging &UserId"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(19, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "First &School Name"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtUserId, Me.txtLastName, Me.txtFirstName})
        Me.GroupBox1.Location = New System.Drawing.Point(9, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(320, 107)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Name and UserId"
        '
        'txtUserId
        '
        Me.txtUserId.Location = New System.Drawing.Point(130, 81)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(171, 20)
        Me.txtUserId.TabIndex = 2
        Me.txtUserId.Text = ""
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(130, 52)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(171, 20)
        Me.txtLastName.TabIndex = 1
        Me.txtLastName.Text = ""
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(130, 23)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(171, 20)
        Me.txtFirstName.TabIndex = 0
        Me.txtFirstName.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbDate, Me.cmbMonth, Me.txtYear, Me.lblDOB, Me.Label4, Me.txtSchoolName})
        Me.GroupBox2.Location = New System.Drawing.Point(9, 134)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(319, 83)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "First School Name and DOB"
        '
        'cmbDate
        '
        Me.cmbDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDate.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cmbDate.Location = New System.Drawing.Point(213, 51)
        Me.cmbDate.Name = "cmbDate"
        Me.cmbDate.Size = New System.Drawing.Size(44, 21)
        Me.cmbDate.TabIndex = 5
        '
        'cmbMonth
        '
        Me.cmbMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmbMonth.Location = New System.Drawing.Point(130, 51)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(83, 21)
        Me.cmbMonth.TabIndex = 4
        Me.cmbMonth.Text = "January"
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(257, 51)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(45, 20)
        Me.txtYear.TabIndex = 6
        Me.txtYear.Text = ""
        '
        'lblDOB
        '
        Me.lblDOB.Location = New System.Drawing.Point(20, 55)
        Me.lblDOB.Name = "lblDOB"
        Me.lblDOB.Size = New System.Drawing.Size(79, 15)
        Me.lblDOB.TabIndex = 4
        Me.lblDOB.Text = "&Date of Birth"
        '
        'txtSchoolName
        '
        Me.txtSchoolName.Location = New System.Drawing.Point(130, 22)
        Me.txtSchoolName.Name = "txtSchoolName"
        Me.txtSchoolName.Size = New System.Drawing.Size(171, 20)
        Me.txtSchoolName.TabIndex = 3
        Me.txtSchoolName.Text = ""
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Location = New System.Drawing.Point(139, 318)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(171, 20)
        Me.txtEmailAddress.TabIndex = 9
        Me.txtEmailAddress.Text = ""
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.Location = New System.Drawing.Point(27, 323)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(88, 15)
        Me.lblEmailAddress.TabIndex = 5
        Me.lblEmailAddress.Text = "&eMail Address"
        '
        'cmdRegister
        '
        Me.cmdRegister.Location = New System.Drawing.Point(10, 355)
        Me.cmdRegister.Name = "cmdRegister"
        Me.cmdRegister.Size = New System.Drawing.Size(115, 22)
        Me.cmdRegister.TabIndex = 10
        Me.cmdRegister.Text = "&Register"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(211, 355)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(115, 22)
        Me.cmdClose.TabIndex = 11
        Me.cmdClose.Text = "&Close"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtRePassword, Me.lblPassword, Me.lblRePassword, Me.txtPassword})
        Me.GroupBox3.Location = New System.Drawing.Point(10, 225)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(319, 83)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Enter new Password"
        '
        'txtRePassword
        '
        Me.txtRePassword.Location = New System.Drawing.Point(129, 53)
        Me.txtRePassword.Name = "txtRePassword"
        Me.txtRePassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtRePassword.Size = New System.Drawing.Size(171, 20)
        Me.txtRePassword.TabIndex = 8
        Me.txtRePassword.Text = ""
        '
        'lblPassword
        '
        Me.lblPassword.Location = New System.Drawing.Point(15, 22)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(103, 15)
        Me.lblPassword.TabIndex = 9
        Me.lblPassword.Text = "&Password"
        '
        'lblRePassword
        '
        Me.lblRePassword.Location = New System.Drawing.Point(16, 54)
        Me.lblRePassword.Name = "lblRePassword"
        Me.lblRePassword.Size = New System.Drawing.Size(106, 15)
        Me.lblRePassword.TabIndex = 10
        Me.lblRePassword.Text = "Re-enter P&assword"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(128, 22)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(171, 20)
        Me.txtPassword.TabIndex = 7
        Me.txtPassword.Text = ""
        '
        'frmRegistration
        '
        Me.AcceptButton = Me.cmdRegister
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(338, 388)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox3, Me.cmdClose, Me.cmdRegister, Me.GroupBox2, Me.lblUserId, Me.lblLastName, Me.lblFirstName, Me.GroupBox1, Me.txtEmailAddress, Me.lblEmailAddress})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRegistration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Register with iMessaging Service"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        Dim i As Integer
        cmbDate.Items.Clear()
        For i = 1 To Date.DaysInMonth(Val(txtYear.Text), cmbMonth.SelectedIndex + 1)
            cmbDate.Items.Add(i)
        Next
        cmbDate.SelectedIndex = Now.Day - 1
    End Sub

    Private Sub frmRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modIsRegistrationOpen = True
        txtFirstName.Focus()
        cmbMonth.SelectedIndex = 0
        cmbDate.SelectedIndex = 0
        Try
            RegistrationServiceStub = New RegistrationService.RegistrationService()
        Catch Ex As Exception
            MsgBox(Ex.ToString)
        End Try
    End Sub

    Private Sub frmRegistration_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        modIsRegistrationOpen = False
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRegister.Click
        Dim DOB As String
        Dim MessageBuffer As String

        'Validating User Inputs
        If txtFirstName.Text = "" Then
            MsgBox("Enter your First Name", MsgBoxStyle.Information, "First Name")
            Exit Sub
        End If
        If txtLastName.Text = "" Then
            MsgBox("Enter your Last Name", MsgBoxStyle.Information, "Last Name")
            Exit Sub
        End If
        If txtUserId.Text = "" Then
            MsgBox("Enter any UserId", MsgBoxStyle.Information, "UserId Required")
            Exit Sub
        End If
        If txtSchoolName.Text = "" Then
            MsgBox("Enter your first school name", MsgBoxStyle.Information, "School Name")
            Exit Sub
        End If
        If cmbMonth.SelectedIndex <> -1 And cmbDate.SelectedIndex <> -1 Then
            DOB = cmbMonth.SelectedIndex + 1 & "/" & cmbDate.SelectedIndex + 1 & "/" & txtYear.Text
        Else
            MsgBox("Please specify your date of birth", MsgBoxStyle.Information, "Date of Birth")
            cmbMonth.Focus()
            Exit Sub
        End If
        If txtYear.Text = "" Then
            MsgBox("Enter the year of your birth", MsgBoxStyle.Critical, "Year Required")
            Exit Sub
        End If
        If txtPassword.Text = "" Then
            MsgBox("Enter password", MsgBoxStyle.Information, "Password Required")
            Exit Sub
        End If
        If txtRePassword.Text = "" Then
            MsgBox("Re-enter password", MsgBoxStyle.Information, "Password Required")
            Exit Sub
        End If
        If txtEmailAddress.Text = "" Then
            MsgBox("Enter your eMail Address", MsgBoxStyle.Information, "eMail Address")
            Exit Sub
        End If
        If txtPassword.Text <> txtRePassword.Text Then
            MsgBox("Passwords doesn't match", MsgBoxStyle.Critical, "Re-enter password")
            txtPassword.Text = ""
            txtPassword.Focus()
            txtRePassword.Text = ""
            Exit Sub
        Else
            If txtPassword.Text.Length < 6 Then
                MsgBox("Passwords should atleast be of 6 characters length", MsgBoxStyle.Information, "Re-enter Password")
                Exit Sub
            End If
        End If
        If txtEmailAddress.Text.IndexOf("@") = -1 Then
            MsgBox("eMail Address should have @ symbol", MsgBoxStyle.Information, "Invalid eMail Id")
            txtEmailAddress.Focus()
            Exit Sub
        End If

        MessageBuffer = RegistrationServiceStub.Register(txtFirstName.Text, txtLastName.Text, txtUserId.Text, txtSchoolName.Text, DOB, txtEmailAddress.Text, txtPassword.Text)
        If MessageBuffer = "ERROR-14: USERID ALREADY EXISTS" Then
            MsgBox("UserId already exists. Please select different one", MsgBoxStyle.Exclamation, "Enter UserId")
            txtUserId.Focus()
            Exit Sub
        End If

        If MessageBuffer = "MESAG-26: USER REGISTERED" Then
            MsgBox("You have been registered", MsgBoxStyle.Information, txtUserId.Text & " registered")
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Sub frmRegistration_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.DoubleClick
        Dim UserId As String = ""
        Dim MessageBuffer As String

        UserId = InputBox("Enter the UserId you want to delete", "Delete User")

        If UserId <> "" Then
            MessageBuffer = RegistrationServiceStub.Remove(UserId)
            MsgBox(MessageBuffer)
        End If
        Exit Sub
    End Sub
End Class
