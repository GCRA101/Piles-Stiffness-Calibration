Public Class ResultsPuller
    Inherits Puller

    'ATTRIBUTES
    'All protected attributes inherited from the superclass

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel, resultType As PDispResultType, analysisMethod As PDispAnalysisMethod)

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

    End Sub


    'METHODS
    Public Function pull() As List(Of PDispData)
        Return Me.pullBehaviour.pull()
    End Function

End Class
