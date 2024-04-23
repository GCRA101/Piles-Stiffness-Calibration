Imports pdispauto_20_1

Public Class PDispCircLoad
    Inherits PDispLoad

    'ATTRIBUTES *******************
    Private circLoad As CircLoad

    'CONSTRUCTORS *****************
    'Overloaded
    Public Sub New(circLoad As CircLoad)
        Me.circLoad = circLoad
    End Sub

    'METHODS **********************

    'Setters and Getters
    Public Sub setLoad(circLoad As CircLoad)
        Me.circLoad = circLoad
    End Sub
    Public Function getLoad() As CircLoad
        Return Me.circLoad
    End Function

End Class
