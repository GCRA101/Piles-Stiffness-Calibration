Imports pdispauto_20_1

Public Class PullBSQResults(Of T As PDispData)
    Inherits PullBehaviour(Of T)

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub

End Class
