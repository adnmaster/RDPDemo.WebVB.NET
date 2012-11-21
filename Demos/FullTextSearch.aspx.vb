Public Class FullTextSearch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		RDPGateway.RDPClient.FullTextSearch.Search("")

    End Sub

End Class