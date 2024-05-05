Imports System.IO
Imports System.Reflection.Emit

Public Class SoundManager
	Implements AudioManagerInterface

	' SOUNDSMANAGER
	' 
	' Concrete Class implementing the interface AudioManagerInterface and that is responsible 
	' for playing the sound effects of the application, when active.
	'
	' Specific Techniques
	' - SINGLETON Design Pattern

	' ATTRIBUTES
	Private Shared instance As SoundManager
	Private active As Boolean = True

	' CONSTRUCTOR - Private'
	Private Sub New()
	End Sub

	' STATIC METHOD .getInstance() '
	Public Shared Function getInstance() As SoundManager
		If (instance Is Nothing) Then
			instance = New SoundManager()
		End If
		Return instance
	End Function

	' METHODS

	'Play Method - Overloaded

	'Overloaded play method taking the enum sound as input and calling within it the play method implemented from
	'the AudioManagerInterface interface that is turned into private in order to keep it hidden from the client.
	'This allows the client to input just the Sound Enum rather than its filepath, leaving it getting retrieved under
	'the hood by the Static Class SoundPath.
	'This makes the clode cleaner and easier to extend.
	Public Sub play(sound As Sound)
		play(SoundPath.getPath(sound))
	End Sub

	Private Sub play(filePath As String) Implements AudioManagerInterface.play
		'Execute this Sub only if the SoundManager is set to active
		If Me.active = False Then Return

		Try
			'Play the File in the background without stopping user's interaction
			My.Computer.Audio.Play(filePath, AudioPlayMode.Background)
		Catch ex1 As FileNotFoundException
			MsgBox(ex1.Message, vbOKOnly And MsgBoxStyle.Exclamation, "WARNING")
		Catch ex2 As IOException
			MsgBox(ex2.Message, vbOKOnly And MsgBoxStyle.Exclamation, "WARNING")
		Catch ex3 As Exception
			MsgBox(ex3.Message, vbOKOnly And MsgBoxStyle.Exclamation, "WARNING")
		End Try

	End Sub

	Public Sub setActive(active As Boolean) Implements AudioManagerInterface.setActive
		Me.active = active
	End Sub

	Public Function isActive() As Boolean Implements AudioManagerInterface.isActive
		Return Me.active
	End Function

End Class
