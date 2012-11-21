Imports RDP.Client
Imports RDP.Interfaces

Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		Dim ServiceDescription As RDP.Interfaces.ServiceContractDescription = Nothing
		Dim ServiceDescriptionFromCache As Boolean =
		 LatentCache.GetCacheItem("Service.ServiceDescription", Nothing, False,
		 ServiceDescription, Function() RDPGateway.RDPClient.Service.ServiceDescription)

		lblVersion.Text = String.Format("Current version: {0}", ServiceDescription.Version)

	End Sub

End Class