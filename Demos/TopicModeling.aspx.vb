Public Class TopicModeling
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		RDPGateway.RDPClient.TopicModeling.GetTopics()

    End Sub

End Class