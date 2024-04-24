Public Class LoadsPusher
    Inherits Pusher

    'ATTRIBUTES
    'All protected attributes inherited from the superclass

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        Me.pDispModel = pDispModel
    End Sub


    'METHODS
    Public Sub push(pDispLoads As List(Of PDispLoad), overwrite As Boolean)
        'Initialize corresponding push behaviour class
        If pDispLoads.GetType().ToString.Contains("rect") Then
            Me.pushBehaviour = New PushRectLoads(pDispModel, pDispLoads.Cast(Of PDispRectLoad))
        ElseIf pDispLoads.GetType().ToString.Contains("circ") Then
            Me.pushBehaviour = New PushCircLoads(pDispModel, pDispLoads.Cast(Of PDispCircLoad))
        ElseIf pDispLoads.GetType().ToString.Contains("poly") Then
            Me.pushBehaviour = New PushPolyLoads(pDispModel, pDispLoads.Cast(Of PDispPolyLoad))
        Else
            Return
        End If
        'Push loads 
        Me.pushBehaviour.push(overwrite)
    End Sub


End Class
