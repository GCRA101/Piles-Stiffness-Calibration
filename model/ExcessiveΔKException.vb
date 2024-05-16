Public Class ExcessiveΔKException
    Inherits Exception

    'ATTRIBUTES
    Private pileObjs As List(Of PileObject)

    'CONSTRUCTOR
    Public Sub New(message As String, pileObjs As List(Of PileObject))
        MyBase.New(message)
        Me.pileObjs = pileObjs
    End Sub

    'METHODS

    'Setters and Getters
    Public Function getPileObjs() As List(Of PileObject)
        Return Me.pileObjs
    End Function


End Class
