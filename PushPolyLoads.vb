Public Class PushPolyLoads
    Inherits PushBehaviour
    Implements PushData

    'ATTRIBUTES
    Private polyLoads As List(Of PDispPolyLoad)

    'CONSTRUCTORS
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub
    Public Sub New(pDispModel As PDispModel, polyLoads As List(Of PDispPolyLoad))
        MyBase.New(pDispModel)
        Me.polyLoads = polyLoads
    End Sub

    'method
    Public Sub setPolyLoads(polyLoads As List(Of PDispPolyLoad))
        Me.polyLoads = polyLoads
    End Sub

    Public Sub push(overwrite As Boolean) Implements PushData.push

        With Me.pDispModel.getPDispApp()
            '1. DELETE EXISTING RECTLOADS IF overwrite=True
            If (overwrite) Then
                Dim numPolyLoads As Short
                .NumPolyLoads(numPolyLoads)
                For i As Integer = 0 To (numPolyLoads - 1) Step 1
                    Me.pDispModel.getPDispApp().DeletePolyLoad(i)
                Next
            End If
            '2. ADD NEW RECTLOADS
            Me.polyLoads.ForEach(Sub(polyLd) .AddPolyLoad(polyLd.getLoad()))
        End With

    End Sub



End Class
