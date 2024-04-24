Imports pdispauto_20_1

Public Class PushCircLoads
    Inherits PushBehaviour
    Implements PushData

    'ATTRIBUTES
    Private circLoads As List(Of PDispCircLoad)

    'CONSTRUCTORS
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub
    Public Sub New(pDispModel As PDispModel, circLoads As List(Of PDispCircLoad))
        MyBase.New(pDispModel)
        Me.circLoads = circLoads
    End Sub

    'method
    Public Sub setCircLoads(circLoads As List(Of PDispCircLoad))
        Me.circLoads = circLoads
    End Sub

    Public Sub push(overwrite As Boolean) Implements PushData.push

        With Me.pDispModel.getPDispApp()
            '1. DELETE EXISTING RECTLOADS IF overwrite=True
            If (overwrite) Then
                Dim numCircLoads As Short
                .NumCircLoads(numCircLoads)
                For i As Integer = 0 To (numCircLoads - 1) Step 1
                    Me.pDispModel.getPDispApp().DeleteCircLoad(i)
                Next
            End If
            '2. ADD NEW RECTLOADS
            Me.circLoads.ForEach(Sub(circLd) .AddCircLoad(circLd.getLoad()))

        End With

    End Sub


End Class
