Imports System.Windows.Forms
Imports ETABSv1
Imports pdispauto_20_1


Public Class cPlugin
    Implements ETABSv1.cPluginContract

    Public Sub Main(ByRef SapModel As cSapModel, ByRef ISapPlugin As cPluginCallback) Implements cPluginContract.Main
        Dim splashScreen As splashScreen, aboutBox As aboutBox
        splashScreen = New splashScreen()
        aboutBox = New aboutBox()
        splashScreen.Show()
        splashScreen.Refresh()
        System.Threading.Thread.Sleep(4000)
        splashScreen.Close()
        aboutBox.Show()
    End Sub

    Public Function Info(ByRef Text As String) As Integer Implements cPluginContract.Info
        Text = "Plugin carrying out the iterative analysis of piles stiffnesses"
        Return 0
    End Function



End Class
