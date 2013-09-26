Public Class frmAddressBook
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
    Friend WithEvents tabAddressBook As System.Windows.Forms.TabControl
    Friend WithEvents tpGroups As System.Windows.Forms.TabPage
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents treeGroups As System.Windows.Forms.TreeView
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents chkBlockStatus As System.Windows.Forms.CheckBox
    Friend WithEvents lstUsers As System.Windows.Forms.ListBox
    Friend WithEvents tpUsers As System.Windows.Forms.TabPage
    Friend WithEvents tabUsers As System.Windows.Forms.TabControl
    Friend WithEvents tpAddUsers As System.Windows.Forms.TabPage
    Friend WithEvents tpDeleteUsers As System.Windows.Forms.TabPage
    Friend WithEvents lblAddUserId As System.Windows.Forms.Label
    Friend WithEvents txtAddUserId As System.Windows.Forms.TextBox
    Friend WithEvents cmdAddUser As System.Windows.Forms.Button
    Friend WithEvents cmdUserDelete As System.Windows.Forms.Button
    Friend WithEvents txtDeleteUserId As System.Windows.Forms.TextBox
    Friend WithEvents lblDeleteUserId As System.Windows.Forms.Label
    Friend WithEvents tabGroups As System.Windows.Forms.TabControl
    Friend WithEvents tpAddGroups As System.Windows.Forms.TabPage
    Friend WithEvents tpDeleteGroups As System.Windows.Forms.TabPage
    Friend WithEvents tpEditGroups As System.Windows.Forms.TabPage
    Friend WithEvents lblAddGroupId As System.Windows.Forms.Label
    Friend WithEvents txtAddGroupId As System.Windows.Forms.TextBox
    Friend WithEvents lblAddUserIds As System.Windows.Forms.Label
    Friend WithEvents txtAddUserIds As System.Windows.Forms.TextBox
    Friend WithEvents txtDeleteGroupId As System.Windows.Forms.TextBox
    Friend WithEvents lblDeleteGroupId As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteGroup As System.Windows.Forms.Button
    Friend WithEvents txtEditUserIds As System.Windows.Forms.TextBox
    Friend WithEvents lblEditUserIds As System.Windows.Forms.Label
    Friend WithEvents txtEditGroupId As System.Windows.Forms.TextBox
    Friend WithEvents lblEditGroupId As System.Windows.Forms.Label
    Friend WithEvents cmdEditGroup As System.Windows.Forms.Button
    Friend WithEvents cmdAddGroup As System.Windows.Forms.Button
    Friend WithEvents cmdUserSendMessage As System.Windows.Forms.Button
    Friend WithEvents cmdGroupSendMessage As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAddressBook))
        Me.tabAddressBook = New System.Windows.Forms.TabControl()
        Me.tpUsers = New System.Windows.Forms.TabPage()
        Me.cmdUserSendMessage = New System.Windows.Forms.Button()
        Me.tabUsers = New System.Windows.Forms.TabControl()
        Me.tpAddUsers = New System.Windows.Forms.TabPage()
        Me.cmdAddUser = New System.Windows.Forms.Button()
        Me.txtAddUserId = New System.Windows.Forms.TextBox()
        Me.lblAddUserId = New System.Windows.Forms.Label()
        Me.tpDeleteUsers = New System.Windows.Forms.TabPage()
        Me.cmdUserDelete = New System.Windows.Forms.Button()
        Me.txtDeleteUserId = New System.Windows.Forms.TextBox()
        Me.lblDeleteUserId = New System.Windows.Forms.Label()
        Me.chkBlockStatus = New System.Windows.Forms.CheckBox()
        Me.lstUsers = New System.Windows.Forms.ListBox()
        Me.tpGroups = New System.Windows.Forms.TabPage()
        Me.cmdGroupSendMessage = New System.Windows.Forms.Button()
        Me.tabGroups = New System.Windows.Forms.TabControl()
        Me.tpAddGroups = New System.Windows.Forms.TabPage()
        Me.txtAddUserIds = New System.Windows.Forms.TextBox()
        Me.lblAddUserIds = New System.Windows.Forms.Label()
        Me.txtAddGroupId = New System.Windows.Forms.TextBox()
        Me.lblAddGroupId = New System.Windows.Forms.Label()
        Me.cmdAddGroup = New System.Windows.Forms.Button()
        Me.tpDeleteGroups = New System.Windows.Forms.TabPage()
        Me.txtDeleteGroupId = New System.Windows.Forms.TextBox()
        Me.lblDeleteGroupId = New System.Windows.Forms.Label()
        Me.cmdDeleteGroup = New System.Windows.Forms.Button()
        Me.tpEditGroups = New System.Windows.Forms.TabPage()
        Me.txtEditUserIds = New System.Windows.Forms.TextBox()
        Me.lblEditUserIds = New System.Windows.Forms.Label()
        Me.txtEditGroupId = New System.Windows.Forms.TextBox()
        Me.lblEditGroupId = New System.Windows.Forms.Label()
        Me.cmdEditGroup = New System.Windows.Forms.Button()
        Me.treeGroups = New System.Windows.Forms.TreeView()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.tabAddressBook.SuspendLayout()
        Me.tpUsers.SuspendLayout()
        Me.tabUsers.SuspendLayout()
        Me.tpAddUsers.SuspendLayout()
        Me.tpDeleteUsers.SuspendLayout()
        Me.tpGroups.SuspendLayout()
        Me.tabGroups.SuspendLayout()
        Me.tpAddGroups.SuspendLayout()
        Me.tpDeleteGroups.SuspendLayout()
        Me.tpEditGroups.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabAddressBook
        '
        Me.tabAddressBook.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpUsers, Me.tpGroups})
        Me.tabAddressBook.Dock = System.Windows.Forms.DockStyle.Top
        Me.tabAddressBook.Name = "tabAddressBook"
        Me.tabAddressBook.SelectedIndex = 0
        Me.tabAddressBook.Size = New System.Drawing.Size(438, 191)
        Me.tabAddressBook.TabIndex = 0
        '
        'tpUsers
        '
        Me.tpUsers.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdUserSendMessage, Me.tabUsers, Me.chkBlockStatus, Me.lstUsers})
        Me.tpUsers.Location = New System.Drawing.Point(4, 22)
        Me.tpUsers.Name = "tpUsers"
        Me.tpUsers.Size = New System.Drawing.Size(430, 165)
        Me.tpUsers.TabIndex = 0
        Me.tpUsers.Text = "Users"
        '
        'cmdUserSendMessage
        '
        Me.cmdUserSendMessage.Location = New System.Drawing.Point(338, 138)
        Me.cmdUserSendMessage.Name = "cmdUserSendMessage"
        Me.cmdUserSendMessage.Size = New System.Drawing.Size(90, 21)
        Me.cmdUserSendMessage.TabIndex = 6
        Me.cmdUserSendMessage.Text = "Send &Message"
        '
        'tabUsers
        '
        Me.tabUsers.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpAddUsers, Me.tpDeleteUsers})
        Me.tabUsers.Location = New System.Drawing.Point(160, 2)
        Me.tabUsers.Name = "tabUsers"
        Me.tabUsers.SelectedIndex = 0
        Me.tabUsers.Size = New System.Drawing.Size(284, 129)
        Me.tabUsers.TabIndex = 5
        '
        'tpAddUsers
        '
        Me.tpAddUsers.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdAddUser, Me.txtAddUserId, Me.lblAddUserId})
        Me.tpAddUsers.Location = New System.Drawing.Point(4, 22)
        Me.tpAddUsers.Name = "tpAddUsers"
        Me.tpAddUsers.Size = New System.Drawing.Size(276, 103)
        Me.tpAddUsers.TabIndex = 0
        Me.tpAddUsers.Text = "Add"
        '
        'cmdAddUser
        '
        Me.cmdAddUser.Location = New System.Drawing.Point(152, 80)
        Me.cmdAddUser.Name = "cmdAddUser"
        Me.cmdAddUser.Size = New System.Drawing.Size(112, 21)
        Me.cmdAddUser.TabIndex = 2
        Me.cmdAddUser.Text = "&Add"
        '
        'txtAddUserId
        '
        Me.txtAddUserId.Location = New System.Drawing.Point(112, 8)
        Me.txtAddUserId.Name = "txtAddUserId"
        Me.txtAddUserId.Size = New System.Drawing.Size(152, 20)
        Me.txtAddUserId.TabIndex = 1
        Me.txtAddUserId.Text = ""
        '
        'lblAddUserId
        '
        Me.lblAddUserId.Location = New System.Drawing.Point(10, 13)
        Me.lblAddUserId.Name = "lblAddUserId"
        Me.lblAddUserId.Size = New System.Drawing.Size(64, 19)
        Me.lblAddUserId.TabIndex = 0
        Me.lblAddUserId.Text = "&UserId"
        '
        'tpDeleteUsers
        '
        Me.tpDeleteUsers.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdUserDelete, Me.txtDeleteUserId, Me.lblDeleteUserId})
        Me.tpDeleteUsers.Location = New System.Drawing.Point(4, 22)
        Me.tpDeleteUsers.Name = "tpDeleteUsers"
        Me.tpDeleteUsers.Size = New System.Drawing.Size(276, 103)
        Me.tpDeleteUsers.TabIndex = 1
        Me.tpDeleteUsers.Text = "Delete"
        '
        'cmdUserDelete
        '
        Me.cmdUserDelete.Location = New System.Drawing.Point(152, 80)
        Me.cmdUserDelete.Name = "cmdUserDelete"
        Me.cmdUserDelete.Size = New System.Drawing.Size(112, 21)
        Me.cmdUserDelete.TabIndex = 5
        Me.cmdUserDelete.Text = "&Delete"
        '
        'txtDeleteUserId
        '
        Me.txtDeleteUserId.Location = New System.Drawing.Point(112, 8)
        Me.txtDeleteUserId.Name = "txtDeleteUserId"
        Me.txtDeleteUserId.Size = New System.Drawing.Size(152, 20)
        Me.txtDeleteUserId.TabIndex = 4
        Me.txtDeleteUserId.Text = ""
        '
        'lblDeleteUserId
        '
        Me.lblDeleteUserId.Location = New System.Drawing.Point(10, 13)
        Me.lblDeleteUserId.Name = "lblDeleteUserId"
        Me.lblDeleteUserId.Size = New System.Drawing.Size(64, 24)
        Me.lblDeleteUserId.TabIndex = 3
        Me.lblDeleteUserId.Text = "&UserId"
        '
        'chkBlockStatus
        '
        Me.chkBlockStatus.Location = New System.Drawing.Point(162, 141)
        Me.chkBlockStatus.Name = "chkBlockStatus"
        Me.chkBlockStatus.Size = New System.Drawing.Size(175, 16)
        Me.chkBlockStatus.TabIndex = 4
        Me.chkBlockStatus.Text = "&Block message from this user"
        '
        'lstUsers
        '
        Me.lstUsers.Name = "lstUsers"
        Me.lstUsers.Size = New System.Drawing.Size(160, 173)
        Me.lstUsers.TabIndex = 0
        '
        'tpGroups
        '
        Me.tpGroups.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdGroupSendMessage, Me.tabGroups, Me.treeGroups})
        Me.tpGroups.Location = New System.Drawing.Point(4, 22)
        Me.tpGroups.Name = "tpGroups"
        Me.tpGroups.Size = New System.Drawing.Size(430, 165)
        Me.tpGroups.TabIndex = 1
        Me.tpGroups.Text = "Groups"
        '
        'cmdGroupSendMessage
        '
        Me.cmdGroupSendMessage.Location = New System.Drawing.Point(336, 138)
        Me.cmdGroupSendMessage.Name = "cmdGroupSendMessage"
        Me.cmdGroupSendMessage.Size = New System.Drawing.Size(91, 21)
        Me.cmdGroupSendMessage.TabIndex = 7
        Me.cmdGroupSendMessage.Text = "Send &Message"
        '
        'tabGroups
        '
        Me.tabGroups.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpAddGroups, Me.tpDeleteGroups, Me.tpEditGroups})
        Me.tabGroups.Location = New System.Drawing.Point(160, 2)
        Me.tabGroups.Name = "tabGroups"
        Me.tabGroups.SelectedIndex = 0
        Me.tabGroups.Size = New System.Drawing.Size(284, 129)
        Me.tabGroups.TabIndex = 1
        '
        'tpAddGroups
        '
        Me.tpAddGroups.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtAddUserIds, Me.lblAddUserIds, Me.txtAddGroupId, Me.lblAddGroupId, Me.cmdAddGroup})
        Me.tpAddGroups.Location = New System.Drawing.Point(4, 22)
        Me.tpAddGroups.Name = "tpAddGroups"
        Me.tpAddGroups.Size = New System.Drawing.Size(276, 103)
        Me.tpAddGroups.TabIndex = 0
        Me.tpAddGroups.Text = "Add"
        '
        'txtAddUserIds
        '
        Me.txtAddUserIds.Location = New System.Drawing.Point(112, 35)
        Me.txtAddUserIds.Multiline = True
        Me.txtAddUserIds.Name = "txtAddUserIds"
        Me.txtAddUserIds.Size = New System.Drawing.Size(152, 40)
        Me.txtAddUserIds.TabIndex = 3
        Me.txtAddUserIds.Text = "Enter UserIds seperated by comma"
        '
        'lblAddUserIds
        '
        Me.lblAddUserIds.Location = New System.Drawing.Point(10, 37)
        Me.lblAddUserIds.Name = "lblAddUserIds"
        Me.lblAddUserIds.Size = New System.Drawing.Size(80, 19)
        Me.lblAddUserIds.TabIndex = 2
        Me.lblAddUserIds.Text = "&Users in Group"
        '
        'txtAddGroupId
        '
        Me.txtAddGroupId.Location = New System.Drawing.Point(112, 8)
        Me.txtAddGroupId.Name = "txtAddGroupId"
        Me.txtAddGroupId.Size = New System.Drawing.Size(152, 20)
        Me.txtAddGroupId.TabIndex = 1
        Me.txtAddGroupId.Text = ""
        '
        'lblAddGroupId
        '
        Me.lblAddGroupId.Location = New System.Drawing.Point(10, 13)
        Me.lblAddGroupId.Name = "lblAddGroupId"
        Me.lblAddGroupId.Size = New System.Drawing.Size(52, 16)
        Me.lblAddGroupId.TabIndex = 0
        Me.lblAddGroupId.Text = "&GroupId"
        '
        'cmdAddGroup
        '
        Me.cmdAddGroup.Location = New System.Drawing.Point(152, 80)
        Me.cmdAddGroup.Name = "cmdAddGroup"
        Me.cmdAddGroup.Size = New System.Drawing.Size(112, 21)
        Me.cmdAddGroup.TabIndex = 7
        Me.cmdAddGroup.Text = "&Add"
        '
        'tpDeleteGroups
        '
        Me.tpDeleteGroups.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDeleteGroupId, Me.lblDeleteGroupId, Me.cmdDeleteGroup})
        Me.tpDeleteGroups.Location = New System.Drawing.Point(4, 22)
        Me.tpDeleteGroups.Name = "tpDeleteGroups"
        Me.tpDeleteGroups.Size = New System.Drawing.Size(276, 103)
        Me.tpDeleteGroups.TabIndex = 1
        Me.tpDeleteGroups.Text = "Delete"
        '
        'txtDeleteGroupId
        '
        Me.txtDeleteGroupId.Location = New System.Drawing.Point(112, 8)
        Me.txtDeleteGroupId.Name = "txtDeleteGroupId"
        Me.txtDeleteGroupId.Size = New System.Drawing.Size(152, 20)
        Me.txtDeleteGroupId.TabIndex = 9
        Me.txtDeleteGroupId.Text = ""
        '
        'lblDeleteGroupId
        '
        Me.lblDeleteGroupId.Location = New System.Drawing.Point(10, 13)
        Me.lblDeleteGroupId.Name = "lblDeleteGroupId"
        Me.lblDeleteGroupId.Size = New System.Drawing.Size(54, 16)
        Me.lblDeleteGroupId.TabIndex = 8
        Me.lblDeleteGroupId.Text = "&GroupId"
        '
        'cmdDeleteGroup
        '
        Me.cmdDeleteGroup.Location = New System.Drawing.Point(152, 80)
        Me.cmdDeleteGroup.Name = "cmdDeleteGroup"
        Me.cmdDeleteGroup.Size = New System.Drawing.Size(112, 21)
        Me.cmdDeleteGroup.TabIndex = 10
        Me.cmdDeleteGroup.Text = "Delete"
        '
        'tpEditGroups
        '
        Me.tpEditGroups.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtEditUserIds, Me.lblEditUserIds, Me.txtEditGroupId, Me.lblEditGroupId, Me.cmdEditGroup})
        Me.tpEditGroups.Location = New System.Drawing.Point(4, 22)
        Me.tpEditGroups.Name = "tpEditGroups"
        Me.tpEditGroups.Size = New System.Drawing.Size(276, 103)
        Me.tpEditGroups.TabIndex = 2
        Me.tpEditGroups.Text = "Edit"
        '
        'txtEditUserIds
        '
        Me.txtEditUserIds.Location = New System.Drawing.Point(112, 35)
        Me.txtEditUserIds.Multiline = True
        Me.txtEditUserIds.Name = "txtEditUserIds"
        Me.txtEditUserIds.Size = New System.Drawing.Size(152, 40)
        Me.txtEditUserIds.TabIndex = 11
        Me.txtEditUserIds.Text = ""
        '
        'lblEditUserIds
        '
        Me.lblEditUserIds.Location = New System.Drawing.Point(10, 37)
        Me.lblEditUserIds.Name = "lblEditUserIds"
        Me.lblEditUserIds.Size = New System.Drawing.Size(80, 14)
        Me.lblEditUserIds.TabIndex = 10
        Me.lblEditUserIds.Text = "&Users in Group"
        '
        'txtEditGroupId
        '
        Me.txtEditGroupId.Location = New System.Drawing.Point(112, 8)
        Me.txtEditGroupId.Name = "txtEditGroupId"
        Me.txtEditGroupId.Size = New System.Drawing.Size(152, 20)
        Me.txtEditGroupId.TabIndex = 9
        Me.txtEditGroupId.Text = ""
        '
        'lblEditGroupId
        '
        Me.lblEditGroupId.Location = New System.Drawing.Point(10, 13)
        Me.lblEditGroupId.Name = "lblEditGroupId"
        Me.lblEditGroupId.Size = New System.Drawing.Size(52, 16)
        Me.lblEditGroupId.TabIndex = 8
        Me.lblEditGroupId.Text = "&GroupId"
        '
        'cmdEditGroup
        '
        Me.cmdEditGroup.Location = New System.Drawing.Point(152, 80)
        Me.cmdEditGroup.Name = "cmdEditGroup"
        Me.cmdEditGroup.Size = New System.Drawing.Size(112, 21)
        Me.cmdEditGroup.TabIndex = 12
        Me.cmdEditGroup.Text = "&Edit"
        '
        'treeGroups
        '
        Me.treeGroups.ImageIndex = -1
        Me.treeGroups.LabelEdit = True
        Me.treeGroups.Name = "treeGroups"
        Me.treeGroups.SelectedImageIndex = -1
        Me.treeGroups.Size = New System.Drawing.Size(160, 168)
        Me.treeGroups.TabIndex = 0
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(345, 193)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(88, 21)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "&Close"
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(3, 193)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(96, 21)
        Me.cmdUpdate.TabIndex = 2
        Me.cmdUpdate.Text = "U&pdate"
        '
        'frmAddressBook
        '
        Me.AcceptButton = Me.cmdUpdate
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(438, 217)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdUpdate, Me.cmdClose, Me.tabAddressBook})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddressBook"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "at Load Time"
        Me.tabAddressBook.ResumeLayout(False)
        Me.tpUsers.ResumeLayout(False)
        Me.tabUsers.ResumeLayout(False)
        Me.tpAddUsers.ResumeLayout(False)
        Me.tpDeleteUsers.ResumeLayout(False)
        Me.tpGroups.ResumeLayout(False)
        Me.tabGroups.ResumeLayout(False)
        Me.tpAddGroups.ResumeLayout(False)
        Me.tpDeleteGroups.ResumeLayout(False)
        Me.tpEditGroups.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "UserTab"

    Private Sub lstUsers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstUsers.DoubleClick
        txtDeleteUserId.Text = lstUsers.SelectedItem
        tabUsers.SelectedIndex = 1
        txtDeleteUserId.Focus()
    End Sub

    Private Sub cmdAddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddUser.Click
        Dim MessageBuffer As String

        'If UserId is Null
        If txtAddUserId.Text = "" Then
            MsgBox("Please enter a user name!", MsgBoxStyle.Information, "UserId Needed")
            txtAddUserId.Focus()
            Me.Refresh()
            Exit Sub
        End If

        MessageBuffer = modAddressBook.AddUser(txtAddUserId.Text)
        If MessageBuffer = "UserId already exist" Then
            MsgBox(MessageBuffer, MsgBoxStyle.Information, "Address Book")
            Exit Sub
        End If
        lstUsers.Items.Add(txtAddUserId.Text)
    End Sub

    Private Sub cmdUserDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserDelete.Click
        Dim MessageBuffer As String

        'If UserId is Null
        If txtDeleteUserId.Text = "" Then
            MsgBox("Please enter a user name!", MsgBoxStyle.Information, "UserId Needed")
            txtAddUserId.Focus()
            Me.Refresh()
            Exit Sub
        End If

        MessageBuffer = modAddressBook.DeleteUser(txtDeleteUserId.Text)
        If MessageBuffer = "UserId doesnot exist" Then
            MsgBox(MessageBuffer, MsgBoxStyle.Information, "Address Book")
            Exit Sub
        End If
        lstUsers.Items.Remove(txtDeleteUserId.Text)
    End Sub

    Private Sub lstUsers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUsers.SelectedIndexChanged
        Dim TheString As String

        'If no user in the list
        If lstUsers.Items.Count = 0 Then
            chkBlockStatus.Enabled = False
        End If

        If lstUsers.SelectedIndex = -1 Then
            Exit Sub
        Else

            TheString = modAddressBook.UserAddressTable.Item(lstUsers.SelectedItem)
            If TheString.Split(":")(1) = "N" Then
                chkBlockStatus.Checked = False
            Else
                chkBlockStatus.Checked = True
            End If
        End If
    End Sub

    Private Sub chkBlockStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBlockStatus.CheckedChanged
        If lstUsers.SelectedIndex <> -1 Then
            If chkBlockStatus.Checked = True Then
                modAddressBook.UserAddressTable.Item(lstUsers.SelectedItem) = lstUsers.SelectedItem & ":B"
            Else
                modAddressBook.UserAddressTable.Item(lstUsers.SelectedItem) = lstUsers.SelectedItem & ":N"
            End If
        End If
    End Sub

#End Region

#Region "GroupTab"

    Private Sub cmdAddGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddGroup.Click
        Dim MessageBuffer As String
        Dim UserIdsArray() As String
        Dim I As Integer
        Dim GroupLevelNode As New TreeNode()

        'If GroupId is Null
        If txtAddGroupId.Text = "" Then
            MsgBox("Please enter a group name!", MsgBoxStyle.Information, "GroupId Needed")
            Exit Sub
        End If

        MessageBuffer = modAddressBook.AddGroup(txtAddGroupId.Text, txtAddUserIds.Text)
        If MessageBuffer = "GroupId already exist" Then
            MsgBox(MessageBuffer, MsgBoxStyle.Information, "GroupId exists")
            Exit Sub
        Else
            UserIdsArray = txtAddUserIds.Text.Split(",")
            For I = 0 To UserIdsArray.Length - 1
                GroupLevelNode.Nodes.Add(UserIdsArray(I))
            Next
            GroupLevelNode.Text = txtAddGroupId.Text
            treeGroups.Nodes.Add(GroupLevelNode)
        End If
        SortTree()
    End Sub

    Private Sub cmdDeleteGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteGroup.Click
        Dim MessageBuffer As String
        Dim GroupsArray, UserIdsArray As Array
        Dim I, J As Integer

        'If GroupId is Null
        If txtDeleteGroupId.Text = "" Then
            MsgBox("Please enter a group name!", MsgBoxStyle.Information, "GroupId Needed")
            Exit Sub
        End If

        MessageBuffer = modAddressBook.DeleteGroup(txtDeleteGroupId.Text)
        If MessageBuffer = "GroupId doesnot exist" Then
            MsgBox(MessageBuffer, MsgBoxStyle.Information, "Invalid GroupId")
            Exit Sub
        Else
            DisplayTree()
        End If
    End Sub

    Private Sub cmdEditGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditGroup.Click
        Dim MessageBuffer As String
        Dim GroupsArray, UserIdsArray As Array
        Dim I, J As Integer

        MessageBuffer = modAddressBook.EditGroup(txtEditGroupId.Text, txtEditUserIds.Text)
        If MessageBuffer = "GroupId doesnot exist" Then
            MsgBox(MessageBuffer, MsgBoxStyle.Information, "Invalid GroupId")
            Exit Sub
        Else
            DisplayTree()
        End If
    End Sub

    Private Sub txtEditGroupId_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEditGroupId.Leave
        Dim TheString As String
        Dim TempArray() As String
        Dim I As Integer

        If Not modAddressBook.GroupAddressTable.Contains(txtEditGroupId.Text) Then
            MsgBox("GroupId doesnot exist")
            Exit Sub
        End If

        TheString = modAddressBook.GroupAddressTable.Item(txtEditGroupId.Text)
        TempArray = TheString.Split(":")

        txtEditUserIds.Text = ""
        For I = 1 To TempArray.Length - 1 'First element is group name
            txtEditUserIds.Text &= TempArray(I) & ","
        Next
        txtEditUserIds.Focus()
    End Sub


    Private Sub SortTree()
        treeGroups.Sorted = True
        treeGroups.Refresh()
        treeGroups.Sorted = False
    End Sub

    Private Sub DisplayTree()
        Dim UserIdsArray() As String
        Dim GroupsArray As Array
        Dim I, J As Integer

        'Clear and Populate GroupList
        treeGroups.Nodes.Clear()
        If modAddressBook.GroupAddressTable.Count <> 0 Then
            GroupsArray = Array.CreateInstance(GetType(String), modAddressBook.GroupAddressTable.Count)
            modAddressBook.GroupAddressTable.Values.CopyTo(GroupsArray, 0)
            For I = 0 To GroupsArray.Length - 1
                'Add Group Name
                treeGroups.Nodes.Add(CType(GroupsArray(I), String).Split(":")(0))

                'Add chlid Nodes
                UserIdsArray = CType(GroupsArray(I), String).Split(":")
                For J = 1 To UserIdsArray.Length - 1 'First element is GroupId itself
                    treeGroups.Nodes(I).Nodes.Add(UserIdsArray(J))
                Next
            Next
        End If
        SortTree()
    End Sub

#End Region


    Private Sub frmAddressBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim I, J As Integer
        Dim TempArray As Array


        modIsAddressBookOpen = True
        Me.Text = "AddressBook - " & modUserId

        'Clear and Populate UserList
        lstUsers.Items.Clear()
        If modAddressBook.UserAddressTable.Count <> 0 Then
            TempArray = Array.CreateInstance(GetType(String), modAddressBook.UserAddressTable.Count)
            modAddressBook.UserAddressTable.Keys.CopyTo(TempArray, 0)
            For I = 0 To TempArray.Length - 1
                lstUsers.Items.Add(TempArray(I))
            Next
        End If

        'Clear and populate GroupList
        If modAddressBook.GroupAddressTable.Count <> 0 Then
            DisplayTree()
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdUserSendMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserSendMessage.Click
        If lstUsers.SelectedIndex <> -1 Then
            If Not modIsSendMessageOpen Then
                modfrmSendMessage = New frmSendMessage()
                modfrmSendMessage.Show()
                modfrmSendMessage.Refresh()
            Else
                modfrmSendMessage.Activate()
                modfrmSendMessage.Refresh()
            End If

            modfrmSendMessage.txtDestId.Text = lstUsers.SelectedItem
            modfrmSendMessage.rtbMessage.Focus()
        End If
    End Sub

    Private Sub cmdGroupSendMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGroupSendMessage.Click
        Dim TheNode As TreeNode
        TheNode = treeGroups.SelectedNode

        If Not TheNode Is Nothing Then
            If TheNode.GetNodeCount(True) = 0 Then
                TheNode = TheNode.Parent
            End If
            If Not modIsSendMessageOpen Then
                modfrmSendMessage = New frmSendMessage()
                modfrmSendMessage.Show()
                modfrmSendMessage.Refresh()
            Else
                modfrmSendMessage.Activate()
                modfrmSendMessage.Refresh()
            End If

            modfrmSendMessage.cbGroupMessage.Checked = True
            modfrmSendMessage.txtDestId.Text = TheNode.Text
            modfrmSendMessage.rtbMessage.Focus()
        End If
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim TheString, MessageBuffer As String
        TheString = modAddressBook.LoadAddressString()
        MessageBuffer = modServiceObject.StoreAddressBook(modUserId, modPasswordChallenge, TheString)

        If MessageBuffer = "MESAG-22: ADDRESSBOOK STORED" Then
            MsgBox("Addressbook Updated", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub frmAddressBook_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        modIsAddressBookOpen = False
    End Sub

    Private Sub treeGroups_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles treeGroups.Click
        If Not treeGroups.SelectedNode Is Nothing Then
            txtDeleteGroupId.Text = treeGroups.SelectedNode.Text
            tabGroups.SelectedIndex = 1
        End If
    End Sub
End Class
