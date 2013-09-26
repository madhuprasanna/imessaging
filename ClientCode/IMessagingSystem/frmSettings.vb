Public Class frmSettings
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
    Friend WithEvents tabSettings As System.Windows.Forms.TabControl
    Friend WithEvents tpChangePassword As System.Windows.Forms.TabPage
    Friend WithEvents txtNewPassword2 As System.Windows.Forms.TextBox
    Friend WithEvents lblNewPassword2 As System.Windows.Forms.Label
    Friend WithEvents txtNewPassword1 As System.Windows.Forms.TextBox
    Friend WithEvents txtOldPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserId As System.Windows.Forms.TextBox
    Friend WithEvents lblNewPassword1 As System.Windows.Forms.Label
    Friend WithEvents lblOldPassword As System.Windows.Forms.Label
    Friend WithEvents lblUserId As System.Windows.Forms.Label
    Friend WithEvents cmdChangePassword As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents grpChangePassword As System.Windows.Forms.GroupBox
    Friend WithEvents cmdChangePasswordClose As System.Windows.Forms.Button
    Friend WithEvents tpMessageSettings As System.Windows.Forms.TabPage
    Friend WithEvents tpTimeSync As System.Windows.Forms.TabPage
    Friend WithEvents lblLastSyncTime As System.Windows.Forms.Label
    Friend WithEvents lblSystemTime As System.Windows.Forms.Label
    Friend WithEvents lblSyncServerTime As System.Windows.Forms.Label
    Friend WithEvents txtLastSync As System.Windows.Forms.TextBox
    Friend WithEvents txtSysTime As System.Windows.Forms.TextBox
    Friend WithEvents cmdGetServerTime As System.Windows.Forms.Button
    Friend WithEvents txtSyncServerTime As System.Windows.Forms.TextBox
    Friend WithEvents cmdSync As System.Windows.Forms.Button
    Friend WithEvents cmdTimeClose As System.Windows.Forms.Button
    Friend WithEvents tmrSettings As System.Timers.Timer
    Friend WithEvents grpTime As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbNonSilent As System.Windows.Forms.RadioButton
    Friend WithEvents rbSilent As System.Windows.Forms.RadioButton
    Friend WithEvents lblTunes As System.Windows.Forms.Label
    Friend WithEvents cmbTunes As System.Windows.Forms.ComboBox
    Friend WithEvents cmdMessageClose As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDefault As System.Windows.Forms.Button
    Friend WithEvents cbShowMyIp As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSettings))
        Me.tabSettings = New System.Windows.Forms.TabControl()
        Me.tpChangePassword = New System.Windows.Forms.TabPage()
        Me.cmdChangePasswordClose = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdChangePassword = New System.Windows.Forms.Button()
        Me.txtNewPassword2 = New System.Windows.Forms.TextBox()
        Me.lblNewPassword2 = New System.Windows.Forms.Label()
        Me.txtNewPassword1 = New System.Windows.Forms.TextBox()
        Me.txtOldPassword = New System.Windows.Forms.TextBox()
        Me.txtUserId = New System.Windows.Forms.TextBox()
        Me.lblNewPassword1 = New System.Windows.Forms.Label()
        Me.lblOldPassword = New System.Windows.Forms.Label()
        Me.lblUserId = New System.Windows.Forms.Label()
        Me.grpChangePassword = New System.Windows.Forms.GroupBox()
        Me.tpTimeSync = New System.Windows.Forms.TabPage()
        Me.cmdTimeClose = New System.Windows.Forms.Button()
        Me.cmdSync = New System.Windows.Forms.Button()
        Me.cmdGetServerTime = New System.Windows.Forms.Button()
        Me.txtSyncServerTime = New System.Windows.Forms.TextBox()
        Me.txtSysTime = New System.Windows.Forms.TextBox()
        Me.txtLastSync = New System.Windows.Forms.TextBox()
        Me.lblSyncServerTime = New System.Windows.Forms.Label()
        Me.lblSystemTime = New System.Windows.Forms.Label()
        Me.lblLastSyncTime = New System.Windows.Forms.Label()
        Me.grpTime = New System.Windows.Forms.GroupBox()
        Me.tpMessageSettings = New System.Windows.Forms.TabPage()
        Me.cbShowMyIp = New System.Windows.Forms.CheckBox()
        Me.cmdDefault = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdMessageClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbTunes = New System.Windows.Forms.ComboBox()
        Me.lblTunes = New System.Windows.Forms.Label()
        Me.rbSilent = New System.Windows.Forms.RadioButton()
        Me.rbNonSilent = New System.Windows.Forms.RadioButton()
        Me.tmrSettings = New System.Timers.Timer()
        Me.tabSettings.SuspendLayout()
        Me.tpChangePassword.SuspendLayout()
        Me.tpTimeSync.SuspendLayout()
        Me.tpMessageSettings.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tmrSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabSettings
        '
        Me.tabSettings.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpChangePassword, Me.tpTimeSync, Me.tpMessageSettings})
        Me.tabSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.SelectedIndex = 0
        Me.tabSettings.Size = New System.Drawing.Size(434, 209)
        Me.tabSettings.TabIndex = 0
        '
        'tpChangePassword
        '
        Me.tpChangePassword.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdChangePasswordClose, Me.cmdClear, Me.cmdChangePassword, Me.txtNewPassword2, Me.lblNewPassword2, Me.txtNewPassword1, Me.txtOldPassword, Me.txtUserId, Me.lblNewPassword1, Me.lblOldPassword, Me.lblUserId, Me.grpChangePassword})
        Me.tpChangePassword.Location = New System.Drawing.Point(4, 22)
        Me.tpChangePassword.Name = "tpChangePassword"
        Me.tpChangePassword.Size = New System.Drawing.Size(426, 183)
        Me.tpChangePassword.TabIndex = 0
        Me.tpChangePassword.Text = "Change Password"
        '
        'cmdChangePasswordClose
        '
        Me.cmdChangePasswordClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdChangePasswordClose.Location = New System.Drawing.Point(296, 156)
        Me.cmdChangePasswordClose.Name = "cmdChangePasswordClose"
        Me.cmdChangePasswordClose.Size = New System.Drawing.Size(120, 24)
        Me.cmdChangePasswordClose.TabIndex = 6
        Me.cmdChangePasswordClose.Text = "&Close"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(152, 156)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(120, 24)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.Text = "C&lear"
        '
        'cmdChangePassword
        '
        Me.cmdChangePassword.Location = New System.Drawing.Point(8, 156)
        Me.cmdChangePassword.Name = "cmdChangePassword"
        Me.cmdChangePassword.Size = New System.Drawing.Size(120, 24)
        Me.cmdChangePassword.TabIndex = 4
        Me.cmdChangePassword.Text = "&Change Password"
        '
        'txtNewPassword2
        '
        Me.txtNewPassword2.Location = New System.Drawing.Point(224, 120)
        Me.txtNewPassword2.Name = "txtNewPassword2"
        Me.txtNewPassword2.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword2.Size = New System.Drawing.Size(176, 20)
        Me.txtNewPassword2.TabIndex = 3
        Me.txtNewPassword2.Text = ""
        '
        'lblNewPassword2
        '
        Me.lblNewPassword2.Location = New System.Drawing.Point(16, 120)
        Me.lblNewPassword2.Name = "lblNewPassword2"
        Me.lblNewPassword2.Size = New System.Drawing.Size(120, 16)
        Me.lblNewPassword2.TabIndex = 14
        Me.lblNewPassword2.Text = "&Retype New Password"
        '
        'txtNewPassword1
        '
        Me.txtNewPassword1.Location = New System.Drawing.Point(224, 88)
        Me.txtNewPassword1.Name = "txtNewPassword1"
        Me.txtNewPassword1.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword1.Size = New System.Drawing.Size(176, 20)
        Me.txtNewPassword1.TabIndex = 13
        Me.txtNewPassword1.Text = ""
        '
        'txtOldPassword
        '
        Me.txtOldPassword.Location = New System.Drawing.Point(224, 56)
        Me.txtOldPassword.Name = "txtOldPassword"
        Me.txtOldPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtOldPassword.Size = New System.Drawing.Size(176, 20)
        Me.txtOldPassword.TabIndex = 1
        Me.txtOldPassword.Text = ""
        '
        'txtUserId
        '
        Me.txtUserId.Location = New System.Drawing.Point(224, 24)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(176, 20)
        Me.txtUserId.TabIndex = 0
        Me.txtUserId.Text = ""
        '
        'lblNewPassword1
        '
        Me.lblNewPassword1.Location = New System.Drawing.Point(16, 88)
        Me.lblNewPassword1.Name = "lblNewPassword1"
        Me.lblNewPassword1.Size = New System.Drawing.Size(88, 16)
        Me.lblNewPassword1.TabIndex = 10
        Me.lblNewPassword1.Text = "&New Password"
        '
        'lblOldPassword
        '
        Me.lblOldPassword.Location = New System.Drawing.Point(16, 56)
        Me.lblOldPassword.Name = "lblOldPassword"
        Me.lblOldPassword.Size = New System.Drawing.Size(96, 16)
        Me.lblOldPassword.TabIndex = 9
        Me.lblOldPassword.Text = "&Old Password"
        '
        'lblUserId
        '
        Me.lblUserId.Location = New System.Drawing.Point(16, 24)
        Me.lblUserId.Name = "lblUserId"
        Me.lblUserId.Size = New System.Drawing.Size(56, 16)
        Me.lblUserId.TabIndex = 8
        Me.lblUserId.Text = "&UserId"
        '
        'grpChangePassword
        '
        Me.grpChangePassword.Location = New System.Drawing.Point(8, 8)
        Me.grpChangePassword.Name = "grpChangePassword"
        Me.grpChangePassword.Size = New System.Drawing.Size(408, 144)
        Me.grpChangePassword.TabIndex = 2
        Me.grpChangePassword.TabStop = False
        Me.grpChangePassword.Text = "Enter your details"
        '
        'tpTimeSync
        '
        Me.tpTimeSync.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdTimeClose, Me.cmdSync, Me.cmdGetServerTime, Me.txtSyncServerTime, Me.txtSysTime, Me.txtLastSync, Me.lblSyncServerTime, Me.lblSystemTime, Me.lblLastSyncTime, Me.grpTime})
        Me.tpTimeSync.Location = New System.Drawing.Point(4, 22)
        Me.tpTimeSync.Name = "tpTimeSync"
        Me.tpTimeSync.Size = New System.Drawing.Size(426, 183)
        Me.tpTimeSync.TabIndex = 4
        Me.tpTimeSync.Text = "Time synchronisation"
        '
        'cmdTimeClose
        '
        Me.cmdTimeClose.Location = New System.Drawing.Point(321, 145)
        Me.cmdTimeClose.Name = "cmdTimeClose"
        Me.cmdTimeClose.Size = New System.Drawing.Size(92, 24)
        Me.cmdTimeClose.TabIndex = 5
        Me.cmdTimeClose.Text = "Close"
        '
        'cmdSync
        '
        Me.cmdSync.Location = New System.Drawing.Point(130, 145)
        Me.cmdSync.Name = "cmdSync"
        Me.cmdSync.Size = New System.Drawing.Size(172, 24)
        Me.cmdSync.TabIndex = 4
        Me.cmdSync.Text = "&Synchronise  Application Time"
        '
        'cmdGetServerTime
        '
        Me.cmdGetServerTime.Location = New System.Drawing.Point(7, 145)
        Me.cmdGetServerTime.Name = "cmdGetServerTime"
        Me.cmdGetServerTime.Size = New System.Drawing.Size(104, 24)
        Me.cmdGetServerTime.TabIndex = 3
        Me.cmdGetServerTime.Text = "&Get Server Time"
        '
        'txtSyncServerTime
        '
        Me.txtSyncServerTime.Enabled = False
        Me.txtSyncServerTime.Location = New System.Drawing.Point(205, 99)
        Me.txtSyncServerTime.Name = "txtSyncServerTime"
        Me.txtSyncServerTime.Size = New System.Drawing.Size(184, 20)
        Me.txtSyncServerTime.TabIndex = 2
        Me.txtSyncServerTime.Text = ""
        '
        'txtSysTime
        '
        Me.txtSysTime.Location = New System.Drawing.Point(205, 67)
        Me.txtSysTime.Name = "txtSysTime"
        Me.txtSysTime.Size = New System.Drawing.Size(184, 20)
        Me.txtSysTime.TabIndex = 1
        Me.txtSysTime.Text = ""
        '
        'txtLastSync
        '
        Me.txtLastSync.Location = New System.Drawing.Point(205, 35)
        Me.txtLastSync.Name = "txtLastSync"
        Me.txtLastSync.Size = New System.Drawing.Size(184, 20)
        Me.txtLastSync.TabIndex = 0
        Me.txtLastSync.Text = ""
        '
        'lblSyncServerTime
        '
        Me.lblSyncServerTime.Location = New System.Drawing.Point(13, 99)
        Me.lblSyncServerTime.Name = "lblSyncServerTime"
        Me.lblSyncServerTime.Size = New System.Drawing.Size(160, 16)
        Me.lblSyncServerTime.TabIndex = 2
        Me.lblSyncServerTime.Text = "&Server's current universal time"
        '
        'lblSystemTime
        '
        Me.lblSystemTime.Location = New System.Drawing.Point(14, 68)
        Me.lblSystemTime.Name = "lblSystemTime"
        Me.lblSystemTime.Size = New System.Drawing.Size(160, 16)
        Me.lblSystemTime.TabIndex = 1
        Me.lblSystemTime.Text = "&Local system time"
        '
        'lblLastSyncTime
        '
        Me.lblLastSyncTime.Location = New System.Drawing.Point(13, 35)
        Me.lblLastSyncTime.Name = "lblLastSyncTime"
        Me.lblLastSyncTime.Size = New System.Drawing.Size(168, 16)
        Me.lblLastSyncTime.TabIndex = 0
        Me.lblLastSyncTime.Text = "&Application's Time"
        '
        'grpTime
        '
        Me.grpTime.Location = New System.Drawing.Point(5, 19)
        Me.grpTime.Name = "grpTime"
        Me.grpTime.Size = New System.Drawing.Size(408, 112)
        Me.grpTime.TabIndex = 6
        Me.grpTime.TabStop = False
        Me.grpTime.Text = "Different times that iMessaging uses"
        '
        'tpMessageSettings
        '
        Me.tpMessageSettings.Controls.AddRange(New System.Windows.Forms.Control() {Me.cbShowMyIp, Me.cmdDefault, Me.cmdSave, Me.cmdMessageClose, Me.GroupBox1})
        Me.tpMessageSettings.Location = New System.Drawing.Point(4, 22)
        Me.tpMessageSettings.Name = "tpMessageSettings"
        Me.tpMessageSettings.Size = New System.Drawing.Size(426, 183)
        Me.tpMessageSettings.TabIndex = 2
        Me.tpMessageSettings.Text = "Message Settings"
        '
        'cbShowMyIp
        '
        Me.cbShowMyIp.Location = New System.Drawing.Point(8, 115)
        Me.cbShowMyIp.Name = "cbShowMyIp"
        Me.cbShowMyIp.Size = New System.Drawing.Size(267, 24)
        Me.cbShowMyIp.TabIndex = 3
        Me.cbShowMyIp.Text = "Show my &IP address if somebody searches me"
        '
        'cmdDefault
        '
        Me.cmdDefault.Location = New System.Drawing.Point(165, 151)
        Me.cmdDefault.Name = "cmdDefault"
        Me.cmdDefault.Size = New System.Drawing.Size(88, 24)
        Me.cmdDefault.TabIndex = 5
        Me.cmdDefault.Text = "&Default"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(8, 153)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(86, 22)
        Me.cmdSave.TabIndex = 4
        Me.cmdSave.Text = "&Save Settings"
        '
        'cmdMessageClose
        '
        Me.cmdMessageClose.Location = New System.Drawing.Point(324, 151)
        Me.cmdMessageClose.Name = "cmdMessageClose"
        Me.cmdMessageClose.Size = New System.Drawing.Size(88, 24)
        Me.cmdMessageClose.TabIndex = 6
        Me.cmdMessageClose.Text = "&Close"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbTunes, Me.lblTunes, Me.rbSilent, Me.rbNonSilent})
        Me.GroupBox1.Location = New System.Drawing.Point(7, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 97)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Message ring tone"
        '
        'cmbTunes
        '
        Me.cmbTunes.Location = New System.Drawing.Point(230, 45)
        Me.cmbTunes.Name = "cmbTunes"
        Me.cmbTunes.Size = New System.Drawing.Size(146, 21)
        Me.cmbTunes.TabIndex = 1
        Me.cmbTunes.Text = "Select a tune"
        '
        'lblTunes
        '
        Me.lblTunes.Location = New System.Drawing.Point(84, 45)
        Me.lblTunes.Name = "lblTunes"
        Me.lblTunes.Size = New System.Drawing.Size(134, 24)
        Me.lblTunes.TabIndex = 1
        Me.lblTunes.Text = "Incomming message &tune"
        '
        'rbSilent
        '
        Me.rbSilent.Location = New System.Drawing.Point(12, 66)
        Me.rbSilent.Name = "rbSilent"
        Me.rbSilent.Size = New System.Drawing.Size(148, 24)
        Me.rbSilent.TabIndex = 2
        Me.rbSilent.Text = "Operate in &silent mode"
        '
        'rbNonSilent
        '
        Me.rbNonSilent.Location = New System.Drawing.Point(12, 17)
        Me.rbNonSilent.Name = "rbNonSilent"
        Me.rbNonSilent.Size = New System.Drawing.Size(174, 24)
        Me.rbNonSilent.TabIndex = 0
        Me.rbNonSilent.Text = "Operate in &non-silent mode"
        '
        'tmrSettings
        '
        Me.tmrSettings.Interval = 1000
        Me.tmrSettings.SynchronizingObject = Me
        '
        'frmSettings
        '
        Me.AcceptButton = Me.cmdChangePassword
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdChangePasswordClose
        Me.ClientSize = New System.Drawing.Size(434, 209)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabSettings})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.Text = "at Form Load"
        Me.tabSettings.ResumeLayout(False)
        Me.tpChangePassword.ResumeLayout(False)
        Me.tpTimeSync.ResumeLayout(False)
        Me.tpMessageSettings.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.tmrSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modIsSettingsOpen = True

        'Page enable disable
        If modSessionStatus = "LOGGED" Then
            Me.Text = "Settings - " & modUserId
            tabSettings.TabPages(2).Enabled = True
            tabSettings.TabPages(0).Enabled = False
        Else
            Me.Text = "Settings"
            tabSettings.TabPages(2).Enabled = False
            tabSettings.TabPages(0).Enabled = True
        End If

        'start timer
        tmrSettings.Enabled = True
        tmrSettings.Start()
    End Sub

    Private Sub tabSettings_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabSettings.SelectedIndexChanged
        Dim I As Integer

        Select Case tabSettings.SelectedIndex()
            Case 2
                'Load user settings
                cmbTunes.Items.Clear()
                cmbTunes.Items.AddRange(modTuneFileNameArray)

                If modOperationMode = "NOTSILENT" Then
                    rbNonSilent.Checked = True
                    cmbTunes.SelectedIndex = modTuneFileNo
                Else
                    rbSilent.Checked = True
                End If

                If modShowMyIp = "SHOWIP" Then
                    cbShowMyIp.Checked = True
                Else
                    cbShowMyIp.Checked = False
                End If

        End Select
    End Sub

    Private Sub tmrSettings_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles tmrSettings.Elapsed
        If tabSettings.SelectedIndex() = 1 Then
            txtLastSync.Text = Date.FromFileTime(CType(modUniversalServerTime, Long))
            txtSysTime.Text = Date.Now
            If (txtSyncServerTime.Text <> "") Then
                txtSyncServerTime.Text = CType(txtSyncServerTime.Text, Date).AddSeconds(1)
            End If
            txtSyncServerTime.Refresh()
        End If
    End Sub

#Region "Change Password"

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtNewPassword1.Text = ""
        txtNewPassword2.Text = ""
        txtOldPassword.Text = ""
        txtUserId.Text = ""
    End Sub

    Private Sub cmdChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangePassword.Click
        Dim MessageBuffer As String
        Dim WasteArg1 As Object, WasteArg2 As EventArgs


        'Check empty textboxes
        If txtUserId.Text = "" Then
            MsgBox("UserId needed", MsgBoxStyle.Information)
            txtUserId.Focus()
            Exit Sub
        End If
        If txtOldPassword.Text = "" Then
            MsgBox("Old password Needed", MsgBoxStyle.Information)
            txtOldPassword.Focus()
            Exit Sub
        End If
        If txtNewPassword1.Text = "" Then
            MsgBox("Enter new password", MsgBoxStyle.Information)
            txtNewPassword1.Focus()
            Exit Sub
        End If
        If txtNewPassword2.Text = "" Then
            MsgBox("Retype new password", MsgBoxStyle.Information)
            txtNewPassword2.Focus()
            Exit Sub
        End If
        If txtNewPassword1.Text <> txtNewPassword2.Text Then
            MsgBox("Password doesnot match! Reenter", MsgBoxStyle.Information)
            txtNewPassword1.Text = ""
            txtNewPassword2.Text = ""
            txtNewPassword1.Focus()
            Exit Sub
        End If

        MessageBuffer = modServiceObject.ChangePassword(txtUserId.Text, txtOldPassword.Text, txtNewPassword1.Text)
        'Check for Invalid UserId
        If MessageBuffer = "ERROR-01: INVALID USERID" Then
            MsgBox("Invalid UserId! UserId is case sensitive", MsgBoxStyle.Information)
            cmdClear_Click(WasteArg1, WasteArg2)
            txtUserId.Focus()
            Exit Sub
        End If
        If MessageBuffer = "ERROR-06: DATA INVALID" Then
            MsgBox("Invalid old password", MsgBoxStyle.Information)
            txtOldPassword.Text = ""
            txtNewPassword1.Text = ""
            txtNewPassword2.Text = ""
            txtUserId.Focus()
            Exit Sub
        End If
        If MessageBuffer = "MESAG-14: PASSWORD CHANGED" Then
            MsgBox("Password cleared! Use new password to use the service", MsgBoxStyle.Information)
            cmdClear_Click(WasteArg1, WasteArg2)
            cmdChangePasswordClose.Focus()
        End If

    End Sub

    Private Sub cmdChangePasswordClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangePasswordClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

#End Region

#Region "Time Synchronisation"

    Private Sub cmdGetServerTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetServerTime.Click
        Dim TempString As String
        TempString = modServiceObject.GetUniversalServerTime()
        txtSyncServerTime.Text = Date.FromFileTime(CType(TempString, Long))
    End Sub

    Private Sub cmdTimeClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTimeClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSync.Click
        Try
            modUniversalServerTime = CType(txtSyncServerTime.Text, Date).ToFileTime
        Catch
            MsgBox("Synchronous server time is invalid", MsgBoxStyle.Information, "Invalid Date")
            txtSyncServerTime.Focus()
        End Try
    End Sub

    Private Sub cmdUpdateSysTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

#End Region

#Region "Message Settings"

    Private Sub rbSilent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSilent.CheckedChanged
        If rbSilent.Checked Then
            lblTunes.Enabled = False
            cmbTunes.Enabled = False
        Else
            lblTunes.Enabled = True
            cmbTunes.Enabled = True
        End If
        cmdSave.Enabled = True
    End Sub

    Private Sub cmdMessageClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMessageClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefault.Click
        rbNonSilent.Checked = True
        cmbTunes.SelectedIndex = 0
        cbShowMyIp.Checked = True
        cmdSave.Enabled = True
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If rbNonSilent.Checked Then
            modOperationMode = "NOTSILENT"
            modTuneFileNo = cmbTunes.SelectedIndex
        Else
            modOperationMode = "SILENT"
            modTuneFileNo = -1
        End If

        If cbShowMyIp.Checked Then
            modShowMyIp = "SHOWIP"
        Else
            modShowMyIp = "HIDEIP"
        End If

        cmdSave.Enabled = False
    End Sub

#End Region

    Private Sub cmbTunes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTunes.SelectedIndexChanged
        cmdSave.Enabled = True
    End Sub

    Private Sub cbShowMyIp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbShowMyIp.CheckedChanged
        cmdSave.Enabled = True
    End Sub

    Private Sub frmSettings_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        modIsSettingsOpen = False
    End Sub
End Class
