Class CSound
    Declare Auto Function PlaySound Lib "winmm.dll" (ByVal name As String, ByVal hmod As Integer, ByVal flags As Integer) As Integer
    Public Const SND_ASYNC As Integer = &H1
    Public Const SND_FILENAME As Integer = &H20000

    Public Sub PlaySoundFile(ByVal filename As String)
        PlaySound(filename, Nothing, SND_FILENAME Or SND_ASYNC)
    End Sub
End Class
