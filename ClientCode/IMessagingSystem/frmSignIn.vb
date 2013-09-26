Public Class frmSignIn
    Inherits System.Windows.Forms.Form

    Dim ObjfrmOperationMessages As New frmOperationMessages()

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
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserId As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdLogin As System.Windows.Forms.Button
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents grpNothing As System.Windows.Forms.GroupBox
    Friend WithEvents llRegister As System.Windows.Forms.LinkLabel
    Friend WithEvents llHelp As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSignIn))
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdLogin = New System.Windows.Forms.Button()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.grpNothing = New System.Windows.Forms.GroupBox()
        Me.llRegister = New System.Windows.Forms.LinkLabel()
        Me.llHelp = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(106, 129)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(162, 20)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.Text = ""
        '
        'txtUserId
        '
        Me.txtUserId.Location = New System.Drawing.Point(107, 97)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(162, 20)
        Me.txtUserId.TabIndex = 0
        Me.txtUserId.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 14)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "&Password"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "&User Id"
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.Location = New System.Drawing.Point(198, 161)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(72, 23)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "&Close"
        '
        'cmdLogin
        '
        Me.cmdLogin.Location = New System.Drawing.Point(106, 161)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(69, 23)
        Me.cmdLogin.TabIndex = 2
        Me.cmdLogin.Text = "&Login"
        '
        'picIcon
        '
        Me.picIcon.Image = CType(resources.GetObject("picIcon.Image"), System.Drawing.Bitmap)
        Me.picIcon.Location = New System.Drawing.Point(6, 21)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(31, 32)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picIcon.TabIndex = 20
        Me.picIcon.TabStop = False
        '
        'lblMessage
        '
        Me.lblMessage.Location = New System.Drawing.Point(41, 16)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(228, 50)
        Me.lblMessage.TabIndex = 21
        Me.lblMessage.Text = "Sign in with iMessaging UserId to start the service working for you. If you are n" & _
        "ew to the service register with iMessaging Service."
        '
        'grpNothing
        '
        Me.grpNothing.Location = New System.Drawing.Point(4, 194)
        Me.grpNothing.Name = "grpNothing"
        Me.grpNothing.Size = New System.Drawing.Size(277, 3)
        Me.grpNothing.TabIndex = 22
        Me.grpNothing.TabStop = False
        '
        'llRegister
        '
        Me.llRegister.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.llRegister.Location = New System.Drawing.Point(4, 200)
        Me.llRegister.Name = "llRegister"
        Me.llRegister.Size = New System.Drawing.Size(135, 18)
        Me.llRegister.TabIndex = 4
        Me.llRegister.TabStop = True
        Me.llRegister.Text = "&Register with iMessaging"
        '
        'llHelp
        '
        Me.llHelp.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.llHelp.Location = New System.Drawing.Point(246, 199)
        Me.llHelp.Name = "llHelp"
        Me.llHelp.Size = New System.Drawing.Size(32, 18)
        Me.llHelp.TabIndex = 5
        Me.llHelp.TabStop = True
        Me.llHelp.Text = "&Help"
        Me.llHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmSignIn
        '
        Me.AcceptButton = Me.cmdLogin
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdExit
        Me.ClientSize = New System.Drawing.Size(283, 219)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.llHelp, Me.llRegister, Me.grpNothing, Me.lblMessage, Me.picIcon, Me.txtPassword, Me.txtUserId, Me.Label2, Me.Label1, Me.cmdExit, Me.cmdLogin})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSignIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "iMessaging Login"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub AuthenticationSuccessActions()

        'Update Session info if Authentication succeeds
        modUserId = txtUserId.Text
        modPassword = txtPassword.Text
        modSessionStatus = "LOGGED"

        'Change context menu enable disable
        FormatContextMenuEnableDisable()
        modSystrayIcon.ContextMenu.MenuItems(1).Text = "Sign Out " & modUserId & "..."
        modSystrayIcon.ContextMenu.MenuItems(9).Text = modUserId & "'s Vote Results..."

        'Send back IPAddress
        ObjfrmOperationMessages.lblMessage.Text = "Registering IpAddress..."
        ObjfrmOperationMessages.Show()
        ObjfrmOperationMessages.Refresh()
        modServiceObject.StoreIPAddress(modUserId, modPasswordChallenge, modSystemIpAddress)

        'Load permanent settings
        ObjfrmOperationMessages.lblMessage.Text = "Loading " & modUserId & "'s settings..."
        ObjfrmOperationMessages.Show()
        ObjfrmOperationMessages.Refresh()
        modPermanentSettingsString = modServiceObject.LoadSettings(modUserId, modPasswordChallenge)
        modShowMyIp = modPermanentSettingsString.Split(";")(0)
        modOperationMode = modPermanentSettingsString.Split(";")(1).Split(":")(0)
        modTuneFileNo = modPermanentSettingsString.Split(";")(1).Split(":")(1)

        'Load address book
        ObjfrmOperationMessages.lblMessage.Text = "Loading " & modUserId & "'s Address book..."
        ObjfrmOperationMessages.Show()
        ObjfrmOperationMessages.Refresh()
        modAddressbookString = modServiceObject.LoadAddressBook(modUserId, modPasswordChallenge)
        modAddressBook.StoreAddressString(modAddressbookString)

        'Start Async Message req and start displayer.
        modMessageReceiverObject.StartReceive()
        modMessageDisplayerObject.StartDisplay()

        ObjfrmOperationMessages.Close()
        ObjfrmOperationMessages.Dispose()
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmSignIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modIsSignInOpen = True
    End Sub

    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        Dim MessageBuffer As String
        Dim StatusBarText As String

        'Check empty textboxes
        If txtUserId.Text = "" Then
            MsgBox("UserId needed", MsgBoxStyle.Information)
            txtUserId.Focus()
            Exit Sub
        End If
        If txtPassword.Text = "" Then
            MsgBox("Password needed", MsgBoxStyle.Information)
            txtPassword.Focus()
            Exit Sub
        End If


        'Call RequestChallenge
        ObjfrmOperationMessages.lblMessage.Text = "Requesting Challenge..."
        ObjfrmOperationMessages.Show()
        ObjfrmOperationMessages.Refresh()
        MessageBuffer = modServiceObject.RequestChallenge(txtUserId.Text)

        'Check for Invalid UserId
        If MessageBuffer = "ERROR-01: INVALID USERID" Then
            ObjfrmOperationMessages.Hide()
            MsgBox("Invalid UserId! UserId is case sensitive", MsgBoxStyle.Information)
            txtUserId.Text = ""
            txtPassword.Text = ""
            txtUserId.Focus()
            Exit Sub
        End If
        'Check for already logged session
        If MessageBuffer = "ERROR-05: ALREADY LOGGED" Then
            ObjfrmOperationMessages.Hide()
            MsgBox("Already logged! Use Clear Session and Login Again", MsgBoxStyle.Information)
            txtPassword.Text = ""
            modSystrayIcon.ContextMenu.Show(Me, Me.MousePosition())
            Exit Sub
        End If
        'Check for challenge
        If MessageBuffer.Length < 3 Then
            modChallenge = MessageBuffer
        End If

        'Generate PasswordChallenge
        modPasswordChallenge = GenerateChallengeValue(txtPassword.Text, modChallenge)

        'Call Authenticate 
        ObjfrmOperationMessages.lblMessage.Text = "Authenticating UserId..."
        ObjfrmOperationMessages.Show()
        ObjfrmOperationMessages.Refresh()

        MessageBuffer = modServiceObject.Authenticate(txtUserId.Text, modPasswordChallenge)

        'Check for Authentication failure
        If MessageBuffer = "ERROR-02: AUTHENTICATION FAILURE" Then
            ObjfrmOperationMessages.Hide()
            MsgBox("Incorrect Password! Retry Again", MsgBoxStyle.Information)
            txtPassword.Text = ""
            txtPassword.Focus()
            Exit Sub
        End If
        If MessageBuffer = "MESAG-01: AUTHENTICATION SUCCESS" Then
            AuthenticationSuccessActions()
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub llHelp_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llHelp.LinkClicked
        Help.ShowHelp(Me, hpiMessagingHelp.HelpNamespace)
    End Sub

    Private Sub frmSignIn_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        modIsSignInOpen = False
    End Sub

    Private Sub llRegister_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llRegister.LinkClicked
        If modIsRegistrationOpen = False Then
            modfrmRegistration = New frmRegistration()
            modfrmRegistration.Show()
            modfrmRegistration.Refresh()
        Else
            modfrmRegistration.Activate()
            modfrmRegistration.Refresh()
        End If
    End Sub
End Class
