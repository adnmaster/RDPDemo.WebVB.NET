Imports RDP.Interfaces
Imports RDP.Client

Public Class TopicModeling
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		Dim Topics As List(Of Topic) = Nothing
		Dim TopicsFromCache As Boolean =
		 LatentCache.GetCacheItem("GetTopics", Nothing, False,
		 Topics, Function() RDPGateway.RDPClient.TopicModeling.GetTopics())

		Topics.RemoveAll(Function(T) (T.Used = False) Or (T.LinkDept < 0))

		Dim TopicListDataSource As New TopicListDataSource
		TopicListDataSource.AddRange(Topics)

		Datalist1.DataSource = TopicListDataSource.Select
		Datalist1.DataBind()

	End Sub

End Class