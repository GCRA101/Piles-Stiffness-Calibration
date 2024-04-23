Imports ETABSv1
Imports pdispauto_20_1


Public Class cPlugin
    Implements ETABSv1.cPluginContract

    Public Sub Main(ByRef SapModel As cSapModel, ByRef ISapPlugin As cPluginCallback) Implements cPluginContract.Main
        Dim ufInputs As ufInputs
        ufInputs = New ufInputs(SapModel, ISapPlugin)
        ufInputs.Show()
    End Sub

    Public Function Info(ByRef Text As String) As Integer Implements cPluginContract.Info
        Text = "Plugin carrying out the iterative analysis of piles stiffnesses"
        Return 0
    End Function



End Class
