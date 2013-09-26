Imports Microsoft.VisualBasic.Strings

Public Class frmSearch
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
    Friend WithEvents chUserId As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents lstSearchResult As System.Windows.Forms.ListView
    Friend WithEvents chFirstName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chLastName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chIPAddress As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents cmdSendMessage As System.Windows.Forms.Button
    Friend WithEvents cmdAddtoAddBook As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents txtSearchString As System.Windows.Forms.TextBox
    Friend WithEvents chStatus As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSearch))
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmdSendMessage = New System.Windows.Forms.Button()
        Me.cmdAddtoAddBook = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtSearchString = New System.Windows.Forms.TextBox()
        Me.lstSearchResult = New System.Windows.Forms.ListView()
        Me.chUserId = New System.Windows.Forms.ColumnHeader()
        Me.chFirstName = New System.Windows.Forms.ColumnHeader()
        Me.chLastName = New System.Windows.Forms.ColumnHeader()
        Me.chStatus = New System.Windows.Forms.ColumnHeader()
        Me.chIPAddress = New System.Windows.Forms.ColumnHeader()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(356, 15)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(91, 22)
        Me.cmdSearch.TabIndex = 1
        Me.cmdSearch.Text = "&Search"
        '
        'cmdSendMessage
        '
        Me.cmdSendMessage.Location = New System.Drawing.Point(4, 183)
        Me.cmdSendMessage.Name = "cmdSendMessage"
        Me.cmdSendMessage.Size = New System.Drawing.Size(96, 24)
        Me.cmdSendMessage.TabIndex = 3
        Me.cmdSendMessage.Text = "Send &Message"
        '
        'cmdAddtoAddBook
        '
        Me.cmdAddtoAddBook.Location = New System.Drawing.Point(159, 183)
        Me.cmdAddtoAddBook.Name = "cmdAddtoAddBook"
        Me.cmdAddtoAddBook.Size = New System.Drawing.Size(126, 24)
        Me.cmdAddtoAddBook.TabIndex = 4
        Me.cmdAddtoAddBook.Text = "&Add to Address Book"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(344, 183)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(104, 24)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "&Close"
        '
        'txtSearchString
        '
        Me.txtSearchString.Location = New System.Drawing.Point(153, 15)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Size = New System.Drawing.Size(192, 20)
        Me.txtSearchString.TabIndex = 0
        Me.txtSearchString.Text = "Enter the string to search"
        '
        'lstSearchResult
        '
        Me.lstSearchResult.AllowColumnReorder = True
        Me.lstSearchResult.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chUserId, Me.chFirstName, Me.chLastName, Me.chStatus, Me.chIPAddress})
        Me.lstSearchResult.GridLines = True
        Me.lstSearchResult.HideSelection = False
        Me.lstSearchResult.Location = New System.Drawing.Point(0, 48)
        Me.lstSearchResult.Name = "lstSearchResult"
        Me.lstSearchResult.Size = New System.Drawing.Size(456, 128)
        Me.lstSearchResult.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lstSearchResult.TabIndex = 2
        Me.lstSearchResult.View = System.Windows.Forms.View.Details
        '
        'chUserId
        '
        Me.chUserId.Text = "UserId"
        Me.chUserId.Width = 90
        '
        'chFirstName
        '
        Me.chFirstName.Text = "FirstName"
        Me.chFirstName.Width = 100
        '
        'chLastName
        '
        Me.chLastName.Text = "LastName"
        Me.chLastName.Width = 100
        '
        'chStatus
        '
        Me.chStatus.Text = "Status"
        Me.chStatus.Width = 70
        '
        'chIPAddress
        '
        Me.chIPAddress.Text = "IPAddress"
        Me.chIPAddress.Width = 90
        '
        'lblSearch
        '
        Me.lblSearch.Location = New System.Drawing.Point(0, 16)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(152, 16)
        Me.lblSearch.TabIndex = 6
        Me.lblSearch.Text = "Enter full or part of the &UserId "
        '
        'frmSearch
        '
        Me.AcceptButton = Me.cmdSearch
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(453, 211)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSearch, Me.lstSearchResult, Me.txtSearchString, Me.cmdAddtoAddBook, Me.cmdSendMessage, Me.cmdSearch, Me.cmdClose})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "At form Load Time"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modIsSearchOpen = True
        Me.Text = "Search - " & modUserId

        txtSearchString.SelectAll()
        txtSearchString.Focus()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim MessageBuffer As String
        Dim RowsArray() As String
        Dim ColArray() As String
        Dim DisplayArray() As String

        Dim I, J As Integer
        Dim objfrmOperationMessages As New frmOperationMessages()
        'Check for SearchStrings Validity
        If txtSearchString.Text = "" Or txtSearchString.Text = "Enter the string to search" Then
            MsgBox("Enter any search string before starting search", MsgBoxStyle.Information)
            Exit Sub
        End If

        'Call Search
        objfrmOperationMessages.lblMessage.Text = "Searching for " & txtSearchString.Text & " Please wait..."
        objfrmOperationMessages.Show()
        objfrmOperationMessages.Refresh()
        MessageBuffer = modServiceObject.Search(modUserId, modPasswordChallenge, txtSearchString.Text)
        objfrmOperationMessages.Dispose()
        'No Elements found
        If MessageBuffer = "MESAG-18: SEARCHID NOT FOUND" Then
            MsgBox("The Search string doesnot match any UserId", MsgBoxStyle.Information, "Search returns nothing")
            txtSearchString.Focus()
            Exit Sub
        End If

        'Split search result and display
        lstSearchResult.Items.Clear()
        RowsArray = MessageBuffer.Split(";")
        For I = 0 To RowsArray.Length - 2
            ColArray = RowsArray(I).Split(":")
            ReDim DisplayArray(ColArray.Length)
            For J = 0 To ColArray.Length - 1
                'Status String
                If J = 3 Then
                    If ColArray(J) = "LOGGED" Then
                        DisplayArray(J) = "Online"
                    Else
                        DisplayArray(J) = "Offline"
                    End If
                End If
                'IpAddress
                If J = 4 Then
                    If ColArray(J - 1) = "LOGGED" Then
                        If ColArray(J) = "HIDEIP" Then
                            DisplayArray(J) = "IP Hidden"
                        Else
                            DisplayArray(J) = ColArray(J)
                        End If
                    Else
                        DisplayArray(J) = " "
                    End If
                End If
                If J < 3 Then
                    DisplayArray(J) = ColArray(J)
                End If

            Next
            lstSearchResult.Items.Add(New ListViewItem(DisplayArray))
        Next
    End Sub

    Private Sub lstSearchResult_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSearchResult.DoubleClick
        Dim WasteArg1 As Object, WasteArg2 As System.EventArgs
        cmdSendMessage_Click(WasteArg1, WasteArg2)
    End Sub

    Private Sub cmdSendMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendMessage.Click
        Dim ObjfrmSendMessage As New frmSendMessage()
        Dim NoOfSelection, I As Integer
        Dim SelectedId As String = ""

        NoOfSelection = lstSearchResult.SelectedItems.Count()
        If NoOfSelection = 0 Then
            MsgBox("Please select any UserId!", MsgBoxStyle.Information, "Send Message")
            Exit Sub
        End If
        For I = 0 To NoOfSelection - 1
            SelectedId &= lstSearchResult.SelectedItems.Item(I).Text & ","
        Next
        SelectedId = SelectedId.Substring(0, SelectedId.Length - 1)

        If Not modIsSendMessageOpen Then
            modfrmSendMessage = New frmSendMessage()
            modfrmSendMessage.Show()
            modfrmSendMessage.Refresh()
        Else
            modfrmSendMessage.Activate()
            modfrmSendMessage.Refresh()
        End If

        modfrmSendMessage.txtDestId.Text = SelectedId
        modfrmSendMessage.rtbMessage.Focus()
    End Sub

    Private Sub cmdAddtoAddBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddtoAddBook.Click
        Dim ObjfrmAddressBook As New frmAddressBook()
        Dim NoOfSelection As Integer

        NoOfSelection = lstSearchResult.SelectedItems.Count()
        If NoOfSelection = 0 Then
            MsgBox("Please select any UserId!", MsgBoxStyle.Information, "Add to AddressBook")
            Exit Sub
        End If

        Dim MessageBuffer As String
        MessageBuffer = modAddressBook.AddUser(lstSearchResult.SelectedItems(0).Text)
        MsgBox(MessageBuffer, MsgBoxStyle.Information, "UserId Added")
    End Sub

    Private Sub frmSearch_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        modIsSearchOpen = False
    End Sub
End Class
