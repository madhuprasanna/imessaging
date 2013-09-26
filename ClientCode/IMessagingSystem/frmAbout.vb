Public Class frmAbout
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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblInfo1 As System.Windows.Forms.Label
    Friend WithEvents lblLicense As System.Windows.Forms.Label
    Friend WithEvents llEULA As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents lblInfo2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAbout))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblInfo1 = New System.Windows.Forms.Label()
        Me.lblLicense = New System.Windows.Forms.Label()
        Me.llEULA = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.lblInfo2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(344, 84)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Bitmap)
        Me.PictureBox2.Location = New System.Drawing.Point(8, 116)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 32)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.RoyalBlue
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox3.Location = New System.Drawing.Point(0, 84)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(344, 6)
        Me.PictureBox3.TabIndex = 2
        Me.PictureBox3.TabStop = False
        '
        'lblInfo1
        '
        Me.lblInfo1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo1.Location = New System.Drawing.Point(84, 116)
        Me.lblInfo1.Name = "lblInfo1"
        Me.lblInfo1.Size = New System.Drawing.Size(238, 51)
        Me.lblInfo1.TabIndex = 3
        '
        'lblLicense
        '
        Me.lblLicense.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicense.Location = New System.Drawing.Point(83, 181)
        Me.lblLicense.Name = "lblLicense"
        Me.lblLicense.Size = New System.Drawing.Size(237, 28)
        Me.lblLicense.TabIndex = 4
        '
        'llEULA
        '
        Me.llEULA.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llEULA.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.llEULA.Location = New System.Drawing.Point(83, 210)
        Me.llEULA.Name = "llEULA"
        Me.llEULA.Size = New System.Drawing.Size(240, 15)
        Me.llEULA.TabIndex = 5
        Me.llEULA.TabStop = True
        Me.llEULA.Text = "End-User License Agreement"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(83, 239)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 2)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'cmdOk
        '
        Me.cmdOk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Location = New System.Drawing.Point(246, 267)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(91, 21)
        Me.cmdOk.TabIndex = 7
        Me.cmdOk.Text = "&Ok"
        '
        'lblInfo2
        '
        Me.lblInfo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo2.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblInfo2.Location = New System.Drawing.Point(84, 247)
        Me.lblInfo2.Name = "lblInfo2"
        Me.lblInfo2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInfo2.Size = New System.Drawing.Size(255, 12)
        Me.lblInfo2.TabIndex = 8
        Me.lblInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmAbout
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(344, 295)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblInfo2, Me.cmdOk, Me.GroupBox1, Me.llEULA, Me.lblLicense, Me.lblInfo1, Me.PictureBox3, Me.PictureBox2, Me.PictureBox1})
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About iMessaging"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmAbout_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        modIsAboutOpen = False
    End Sub

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modIsAboutOpen = True
        lblInfo1.Text = "iMessaging Client System 1.0" & vbCrLf
        lblInfo1.Text &= "Beta Version" & vbCrLf
        lblInfo1.Text &= "Copyright © 2003-2004 Creative Labs"

        lblLicense.Text = "This product uses .NET redistributable" & vbCrLf
        lblLicense.Text &= "package which is redistributed under  "

        lblInfo2.Text = "© 2004 Creative Labs. All rights reserved"
    End Sub

    Private Sub llEULA_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llEULA.LinkClicked
        Shell("notepad eula.txt", AppWinStyle.NormalFocus)
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        modIsAboutOpen = False
        Me.Close()
        Me.Dispose()
    End Sub
End Class
