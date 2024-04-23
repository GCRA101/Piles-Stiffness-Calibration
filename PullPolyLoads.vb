Imports pdispauto_20_1

Public Class PullPolyLoads
    Inherits PullBehaviour

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub

    'METHODS
    Public Function pull() As List(Of PDispPolyLoad)

        '1. Get Number of Results
        Dim numResults As Short
        ret = Me.pDispModel.getPDispApp().NumResults(numResults)

        '2. Get RectLoads
        Dim polyLoads As List(Of PDispPolyLoad)
        For i As Integer = 0 To numResults - 1 Step 1
            Dim polyLoad As PolyLoad
            Me.pDispModel.getPDispApp().GetPolyLoad(i, polyLoad)
            polyLoads.Add(New PDispPolyLoad(polyLoad))
        Next

        Return polyLoads

    End Function
End Class
