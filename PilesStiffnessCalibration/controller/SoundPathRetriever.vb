''' <summary>
'''     <remarks>
'''         <para>
'''         Static class used to retrieve preset filepaths based on the value of the input Sound enumeration.
'''         This allows to keep all the filepaths encapsuled within the getPath() method of the present class.
'''         These filepaths can be directly accessed via shorter and more intuitive nicknames/short names as per 
'''         the Sound enumeration values, thus making the coding much better readable.
'''         </para>
'''         <para>Design Patterns: - FACADE</para>
'''     </remarks>
''' </summary>

Module SoundPathRetriever

    'CONSTRUCTOR
    Sub New()
    End Sub

    'METHODS
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
