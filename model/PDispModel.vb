Imports pdispauto_20_1

Public Class PDispModel

    ' ATTRIBUTES *********************************************
    Private pDispApp As pdispauto_20_1.Application
    Private filePath As String


    ' CONSTRUCTORS ******************************************
    ' Overloaded
    Public Sub New(Optional filePath As String = "")
        '1. Initialize PDisp Application
        Me.pDispApp = New pdispauto_20_1.Application
        '2. Create/Open PDisp Model
        If filePath = "" Then
            Me.pDispApp.NewFile()
        ElseIf filePath.Contains("pdd") Then
            Me.pDispApp.Open(filePath)
            Me.filePath = filePath
        Else
            Return
        End If
    End Sub


    'METHODS *************************************************

    Public Sub save(Optional filePath As String = "")
        If filePath = "" Then
            Me.pDispApp.Save()
        ElseIf filePath.Contains("pdd") Then
            Me.pDispApp.SaveAs(filePath)
        Else
            Return
        End If
    End Sub

    Public Sub analyse(Optional analysisMethod As PDispAnalysisMethod = Nothing)

        '1. Delete previous results
        Me.pDispApp.Delete()

        '2. Set up analysis method, if specified
        If analysisMethod = PDispAnalysisMethod.MINDLIN Then
            Me.pDispApp.SetAnalysisMethod(0)
        ElseIf analysisMethod = PDispAnalysisMethod.BOUSSINESQ Then
            Me.pDispApp.SetAnalysisMethod(1)
        End If

        '3. Run analysis
        Me.pDispApp.Analyse()

    End Sub


    Public Sub close(Optional saveFile As Boolean = False)

        '1. Save file if specified
        If saveFile = True Then
            Me.pDispApp.Save()
        End If

        '2. Close the PDisp Application
        Me.pDispApp.Close()

        '3. Release allocated memory
        Me.pDispApp = Nothing
    End Sub


    Public Sub setVisibility(visibility As Boolean)
        If visibility = True Then
            Me.pDispApp.Show()
        End If
    End Sub

    Public Function getPDispApp() As Application
        Return Me.pDispApp
    End Function




End Class
