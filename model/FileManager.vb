Imports System.IO
Imports System.Windows.Forms

''' <summary>
'''     <remarks>
'''         <para>Static Class responsible to provide utility methods allowing to set folder paths
'''         and file names for all the outputs files produced by the application.</para>
'''         <para>The file paths/names are labelled with information about creation date and corresponding
'''         analysis iteration number. This prevents any overriding of the output files and allows
'''         for proper tracking of the different stages of the iterative analysis carried out.</para>
'''     </remarks>
''' </summary>
''' 


Module FileManager

    'METHODS
    Public Function setDatedFolderPath(folderPath As String, subFolderName As String) As String
        Dim dateObj As Date = Date.Now
        Dim datedFolderPath As String = ""
        'Add current time and date in front of subfolder name
        With dateObj
            datedFolderPath = folderPath + "\" + .Year.ToString + .Month.ToString("D2") +
                                .Day.ToString("D2") + .Hour.ToString() + .Minute.ToString() + "_" + subFolderName
        End With

        Return datedFolderPath

    End Function


    Public Function setNewFilePath(oldFilePath As String, iterNum As Integer) As String

        Dim newFilePath As String
        Dim dateObj As Date = Date.Now

        Dim sep() As Char = {"/", "\", "//"}
        'Add Label in front of file name containing info about current date and iteration number.
        'File gets saved in the same folder of the original
        With dateObj
            newFilePath = oldFilePath.Remove(oldFilePath.IndexOf(oldFilePath.Split(sep).Last())) + "PSCT" +
                        .Year.ToString + .Month.ToString("D2") +
                        .Day.ToString("D2") + "_" + .Hour.ToString() + .Minute.ToString() + "_" + "Iteration_" + CStr(iterNum) +
                        "_" + oldFilePath.Split(sep).Last()

        End With

        Return newFilePath

    End Function

    Public Function setNewFilePath(oldFilePath As String, destinationFolderPath As String, iterNum As Integer) As String

        Dim newFilePath As String
        Dim dateObj As Date = Date.Now

        'Add Label in front of file name containing info about current date and iteration number.
        'File gets saved in a different folder than the original
        With dateObj
            newFilePath = destinationFolderPath + "\" + "PSCT" + .Year.ToString + .Month.ToString("D2") +
                            .Day.ToString("D2") + "_" + "Iteration_" + CStr(iterNum) +
                             "_" + Path.GetFileName(oldFilePath)
        End With

        Return newFilePath

    End Function



End Module
