Public Class LoadsPuller
    Inherits Puller

    'ATTRIBUTES
    'All protected attributes inherited from the superclass

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel, loadType As PDispLoadType)
        Select Case loadType
            Case PDispLoadType.RECT
                Me.pullBehaviour = New PullRectLoads(pDispModel)
            Case PDispLoadType.CIRC
                Me.pullBehaviour = New PullCircLoads(pDispModel)
            Case PDispLoadType.POLY
                Me.pullBehaviour = New PullPolyLoads(pDispModel)
        End Select
    End Sub


    'METHODS
    Public Function pull() As List(Of PDispData)
        Return Me.pullBehaviour.pull()
    End Function


End Class
