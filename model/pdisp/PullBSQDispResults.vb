Imports pdispauto_20_1

Public Class PullBSQDispResults
    Inherits PullBSQResults(Of PDispBSQDispResult)
    Implements PullData(Of PDispBSQDispResult)

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub


    'METHODS
    Public Overrides Function pull() As List(Of PDispBSQDispResult)

        '1. Get Number of Results
        'Dim numResults As Short
        'ret = Me.pDispModel.getPDispApp().NumResults(numResults)

        Dim numDispPoints As Short
        ret = Me.pDispModel.getPDispApp().NumDisplacementPoints(numDispPoints)

        '2. Get RectLoads
        Dim pDispBSQDispResults As List(Of PDispBSQDispResult) = New List(Of PDispBSQDispResult)
        For i As Integer = 0 To numDispPoints - 1 Step 1
            Dim pDispBSQDispResult As New PdispBoussinesqResult()
            Me.pDispModel.getPDispApp().GetBoussResult_DispPoint(i + 1, pDispBSQDispResult)
            pDispBSQDispResults.Add(New PDispBSQDispResult(pDispBSQDispResult))
        Next

        Return pDispBSQDispResults
    End Function

End Class
