Imports pdispauto_20_1

Public Class PullBSQLoadResults
    Inherits PullBSQResults
    Implements PullData

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub


    'METHODS
    Public Function pull() As List(Of PDispBSQLoadResult)

        '1. Get Number of Results
        Dim numResults As Short
        ret = Me.pDispModel.getPDispApp().NumResults(numResults)

        '2. Get RectLoads
        Dim pDispBSQLoadResults As List(Of PDispBSQLoadResult)
        For i As Integer = 0 To numResults - 1 Step 1
            Dim pDispBSQLoadResult As PdispBoussinesqResult
            Me.pDispModel.getPDispApp().GetBoussResult_RectLoad(i, pDispBSQLoadResult)
            pDispBSQLoadResults.Add(New PDispBSQLoadResult(pDispBSQLoadResult))
        Next

        Return pDispBSQLoadResults
    End Function

End Class
