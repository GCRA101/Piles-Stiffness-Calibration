Imports pdispauto_20_1

Public Class PullCircLoads
    Inherits PullBehaviour

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub

    'METHODS
    Public Function pull() As List(Of PDispCircLoad)

        '1. Get Number of Results
        Dim numResults As Short
        ret = Me.pDispModel.getPDispApp().NumResults(numResults)

        '2. Get RectLoads
        Dim circLoads As List(Of PDispCircLoad)
        For i As Integer = 0 To numResults - 1 Step 1
            Dim circLoad As CircLoad
            Me.pDispModel.getPDispApp().GetCircLoad(i, circLoad)
            circLoads.Add(New PDispCircLoad(circLoad))
        Next

        Return circLoads

    End Function

End Class
