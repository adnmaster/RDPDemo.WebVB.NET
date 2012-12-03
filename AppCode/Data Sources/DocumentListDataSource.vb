Public Class DocumentListDataSource

	Property DocumentList As List(Of DocumentListDataSource)

	Sub New()
		_DocumentList = New List(Of DocumentListDataSource)
	End Sub

	Sub Add(ByVal DocumentInfo As RDP.Interfaces.DocumentInfo)

		Dim DocStruct As New DocumentListDataSource
		With DocStruct
			.ID = DocumentInfo.ID
			.Name = DocumentInfo.MetaDocument.Name
			.Extension = DocumentInfo.MetaDocument.DocExtension
			.Excerpt = DocumentInfo.Excerpt
			.DocTypeExt = DocumentInfo.DocType & " (Ext)".Replace("Ext", DocumentInfo.MetaDocument.DocExtension)
			.Words = DocumentInfo.MetaDocument.NumberOfWords

			.Topic = DocumentInfo.Status.InternalTopic
		End With

		_DocumentList.Add(DocStruct)

	End Sub

	Sub AddRange(ByVal ParamArray DocumentInfo() As RDP.Interfaces.DocumentInfo)

		For Each DocInfo In DocumentInfo
			Add(DocInfo)
		Next

	End Sub

	Sub AddRange(ByVal DocumentInfo As List(Of RDP.Interfaces.DocumentInfo))

		AddRange(DocumentInfo.ToArray)

	End Sub

	Property ID As String
	Property Name As String
	Property Extension As String

	Property Excerpt As String

	Property DocTypeExt As String
	Property Words As Long

	Private TopicSysName As String
	Property Topic As String
		Get
			Dim PotList As String() = TopicSysName.Split("/"c)
			Return String.Join(" - ", PotList)
			'Return TopicSysName
		End Get
		Set(ByVal value As String)
			TopicSysName = value
		End Set
	End Property

	Function [Select]() As List(Of DocumentListDataSource)
		Return DocumentList
	End Function

End Class
