''' <summary>
''' 
''' <remarks>
''' <para> Static Class returning the string name of the Window corresponding to a specific process. </para>
''' <para> Given an input <see cref="ProcessName"/> Enumeration value, the class returns its corresponding string 
'''  </para>
''' 
''' <para> Desing Patterns: 
''' - FACADE </para>
''' 
''' </remarks>
''' 
''' </summary>

Public Module ProcessNameRetriever

    Public Function getName(processName As ProcessName) As String
        Select Case processName
            Case ProcessName.AUTODESK_REVIT
                Return "Revit"
            Case ProcessName.AUTODESK_ROBOT
                Return "Robot"
            Case ProcessName.CSI_ETABS
                Return "ETABS"
            Case ProcessName.CSI_SAP
                Return "SAP"
            Case ProcessName.OASYS_PDISP
                Return "PDisp"
            Case ProcessName.RHINO3D
                Return "Rhino"
            Case Else
                Return Nothing
        End Select
    End Function

End Module
