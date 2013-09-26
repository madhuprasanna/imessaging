Public Class frmMessageBox
    Inherits System.Windows.Forms.Form

    Public SenderName As String

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
    Friend WithEvents rtbHeader As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbMessage As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdReply As System.Windows.Forms.Button
    Friend WithEvents llAddAddress As System.Windows.Forms.LinkLabel
    Friend WithEvents llBlockMessage As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMessageBox))
        Me.rtbHeader = New System.Windows.Forms.RichTextBox()
        Me.rtbMessage = New System.Windows.Forms.RichTextBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdReply = New System.Windows.Forms.Button()
        Me.llAddAddress = New System.Windows.Forms.LinkLabel()
        Me.llBlockMessage = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'rtbHeader
        '
        Me.rtbHeader.BackColor = System.Drawing.SystemColors.Control
        Me.rtbHeader.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbHeader.Cursor = System.Windows.Forms.Cursors.No
        Me.rtbHeader.Font = New System.Drawing.Font("Verdana", 8.0!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbHeader.ForeColor = System.Drawing.Color.Navy
        Me.rtbHeader.Location = New System.Drawing.Point(0, 8)
        Me.rtbHeader.Name = "rtbHeader"
        Me.rtbHeader.ReadOnly = True
        Me.rtbHeader.Size = New System.Drawing.Size(296, 32)
        Me.rtbHeader.TabIndex = 5
        Me.rtbHeader.TabStop = False
        Me.rtbHeader.Text = "From"
        '
        'rtbMessage
        '
        Me.rtbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbMessage.Location = New System.Drawing.Point(0, 56)
        Me.rtbMessage.Name = "rtbMessage"
        Me.rtbMessage.ReadOnly = True
        Me.rtbMessage.Size = New System.Drawing.Size(296, 64)
        Me.rtbMessage.TabIndex = 2
        Me.rtbMessage.Text = ""
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(1, 122)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(45, 23)
        Me.cmdOk.TabIndex = 3
        Me.cmdOk.Text = "&Ok"
        '
        'cmdReply
        '
        Me.cmdReply.Location = New System.Drawing.Point(251, 122)
        Me.cmdReply.Name = "cmdReply"
        Me.cmdReply.Size = New System.Drawing.Size(45, 23)
        Me.cmdReply.TabIndex = 4
        Me.cmdReply.Text = "&Reply"
        '
        'llAddAddress
        '
        Me.llAddAddress.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.llAddAddress.Location = New System.Drawing.Point(176, 40)
        Me.llAddAddress.Name = "llAddAddress"
        Me.llAddAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.llAddAddress.Size = New System.Drawing.Size(120, 16)
        Me.llAddAddress.TabIndex = 1
        Me.llAddAddress.TabStop = True
        Me.llAddAddress.Text = "&Add to address book"
        '
        'llBlockMessage
        '
        Me.llBlockMessage.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.llBlockMessage.Location = New System.Drawing.Point(0, 40)
        Me.llBlockMessage.Name = "llBlockMessage"
        Me.llBlockMessage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.llBlockMessage.Size = New System.Drawing.Size(160, 16)
        Me.llBlockMessage.TabIndex = 0
        Me.llBlockMessage.TabStop = True
        Me.llBlockMessage.Text = "&Block message from this user"
        '
        'frmMessageBox
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(298, 147)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.llBlockMessage, Me.llAddAddress, Me.cmdReply, Me.cmdOk, Me.rtbMessage, Me.rtbHeader})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMessageBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "By Displayer"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Sub New(ByVal SenderId As String)
        Me.New()
        SenderName = SenderId
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmMessageBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim TheFileName As String
        If modOperationMode <> "SILENT" Then

            Try
                TheFileName = modTuneFileNameArray(modTuneFileNo)
            Catch
                TheFileName = modTuneFileNameArray(0)
            End Try

            'Try block used to confirm release of resources
            Try
                Dim ObjSound As New CSound()
                ObjSound.PlaySoundFile(modTuneFileNameArray(modTuneFileNo))
            Catch
                'Intentionally left Empty
            End Try
        End If
    End Sub

    Private Sub llAddAddress_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llAddAddress.LinkClicked
        Dim MessageBuffer As String
        MessageBuffer = modAddressBook.AddUser(SenderName)
        MsgBox(MessageBuffer, MsgBoxStyle.Information, MessageBuffer)
    End Sub

    Private Sub llBlockMessage_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llBlockMessage.LinkClicked
        Dim MessageBuffer As String
        MessageBuffer = modAddressBook.AddUser(SenderName)
        modAddressBook.UserAddressTable.Item(SenderName) = SenderName & ":B"
        MsgBox("User blocked! All further messages from " & SenderName & " will be blocked", MsgBoxStyle.Information, SenderName & " blocked")
    End Sub

    Private Sub cmdReply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReply.Click
        If Not modIsSendMessageOpen Then
            modfrmSendMessage = New frmSendMessage()
            modfrmSendMessage.Show()
            modfrmSendMessage.Refresh()
        Else
            modfrmSendMessage.Activate()
            modfrmSendMessage.Refresh()
        End If

        modfrmSendMessage.txtDestId.Text = SenderName
        modfrmSendMessage.rtbMessage.Text = Me.rtbMessage.Text & vbCrLf
        modfrmSendMessage.rtbMessage.SelectAll()
        modfrmSendMessage.rtbMessage.Focus()
        Me.Close()
        Me.Dispose()
    End Sub
End Class
