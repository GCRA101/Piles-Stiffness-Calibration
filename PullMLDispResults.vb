Imports pdispauto_20_1

Public Class PullMLDispResults
    Inherits PullMLResults
    Implements PullData

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub


    'METHODS
    Public Function pull() As List(Of PDispMLDispResult)

        '1. Get Number of Results
        Dim numResults As Short
        ret = Me.pDispModel.getPDispApp().NumResults(numResults)

        '2. Get RectLoads
        Dim pDispMLDispResults As List(Of PDispMLDispResult)
        For i As Integer = 0 To numResults - 1 Step 1
            Dim pDispMLDispResult As PdispMindlinResult
            Me.pDispModel.getPDispApp().GetMindlinResult_DispPoint(i, pDispMLDispResult)
            pDispMLDispResults.Add(New PDispMLDispResult(pDispMLDispResult))
        Next

        Return pDispMLDispResults
    End Function

End Class
