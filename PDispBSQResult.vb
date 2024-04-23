
Imports pdispauto_20_1

Public Class PDispBSQResult
    Inherits PDispResult

    'ATTRIBUTES ***********************************************
    Private result As PdispBoussinesqResult

    'CONSTRUCTOR **********************************************
    'Overloaded
    Public Sub New(pDispBoussinesqResult As PdispBoussinesqResult)
        Me.result = pDispBoussinesqResult
    End Sub

    'METHODS **************************************************

    'Setters and Getters
    Public Sub setResult(pDispBoussinesqResult As PdispBoussinesqResult)
        Me.result = pDispBoussinesqResult
    End Sub
    Public Function getResult() As PdispBoussinesqResult
        Return Me.result
    End Function



End Class
