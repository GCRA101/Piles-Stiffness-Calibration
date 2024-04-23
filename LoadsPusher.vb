Public Class LoadsPusher
    Inherits Pusher

    'ATTRIBUTES
    'All protected attributes inherited from the superclass

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel, loadType As PDispLoadType)
        Select Case loadType
            Case PDispLoadType.RECT
                Me.pushBehaviour = New PushRectLoads(pDispModel)
            Case PDispLoadType.CIRC
                Me.pushBehaviour = New PushCircLoads(pDispModel)
            Case PDispLoadType.POLY
                Me.pushBehaviour = New PushPolyLoads(pDispModel)
        End Select
    End Sub


    'METHODS
    Public Sub push(overwrite As Boolean)
        Me.pushBehaviour.push(overwrite)
    End Sub


End Class
