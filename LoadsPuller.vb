Public Class LoadsPuller
    Inherits Puller

    'ATTRIBUTES
    'All protected attributes inherited from the superclass

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub


    'METHODS
    Public Function pull(loadType As PDispLoadType) As List(Of PDispData)

        Select Case loadType
            Case PDispLoadType.RECT
                Me.pullBehaviour = New PullRectLoads(pDispModel)
                Return Me.pullBehaviour.pull()
            Case PDispLoadType.CIRC
                Me.pullBehaviour = New PullCircLoads(pDispModel)
                Return Me.pullBehaviour.pull()
            Case PDispLoadType.POLY
                Me.pullBehaviour = New PullPolyLoads(pDispModel)
                Return Me.pullBehaviour.pull()
        End Select

        Return Nothing

    End Function


End Class
