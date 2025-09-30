Public Class ResultsPuller(Of T As PDispResult)
    Inherits Puller(Of T)

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
            Case GetType(PDispBSQLoadResult)
                Dim pullBehaviour As PullBSQLoadResults = New PullBSQLoadResults(pDispModel)
                Return pullBehaviour.pull().Cast(Of T)
            Case GetType(PDispBSQDispResult)
                Dim pullBehaviour As PullBSQDispResults = New PullBSQDispResults(pDispModel)
                Return pullBehaviour.pull().Cast(Of T)
            Case GetType(PDispMLLoadResult)
                Dim pullBehaviour As PullMLLoadResults = New PullMLLoadResults(pDispModel)
                Return pullBehaviour.pull().Cast(Of T)
            Case GetType(PDispMLDispResult)
                Dim pullBehaviour As PullMLDispResults = New PullMLDispResults(pDispModel)
                Return pullBehaviour.pull().Cast(Of T)
        End Select

    End Function

End Class
