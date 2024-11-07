''' <summary>
'''     <remarks>
'''         Static class used to retrieve preset filepaths based on the value of the input Document enumeration.
'''         This allows to keep all the filepaths encapsuled within the getPath() method of the present class.
'''         These filepaths can be directly accessed via shorter and more intuitive nicknames/short names as per 
'''         the Document enumeration values, thus making the coding much better readable.
'''     </remarks>
''' </summary>

Module FilePathRetriever

    'CONSTRUCTOR
    Sub New()
    End Sub

    'METHODS
    Function getPath(doc As Document) As String
        'Return a pre-set file path depending on the value of the input Document enumeration
        Select Case doc
            Case Document.APP_DESCRIPTION
                Return "Piles_Stiffness_Calibration.AboutBoxDescription.txt"
            Case Else
                Return Nothing
        End Select
    End Function

End Module
