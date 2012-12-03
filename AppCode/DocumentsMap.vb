Imports RDP.Client

Public Class DocumentsMap

	Private Shared __Lock As New Object

	Private Shared MapFile As String = Hosting.HostingEnvironment.MapPath("~/App_Data/Files/Map.json")
	Private Shared _IDFileName As Dictionary(Of String, String)

	Shared ReadOnly Property IDFileName As Dictionary(Of String, String)
		Get
			If _IDFileName Is Nothing Then
				Load()
			End If
			Return _IDFileName
		End Get
	End Property

	Shared Sub Load()

		SyncLock __Lock
			_IDFileName = IO.File.ReadAllText(MapFile).FromJSAnnotation(Of Dictionary(Of String, String))()
		End SyncLock

	End Sub

	Shared Sub Save()
		SyncLock __Lock
			IO.File.WriteAllText(MapFile, IDFileName.ToJSAnnotation)
		End SyncLock
	End Sub

End Class
