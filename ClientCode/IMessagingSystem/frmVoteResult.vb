Public Class frmVoteResult
    Inherits System.Windows.Forms.Form

    Dim MessagesArray As New ArrayList()

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
    Friend WithEvents chDestinationGroup As System.Windows.Forms.ColumnHeader
    Friend WithEvents chVoteDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAgree As System.Windows.Forms.ColumnHeader
    Friend WithEvents ChOppose As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstResult As System.Windows.Forms.ListView
    Friend WithEvents grpPendingVoteReq As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdPostVote As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmVoteResult))
        Me.lstResult = New System.Windows.Forms.ListView()
        Me.chDestinationGroup = New System.Windows.Forms.ColumnHeader()
        Me.chVoteDescription = New System.Windows.Forms.ColumnHeader()
        Me.chAgree = New System.Windows.Forms.ColumnHeader()
        Me.ChOppose = New System.Windows.Forms.ColumnHeader()
        Me.grpPendingVoteReq = New System.Windows.Forms.GroupBox()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdPostVote = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstResult
        '
        Me.lstResult.AllowColumnReorder = True
        Me.lstResult.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chDestinationGroup, Me.chVoteDescription, Me.chAgree, Me.ChOppose})
        Me.lstResult.FullRowSelect = True
        Me.lstResult.GridLines = True
        Me.lstResult.HideSelection = False
        Me.lstResult.Location = New System.Drawing.Point(15, 22)
        Me.lstResult.MultiSelect = False
        Me.lstResult.Name = "lstResult"
        Me.lstResult.Size = New System.Drawing.Size(390, 97)
        Me.lstResult.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lstResult.TabIndex = 0
        Me.lstResult.View = System.Windows.Forms.View.Details
        '
        'chDestinationGroup
        '
        Me.chDestinationGroup.Text = "Destination Group"
        Me.chDestinationGroup.Width = 100
        '
        'chVoteDescription
        '
        Me.chVoteDescription.Text = "Vote Description"
        Me.chVoteDescription.Width = 165
        '
        'chAgree
        '
        Me.chAgree.Text = "Agree"
        '
        'ChOppose
        '
        Me.ChOppose.Text = "Oppose"
        '
        'grpPendingVoteReq
        '
        Me.grpPendingVoteReq.Location = New System.Drawing.Point(6, 3)
        Me.grpPendingVoteReq.Name = "grpPendingVoteReq"
        Me.grpPendingVoteReq.Size = New System.Drawing.Size(411, 128)
        Me.grpPendingVoteReq.TabIndex = 1
        Me.grpPendingVoteReq.TabStop = False
        Me.grpPendingVoteReq.Text = "Pending vote requests"
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(7, 137)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(94, 22)
        Me.cmdDelete.TabIndex = 1
        Me.cmdDelete.Text = "&Delete Request"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(323, 137)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(94, 22)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "&Close"
        '
        'cmdPostVote
        '
        Me.cmdPostVote.Location = New System.Drawing.Point(165, 137)
        Me.cmdPostVote.Name = "cmdPostVote"
        Me.cmdPostVote.Size = New System.Drawing.Size(94, 22)
        Me.cmdPostVote.TabIndex = 2
        Me.cmdPostVote.Text = "&Post Vote"
        '
        'frmVoteResult
        '
        Me.AcceptButton = Me.cmdDelete
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(423, 167)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdPostVote, Me.cmdClose, Me.cmdDelete, Me.lstResult, Me.grpPendingVoteReq})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVoteResult"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "at Load Time"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmVoteResult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modIsVoteResultOpen = True
        Me.Text = "Vote Messages and Results - " & modUserId

        Me.Show()
        Me.Refresh()

        Dim ObjfrmOperationMessages As New frmOperationMessages()
        ObjfrmOperationMessages.lblMessage.Text = "Loading vote details..."
        ObjfrmOperationMessages.Show()
        ObjfrmOperationMessages.Refresh()

        PopulateVoteReqs()
        ObjfrmOperationMessages.Dispose()
    End Sub

    Private Sub cmdPostVote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostVote.Click
        If Not modIsSendMessageOpen Then
            modfrmSendMessage = New frmSendMessage()
            modfrmSendMessage.Show()
            modfrmSendMessage.Refresh()
        Else
            modfrmSendMessage.Activate()
            modfrmSendMessage.Refresh()
        End If
        modfrmSendMessage.tabSendMessage.SelectedIndex = 1
        modfrmSendMessage.txtVoteDest.Focus()

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub PopulateVoteReqs()
        Dim FieldsArray(), DisplayArray(4) As String
        Dim MessageBuffer As String
        Dim I, J As Integer

        MessageBuffer = modServiceObject.GetVoteDetails(modUserId, modPasswordChallenge)
        If MessageBuffer = "ERROR-03: INVALID SESSION" Then
            MsgBox("Your session has become invalid. Clear session and continue", MsgBoxStyle.Information, "Session Invalid")
            Exit Sub
        End If
        If MessageBuffer = "MESAG-25: NO PENDING VOTE MESSAGES" Then
            MsgBox("No Pending vote requests", MsgBoxStyle.Information, "Voting System - iMessaging")
            Exit Sub
        End If

        'Display the details
        lstResult.Items.Clear()
        MessagesArray.AddRange(CType(MessageBuffer.Split("»")(1).Split("î"), ICollection))
        For I = 0 To MessagesArray.Count - 2
            FieldsArray = MessagesArray(I).Split("ï")
            DisplayArray(0) = FieldsArray(0).Split(":")(1) 'Copy Destination Group
            DisplayArray(1) = FieldsArray(1)               'Copy Description
            DisplayArray(2) = FieldsArray(2)               'Copy Agree count 
            DisplayArray(3) = FieldsArray(3)               'Copy Oppose count 

            lstResult.Items.Add(New ListViewItem(DisplayArray))
        Next
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim MessageBuffer As String
        Dim DelMessageId As String

        'If no vote request is selected
        If lstResult.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        DelMessageId = MessagesArray(lstResult.SelectedItems(0).Index).Split("ï")(0)
        MessageBuffer = modServiceObject.DeleteVote(modUserId, modPasswordChallenge, DelMessageId)

        If MessageBuffer = "ERROR-03: INVALID SESSION" Then
            MsgBox("Your session has become invalid. Clear session and continue", MsgBoxStyle.Information, "Session Invalid")
            Exit Sub
        End If
        If MessageBuffer = "ERROR-11: USER NOT AUTHERIZED" Then
            MsgBox("You are not autherized to delete this message!", MsgBoxStyle.Critical, "Not Autherized")
            Exit Sub
        End If
        If MessageBuffer = "ERROR-13: INVALID MESSAGEID" Then
            MsgBox("The Message reference is invalid! Operation incomplete", MsgBoxStyle.Critical, "Invalid Message Reference")
            Exit Sub
        End If
        If MessageBuffer = "MESAG-26: VOTE MESSAGE DELETED" Then
            MsgBox("Vote request deleted! All further reference to this request will be aborted", MsgBoxStyle.Information, "Request deleted")
        End If

        'Remove the selected request from list and MessagesArray
        MessagesArray.RemoveAt(lstResult.SelectedItems(0).Index)
        lstResult.Items.RemoveAt(lstResult.SelectedItems(0).Index)
        lstResult.Refresh()
    End Sub

    Private Sub frmVoteResult_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        modIsVoteResultOpen = False
    End Sub
End Class
