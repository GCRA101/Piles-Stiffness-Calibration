Imports pdispauto_20_1

Public Class PDispRectLoad
    Inherits PDispLoad

    'ATTRIBUTES *******************
    Private rectLoad As RectLoad

    'CONSTRUCTORS *****************
    'Overloaded
    Public Sub New(rectLoad As RectLoad)
        Me.rectLoad = rectLoad
    End Sub

    'METHODS **********************

    'Setters and Getters
    Public Sub setLoad(rectLoad As RectLoad)
        Me.rectLoad = rectLoad
    End Sub
    Public Function getLoad() As RectLoad
        Return Me.rectLoad
    End Function

End Class
