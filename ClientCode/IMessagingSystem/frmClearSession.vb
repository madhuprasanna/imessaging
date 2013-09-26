Public Class frmClearSession
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents lblUserId As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUserId As System.Windows.Forms.TextBox
    Friend WithEvents txtSchoolName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents cmbDate As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents cmdClearSession As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents grpClearType As System.Windows.Forms.GroupBox
    Friend WithEvents rbSession As System.Windows.Forms.RadioButton
    Friend WithEvents rbPassword As System.Windows.Forms.RadioButton
    Friend WithEvents lblDOB As System.Windows.Forms.Label
    Friend WithEvents lblSchool As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmClearSession))
        Me.lblUserId = New System.Windows.Forms.Label()
        Me.lblDOB = New System.Windows.Forms.Label()
        Me.lblSchool = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbDate = New System.Windows.Forms.ComboBox()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtSchoolName = New System.Windows.Forms.TextBox()
        Me.txtUserId = New System.Windows.Forms.TextBox()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.cmdClearSession = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.grpClearType = New System.Windows.Forms.GroupBox()
        Me.rbPassword = New System.Windows.Forms.RadioButton()
        Me.rbSession = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.grpClearType.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblUserId
        '
        Me.lblUserId.Location = New System.Drawing.Point(16, 80)
        Me.lblUserId.Name = "lblUserId"
        Me.lblUserId.Size = New System.Drawing.Size(84, 16)
        Me.lblUserId.TabIndex = 0
        Me.lblUserId.Text = "&UserId"
        '
        'lblDOB
        '
        Me.lblDOB.Location = New System.Drawing.Point(16, 112)
        Me.lblDOB.Name = "lblDOB"
        Me.lblDOB.Size = New System.Drawing.Size(84, 16)
        Me.lblDOB.TabIndex = 1
        Me.lblDOB.Text = "Date of &Birth"
        '
        'lblSchool
        '
        Me.lblSchool.Location = New System.Drawing.Point(16, 144)
        Me.lblSchool.Name = "lblSchool"
        Me.lblSchool.Size = New System.Drawing.Size(132, 16)
        Me.lblSchool.TabIndex = 2
        Me.lblSchool.Text = "&Name of your first school"
        '
        'lblPassword
        '
        Me.lblPassword.Location = New System.Drawing.Point(16, 176)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(84, 16)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = "Pass&word"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbDate, Me.cmbMonth, Me.txtPassword, Me.txtSchoolName, Me.txtUserId, Me.txtYear})
        Me.GroupBox1.Location = New System.Drawing.Point(8, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 148)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Enter your account details"
        '
        'cmbDate
        '
        Me.cmbDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDate.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cmbDate.Location = New System.Drawing.Point(244, 52)
        Me.cmbDate.Name = "cmbDate"
        Me.cmbDate.Size = New System.Drawing.Size(40, 21)
        Me.cmbDate.TabIndex = 4
        '
        'cmbMonth
        '
        Me.cmbMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmbMonth.Location = New System.Drawing.Point(172, 52)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(72, 21)
        Me.cmbMonth.TabIndex = 3
        Me.cmbMonth.Text = "January"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(172, 116)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(144, 20)
        Me.txtPassword.TabIndex = 7
        Me.txtPassword.Text = ""
        '
        'txtSchoolName
        '
        Me.txtSchoolName.Location = New System.Drawing.Point(172, 84)
        Me.txtSchoolName.Name = "txtSchoolName"
        Me.txtSchoolName.Size = New System.Drawing.Size(144, 20)
        Me.txtSchoolName.TabIndex = 6
        Me.txtSchoolName.Text = ""
        '
        'txtUserId
        '
        Me.txtUserId.Location = New System.Drawing.Point(172, 20)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(144, 20)
        Me.txtUserId.TabIndex = 2
        Me.txtUserId.Text = ""
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(284, 52)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(32, 20)
        Me.txtYear.TabIndex = 5
        Me.txtYear.Text = ""
        '
        'cmdClearSession
        '
        Me.cmdClearSession.Location = New System.Drawing.Point(8, 216)
        Me.cmdClearSession.Name = "cmdClearSession"
        Me.cmdClearSession.Size = New System.Drawing.Size(92, 24)
        Me.cmdClearSession.TabIndex = 8
        Me.cmdClearSession.Text = "C&lear "
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(243, 216)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(92, 24)
        Me.cmdClose.TabIndex = 9
        Me.cmdClose.Text = "&Close"
        '
        'grpClearType
        '
        Me.grpClearType.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbPassword, Me.rbSession})
        Me.grpClearType.Location = New System.Drawing.Point(8, 8)
        Me.grpClearType.Name = "grpClearType"
        Me.grpClearType.Size = New System.Drawing.Size(328, 40)
        Me.grpClearType.TabIndex = 10
        Me.grpClearType.TabStop = False
        Me.grpClearType.Text = "Clear Session or Password"
        '
        'rbPassword
        '
        Me.rbPassword.Location = New System.Drawing.Point(248, 16)
        Me.rbPassword.Name = "rbPassword"
        Me.rbPassword.Size = New System.Drawing.Size(74, 16)
        Me.rbPassword.TabIndex = 1
        Me.rbPassword.Text = "&Password"
        Me.rbPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rbSession
        '
        Me.rbSession.Location = New System.Drawing.Point(8, 16)
        Me.rbSession.Name = "rbSession"
        Me.rbSession.Size = New System.Drawing.Size(72, 16)
        Me.rbSession.TabIndex = 0
        Me.rbSession.Text = "&Session"
        '
        'frmClearSession
        '
        Me.AcceptButton = Me.cmdClearSession
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(346, 248)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpClearType, Me.cmdClose, Me.cmdClearSession, Me.lblPassword, Me.lblSchool, Me.lblDOB, Me.lblUserId, Me.GroupBox1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmClearSession"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "at Form Load "
        Me.GroupBox1.ResumeLayout(False)
        Me.grpClearType.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmClearSession_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modIsClearSessionOpen = True

        Me.Text = "Clear Session/Password"
        cmbMonth.SelectedIndex = Now.Month - 1
        cmbDate.SelectedIndex = Now.Day - 1
        txtYear.Text = Now.Year

        rbSession.Checked = True
    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        Dim i As Integer
        cmbDate.Items.Clear()
        For i = 1 To Date.DaysInMonth(Val(txtYear.Text), cmbMonth.SelectedIndex + 1)
            cmbDate.Items.Add(i)
        Next
        cmbDate.SelectedIndex = Now.Day - 1
    End Sub

    Private Sub cmdClearSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearSession.Click
        Dim BirthDate As String
        Dim MessageBuffer As String

        'Formate BirthDate
        BirthDate = cmbMonth.SelectedIndex + 1 & "/" & cmbDate.SelectedIndex + 1 & "/" & txtYear.Text

        'Call Clear Session
        If rbSession.Checked = True Then
            MessageBuffer = modServiceObject.ClearSession(txtUserId.Text, txtPassword.Text, BirthDate, txtSchoolName.Text)
        Else
            MessageBuffer = modServiceObject.ClearPassword(txtUserId.Text, BirthDate, txtSchoolName.Text)
        End If

        'UserId is invalid
        If MessageBuffer = "ERROR-01: INVALID USERID" Then
            MsgBox("Invalid UserId! UserId is case sensitive", MsgBoxStyle.Information)
            Exit Sub
        End If
        'Invalid Registration Data
        If MessageBuffer = "ERROR-06: DATA INVALID" Then
            MsgBox("Wrong Data! Unable to clear session", MsgBoxStyle.Information)
            Exit Sub
        End If
        'Session Cleared
        If MessageBuffer = "MESAG-05: SESSION CLEARED" Then
            MsgBox("Session Cleared! Login to use the Service", MsgBoxStyle.Information)
            Me.Close()
        End If
        If MessageBuffer = "MESAG-06: PASSWORD CLEARED" Then
            MsgBox("Password Cleared! Login to use the Service", MsgBoxStyle.Information)
            Me.Close()
        End If

    End Sub

    Private Sub rbSession_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSession.CheckedChanged
        If rbSession.Checked = False Then
            lblPassword.Visible = False
            txtPassword.Visible = False
        End If
        If rbSession.Checked = True Then
            lblPassword.Visible = True
            txtPassword.Visible = True
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmClearSession_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        modIsClearSessionOpen = False
    End Sub

End Class
