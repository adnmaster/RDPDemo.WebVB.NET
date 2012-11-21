Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)

		RDP.Client.LatentCache.SlidingExpiration = TimeSpan.FromDays(1)
		RDP.Client.LatentCache.HostedEnvironment = True

    End Sub


    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

End Class