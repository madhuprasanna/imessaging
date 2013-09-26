Public Class frmGetIpAddress
    Inherits System.Windows.Forms.Form

    Dim CallerForm As frmMain

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
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents txtIpAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblIpAddress As System.Windows.Forms.Label
    Friend WithEvents cmdConnect As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdTestInternetConnection As System.Windows.Forms.Button
    Friend WithEvents cmdExitApplication As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGetIpAddress))
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.txtIpAddress = New System.Windows.Forms.TextBox()
        Me.lblIpAddress = New System.Windows.Forms.Label()
        Me.cmdConnect = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdTestInternetConnection = New System.Windows.Forms.Button()
        Me.cmdExitApplication = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblMessage
        '
        Me.lblMessage.Location = New System.Drawing.Point(16, 16)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(312, 64)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "Your system has no Internet connection currently. Please enter the IpAddress of t" & _
        "he system in the LAN which has Internet Connection.Or check your Internet connec" & _
        "tion if your system is not part of any LAN."
        '
        'txtIpAddress
        '
        Me.txtIpAddress.Location = New System.Drawing.Point(160, 104)
        Me.txtIpAddress.Name = "txtIpAddress"
        Me.txtIpAddress.Size = New System.Drawing.Size(160, 20)
        Me.txtIpAddress.TabIndex = 0
        Me.txtIpAddress.Text = "127.0.0.1"
        '
        'lblIpAddress
        '
        Me.lblIpAddress.Location = New System.Drawing.Point(16, 104)
        Me.lblIpAddress.Name = "lblIpAddress"
        Me.lblIpAddress.Size = New System.Drawing.Size(112, 16)
        Me.lblIpAddress.TabIndex = 2
        Me.lblIpAddress.Text = "Enter an IP Address"
        '
        'cmdConnect
        '
        Me.cmdConnect.Location = New System.Drawing.Point(240, 136)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(80, 24)
        Me.cmdConnect.TabIndex = 3
        Me.cmdConnect.TabStop = False
        Me.cmdConnect.Text = "Connect"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 168)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Enter an IP Address"
        '
        'cmdTestInternetConnection
        '
        Me.cmdTestInternetConnection.Location = New System.Drawing.Point(8, 176)
        Me.cmdTestInternetConnection.Name = "cmdTestInternetConnection"
        Me.cmdTestInternetConnection.Size = New System.Drawing.Size(136, 24)
        Me.cmdTestInternetConnection.TabIndex = 1
        Me.cmdTestInternetConnection.Text = "Test Internet Connection"
        '
        'cmdExitApplication
        '
        Me.cmdExitApplication.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExitApplication.Location = New System.Drawing.Point(200, 176)
        Me.cmdExitApplication.Name = "cmdExitApplication"
        Me.cmdExitApplication.Size = New System.Drawing.Size(136, 24)
        Me.cmdExitApplication.TabIndex = 2
        Me.cmdExitApplication.Text = "Exit iMessaging System"
        '
        'frmGetIpAddress
        '
        Me.AcceptButton = Me.cmdConnect
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdExitApplication
        Me.ClientSize = New System.Drawing.Size(346, 208)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdExitApplication, Me.cmdTestInternetConnection, Me.cmdConnect, Me.lblIpAddress, Me.txtIpAddress, Me.lblMessage, Me.GroupBox1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGetIpAddress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enter an IpAddress"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Sub New(ByRef reffrmMain As frmMain)
        Me.New()
        CallerForm = reffrmMain
    End Sub

    Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click
        modHandlerIpAddress = txtIpAddress.Text
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdExitApplication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExitApplication.Click
        End
    End Sub

    Private Sub cmdTestInternetConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTestInternetConnection.Click
        Dim ObjfrmOperationMessages As New frmOperationMessages()
        ObjfrmOperationMessages.lblMessage.Text = "Checking for Internet connection Please wait ..."
        ObjfrmOperationMessages.Show()
        ObjfrmOperationMessages.Refresh()
        modInternetConnection = CheckforInternetConnection()
        ObjfrmOperationMessages.Close()
        ObjfrmOperationMessages.Dispose()

        If modInternetConnection Then
            MsgBox("Your Internet connection is Ok", MsgBoxStyle.Exclamation, "Connection OK")
            Me.Close()
            Me.Dispose()
        Else
            MsgBox("No Internet connection available in this system", MsgBoxStyle.Critical, "Connection Failed")
            Exit Sub
        End If
    End Sub
End Class
