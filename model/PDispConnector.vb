Imports pdispauto_20_1

Public Class PDispConnector
    Implements PDispConnection

    'ATTRIBUTES
    Private Shared instance As PDispConnector
    Private pDispApp As pdispauto_20_1.Application
    Private ret As Integer
    Private AppVisibility As Boolean


    'CONSTRUCTORS
    Private Sub New()
        '1. Initialize PDisp Application
        Me.pDispApp = New pdispauto_20_1.Application
    End Sub

    Public Function getInstance() As PDispConnector
        If instance Is Nothing Then
            instance = New PDispConnector()
        End If
        Return instance
    End Function


    Public Sub initialize() Implements PDispConnection.initialize

    End Sub

    Public Sub dispose() Implements PDispConnection.dispose
        Me.pDispApp.Close()
        Me.pDispApp = Nothing
    End Sub

    Public Sub setAppVisibility(bool As Boolean) Implements PDispConnection.setAppVisibility
        If bool = True Then
            Me.pDispApp.Show()
        End If
    End Sub

    Public Function getPDispApp() As Application Implements PDispConnection.getPDispApp
        Return Me.pDispApp
    End Function
End Class
