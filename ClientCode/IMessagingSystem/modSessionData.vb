Module modSessionData

#Region "Global Data"

    'Session Data
    Public modUserId As String = ""
    Public modPassword As String = ""
    Public modChallenge As String = ""
    Public modPasswordChallenge As String = ""
    Public modSessionStatus As String = "NOTLOGGED"
    Public modUniversalServerTime As Long
    Public modPermanentSettingsString As String = ""

    'Internet Connection Data
    Public modInternetConnection As Boolean = False
    Public modHandlerIpAddress As String = "127.0.0.1"
    Public modHandlerPort As Integer = 12345
    Public modSystemIpAddress = ""

    'Other resource locations
    Public modicoSystrayIcon As New Icon("TestIcon.ico")
    Public modSystrayIcon As New NotifyIcon()
    Public hpiMessagingHelp As New HelpProvider()

    'Database connection codes and timer
    Public ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ClientDB.mdb"
    Public tmrApplication As New System.Windows.Forms.Timer()

    'Message Receiver, Message Displayer and Connection Objects
    Public modServiceObject As CMessagingServices
    Public modMessageReceiverObject As New CMessageReceiver()
    Public modMessageDisplayerObject As New CMessageDisplayer()

    'Form Variables
    Public modfrmAbout As frmAbout
    Public modfrmAddressBook As frmAddressBook
    Public modfrmClearSession As frmClearSession
    Public modfrmSearch As frmSearch
    Public modfrmSendMessage As frmSendMessage
    Public modfrmSettings As frmSettings
    Public modfrmSignIn As frmSignIn
    Public modfrmVoteResult As frmVoteResult
    Public modfrmRegistration As frmRegistration

    Public modIsAboutOpen, modIsAddressBookOpen, modIsClearSessionOpen As Boolean
    Public modIsSearchOpen, modIsSendMessageOpen, modIsSettingsOpen As Boolean
    Public modIsSignInOpen, modIsVoteResultOpen, modIsRegistrationOpen As Boolean

    'Used Message Settings Form
    Public modShowMyIp As String = ""
    Public modOperationMode As String = ""
    Public modTuneFileNo = 0
    Public modTuneFileNameArray(7) As String
    Public modIsSilentIconSet As Boolean = False

    'Used by Address Book
    Public modAddressbookString As String = ""
    Public modAddressBook As New CAddressBook()

#End Region

    'Public Procedures 
#Region "Public Functions"

    'Password+Challenge Function
    Public Function GenerateChallengeValue(ByVal Password As String, ByVal Challenge As String)
        Dim i As Integer
        Dim ChallengeValue As String

        For i = 0 To Password.Length - 1
            ChallengeValue = ChallengeValue & Chr(Asc(Password.Substring(i, 1)) + Val(Challenge))
        Next

        Return ChallengeValue
    End Function

    'Checks for Internet connectivity [Not uses connection class objects]
    Public Function CheckforInternetConnection() As Boolean
        Dim AuthServiceStub As New AuthService.AuthService()
        Dim MessageBuffer As String
        Dim boolInternetConnection As Boolean
        Dim e As Exception

        boolInternetConnection = False

        'Checking for Internet connection by Requesting Challenge
        Try
            MessageBuffer = AuthServiceStub.TestConnection("TestString")
            If MessageBuffer = "TestString" Then
                boolInternetConnection = True
            End If
        Catch e
            MsgBox(e.ToString)
            Exit Function
        End Try

        Return boolInternetConnection
    End Function

    'Menu Enable and Disable function
    Public Sub FormatContextMenuEnableDisable()
        Dim I As Integer = 0
        If modSessionStatus = "NOTLOGGED" Then
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = True : I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = False : I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = True : I = I + 1

            I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = True : I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = False : I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = False : I = I + 1

            I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = False : I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = False : I = I + 1

            I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = True : I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = True : I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = True
        End If

        If modSessionStatus = "LOGGED" Then
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = False : I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = True : I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = False : I = I + 1

            I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = True : I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = True : I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = True : I = I + 1

            I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = True : I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = True : I = I + 1

            I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = True : I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = True : I = I + 1
            modSystrayIcon.ContextMenu.MenuItems.Item(I).Enabled = True
        End If
    End Sub
#End Region

End Module
