Module SoundPath

    'ATTIBUTES
    Private sound As Sound

    'CONSTRUCTOR
    Sub New()
    End Sub

    Function getPath(sound As Sound) As String
        Select Case sound
            Case Sound.SPLASHSCREEN
                Return "Piles Stiffness Iteration.sounds.SPLASHSCREEN.wav"
            Case Sound.CLICKBUTTON
                Return "Piles Stiffness Iteration.sounds.CLICKBUTTON.wav"
            Case Sound.CHECKBOX
                Return "Piles Stiffness Iteration.sounds.CHECKBOX.wav"
            Case Sound.WARNING
                Return "Piles Stiffness Iteration.sounds.WARNING.wav"
            Case Sound.ENDITERATION
                Return "Piles Stiffness Iteration.sounds.ENDITERATION.wav"
            Case Else
                Return Nothing
        End Select
    End Function

End Module
