Imports System
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms


''' <summary>
''' 
''' <remarks>
''' <para> Concrete class responsible for the sizing and arrangement of external application windows. </para>
''' <para> The class implements functions from the Windows API assembly "user32.dll" to carry out docking and 
''' resizing operations on windows belonging to external applications running in parallel to the application.
'''  </para>
''' 
''' <para> Desing Patterns: 
''' - FACADE </para>
''' 
''' </remarks>
''' 
''' </summary>


Public Class WindowResizer

    'Import necessary Windows API functions
    <DllImport("user32.dll")>
    Private Shared Function EnumWindows(enumProc As EnumWindowsProc, lParam As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll")>
    Private Shared Function GetWindowText(hWnd As IntPtr, lpString As StringBuilder, nMaxCount As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function IsWindowVisible(hWnd As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function MoveWindow(hWnd As IntPtr, X As Integer, Y As Integer, nWidth As Integer, nHeight As Integer, bRepaint As Boolean) As Boolean
    End Function

    'Delegate for the EnumWindows method
    Private Delegate Function EnumWindowsProc(hWnd As IntPtr, lParam As IntPtr) As Boolean


    Public Shared Sub dockWindow(processName As ProcessName, dockType As DockType)
        'Enumerate all open windows
        EnumWindows((Function(hWnd, lParam)
                         ' Skip windows that are Not visible
                         If Not IsWindowVisible(hWnd) Then
                             Return True
                         End If
                         ' Get the window's title
                         Dim title As StringBuilder = New StringBuilder(256)
                         GetWindowText(hWnd, title, 256)
                         ' Check for a specific window title
                         If title.ToString().Contains(ProcessNameRetriever.getName(processName)) Then
                             ' Dock the window to the left half of the screen
                             Select Case dockType
                                 Case DockType.LEFT
                                     MoveWindow(hWnd, 0, 0, Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height, True)
                                 Case DockType.TOP
                                     MoveWindow(hWnd, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height / 2, True)
                                 Case DockType.RIGHT
                                     MoveWindow(hWnd, Screen.PrimaryScreen.Bounds.Width / 2, 0, Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height, True)
                                 Case DockType.BOTTOM
                                     MoveWindow(hWnd, 0, Screen.PrimaryScreen.Bounds.Height / 2, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height / 2, True)
                                 Case DockType.CENTER
                                     MoveWindow(hWnd, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, True)
                             End Select
                             Return False 'Stop enumerating windows
                         End If
                         Return True ' Continue enumerating windows
                     End Function), IntPtr.Zero)

    End Sub





End Class
