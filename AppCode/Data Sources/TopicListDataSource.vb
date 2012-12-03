Public Class TopicListDataSource

	Property TopicList As List(Of TopicListDataSource)
	Private Max As Integer = 0

	Sub New()
		_TopicList = New List(Of TopicListDataSource)
	End Sub

	Sub Add(ByVal Topic As RDP.Interfaces.Topic)

		Dim TopicStruct As New TopicListDataSource
		With TopicStruct
			.SysName = Topic.SysName
			.Alias = Topic.Alias
			SetLinkDept(Topic.LinkDept)
		End With

		_TopicList.Add(TopicStruct)

	End Sub

	Sub AddRange(ByVal ParamArray Topics() As RDP.Interfaces.Topic)

		For Each Topic In Topics
			Add(Topic)
		Next

	End Sub

	Sub AddRange(ByVal Topics As List(Of RDP.Interfaces.Topic))

		AddRange(Topics.ToArray)

	End Sub

	Property SysName As String
	Property [Alias] As String

	Private _LinkDept As Integer
	ReadOnly Property LinkDept As String
		Get
			Return _LinkDept & "/" & (Max + 1)
		End Get
	End Property

	Sub SetLinkDept(ByVal value As Integer)
		_LinkDept = value
		If value > Max Then
			Max = value
		End If
	End Sub

	ReadOnly Property Name As String
		Get
			Return ToString()
		End Get
	End Property

	Public Overrides Function ToString() As String

		If SysName.Equals([Alias], StringComparison.Ordinal) Then
			Return SysName
		Else
			Return String.Format("{0} ({1})", SysName, [Alias])
		End If

	End Function

	Function [Select]() As IOrderedEnumerable(Of TopicListDataSource)
		Return _TopicList.OrderByDescending(Function(T) T.LinkDept)
	End Function

End Class
