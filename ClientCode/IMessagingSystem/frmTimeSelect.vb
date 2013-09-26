Public Class frmTimeSelect
    Inherits System.Windows.Forms.Form

    Dim CallerForm As frmSendMessage
    Dim SelectedDateTime As Date
    Dim TimeFormat As String = "LOCAL"

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
    Friend WithEvents DTPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents grpTimeReference As System.Windows.Forms.GroupBox
    Friend WithEvents rbGMT As System.Windows.Forms.RadioButton
    Friend WithEvents rbLocalTime As System.Windows.Forms.RadioButton
    Friend WithEvents grpDeliveryDate As System.Windows.Forms.GroupBox
    Friend WithEvents grpDeliveryTime As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTimeSpan As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSelect As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmbSpanValue As System.Windows.Forms.ComboBox
    Friend WithEvents lblDeliveryTime As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTimeSelect))
        Me.DTPicker = New System.Windows.Forms.DateTimePicker()
        Me.grpDeliveryDate = New System.Windows.Forms.GroupBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.grpTimeReference = New System.Windows.Forms.GroupBox()
        Me.rbLocalTime = New System.Windows.Forms.RadioButton()
        Me.rbGMT = New System.Windows.Forms.RadioButton()
        Me.grpDeliveryTime = New System.Windows.Forms.GroupBox()
        Me.cmbTimeSpan = New System.Windows.Forms.ComboBox()
        Me.cmbSpanValue = New System.Windows.Forms.ComboBox()
        Me.lblDeliveryTime = New System.Windows.Forms.Label()
        Me.cmdSelect = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.grpDeliveryDate.SuspendLayout()
        Me.grpTimeReference.SuspendLayout()
        Me.grpDeliveryTime.SuspendLayout()
        Me.SuspendLayout()
        '
        'DTPicker
        '
        Me.DTPicker.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPicker.CustomFormat = ""
        Me.DTPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DTPicker.Location = New System.Drawing.Point(48, 16)
        Me.DTPicker.MinDate = New Date(2004, 2, 19, 0, 0, 0, 0)
        Me.DTPicker.Name = "DTPicker"
        Me.DTPicker.Size = New System.Drawing.Size(101, 20)
        Me.DTPicker.TabIndex = 2
        '
        'grpDeliveryDate
        '
        Me.grpDeliveryDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDate, Me.DTPicker})
        Me.grpDeliveryDate.Location = New System.Drawing.Point(3, 66)
        Me.grpDeliveryDate.Name = "grpDeliveryDate"
        Me.grpDeliveryDate.Size = New System.Drawing.Size(154, 45)
        Me.grpDeliveryDate.TabIndex = 1
        Me.grpDeliveryDate.TabStop = False
        Me.grpDeliveryDate.Text = "Select Delivery Date"
        '
        'lblDate
        '
        Me.lblDate.Location = New System.Drawing.Point(3, 17)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(35, 16)
        Me.lblDate.TabIndex = 2
        Me.lblDate.Text = "&Date"
        '
        'grpTimeReference
        '
        Me.grpTimeReference.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbLocalTime, Me.rbGMT})
        Me.grpTimeReference.Location = New System.Drawing.Point(2, 0)
        Me.grpTimeReference.Name = "grpTimeReference"
        Me.grpTimeReference.Size = New System.Drawing.Size(155, 64)
        Me.grpTimeReference.TabIndex = 2
        Me.grpTimeReference.TabStop = False
        Me.grpTimeReference.Text = "Select Time Reference"
        '
        'rbLocalTime
        '
        Me.rbLocalTime.Checked = True
        Me.rbLocalTime.Location = New System.Drawing.Point(7, 16)
        Me.rbLocalTime.Name = "rbLocalTime"
        Me.rbLocalTime.Size = New System.Drawing.Size(104, 16)
        Me.rbLocalTime.TabIndex = 0
        Me.rbLocalTime.TabStop = True
        Me.rbLocalTime.Text = "&Local Time"
        '
        'rbGMT
        '
        Me.rbGMT.Location = New System.Drawing.Point(6, 40)
        Me.rbGMT.Name = "rbGMT"
        Me.rbGMT.Size = New System.Drawing.Size(136, 16)
        Me.rbGMT.TabIndex = 1
        Me.rbGMT.Text = "&Universal Time(GMT)"
        '
        'grpDeliveryTime
        '
        Me.grpDeliveryTime.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbTimeSpan, Me.cmbSpanValue, Me.lblDeliveryTime})
        Me.grpDeliveryTime.Location = New System.Drawing.Point(3, 115)
        Me.grpDeliveryTime.Name = "grpDeliveryTime"
        Me.grpDeliveryTime.Size = New System.Drawing.Size(153, 45)
        Me.grpDeliveryTime.TabIndex = 3
        Me.grpDeliveryTime.TabStop = False
        Me.grpDeliveryTime.Text = "Deliver message after"
        '
        'cmbTimeSpan
        '
        Me.cmbTimeSpan.Items.AddRange(New Object() {"Minutes", "Hour(s)"})
        Me.cmbTimeSpan.Location = New System.Drawing.Point(82, 18)
        Me.cmbTimeSpan.Name = "cmbTimeSpan"
        Me.cmbTimeSpan.Size = New System.Drawing.Size(67, 21)
        Me.cmbTimeSpan.TabIndex = 4
        '
        'cmbSpanValue
        '
        Me.cmbSpanValue.Location = New System.Drawing.Point(45, 18)
        Me.cmbSpanValue.Name = "cmbSpanValue"
        Me.cmbSpanValue.Size = New System.Drawing.Size(38, 21)
        Me.cmbSpanValue.TabIndex = 3
        '
        'lblDeliveryTime
        '
        Me.lblDeliveryTime.Location = New System.Drawing.Point(8, 18)
        Me.lblDeliveryTime.Name = "lblDeliveryTime"
        Me.lblDeliveryTime.Size = New System.Drawing.Size(32, 16)
        Me.lblDeliveryTime.TabIndex = 1
        Me.lblDeliveryTime.Text = "&Time"
        '
        'cmdSelect
        '
        Me.cmdSelect.Location = New System.Drawing.Point(4, 163)
        Me.cmdSelect.Name = "cmdSelect"
        Me.cmdSelect.Size = New System.Drawing.Size(48, 17)
        Me.cmdSelect.TabIndex = 5
        Me.cmdSelect.Text = "&Select"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(108, 163)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(47, 18)
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "&Close"
        '
        'frmTimeSelect
        '
        Me.AcceptButton = Me.cmdSelect
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(159, 183)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdClose, Me.cmdSelect, Me.grpDeliveryTime, Me.grpTimeReference, Me.grpDeliveryDate})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTimeSelect"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "at Load Time"
        Me.grpDeliveryDate.ResumeLayout(False)
        Me.grpTimeReference.ResumeLayout(False)
        Me.grpDeliveryTime.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Sub New(ByRef FormRef As frmSendMessage)
        Me.New()
        CallerForm = FormRef
    End Sub

    Private Sub TimeSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Select Time - " & modUserId
        CallerForm.IsTimeSelectOpen = True

        DTPicker.MinDate = Date.Today
        cmbTimeSpan.SelectedIndex = 0
        cmbSpanValue.SelectedIndex = 0
    End Sub

    Private Sub rbGMT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGMT.CheckedChanged
        'Change Date
        If rbGMT.Checked = True Then
            'Change for Universal Time
            DTPicker.MinDate = Date.Today.ToUniversalTime
        Else
            'Change for Local Time
            DTPicker.MinDate = Date.Today
        End If
    End Sub

    Private Sub cmbTimeSpan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTimeSpan.SelectedIndexChanged
        Dim I As Integer
        Select Case cmbTimeSpan.SelectedIndex
            Case 0
                'Minutes
                cmbSpanValue.Items.Clear()
                For I = 3 To 59
                    cmbSpanValue.Items.Add(I)
                Next
                cmbSpanValue.SelectedIndex = 0
            Case 1
                'Hours
                cmbSpanValue.Items.Clear()
                For I = 1 To 23
                    cmbSpanValue.Items.Add(I)
                Next
                cmbSpanValue.SelectedIndex = 0
        End Select
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelect.Click
        Dim TempText As String
        Dim AddTime As Date

        'Get selected date
        SelectedDateTime = DTPicker.Value.Date

        'Get selected time
        If rbLocalTime.Checked = True Then
            'Local Time
            AddTime = Now
            TimeFormat = "LOCAL"
        Else
            'Universal Time
            AddTime = Now.ToUniversalTime
            TimeFormat = "UNIVERSALSERVER"
        End If
        SelectedDateTime = SelectedDateTime.Add(New TimeSpan(AddTime.Hour, AddTime.Minute, AddTime.Second))
        If cmbTimeSpan.SelectedIndex = 0 Then
            SelectedDateTime = SelectedDateTime.AddMinutes(CType(cmbSpanValue.SelectedItem, Double))
        End If
        If cmbTimeSpan.SelectedIndex = 1 Then
            SelectedDateTime = SelectedDateTime.AddHours(CType(cmbSpanValue.SelectedItem, Double))
        End If

        'Return Selected value
        CallerForm.txtDeliveryTime.Text = SelectedDateTime.Date & " " & SelectedDateTime.ToLongTimeString
        CallerForm.TimeFormat = Me.TimeFormat
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmTimeSelect_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        CallerForm.IsTimeSelectOpen = False
    End Sub
End Class
