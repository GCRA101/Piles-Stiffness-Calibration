Imports pdispauto_20_1

Public Class PullMLLoadResults

    Inherits PullBSQResults
    Implements PullData

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub


    'METHODS
    Public Function pull() As List(Of PDispMLLoadResult)

        '1. Get Number of Results
        Dim numResults As Short
        ret = Me.pDispModel.getPDispApp().NumResults(numResults)

        '2. Get RectLoads
        Dim pDispMLLoadResults As List(Of PDispMLLoadResult)
        For i As Integer = 0 To numResults - 1 Step 1
            Dim pDispMLLoadResult As PdispMindlinResult
            Me.pDispModel.getPDispApp().GetMindlinResult_RectLoad(i, pDispMLLoadResult)
            pDispMLLoadResults.Add(New PDispMLLoadResult(pDispMLLoadResult))
        Next

        Return pDispMLLoadResults

    End Function

End Class
