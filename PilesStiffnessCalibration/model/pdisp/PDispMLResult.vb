'IMPORT LIBRARIES
Imports pdispauto_20_1

Public Class PDispMLResult
    Inherits PDispResult

    'ATTRIBUTES ***********************************************
    Private result As PdispMindlinResult

    'CONSTRUCTOR **********************************************
    'Overloaded
    Public Sub New(pDispMindlinResult As PdispMindlinResult)
        Me.result = pDispMindlinResult
    End Sub

    'METHODS **************************************************

    'Setters and Getters
    Public Sub setResult(pDispMindlinResult As PdispMindlinResult)
        Me.result = pDispMindlinResult
    End Sub
    Public Function getResult() As PdispMindlinResult
        Return Me.result
    End Function



End Class
