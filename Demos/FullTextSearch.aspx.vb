Imports RDP.Interfaces
Imports RDP.Client

Public Class FullTextSearch
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		'SuggestSearchTerms()

		If IsPostBack Then
			Exit Sub
		End If

		SampleTerms()

	End Sub

	Sub SampleTerms()

		Dim DocumentInfoList As List(Of RDP.Interfaces.DocumentInfo) = Nothing
		Dim DocumentInfoListFromCache As Boolean =
		 LatentCache.GetCacheItem("GetDocumentInfoList.50.0", Nothing, False,
		 DocumentInfoList, Function() RDPGateway.RDPClient.DocumentServer.GetDocumentInfoList(CStr(50), CStr(0)))

		If Not DocumentInfoListFromCache Then
			For Each Doc In DocumentInfoList
				LatentCache.SetCacheItemManually(Doc.ID, Doc)
			Next
		End If

		Dim SampleTerms As New List(Of String)

		DocumentInfoList.ForEach(
		 Sub(DocInfo)
			 Dim Attributes = DocInfo.MetaDocument.Attributes.Select(Function(Attr) Attr.Name)
			 SampleTerms.AddRange(Attributes)
			 SampleTerms.AddRange(DocInfo.MetaDocument.Keywords)
		 End Sub)

		Dim Rnd As New Random(1247)
		Dim TopTenSamples As IEnumerable(Of String) =
		 SampleTerms.Distinct.ToList.OrderBy(Of Integer)(
		 Function(Item) Rnd.Next(Integer.MaxValue)).Take(10)

		lblQuerySummary.Text = "<p>Try: " & String.Join(" ", TopTenSamples) & "</p>"

	End Sub

	Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click

		Dim Query As String = txtQuery.Text

		If QueryFieldValidator.Enabled = False AndAlso
		  String.IsNullOrWhiteSpace(Query) Then
			SuggestSearchTerms()
			Exit Sub
		End If

		Dim Result As FastSearchResult =
		 RDPGateway.RDPClient.FullTextSearch.FastSearch2(Query)

		ShowResult(Result)

		If Result.Count = 0 Then
			SampleTerms()
		Else

			BroadResults(Query)
			ShowResult(Result)

		End If

	End Sub

	Sub ShowResult(ByVal Result As FastSearchResult)

		lblResultCount.Text = "Result Count: " & Result.Count
		'lblQuerySummary.Text &= "<p>" & Result.ToJSAnnotation & "</p>"

		Dim ResultDocs As New List(Of RDP.Interfaces.DocumentInfo)

		For Each DocID In Result.DocumentIDs

			Dim CurrentDocID As String = DocID

			Dim DocInfo As RDP.Interfaces.DocumentInfo = Nothing
			Dim DocInfoFromCache As Boolean =
			 LatentCache.GetCacheItem(CurrentDocID, Nothing, False,
			 DocInfo, Function() RDPGateway.RDPClient.DocumentServer.GetDocumentInfo(CurrentDocID))

			ResultDocs.Add(DocInfo)

		Next

		Dim DocumentStruct As New DocumentListDataSource

		DocumentStruct.AddRange(ResultDocs)

		DataList1.DataSource = DocumentStruct.Select
		DataList1.DataBind()

	End Sub

	Sub BroadResults(ByVal Query As String)

		Dim F3L = Query.Split(" "c).Select(
		  Function(Term)
			  If Term.Length > 2 Then
				  Return Term.Substring(0, 3)
			  Else
				  Return Term
			  End If
		  End Function)

		Dim WhyNot As String =
		 "OK! Why not try this, post only first 3 letters:<br/>Like: '" & String.Join(" ", F3L) & "'"

		lblQuerySummary.Text = "<p>" & WhyNot & "</p><hr/>"

	End Sub

	Private Sub SuggestSearchTerms()
		Throw New NotImplementedException
	End Sub

End Class