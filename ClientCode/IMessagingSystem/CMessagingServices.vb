Public Class CMessagingServices

    Dim AuthServiceStub As New AuthService.AuthService()
    Dim SendMessageServiceStub As New SendMsgService.SendMessageService()
    Dim ReqMessageServiceStub As New ReqMsgService.ReceiveMessageService()
    Dim SessionServiceStub As New SessionService.SessionService()
    Dim SearchServiceStub As New SearchService.SearchService()
    Dim AddressBookServiceStub As New AddressBookService.AddressBookService()
    Dim VoteServiceStub As New VoteService.VoteService()

    Dim TheTcpClient As System.Net.Sockets.TcpClient
    Dim SockReader As System.IO.StreamReader
    Dim SockWriter As System.IO.StreamWriter

    Sub New()
        If Not modInternetConnection Then
            TheTcpClient = New System.Net.Sockets.TcpClient(modHandlerIpAddress, modHandlerPort)
            SockReader = New System.IO.StreamReader(TheTcpClient.GetStream)
            SockWriter = New System.IO.StreamWriter(TheTcpClient.GetStream)
            SockWriter.AutoFlush = True
        Else
            TheTcpClient = Nothing
        End If
    End Sub

#Region "AuthService"

    Public Function RequestChallenge(ByVal UserId) As String
        Dim MessageBuffer As String

        'Request challenge
        Try
            If modInternetConnection Then
                MessageBuffer = AuthServiceStub.ChallengeRequest(UserId)
            Else
                MessageBuffer = "RequestChallenge" & "ô" & UserId
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
    Public Function Authenticate(ByVal UserId As String, ByVal PasswordChallenge As String) As String
        Dim MessageBuffer As String

        'Trying authenticate
        Try
            If modInternetConnection Then
                MessageBuffer = AuthServiceStub.Authenticate(UserId, PasswordChallenge)
            Else
                MessageBuffer = "Authenticate" & "ô" & UserId & "ô" & PasswordChallenge
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
    Public Function CloseSession(ByVal UserId As String, ByVal PasswordChallenge As String) As String
        Dim MessageBuffer As String

        Try
            If modInternetConnection Then
                MessageBuffer = AuthServiceStub.CloseSession(UserId, PasswordChallenge)
            Else
                MessageBuffer = "CloseSession" & "ô" & UserId & "ô" & PasswordChallenge
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
#End Region

#Region "SendMessageService"

    Public Function SendMessage(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal DestUserId As String, ByVal Message As String) As String
        Dim MessageBuffer As String

        Try
            If modInternetConnection Then
                MessageBuffer = SendMessageServiceStub.SendMessage(UserId, PasswordChallenge, DestUserId, Message)
            Else
                MessageBuffer = "SendMessage" & "ô" & UserId & "ô" & PasswordChallenge & "ô" & DestUserId & "ô" & Message
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
    Public Function SendTimedMessage(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal DestUserId As String, ByVal Message As String, ByVal DispTime As String) As String
        Dim MessageBuffer As String

        Try
            If modInternetConnection Then
                MessageBuffer = SendMessageServiceStub.SendTimedMessage(UserId, PasswordChallenge, DestUserId, Message, DispTime)
            Else
                MessageBuffer = "SendTimedMessage" & "ô" & UserId & "ô" & PasswordChallenge & "ô" & DestUserId & "ô" & Message & "ô" & DispTime
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
    Public Function SendGroupMessage(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal GroupId As String, ByVal Message As String) As String
        Dim MessageBuffer As String

        Try
            If modInternetConnection Then
                MessageBuffer = SendMessageServiceStub.SendGroupMessage(UserId, PasswordChallenge, GroupId, Message)
            Else
                MessageBuffer = "SendGroupMessage" & "ô" & UserId & "ô" & PasswordChallenge & "ô" & GroupId & "ô" & Message
                SockWriter.WriteLine(MessageBuffer)
                Do
                    MessageBuffer = SockReader.ReadLine()
                Loop While Not TheTcpClient.GetStream.DataAvailable()
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
    Public Function SendGroupTimedMessage(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal GroupId As String, ByVal Message As String, ByVal DispTime As String) As String
        Dim MessageBuffer As String

        Try
            If modInternetConnection Then
                MessageBuffer = SendMessageServiceStub.SendGroupTimedMessage(UserId, PasswordChallenge, GroupId, Message, DispTime)
            Else
                MessageBuffer = "SendGroupTimedMessage" & "ô" & UserId & "ô" & PasswordChallenge & "ô" & GroupId & "ô" & Message & "ô" & DispTime
                SockWriter.WriteLine(MessageBuffer)
                Do
                    MessageBuffer = SockReader.ReadLine()
                Loop While Not TheTcpClient.GetStream.DataAvailable()
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
#End Region

#Region "ReceiveMessageService"
    'This function need to be split into begin and end request.
    Public Function RequestMessage(ByVal UserId As String, ByVal PasswordChallenge As String) As String
        Dim MessageBuffer As String

        Try
            'Request challenge
            If modInternetConnection Then
                MessageBuffer = ReqMessageServiceStub.SyncMessageRequest(UserId, PasswordChallenge)
            Else
                MessageBuffer = "RequestMessage" & "ô" & UserId & "ô" & PasswordChallenge
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
#End Region

#Region "SessionService"
    Public Function GetUniversalServerTime() As String
        Dim MessageBuffer As String

        Try
            If modInternetConnection Then
                MessageBuffer = SessionServiceStub.GetServerTime()
            Else
                MessageBuffer = "GetUniversalServerTime"
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
    Public Function ClearSession(ByVal UserId As String, ByVal Password As String, ByVal DOB As String, ByVal SchoolName As String) As String
        Dim MessageBuffer As String

        Try
            If modInternetConnection Then
                MessageBuffer = SessionServiceStub.ClearSession(UserId, Password, DOB, SchoolName)
            Else
                MessageBuffer = "ClearSession" & "ô" & UserId & "ô" & Password & "ô" & DOB & "ô" & SchoolName
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
    Public Function ClearPassword(ByVal UserId As String, ByVal DOB As String, ByVal SchoolName As String) As String
        Dim MessageBuffer As String

        Try
            If modInternetConnection Then
                MessageBuffer = SessionServiceStub.ClearPassword(UserId, DOB, SchoolName)
            Else
                MessageBuffer = "ClearPassword" & "ô" & UserId & "ô" & DOB & "ô" & SchoolName
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
    Public Function ChangePassword(ByVal UserId As String, ByVal OldPassword As String, ByVal NewPassword As String) As String
        Dim MessageBuffer As String

        Try
            If modInternetConnection Then
                MessageBuffer = SessionServiceStub.ChangePassword(UserId, OldPassword, NewPassword)
            Else
                MessageBuffer = "ChangePassword" & "ô" & UserId & "ô" & OldPassword & "ô" & NewPassword
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
    Public Function LoadSettings(ByVal UserId As String, ByVal PasswordChallenge As String) As String
        Dim MessageBuffer As String

        Try
            If modInternetConnection Then
                MessageBuffer = SessionServiceStub.LoadSettings(UserId, PasswordChallenge)
            Else
                MessageBuffer = "LoadSettings" & "ô" & UserId & "ô" & PasswordChallenge
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
    Public Function StoreSettings(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal SettingString As String) As String
        Dim MessageBuffer As String

        Try
            If modInternetConnection Then
                MessageBuffer = SessionServiceStub.StoreSettings(UserId, PasswordChallenge, SettingString)
            Else
                MessageBuffer = "StoreSettings" & "ô" & UserId & "ô" & PasswordChallenge & "ô" & SettingString
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
    Public Function StoreIPAddress(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal IPAddress As String)
        Dim MessageBuffer As String

        Try
            If modInternetConnection Then
                MessageBuffer = SessionServiceStub.StoreIPAddress(UserId, PasswordChallenge, IPAddress)
            Else
                MessageBuffer = "StoreIPAddress" & "ô" & UserId & "ô" & PasswordChallenge & "ô" & IPAddress
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
    Public Function StoreBackMessage(ByVal Message As String) As String
        Dim MessageBuffer As String

        Try
            If modInternetConnection Then
                MessageBuffer = SessionServiceStub.StoreBackMessage(Message)
            Else
                MessageBuffer = "StoreBackMessage" & "ô" & Message
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
#End Region


#Region "SearchService"
    Public Function Search(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal SearchString As String) As String
        Dim MessageBuffer As String

        Try
            If modInternetConnection Then
                MessageBuffer = SearchServiceStub.Search(UserId, PasswordChallenge, SearchString)
            Else
                MessageBuffer = "Search" & "ô" & UserId & "ô" & PasswordChallenge & "ô" & SearchString
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
#End Region

#Region "AddressBookService"
    Public Function LoadAddressBook(ByVal UserId As String, ByVal PasswordChallenge As String) As String
        Dim MessageBuffer As String

        Try
            If modInternetConnection Then
                MessageBuffer = AddressBookServiceStub.LoadAddressBook(UserId, PasswordChallenge)
            Else
                MessageBuffer = "LoadAddressBook" & "ô" & UserId & "ô" & PasswordChallenge
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
    Public Function StoreAddressBook(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal AddressBookString As String) As String
        Dim MessageBuffer As String

        Try
            If modInternetConnection Then
                MessageBuffer = AddressBookServiceStub.StoreAddressBook(UserId, PasswordChallenge, AddressBookString)
            Else
                MessageBuffer = "StoreAddressBook" & "ô" & UserId & "ô" & PasswordChallenge & "ô" & AddressBookString
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
#End Region

#Region "VoteService"
    Public Function SendVoteMessage(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal GroupId As String, ByVal Message As String) As String
        Dim MessageBuffer As String
        Try
            If modInternetConnection Then
                MessageBuffer = VoteServiceStub.SendVoteMessage(UserId, PasswordChallenge, GroupId, Message)
            Else
                MessageBuffer = "SendVoteMessage" & "ô" & UserId & "ô" & PasswordChallenge & "ô" & GroupId & "ô" & Message
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
    Public Function MyVote(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal MessageId As String, ByVal VoteString As String) As String
        Dim MessageBuffer As String
        Try
            If modInternetConnection Then
                MessageBuffer = VoteServiceStub.MyVote(UserId, PasswordChallenge, MessageId, VoteString)
            Else
                MessageBuffer = "MyVote" & "ô" & UserId & "ô" & PasswordChallenge & "ô" & MessageId & "ô" & VoteString
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
    Public Function GetVoteDetails(ByVal UserId As String, ByVal PasswordChallenge As String) As String
        Dim MessageBuffer As String
        Try
            If modInternetConnection Then
                MessageBuffer = VoteServiceStub.GetVoteDetails(UserId, PasswordChallenge)
            Else
                MessageBuffer = "GetVoteDetails" & "ô" & UserId & "ô" & PasswordChallenge
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
    Public Function DeleteVote(ByVal UserId As String, ByVal PasswordChallenge As String, ByVal MessageId As String) As String
        Dim MessageBuffer As String
        Try
            If modInternetConnection Then
                MessageBuffer = VoteServiceStub.DeleteVote(UserId, PasswordChallenge, MessageId)
            Else
                MessageBuffer = "DeleteVote" & "ô" & UserId & "ô" & PasswordChallenge & "ô" & MessageId
                SockWriter.WriteLine(MessageBuffer)
                Do
                    If TheTcpClient.GetStream.DataAvailable() Then
                        MessageBuffer = SockReader.ReadLine()
                        Exit Do
                    End If
                Loop
            End If
        Catch e As Exception
            MessageBuffer = "Exception:" & e.ToString
        End Try

        Return MessageBuffer
    End Function
#End Region

End Class
