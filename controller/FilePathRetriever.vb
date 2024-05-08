Module FilePathRetriever

    'ATTIBUTES
    Private doc As Document

    'CONSTRUCTOR
    Sub New()
    End Sub

    Function getPath(doc As Document) As String
        Select Case doc
            Case Document.APP_DESCRIPTION
                Return "Piles_Stiffness_Calibration.AboutBoxDescription.txt"
            Case Else
                Return Nothing
        End Select
    End Function

End Module
