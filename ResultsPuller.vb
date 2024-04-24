Public Class ResultsPuller
    Inherits Puller

    'ATTRIBUTES
    'All protected attributes inherited from the superclass

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub


    'METHODS
    Public Function pull(resultType As PDispResultType, analysisMethod As PDispAnalysisMethod) As List(Of PDispData)

        Select Case analysisMethod
            Case PDispAnalysisMethod.BOUSSINESQ
                Select Case resultType
                    Case PDispResultType.LOAD
                        Me.pullBehaviour = New PullBSQLoadResults(pDispModel)
                    Case PDispResultType.DISPLACEMENT
                        Me.pullBehaviour = New PullBSQDispResults(pDispModel)
                End Select
            Case PDispAnalysisMethod.MINDLIN
                Select Case resultType
                    Case PDispResultType.LOAD
                        Me.pullBehaviour = New PullMLLoadResults(pDispModel)
                    Case PDispResultType.DISPLACEMENT
                        Me.pullBehaviour = New PullMLDispResults(pDispModel)
                End Select
        End Select

        Return Me.pullBehaviour.pull()
    End Function

End Class
