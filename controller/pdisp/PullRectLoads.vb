
Imports pdispauto_20_1

Public Class PullRectLoads
    Inherits PullBehaviour

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub

    'METHODS
    Public Function pull() As List(Of PDispRectLoad)

        '1. Get Number of Results
        Dim numLoads As Short
        ret = Me.pDispModel.getPDispApp().NumRectLoads(numLoads)

        '2. Get RectLoads
        Dim rectLoads As List(Of PDispRectLoad) = New List(Of PDispRectLoad)
        For i As Integer = 0 To numLoads - 1 Step 1
            Dim rectLoad As RectLoad
            Me.pDispModel.getPDispApp().GetRectLoad(i + 1, rectLoad)
            rectLoads.Add(New PDispRectLoad(rectLoad))
        Next

        Return rectLoads

    End Function

End Class
