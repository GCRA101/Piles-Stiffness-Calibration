Public Class LoadsPuller(Of T As PDispLoad)
    Inherits Puller

    'ATTRIBUTES
    'All protected attributes inherited from the superclass

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub


    'METHODS
    Public Function pull() As List(Of T)

        Dim typeOfT As Type = GetType(T)

        Select Case typeOfT
            Case GetType(PDispRectLoad)
                Dim pullBehaviour As PullRectLoads = New PullRectLoads(pDispModel)
                Return pullBehaviour.pull().Cast(Of T)
            Case GetType(PDispCircLoad)
                Dim pullBehaviour As PullCircLoads = New PullCircLoads(pDispModel)
                Return pullBehaviour.pull().Cast(Of T)
            Case GetType(PDispPolyLoad)
                Dim pullBehaviour As PullPolyLoads = New PullPolyLoads(pDispModel)
                Return pullBehaviour.pull().Cast(Of T)
        End Select

        Return Nothing

    End Function


End Class
