Public Class frmVotingMessage
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
    Friend WithEvents llBlockMessage As System.Windows.Forms.LinkLabel
    Friend WithEvents llAddAddress As System.Windows.Forms.LinkLabel
    Friend WithEvents rtbMessage As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbHeader As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdAgree As System.Windows.Forms.Button
    Friend WithEvents cmdOppose As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmVotingMessage))
        Me.llBlockMessage = New System.Windows.Forms.LinkLabel()
        Me.llAddAddress = New System.Windows.Forms.LinkLabel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdAgree = New System.Windows.Forms.Button()
        Me.rtbMessage = New System.Windows.Forms.RichTextBox()
        Me.rtbHeader = New System.Windows.Forms.RichTextBox()
        Me.cmdOppose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
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
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(219, 122)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(78, 23)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "&Close"
        '
        'cmdAgree
        '
        Me.cmdAgree.Location = New System.Drawing.Point(1, 122)
        Me.cmdAgree.Name = "cmdAgree"
        Me.cmdAgree.TabIndex = 3
        Me.cmdAgree.Text = "&Agree"
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
        Me.rtbHeader.TabIndex = 6
        Me.rtbHeader.Text = "From"
        '
        'cmdOppose
        '
        Me.cmdOppose.Location = New System.Drawing.Point(108, 122)
        Me.cmdOppose.Name = "cmdOppose"
        Me.cmdOppose.TabIndex = 4
        Me.cmdOppose.Text = "&Oppose"
        '
        'frmVotingMessage
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(298, 147)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdOppose, Me.llBlockMessage, Me.llAddAddress, Me.cmdClose, Me.cmdAgree, Me.rtbMessage, Me.rtbHeader})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVotingMessage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "By Displayer"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public MessageId As String
    Public SenderName As String

    Sub New(ByVal SenderId As String)
        Me.New()
        SenderName = SenderId
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmVotingMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim TheFileName As String
        If modOperationMode <> "SILENT" Then
            TheFileName = modTuneFileNameArray(modTuneFileNo)
            'Try block used to confirm release of resources
            Try
                Dim ObjSound As New CSound()
                ObjSound.PlaySoundFile(modTuneFileNameArray(modTuneFileNo))
            Catch
                'Intentionally left Empty
            End Try
        End If
    End Sub

    Private Sub cmdAgree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgree.Click
        Dim MessageBuffer As String

        MessageBuffer = modServiceObject.MyVote(modUserId, modPasswordChallenge, MessageId, "Agree")

        If MessageBuffer = "ERROR-03: INVALID SESSION" Then
            MsgBox("Your session has become invalid! Clear session and continue", MsgBoxStyle.Information, "Session Invalid")
            Exit Sub
        End If
        If MessageBuffer = "ERROR-12: ALREADY VOTED" Then
            MsgBox("You have voted already!", MsgBoxStyle.Information, "Already Voted")
            Exit Sub
        End If
        If MessageBuffer = "ERROR-11: USER NOT AUTHERIZED" Then
            MsgBox("You are not autherized to reply this request!", MsgBoxStyle.Critical, "Not Autherized")
            Exit Sub
        End If
        If MessageBuffer = "ERROR-13: INVALID MESSAGEID" Then
            MsgBox("Invalid vote response! This vote request may have been aborted", MsgBoxStyle.Information, "Vote Request Aborted")
            Exit Sub
        End If
        If MessageBuffer = "MESAG-24: VOTE CASTED" Then
            MsgBox("Thanks for your reply", MsgBoxStyle.Exclamation, "Vote Casted")
            Me.Dispose()
        End If
    End Sub

    Private Sub cmdOppose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOppose.Click
        Dim MessageBuffer As String

        MessageBuffer = modServiceObject.MyVote(modUserId, modPasswordChallenge, MessageId, "Oppose")

        If MessageBuffer = "ERROR-03: INVALID SESSION" Then
            MsgBox("Your session has become invalid! Clear session and continue", MsgBoxStyle.Information, "Session Invalid")
            Exit Sub
        End If
        If MessageBuffer = "ERROR-12: ALREADY VOTED" Then
            MsgBox("You have voted already!", MsgBoxStyle.Information, "Already Voted")
            Exit Sub
        End If
        If MessageBuffer = "ERROR-11: USER NOT AUTHERIZED" Then
            MsgBox("You are not autherized to reply this request!", MsgBoxStyle.Critical, "Not Autherized")
            Exit Sub
        End If
        If MessageBuffer = "ERROR-13: INVALID MESSAGEID" Then
            MsgBox("Invalid vote response! This vote request may have been aborted", MsgBoxStyle.Information, "Vote Request Aborted")
            Exit Sub
        End If
        If MessageBuffer = "MESAG-24: VOTE CASTED" Then
            MsgBox("Thanks for your reply", MsgBoxStyle.Exclamation, "Vote Casted")
            Me.Dispose()
        End If
    End Sub

    Private Sub llAddAddress_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llAddAddress.LinkClicked
        Dim MessageBuffer As String
        MessageBuffer = modAddressBook.AddUser(SenderName)
        MsgBox(MessageBuffer, MsgBoxStyle.Information, "UserId Already Exists")
    End Sub

    Private Sub llBlockMessage_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llBlockMessage.LinkClicked
        Dim MessageBuffer As String
        MessageBuffer = modAddressBook.AddUser(SenderName)
        modAddressBook.UserAddressTable.Item(SenderName) = SenderName & ":B"
        MsgBox("User blocked! All further messages from " & SenderName & " will be blocked", MsgBoxStyle.Information, SenderName & " blocked")
    End Sub
End Class
