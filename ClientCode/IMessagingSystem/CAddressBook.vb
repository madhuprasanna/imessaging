Public Class CAddressBook

    'AddressBook UserString format: UserId1:<B>or<N>;UserId2:<B>or<N>
    'AddressBook GroupString format: GroupId1:UserId1:UserId2;GroupId2:UserId3:UserId4
    'These two strings are connected by UserString|GroupString called AddressBookString
    'Empty AddressBook is indiacted by NONE

    Dim TheAddressString As String
    Public UserAddressTable, GroupAddressTable As New Hashtable()

    Public Function StoreAddressString(ByVal AddressString As String) As String
        Dim UserString, GroupString As String
        Dim UserArray(), GroupArray() As String
        Dim I As Integer

        'Add Users
        UserAddressTable.Clear()
        UserString = AddressString.Split("|")(0)
        If UserString <> "NONE" Then
            UserArray = UserString.Split(";")
            For I = 0 To UserArray.Length - 1
                UserAddressTable.Add(UserArray(I).Split(":")(0), UserArray(I))
            Next
        End If

        'Add Groups
        GroupAddressTable.Clear()
        GroupString = AddressString.Split("|")(1)
        If GroupString <> "NONE" Then
            GroupArray = GroupString.Split(";")
            For I = 0 To GroupArray.Length - 1
                GroupAddressTable.Add(GroupArray(I).Split(":")(0), GroupArray(I))
            Next
        End If
    End Function

    Public Function LoadAddressString() As String
        Dim ReturnString As String
        Dim UserArray, GroupArray As Array
        Dim I As Integer
        Dim UserAddressString As String = ""
        Dim GroupAddressString As String = ""

        'Pattern UserString
        If UserAddressTable.Count() = 0 Then
            UserAddressString = "NONE"
        Else
            UserArray = Array.CreateInstance(GetType(String), UserAddressTable.Count())
            UserAddressTable.Values.CopyTo(UserArray, 0)
            For I = 0 To UserArray.Length - 1
                UserAddressString &= UserArray(I) & ";"
            Next
            UserAddressString = UserAddressString.Substring(0, UserAddressString.Length - 1)
        End If

        'Pattern GroupString
        If GroupAddressTable.Count() = 0 Then
            GroupAddressString = "NONE"
        Else
            GroupArray = Array.CreateInstance(GetType(String), GroupAddressTable.Count())
            GroupAddressTable.Values.CopyTo(GroupArray, 0)
            For I = 0 To GroupArray.Length - 1
                GroupAddressString &= GroupArray(I) & ";"
            Next
            GroupAddressString = GroupAddressString.Substring(0, GroupAddressString.Length - 1)
        End If

        ReturnString = UserAddressString & "|" & GroupAddressString
        Return ReturnString
    End Function

    Public Function AddUser(ByVal UserId As String) As String
        Dim ReturnString As String
        If UserAddressTable.Contains(UserId) Then
            ReturnString = "UserId already exist"
        Else
            UserAddressTable.Add(UserId, UserId & ":N")
            ReturnString = "UserId Added"
        End If
        Return ReturnString
    End Function

    Public Function DeleteUser(ByVal UserId As String) As String
        Dim ReturnString As String
        If UserAddressTable.Contains(UserId) Then
            UserAddressTable.Remove(UserId)
            ReturnString = "UserId deleted"
        Else
            ReturnString = "UserId doesnot exist"
        End If

        Return ReturnString
    End Function

    Public Function AddGroup(ByVal GroupId As String, ByVal UserIdString As String) As String
        Dim ReturnString As String
        Dim TheArray() As String
        Dim GroupString As String = ""
        Dim I As Integer

        If GroupAddressTable.Contains(GroupId) Then
            ReturnString = "GroupId already exist"
        Else
            TheArray = UserIdString.Split(",")

            GroupString = GroupString & GroupId
            For I = 0 To TheArray.Length - 1
                GroupString &= ":" & TheArray(I)
            Next
            GroupAddressTable.Add(GroupId, GroupString)
            ReturnString = "GroupId added"
        End If
        Return ReturnString
    End Function

    Public Function DeleteGroup(ByVal GroupId As String)
        Dim ReturnString As String
        If GroupAddressTable.Contains(GroupId) Then
            GroupAddressTable.Remove(GroupId)
            ReturnString = "GroupId deleted"
        Else
            ReturnString = "GroupId doesnot exist"
        End If
        Return ReturnString
    End Function

    Public Function EditGroup(ByVal GroupId As String, ByVal NewUserIdString As String)
        Dim ReturnString As String
        Dim TheArray() As String
        Dim GroupString As String = ""
        Dim I As Integer

        If GroupAddressTable.Contains(GroupId) Then
            'Remove old group 
            GroupAddressTable.Remove(GroupId)
            'Pattern new groupstring
            TheArray = NewUserIdString.Split(",")
            GroupString = GroupString & GroupId
            For I = 0 To TheArray.Length - 1
                GroupString &= ":" & TheArray(I)
            Next
            'Add the modifiedgroup
            GroupAddressTable.Add(GroupId, GroupString)
            ReturnString = "GroupId edited"
        Else
            ReturnString = "GroupId doesnot exist"
        End If
        Return ReturnString
    End Function

    Public Function IsUserBlocked(ByVal UserId As String) As Boolean
        If UserAddressTable.Contains(UserId) Then
            If CType(UserAddressTable.Item(UserId), String).Split(":")(1) = "N" Then
                Return False
            Else
                Return True
            End If
        End If

        Return False
    End Function

End Class
