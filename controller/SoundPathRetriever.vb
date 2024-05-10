Module SoundPathRetriever

    'CONSTRUCTOR
    Sub New()
    End Sub

    Function getPath(sound As Sound) As String
        Select Case sound
            Case Sound.SPLASHSCREEN
                Return "Piles_Stiffness_Calibration.SPLASHSCREEN.wav"
            Case Sound.CLICKBUTTON
                Return "Piles_Stiffness_Calibration.CLICKBUTTON.wav"
            Case Sound.CHECKBOX
                Return "Piles_Stiffness_Calibration.CHECKBOX.wav"
            Case Sound.WARNING
                Return "Piles_Stiffness_Calibration.WARNING.wav"
            Case Sound.ENDITERATION
                Return "Piles_Stiffness_Calibration.ENDITERATION.wav"
            Case Else
                Return Nothing
        End Select
    End Function

End Module
