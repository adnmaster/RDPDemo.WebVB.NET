Imports System.Web.Configuration
Imports RDP.Client

Public Class RDPGateway

	Private Shared _RDPClient As V1.RDPClient
	Shared ReadOnly Property RDPClient As V1.RDPClient
		Get

			If _RDPClient Is Nothing Then
				Set_RDPClient()
			End If

			Return _RDPClient

		End Get
	End Property

	Private Structure RDPConfig
		Public RDPUsername, RDPVerificationKey,
		 RDPMashapePublicKey, RDPMashapePrivateKey,
		 ProductionProxy, TestProxy As String
	End Structure

	Private Shared Sub Set_RDPClient()

#If DEBUG Then
		UseLocalConfig()
		Exit Sub
#End If

		UseHostedConfig()

	End Sub

	Private Shared Sub UseLocalConfig()


		Dim RDPConfigFile As String = Hosting.HostingEnvironment.MapPath("~/RDPClientConfig.json")
		Dim RDPConfigJson As String = IO.File.ReadAllText(RDPConfigFile)
		Dim RDPConfig As RDPConfig = RDPConfigJson.FromJSAnnotation(Of RDPConfig)()

		Dim RDPUsername As String = RDPConfig.RDPUsername
		Dim RDPVerificationKey As String = RDPConfig.RDPVerificationKey
		Dim RDPMashapePublicKey As String = RDPConfig.RDPMashapePublicKey
		Dim RDPMashapePrivateKey As String = RDPConfig.RDPMashapePrivateKey

		Dim ProductionProxy As String = RDPConfig.ProductionProxy
		Dim TestProxy As String = RDPConfig.TestProxy

		Dim MashapeClient As New RDP.Client.RDPMashapeClient(
		 RDPMashapePublicKey, RDPMashapePrivateKey, RDPUsername, RDPVerificationKey,
		  False, RDPMashapeClient.Proxy.Test, ProductionProxy, TestProxy)

		_RDPClient = New V1.RDPClient(MashapeClient)


	End Sub

	Private Shared Sub UseHostedConfig()

		Dim AppSettings As NameValueCollection = WebConfigurationManager.AppSettings

		Dim RDPUsername As String = AppSettings("RDPUsername")
		Dim RDPVerificationKey As String = AppSettings("RDPVerificationKey")
		Dim RDPMashapePublicKey As String = AppSettings("RDPMashapePublicKey")
		Dim RDPMashapePrivateKey As String = AppSettings("RDPMashapePrivateKey")

		Dim MashapeClient As New RDP.Client.RDPMashapeClient(
		 RDPMashapePublicKey, RDPMashapePrivateKey, RDPUsername, RDPVerificationKey)

		_RDPClient = New V1.RDPClient(MashapeClient)

	End Sub

End Class
