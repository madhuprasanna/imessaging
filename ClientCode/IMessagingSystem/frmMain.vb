Imports System.Net
Imports System.Net.Sockets
Imports System.Data.OleDb

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Dim TheHandlerThread As Threading.Thread
    Dim ServiceObjectSocks As CMessagingServices
    Dim CurrentTcpClient As TcpClient


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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(0, 0)
        Me.Enabled = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.Opacity = 0
        Me.ShowInTaskbar = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized

    End Sub

#End Region

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim UserMsg As String
        Dim IsIpAddressOK, IsInternetConnectionOK As Boolean
        Dim ObjfrmGetIpAddress As frmGetIpAddress

        'Load Tune filenames
        modTuneFileNameArray(0) = "Rooster.wav"
        modTuneFileNameArray(1) = "Phone.wav"
        modTuneFileNameArray(2) = "Sheep.wav"
        modTuneFileNameArray(3) = "Sword.wav"
        modTuneFileNameArray(4) = "Airtel.wav"
        modTuneFileNameArray(5) = "BikeBell.wav"
        modTuneFileNameArray(6) = "Coins.wav"
        modTuneFileNameArray(7) = "Kids.wav"

        'Help file
        hpiMessagingHelp.HelpNamespace = "iMessagingHelp.chm"

        'Check for Internet connection 
        modInternetConnection = CheckforInternetConnection()
        'If no Internet connection
        If Not modInternetConnection Then
            Do
                IsInternetConnectionOK = False
                IsIpAddressOK = True
                ObjfrmGetIpAddress = New frmGetIpAddress()
                ObjfrmGetIpAddress.ShowDialog()

                If modInternetConnection = True Then
                    modServiceObject = New CMessagingServices()
                    ServiceObjectSocks = New CMessagingServices()
                    Exit Do
                End If

                Try
                    modServiceObject = New CMessagingServices()
                Catch Ex As Exception
                    MsgBox("Service unavailable at the IP Address " & modHandlerIpAddress, MsgBoxStyle.Critical, "Invalid IP Address")
                    IsIpAddressOK = False
                End Try
            Loop While IsIpAddressOK = False
        Else
            modServiceObject = New CMessagingServices()
            ServiceObjectSocks = New CMessagingServices()
        End If

        'Start Handler here...
        If modInternetConnection Then
            TheHandlerThread = New Threading.Thread(AddressOf SocketConnectionHandler)
            TheHandlerThread.IsBackground = True
            TheHandlerThread.Start()
        End If

        'Application and Server time systems
        AddHandler tmrApplication.Tick, AddressOf tmrApplication_Elapsed
        tmrApplication.Interval = 1000
        tmrApplication.Enabled = True
        tmrApplication.Start()
        modUniversalServerTime = CType(modServiceObject.GetUniversalServerTime(), Long)

        'Get the IpAddress of this System
        modSystemIpAddress = Dns.Resolve(Dns.GetHostName).AddressList(0).ToString

        'Set SystrayIcon and Format it according to Login Status
        InitSystrayIcon()
        FormatContextMenuEnableDisable()
    End Sub

#Region "Procedures handling the SystrayIcon Context menu"

    Private Sub SignInClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not modIsAboutOpen Then
            modfrmSignIn = New frmSignIn()
            modfrmSignIn.Show()
            modfrmSignIn.Refresh()
        Else
            modfrmSignIn.Activate()
            modfrmSignIn.Refresh()
        End If
    End Sub
    Private Sub SignOutClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim MessageBuffer As String
        Dim TempString As String
        Dim ObjfrmOperationMessages As New frmOperationMessages()

        'Close all open forms
        CloseAllOpenForms()

        'Send back Permanent setting
        ObjfrmOperationMessages.lblMessage.Text = "Saving " & modUserId & "'s settings Please wait ..."
        ObjfrmOperationMessages.Show()
        ObjfrmOperationMessages.Refresh()
        modPermanentSettingsString = modShowMyIp & ";" & modOperationMode & ":" & modTuneFileNo
        modServiceObject.StoreSettings(modUserId, modPasswordChallenge, modPermanentSettingsString)

        'Send back AddressBook String
        ObjfrmOperationMessages.lblMessage.Text = "Saving " & modUserId & "'s Address Book Please wait ..."
        ObjfrmOperationMessages.Show()
        ObjfrmOperationMessages.Refresh()
        modAddressbookString = modAddressBook.LoadAddressString()
        modServiceObject.StoreAddressBook(modUserId, modPasswordChallenge, modAddressbookString)

        'Close Session
        ObjfrmOperationMessages.lblMessage.Text = "Logging out " & modUserId & " Please wait ..."
        ObjfrmOperationMessages.Show()
        ObjfrmOperationMessages.Refresh()
        MessageBuffer = modServiceObject.CloseSession(modUserId, modPasswordChallenge)
        If MessageBuffer = "MESAG-04: SESSION CLOSED" Then

            'Stop message reception(also sends quest message) and Stop Displayer
            modMessageReceiverObject.StopReceive()
            modMessageDisplayerObject.StopDisplay()

            'Send back uncleared messages
            ObjfrmOperationMessages.lblMessage.Text = "Saving " & modUserId & "'s Pending Messages Please wait ..."
            ObjfrmOperationMessages.Show()
            ObjfrmOperationMessages.Refresh()
            TempString = PackMessages()
            If TempString <> "" Then
                MessageBuffer = modServiceObject.StoreBackMessage(modUserId & "-" & TempString)
            End If

            'Update module variables and Context Menu
            modUserId = ""
            modPassword = ""
            modSessionStatus = "NOTLOGGED"
            modChallenge = "0"

            FormatContextMenuEnableDisable()
            modSystrayIcon.ContextMenu.MenuItems(1).Text = "Sign Out... "
            modSystrayIcon.ContextMenu.MenuItems(9).Text = "Vote Results..."
        End If

        ObjfrmOperationMessages.Close()
        ObjfrmOperationMessages.Dispose()
    End Sub
    Private Sub ClearSessionClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not modIsClearSessionOpen Then
            modfrmClearSession = New frmClearSession()
            modfrmClearSession.Show()
            modfrmClearSession.Refresh()
        Else
            modfrmClearSession.Activate()
            modfrmClearSession.Refresh()
        End If
    End Sub
    Private Sub SettingsClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not modIsSettingsOpen Then
            modfrmSettings = New frmSettings()
            modfrmSettings.Show()
            modfrmSettings.Refresh()
        Else
            modfrmSettings.Activate()
            modfrmSettings.Refresh()
        End If
    End Sub
    Private Sub SearchClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not modIsSearchOpen Then
            modfrmSearch = New frmSearch()
            modfrmSearch.Show()
            modfrmSearch.Refresh()
        Else
            modfrmSearch.Activate()
            modfrmSearch.Refresh()
        End If
    End Sub
    Private Sub SendMessageClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not modIsSendMessageOpen Then
            modfrmSendMessage = New frmSendMessage()
            modfrmSendMessage.Show()
            modfrmSendMessage.Refresh()
        Else
            modfrmSendMessage.Activate()
            modfrmSendMessage.Refresh()
        End If
    End Sub
    Private Sub AddressBookClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not modIsAddressBookOpen Then
            modfrmAddressBook = New frmAddressBook()
            modfrmAddressBook.Show()
            modfrmAddressBook.Refresh()
        Else
            modfrmAddressBook.Activate()
            modfrmAddressBook.Refresh()
        End If
    End Sub
    Private Sub VoteResultClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not modIsVoteResultOpen Then
            modfrmVoteResult = New frmVoteResult()
            modfrmVoteResult.Show()
            modfrmVoteResult.Refresh()
        Else
            modfrmVoteResult.Activate()
            modfrmVoteResult.Refresh()
        End If
    End Sub
    Private Sub HelpClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Help.ShowHelp(Me, hpiMessagingHelp.HelpNamespace)
    End Sub
    Private Sub AboutClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not modIsAboutOpen Then
            modfrmAbout = New frmAbout()
            modfrmAbout.Show()
            modfrmAbout.Refresh()
        Else
            modfrmAbout.Activate()
            modfrmAbout.Refresh()
        End If
    End Sub
    Private Sub ExitClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim msgResult As MsgBoxResult
        Dim TitleString As String
        Dim WasteArg1 As Object, WasteArg2 As System.EventArgs 'Dummy Arguments

        If modSessionStatus = "NOTLOGGED" Then
            modSystrayIcon.Visible = False
            End
        Else
            TitleString = "Logout " & modUserId & " and Exit"
            msgResult = MsgBox("Do you want to sign out before exiting?", MsgBoxStyle.OKCancel, TitleString)
            If (msgResult = MsgBoxResult.OK) Then
                'Sign out before exiting
                SignOutClick(WasteArg1, WasteArg2)
                modSystrayIcon.Visible = False
                End
            End If
            If (msgResult = MsgBoxResult.Cancel) Then
                Exit Sub
            End If
        End If
    End Sub

#End Region

    'Initializes modSystrayIcon
    Private Sub InitSystrayIcon()
        Dim mnuItem(13) As MenuItem
        Dim TheContextMenu As ContextMenu
        Dim I As Integer = 0

        'Store Menu Items
        mnuItem(I) = New MenuItem("Sign In...", New EventHandler(AddressOf SignInClick)) : I = I + 1
        mnuItem(I) = New MenuItem("Sign Out...", New EventHandler(AddressOf SignOutClick)) : I = I + 1
        mnuItem(I) = New MenuItem("Clear Session/Password...", New EventHandler(AddressOf ClearSessionClick)) : I = I + 1

        mnuItem(I) = New MenuItem("-") : I = I + 1

        mnuItem(I) = New MenuItem("Settings...", New EventHandler(AddressOf SettingsClick)) : I = I + 1
        mnuItem(I) = New MenuItem("Search...", New EventHandler(AddressOf SearchClick)) : I = I + 1
        mnuItem(I) = New MenuItem("Send Message...", New EventHandler(AddressOf SendMessageClick)) : I = I + 1

        mnuItem(I) = New MenuItem("-") : I = I + 1

        mnuItem(I) = New MenuItem("Address Book...", New EventHandler(AddressOf AddressBookClick)) : I = I + 1
        mnuItem(I) = New MenuItem("Vote Results...", New EventHandler(AddressOf VoteResultClick)) : I = I + 1

        mnuItem(I) = New MenuItem("-") : I = I + 1

        mnuItem(I) = New MenuItem("Help", New EventHandler(AddressOf HelpClick)) : I = I + 1
        mnuItem(I) = New MenuItem("About...", New EventHandler(AddressOf AboutClick)) : I = I + 1
        mnuItem(I) = New MenuItem("Exit", New EventHandler(AddressOf ExitClick))

        TheContextMenu = New ContextMenu(mnuItem)

        modSystrayIcon.Icon = modicoSystrayIcon
        modSystrayIcon.ContextMenu = TheContextMenu
        modSystrayIcon.Text = "iMessaging - Right click to get Menu"

        modSystrayIcon.Visible = True
    End Sub

    Private Sub tmrApplication_Elapsed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        modUniversalServerTime = Date.FromFileTime(modUniversalServerTime).AddSeconds(1).ToFileTime
    End Sub

    'Listens for connections from client; Called as a thread from main
    Public Sub SocketConnectionHandler()
        Dim TheTcpListener As New TcpListener(modHandlerPort)
        Dim TheTcpClient As TcpClient
        Dim ThreadArray(10) As Threading.Thread
        Dim ClientCount As Integer = 0

        TheTcpListener.Start()
        'Loops forever
        While True
            TheTcpClient = TheTcpListener.AcceptTcpClient()
            CurrentTcpClient = TheTcpClient
            ThreadArray(ClientCount) = New Threading.Thread(AddressOf ClientRequestHandler)
            CType(ThreadArray.GetValue(ClientCount), Threading.Thread).IsBackground = True
            CType(ThreadArray.GetValue(ClientCount), Threading.Thread).Start()
            ClientCount += 1
        End While
        TheTcpClient.Close()
    End Sub
    Private Sub ClientRequestHandler()
        Dim RequestString, ResponseString As String
        Dim MyTcpClient As TcpClient = CurrentTcpClient
        Dim RequestStream As New IO.StreamReader(MyTcpClient.GetStream)
        Dim ResponseStream As New IO.StreamWriter(MyTcpClient.GetStream)

        Do  'Read from Socket
            If MyTcpClient.GetStream.DataAvailable() Then
                RequestString = RequestStream.ReadLine()

                ResponseString = WSRequestForwarder(RequestString)
                ResponseStream.WriteLine(ResponseString)
                ResponseStream.Flush()
            Else
                Application.DoEvents()
            End If
        Loop
    End Sub
    Private Function WSRequestForwarder(ByVal RequestString As String) As String
        Dim MessageBuffer As String = "UNIDENTIFIED REQUEST"

        Select Case RequestString.Split("ô")(0)

            Case "RequestChallenge"         'AuthService
                MessageBuffer = ServiceObjectSocks.RequestChallenge(RequestString.Split("ô")(1))
                Return MessageBuffer
            Case "Authenticate"
                MessageBuffer = ServiceObjectSocks.Authenticate(RequestString.Split("ô")(1), RequestString.Split("ô")(2))
                Return MessageBuffer
            Case "CloseSession"
                MessageBuffer = ServiceObjectSocks.CloseSession(RequestString.Split("ô")(1), RequestString.Split("ô")(2))
                Return MessageBuffer

            Case "SendMessage"              'SendMessageService
                MessageBuffer = ServiceObjectSocks.SendMessage(RequestString.Split("ô")(1), RequestString.Split("ô")(2), RequestString.Split("ô")(3), RequestString.Split("ô")(4))
                Return MessageBuffer
            Case "SendTimedMessage"
                MessageBuffer = ServiceObjectSocks.SendTimedMessage(RequestString.Split("ô")(1), RequestString.Split("ô")(2), RequestString.Split("ô")(3), RequestString.Split("ô")(4), RequestString.Split("ô")(5))
                Return MessageBuffer
            Case "SendGroupMessage"
                MessageBuffer = ServiceObjectSocks.SendGroupMessage(RequestString.Split("ô")(1), RequestString.Split("ô")(2), RequestString.Split("ô")(3), RequestString.Split("ô")(4))
                Return MessageBuffer
            Case "SendGroupTimedMessage"
                MessageBuffer = ServiceObjectSocks.SendTimedMessage(RequestString.Split("ô")(1), RequestString.Split("ô")(2), RequestString.Split("ô")(3), RequestString.Split("ô")(4), RequestString.Split("ô")(5))
                Return MessageBuffer

            Case "RequestMessage"           'ReceiveMessageService
                MessageBuffer = ServiceObjectSocks.RequestMessage(RequestString.Split("ô")(1), RequestString.Split("ô")(2))
                Return MessageBuffer

            Case "GetUniversalServerTime"   'SessionService
                MessageBuffer = ServiceObjectSocks.GetUniversalServerTime()
                Return MessageBuffer
            Case "ClearSession"
                MessageBuffer = ServiceObjectSocks.ClearSession(RequestString.Split("ô")(1), RequestString.Split("ô")(2), RequestString.Split("ô")(3), RequestString.Split("ô")(4))
                Return MessageBuffer
            Case "ClearPassword"
                MessageBuffer = ServiceObjectSocks.ClearPassword(RequestString.Split("ô")(1), RequestString.Split("ô")(2), RequestString.Split("ô")(3))
                Return MessageBuffer
            Case "ChangePassword"
                MessageBuffer = ServiceObjectSocks.ChangePassword(RequestString.Split("ô")(1), RequestString.Split("ô")(2), RequestString.Split("ô")(3))
                Return MessageBuffer
            Case "LoadSettings"
                MessageBuffer = ServiceObjectSocks.LoadSettings(RequestString.Split("ô")(1), RequestString.Split("ô")(2))
                Return MessageBuffer
            Case "StoreSettings"
                MessageBuffer = ServiceObjectSocks.StoreSettings(RequestString.Split("ô")(1), RequestString.Split("ô")(2), RequestString.Split("ô")(3))
                Return MessageBuffer
            Case "StoreIPAddress"
                MessageBuffer = ServiceObjectSocks.StoreIPAddress(RequestString.Split("ô")(1), RequestString.Split("ô")(2), RequestString.Split("ô")(3))
                Return MessageBuffer
            Case "StoreBackMessage"
                MessageBuffer = ServiceObjectSocks.StoreBackMessage(RequestString.Split("ô")(1))

            Case "Search"               'SearchService
                MessageBuffer = ServiceObjectSocks.Search(RequestString.Split("ô")(1), RequestString.Split("ô")(2), RequestString.Split("ô")(3))
                Return MessageBuffer

            Case "LoadAddressBook"      'AddressBookService
                MessageBuffer = ServiceObjectSocks.LoadAddressBook(RequestString.Split("ô")(1), RequestString.Split("ô")(2))
                Return MessageBuffer
            Case "StoreAddressBook"
                MessageBuffer = ServiceObjectSocks.StoreAddressBook(RequestString.Split("ô")(1), RequestString.Split("ô")(2), RequestString.Split("ô")(3))
                Return MessageBuffer

            Case "SendVoteMessage"      'VoteService
                MessageBuffer = ServiceObjectSocks.SendVoteMessage(RequestString.Split("ô")(1), RequestString.Split("ô")(2), RequestString.Split("ô")(3), RequestString.Split("ô")(4))
                Return MessageBuffer
            Case "MyVote"
                MessageBuffer = ServiceObjectSocks.MyVote(RequestString.Split("ô")(1), RequestString.Split("ô")(2), RequestString.Split("ô")(3), RequestString.Split("ô")(4))
                Return MessageBuffer
            Case "GetVoteDetails"
                MessageBuffer = ServiceObjectSocks.GetVoteDetails(RequestString.Split("ô")(1), RequestString.Split("ô")(2))
                Return MessageBuffer
            Case "DeleteVote"
                MessageBuffer = ServiceObjectSocks.DeleteVote(RequestString.Split("ô")(1), RequestString.Split("ô")(2), RequestString.Split("ô")(3))
                Return MessageBuffer
        End Select

        Return MessageBuffer
    End Function
    Private Sub CloseAllOpenForms()
        If modIsAboutOpen Then
            modfrmAbout.Close()
            modfrmAbout.Dispose()
        End If
        If modIsAddressBookOpen Then
            modfrmAddressBook.Close()
            modfrmAddressBook.Dispose()
        End If
        If modIsClearSessionOpen Then
            modfrmClearSession.Close()
            modfrmClearSession.Dispose()
        End If
        If modIsSearchOpen Then
            modfrmSearch.Close()
            modfrmSearch.Dispose()
        End If
        If modIsSendMessageOpen Then
            modfrmSendMessage.Close()
            modfrmSendMessage.Dispose()
        End If
        If modIsSettingsOpen Then
            modfrmSettings.Close()
            modfrmSettings.Dispose()
        End If
        If modIsSignInOpen Then
            modfrmSignIn.Close()
            modfrmSignIn.Dispose()
        End If
        If modIsVoteResultOpen Then
            modfrmVoteResult.Close()
            modfrmVoteResult.Dispose()
        End If
        If modIsRegistrationOpen Then
            modfrmRegistration.Close()
            modfrmRegistration.Dispose()
        End If
    End Sub
    Private Function PackMessages() As String
        Dim TheDataSet As DataSet
        Dim TheDataAdapter As OleDbDataAdapter
        Dim TheConnection As OleDbConnection
        Dim TheCommand As OleDbCommand
        Dim ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ClientDB.mdb"

        Dim SqlCommand As String

        Dim I As Integer
        Dim RowsCount As Integer
        Dim ReturnString As String
        Dim SenderId, Message, GMTTime As String

        'Select Message from Database
        SqlCommand = "Select * from MessageDB where ReceiverId = '" & modUserId & "'"
        TheDataSet = New DataSet()
        TheDataAdapter = New OleDbDataAdapter(SqlCommand, ConnectionString)
        TheDataAdapter.Fill(TheDataSet, "MessagesPackUp")
        RowsCount = TheDataSet.Tables("MessagesPackUp").Rows.Count()

        If RowsCount = 0 Then
            ReturnString = ""
        Else
            'Message Protocol - 1
            ReturnString = RowsCount & "»"

            For I = 0 To RowsCount - 1
                'Store current message 
                SenderId = TheDataSet.Tables("MessagesPackUp").Rows(I).Item("SenderId")
                GMTTime = TheDataSet.Tables("MessagesPackUp").Rows(I).Item("SentDate")
                Message = TheDataSet.Tables("MessagesPackUp").Rows(I).Item("Message")
                Message = "TIMED:" & TheDataSet.Tables("MessagesPackUp").Rows(I).Item("DeliveryDate") & "§" & Message

                'Message Protocol - 2
                ReturnString &= SenderId & "ï"
                ReturnString &= GMTTime & "ï"
                ReturnString &= Message & "î"
            Next

            'Delete all extracted messages from the MessageDB
            TheConnection = New OleDb.OleDbConnection(ConnectionString)
            TheConnection.Open()
            SqlCommand = "Delete * from MessageDB where ReceiverId = '" & modUserId & "'"
            TheCommand = New OleDb.OleDbCommand(SqlCommand, TheConnection)
            TheCommand.ExecuteNonQuery()
            TheConnection.Close()
        End If

        Return ReturnString
    End Function

End Class
