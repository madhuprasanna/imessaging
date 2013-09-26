Public Class frmSendMessage
    Inherits System.Windows.Forms.Form

    Public TimeFormat As String = "LOCAL"
    Public IsTimeSelectOpen As Boolean = False
    Dim CharCount As Integer = 230

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
    Friend WithEvents lblCharsRemaining As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents rtbMessage As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdSend As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMessage As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuCut As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCopy As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPaste As System.Windows.Forms.MenuItem
    Friend WithEvents mnuClear As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents munSelectAll As System.Windows.Forms.MenuItem
    Friend WithEvents tpSendMessage As System.Windows.Forms.TabPage
    Friend WithEvents cmdSelectTime As System.Windows.Forms.Button
    Friend WithEvents llAddressBook As System.Windows.Forms.LinkLabel
    Friend WithEvents cbTimedMessage As System.Windows.Forms.CheckBox
    Friend WithEvents lblDeliveryTime As System.Windows.Forms.Label
    Friend WithEvents txtDeliveryTime As System.Windows.Forms.TextBox
    Friend WithEvents cbGroupMessage As System.Windows.Forms.CheckBox
    Friend WithEvents txtDestId As System.Windows.Forms.TextBox
    Friend WithEvents lblUserId As System.Windows.Forms.Label
    Friend WithEvents grpMessageType As System.Windows.Forms.GroupBox
    Friend WithEvents tpVoteMessage As System.Windows.Forms.TabPage
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tabSendMessage As System.Windows.Forms.TabControl
    Friend WithEvents llShowAddressBook As System.Windows.Forms.LinkLabel
    Friend WithEvents txtVoteDest As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSendMessage))
        Me.rtbMessage = New System.Windows.Forms.RichTextBox()
        Me.lblCharsRemaining = New System.Windows.Forms.Label()
        Me.cmdSend = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.mnuMessage = New System.Windows.Forms.ContextMenu()
        Me.mnuCut = New System.Windows.Forms.MenuItem()
        Me.mnuCopy = New System.Windows.Forms.MenuItem()
        Me.mnuPaste = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.munSelectAll = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mnuClear = New System.Windows.Forms.MenuItem()
        Me.tpSendMessage = New System.Windows.Forms.TabPage()
        Me.cmdSelectTime = New System.Windows.Forms.Button()
        Me.llAddressBook = New System.Windows.Forms.LinkLabel()
        Me.cbTimedMessage = New System.Windows.Forms.CheckBox()
        Me.lblDeliveryTime = New System.Windows.Forms.Label()
        Me.txtDeliveryTime = New System.Windows.Forms.TextBox()
        Me.cbGroupMessage = New System.Windows.Forms.CheckBox()
        Me.txtDestId = New System.Windows.Forms.TextBox()
        Me.lblUserId = New System.Windows.Forms.Label()
        Me.grpMessageType = New System.Windows.Forms.GroupBox()
        Me.tpVoteMessage = New System.Windows.Forms.TabPage()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.llShowAddressBook = New System.Windows.Forms.LinkLabel()
        Me.txtVoteDest = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tabSendMessage = New System.Windows.Forms.TabControl()
        Me.tpSendMessage.SuspendLayout()
        Me.tpVoteMessage.SuspendLayout()
        Me.tabSendMessage.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbMessage
        '
        Me.rtbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbMessage.Location = New System.Drawing.Point(3, 184)
        Me.rtbMessage.MaxLength = 120
        Me.rtbMessage.Name = "rtbMessage"
        Me.rtbMessage.Size = New System.Drawing.Size(354, 71)
        Me.rtbMessage.TabIndex = 5
        Me.rtbMessage.Text = ""
        Me.rtbMessage.WordWrap = False
        '
        'lblCharsRemaining
        '
        Me.lblCharsRemaining.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblCharsRemaining.Location = New System.Drawing.Point(224, 168)
        Me.lblCharsRemaining.Name = "lblCharsRemaining"
        Me.lblCharsRemaining.Size = New System.Drawing.Size(144, 16)
        Me.lblCharsRemaining.TabIndex = 2
        Me.lblCharsRemaining.Text = "Characters remaining: 120"
        Me.lblCharsRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSend
        '
        Me.cmdSend.Location = New System.Drawing.Point(5, 260)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.TabIndex = 6
        Me.cmdSend.Text = "&Send"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(281, 260)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.TabIndex = 7
        Me.cmdClose.Text = "&Close"
        '
        'lblMessage
        '
        Me.lblMessage.Location = New System.Drawing.Point(0, 170)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(56, 13)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "&Message"
        '
        'mnuMessage
        '
        Me.mnuMessage.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCut, Me.mnuCopy, Me.mnuPaste, Me.MenuItem4, Me.munSelectAll, Me.MenuItem1, Me.mnuClear})
        '
        'mnuCut
        '
        Me.mnuCut.Index = 0
        Me.mnuCut.Text = "Cut"
        '
        'mnuCopy
        '
        Me.mnuCopy.Index = 1
        Me.mnuCopy.Text = "Copy"
        '
        'mnuPaste
        '
        Me.mnuPaste.Index = 2
        Me.mnuPaste.Text = "Paste"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 3
        Me.MenuItem4.Text = "-"
        '
        'munSelectAll
        '
        Me.munSelectAll.Index = 4
        Me.munSelectAll.Text = "Select All"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 5
        Me.MenuItem1.Text = "-"
        '
        'mnuClear
        '
        Me.mnuClear.Index = 6
        Me.mnuClear.Text = "Clear"
        '
        'tpSendMessage
        '
        Me.tpSendMessage.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdSelectTime, Me.llAddressBook, Me.cbTimedMessage, Me.lblDeliveryTime, Me.txtDeliveryTime, Me.cbGroupMessage, Me.txtDestId, Me.lblUserId, Me.grpMessageType})
        Me.tpSendMessage.Location = New System.Drawing.Point(4, 22)
        Me.tpSendMessage.Name = "tpSendMessage"
        Me.tpSendMessage.Size = New System.Drawing.Size(352, 126)
        Me.tpSendMessage.TabIndex = 0
        Me.tpSendMessage.Text = "Send Message"
        '
        'cmdSelectTime
        '
        Me.cmdSelectTime.Enabled = False
        Me.cmdSelectTime.Location = New System.Drawing.Point(247, 96)
        Me.cmdSelectTime.Name = "cmdSelectTime"
        Me.cmdSelectTime.Size = New System.Drawing.Size(90, 24)
        Me.cmdSelectTime.TabIndex = 4
        Me.cmdSelectTime.Text = "S&elect Time..."
        '
        'llAddressBook
        '
        Me.llAddressBook.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.llAddressBook.Location = New System.Drawing.Point(235, 71)
        Me.llAddressBook.Name = "llAddressBook"
        Me.llAddressBook.Size = New System.Drawing.Size(80, 16)
        Me.llAddressBook.TabIndex = 20
        Me.llAddressBook.TabStop = True
        Me.llAddressBook.Text = "Address Book"
        Me.llAddressBook.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbTimedMessage
        '
        Me.cbTimedMessage.Location = New System.Drawing.Point(229, 24)
        Me.cbTimedMessage.Name = "cbTimedMessage"
        Me.cbTimedMessage.Size = New System.Drawing.Size(113, 24)
        Me.cbTimedMessage.TabIndex = 1
        Me.cbTimedMessage.TabStop = False
        Me.cbTimedMessage.Text = "&Timed Message"
        Me.cbTimedMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDeliveryTime
        '
        Me.lblDeliveryTime.Enabled = False
        Me.lblDeliveryTime.Location = New System.Drawing.Point(6, 96)
        Me.lblDeliveryTime.Name = "lblDeliveryTime"
        Me.lblDeliveryTime.Size = New System.Drawing.Size(80, 16)
        Me.lblDeliveryTime.TabIndex = 4
        Me.lblDeliveryTime.Text = "&Delivery Time"
        Me.lblDeliveryTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDeliveryTime
        '
        Me.txtDeliveryTime.Enabled = False
        Me.txtDeliveryTime.Location = New System.Drawing.Point(86, 96)
        Me.txtDeliveryTime.Name = "txtDeliveryTime"
        Me.txtDeliveryTime.Size = New System.Drawing.Size(136, 20)
        Me.txtDeliveryTime.TabIndex = 3
        Me.txtDeliveryTime.Text = ""
        '
        'cbGroupMessage
        '
        Me.cbGroupMessage.Location = New System.Drawing.Point(14, 24)
        Me.cbGroupMessage.Name = "cbGroupMessage"
        Me.cbGroupMessage.Size = New System.Drawing.Size(111, 24)
        Me.cbGroupMessage.TabIndex = 0
        Me.cbGroupMessage.TabStop = False
        Me.cbGroupMessage.Text = "&Group Message"
        '
        'txtDestId
        '
        Me.txtDestId.Location = New System.Drawing.Point(86, 64)
        Me.txtDestId.Name = "txtDestId"
        Me.txtDestId.Size = New System.Drawing.Size(136, 20)
        Me.txtDestId.TabIndex = 2
        Me.txtDestId.Text = ""
        '
        'lblUserId
        '
        Me.lblUserId.Location = New System.Drawing.Point(6, 65)
        Me.lblUserId.Name = "lblUserId"
        Me.lblUserId.Size = New System.Drawing.Size(64, 16)
        Me.lblUserId.TabIndex = 0
        Me.lblUserId.Text = "&User Id"
        Me.lblUserId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpMessageType
        '
        Me.grpMessageType.Location = New System.Drawing.Point(6, 8)
        Me.grpMessageType.Name = "grpMessageType"
        Me.grpMessageType.Size = New System.Drawing.Size(344, 48)
        Me.grpMessageType.TabIndex = 100
        Me.grpMessageType.TabStop = False
        Me.grpMessageType.Text = "Choose Message Type"
        '
        'tpVoteMessage
        '
        Me.tpVoteMessage.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDescription, Me.llShowAddressBook, Me.txtVoteDest, Me.Label1, Me.GroupBox1})
        Me.tpVoteMessage.Location = New System.Drawing.Point(4, 22)
        Me.tpVoteMessage.Name = "tpVoteMessage"
        Me.tpVoteMessage.Size = New System.Drawing.Size(352, 126)
        Me.tpVoteMessage.TabIndex = 1
        Me.tpVoteMessage.Text = "Vote Message"
        '
        'lblDescription
        '
        Me.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescription.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblDescription.Location = New System.Drawing.Point(13, 64)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(323, 52)
        Me.lblDescription.TabIndex = 10
        Me.lblDescription.Text = "Please type the Vote Description in the space provided for Message. Voting can on" & _
        "ly be of Yes/No, True/False boolean types. Vote results can be viewed in Message" & _
        " Archives"
        '
        'llShowAddressBook
        '
        Me.llShowAddressBook.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.llShowAddressBook.Location = New System.Drawing.Point(251, 29)
        Me.llShowAddressBook.Name = "llShowAddressBook"
        Me.llShowAddressBook.Size = New System.Drawing.Size(80, 16)
        Me.llShowAddressBook.TabIndex = 1
        Me.llShowAddressBook.TabStop = True
        Me.llShowAddressBook.Text = "Address Book"
        Me.llShowAddressBook.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVoteDest
        '
        Me.txtVoteDest.Location = New System.Drawing.Point(106, 27)
        Me.txtVoteDest.Name = "txtVoteDest"
        Me.txtVoteDest.Size = New System.Drawing.Size(136, 20)
        Me.txtVoteDest.TabIndex = 0
        Me.txtVoteDest.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "&VoteGroup Id"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(333, 115)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Send Vote Message"
        '
        'tabSendMessage
        '
        Me.tabSendMessage.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpSendMessage, Me.tpVoteMessage})
        Me.tabSendMessage.Dock = System.Windows.Forms.DockStyle.Top
        Me.tabSendMessage.ItemSize = New System.Drawing.Size(83, 18)
        Me.tabSendMessage.Name = "tabSendMessage"
        Me.tabSendMessage.SelectedIndex = 0
        Me.tabSendMessage.Size = New System.Drawing.Size(360, 152)
        Me.tabSendMessage.TabIndex = 0
        Me.tabSendMessage.TabStop = False
        '
        'frmSendMessage
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(360, 286)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMessage, Me.cmdClose, Me.cmdSend, Me.lblCharsRemaining, Me.rtbMessage, Me.tabSendMessage})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSendMessage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "at Load Time"
        Me.tpSendMessage.ResumeLayout(False)
        Me.tpVoteMessage.ResumeLayout(False)
        Me.tabSendMessage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSendMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modIsSendMessageOpen = True
        txtDestId.Focus()
        Me.Text = "Send Message - " & modUserId

        'Richtextbox characterestics 
        rtbMessage.AcceptsTab = False
        rtbMessage.ContextMenu = mnuMessage
        rtbMessage.DetectUrls = True
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub


#Region "Send Message Code"

    Private Sub cbTimedMessge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTimedMessage.CheckedChanged
        If cbTimedMessage.Checked = True Then
            lblDeliveryTime.Enabled = True
            txtDeliveryTime.Enabled = True
            cmdSelectTime.Enabled = True
        Else
            lblDeliveryTime.Enabled = False
            txtDeliveryTime.Enabled = False
            cmdSelectTime.Enabled = False

            txtDeliveryTime.Text = ""
        End If

    End Sub

    Private Sub cbGroupMessage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbGroupMessage.CheckedChanged
        If cbGroupMessage.Checked = True Then
            lblUserId.Text = "Group Id"
        Else
            lblUserId.Text = "User Id"
        End If

    End Sub

    Private Sub cmdSelectTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectTime.Click
        If Not IsTimeSelectOpen Then
            Dim ObjfrmTimeSelect As New frmTimeSelect(Me)
            ObjfrmTimeSelect.ShowDialog()
            ObjfrmTimeSelect.Refresh()
        End If
    End Sub
#End Region

#Region "RichTextBox Format Codes"

    Private Sub rtbMessage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbMessage.TextChanged
        CharCount = 120 - rtbMessage.TextLength
        lblCharsRemaining.Text = "Characters remaining: " & CharCount
    End Sub

    'Context menu codes
    Private Sub mnuCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCut.Click
        rtbMessage.Cut()
    End Sub
    Private Sub mnuCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopy.Click
        rtbMessage.Copy()
    End Sub
    Private Sub mnuPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPaste.Click
        rtbMessage.Paste()
    End Sub
    Private Sub mnuClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClear.Click
        If rtbMessage.SelectedText = "" Then
            rtbMessage.Text = ""
        End If
        rtbMessage.SelectedText = ""
    End Sub
    Private Sub munSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles munSelectAll.Click
        rtbMessage.SelectAll()
    End Sub
#End Region

    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        Dim SplitArray() As String
        Dim MessageBuffer, ReceiverId As String
        Dim Dispdate As Date
        Dim I As Integer

        'Ordinary message tab
        If tabSendMessage.SelectedIndex = 0 Then
            'Check empty textboxes
            If txtDestId.Text = "" Then
                MsgBox("ReceiverID needed for sending message", MsgBoxStyle.Information)
                Exit Sub
            End If
            If txtDeliveryTime.Text = "" And cbTimedMessage.Checked = True Then
                MsgBox("Mention display date and time for Timed Message", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Check for empty message
            If rtbMessage.Text = "" Then
                Dim Res As MsgBoxResult
                Res = MsgBox("Are you sure to send empty message?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "iMessaging System")
                If Res = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            'Check date and time format
            If cbTimedMessage.Checked = True Then
                Try
                    Dispdate = CType(txtDeliveryTime.Text, Date)
                Catch ex As Exception
                    MsgBox("Invalid Date or Time format.", MsgBoxStyle.Information, "Invalid Date")
                    Exit Sub
                End Try

                'Convert LocalTime into UTC
                If TimeFormat = "LOCAL" Then
                    Dispdate = Date.FromFileTime(modUniversalServerTime).Add(Dispdate.Subtract(Now))
                Else
                    Dispdate = Date.FromFileTime(modUniversalServerTime).Add(Dispdate.Subtract(Now.ToUniversalTime))
                End If
            End If

            'Check and send for multiple Messages
            SplitArray = txtDestId.Text.Split(",")
            For I = 0 To SplitArray.Length - 1
                ReceiverId = SplitArray(I)
                'Check whether timed message or ordinary message and send 
                If cbTimedMessage.Checked = True Then
                    If cbGroupMessage.Checked = True Then
                        MessageBuffer = modServiceObject.SendGroupTimedMessage(modUserId, modPasswordChallenge, ReceiverId, rtbMessage.Text, Dispdate.ToFileTime)
                    Else
                        MessageBuffer = modServiceObject.SendTimedMessage(modUserId, modPasswordChallenge, ReceiverId, rtbMessage.Text, Dispdate.ToFileTime)
                    End If
                Else
                    If cbGroupMessage.Checked = True Then
                        MessageBuffer = modServiceObject.SendGroupMessage(modUserId, modPasswordChallenge, ReceiverId, rtbMessage.Text)
                    Else
                        MessageBuffer = modServiceObject.SendMessage(modUserId, modPasswordChallenge, ReceiverId, rtbMessage.Text)
                    End If
                End If

                'Check for Invalid Session 
                If MessageBuffer = "ERROR-03: INVALID SESSION" Then
                    MsgBox("Your session has become invalid. Clear session and continue", MsgBoxStyle.Information, "Session Invalid")
                    Exit Sub
                End If
                'Check for Invalid ReceiverId
                If MessageBuffer = "ERROR-04: INVALID RECEIVERID" Then
                    MsgBox(ReceiverId & " - Incorrect ReceiverId! Please check or Use user search facility", MsgBoxStyle.Information, "Invalid ReceiverId " & ReceiverId)
                    Exit Sub
                End If
                'Check for Invalid GroupId
                If MessageBuffer = "ERROR-08: INVALID GROUPID" Then
                    MsgBox(ReceiverId & " - Incorrect GroupId! Please check with your address book", MsgBoxStyle.Information, "Invalid GroupId " & ReceiverId)
                    Exit Sub
                End If
                'Check for Invalid Members in Group
                If MessageBuffer = "ERROR-09: INVALID USERID IN GROUP" Then
                    MsgBox(ReceiverId & " - This group contains invalid UserIds! Please use user search facility", MsgBoxStyle.Information, "Group " & ReceiverId & " has invalid members")
                    Exit Sub
                End If
                'Message sent successfully
                If MessageBuffer = "MESAG-02: MESSAGE SENT" Then
                    MsgBox("Your message has been sent to " & ReceiverId, MsgBoxStyle.OKOnly, "Message Sent to " & ReceiverId)
                End If
                If MessageBuffer = "MESAG-03: TIMED MESSAGE SENT" Then
                    MsgBox("Your timed message has been submitted to " & ReceiverId, MsgBoxStyle.OKOnly, "Timed Message Sent to " & ReceiverId)
                End If
                If MessageBuffer = "MESAG-11: GROUP MESSAGES SENT" Then
                    MsgBox("Your group message has been sent to group " & ReceiverId, MsgBoxStyle.OKOnly, "Group Message Sent to " & ReceiverId)
                End If
                If MessageBuffer = "MESAG-12: GROUP TIMED MESSAGES SENT" Then
                    MsgBox("Your timed group message has been submitted to group " & ReceiverId, MsgBoxStyle.OKOnly, "Timed Group Message Sent to " & ReceiverId)
                End If
            Next
        Else
            'Check for empty vote message
            If rtbMessage.Text = "" Then
                Dim Res As MsgBoxResult
                Res = MsgBox("Are you sure to send empty message?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "iMessaging System")
                If Res = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            MessageBuffer = modServiceObject.SendVoteMessage(modUserId, modPasswordChallenge, txtVoteDest.Text, rtbMessage.Text)
            'Check for Invalid Session 
            If MessageBuffer = "ERROR-03: INVALID SESSION" Then
                MsgBox("Your session has become invalid. Clear session and continue", MsgBoxStyle.Information, "Session Invalid")
                Exit Sub
            End If
            If MessageBuffer = "ERROR-08: INVALID GROUPID" Then
                MsgBox("Invalid GroupId! Please check with address book", MsgBoxStyle.Information, "Invalid GroupId")
                Exit Sub
            End If
            If MessageBuffer = "ERROR-09: INVALID USERID IN GROUP" Then
                MsgBox(txtVoteDest.Text & " - This group contains invalid UserIds! Please use user search facility", MsgBoxStyle.Information, "Group " & ReceiverId & " has invalid members")
                Exit Sub
            End If
            If MessageBuffer = "MESAG-23: VOTE MESSAGE SENT" Then
                MsgBox("Your Vote has been posted to group " & txtVoteDest.Text, MsgBoxStyle.Information, "Vote Message sent to " & txtVoteDest.Text)
            End If
        End If
    End Sub

    Private Sub txtDestId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDestId.TextChanged
        If e Is vbTab Then
            MsgBox("In")
            rtbMessage.Focus()
        End If
    End Sub

    Private Sub llAddressBook_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llAddressBook.LinkClicked
        If Not modIsAddressBookOpen Then
            modfrmAddressBook = New frmAddressBook()
            modfrmAddressBook.Show()
            modfrmAddressBook.Refresh()
        Else
            modfrmAddressBook.Activate()
            modfrmAddressBook.Refresh()
        End If
    End Sub

    Private Sub llShowAddressBook_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llShowAddressBook.LinkClicked
        If Not modIsAddressBookOpen Then
            modfrmAddressBook = New frmAddressBook()
            modfrmAddressBook.Show()
            modfrmAddressBook.Refresh()
        Else
            modfrmAddressBook.Activate()
            modfrmAddressBook.Refresh()
        End If
    End Sub

    Private Sub frmSendMessage_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        modIsSendMessageOpen = False
    End Sub
End Class
