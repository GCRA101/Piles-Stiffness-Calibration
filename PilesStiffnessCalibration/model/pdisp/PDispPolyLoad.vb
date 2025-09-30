Imports pdispauto_20_1

Public Class PDispPolyLoad
    Inherits PDispLoad

    'ATTRIBUTES *******************
    Private polyLoad As PolyLoad

    'CONSTRUCTORS *****************
    'Overloaded
    Public Sub New(polyLoad As PolyLoad)
        Me.polyLoad = polyLoad
    End Sub

    'METHODS **********************

    'Setters and Getters
    Public Sub setLoad(polyLoad As PolyLoad)
        Me.polyLoad = polyLoad
    End Sub
    Public Function getLoad() As PolyLoad
        Return Me.polyLoad
    End Function

End Class
