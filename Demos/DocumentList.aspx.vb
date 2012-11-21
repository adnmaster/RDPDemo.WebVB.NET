Imports RDP.Client
Imports RDP.Interfaces

Public Class DocumentList
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		Dim DocumentInfoList As List(Of RDP.Interfaces.DocumentInfo) = Nothing
		Dim DocumentInfoListFromCache As Boolean =
		 LatentCache.GetCacheItem("GetDocumentInfoList.50.0", Nothing, False,
		 DocumentInfoList, Function() RDPGateway.RDPClient.DocumentServer.GetDocumentInfoList(CStr(50), CStr(0)))

		SetDataSource(DocumentInfoList)

	End Sub

	Private Sub SetDataSource(ByVal DocInfoList As List(Of RDP.Interfaces.DocumentInfo))

		Dim DocumentStruct As New DocumentListDataSource

		DocumentStruct.AddRange(DocInfoList)

		DataList1.DataSource = DocumentStruct.Select
		DataList1.DataBind()

	End Sub


End Class