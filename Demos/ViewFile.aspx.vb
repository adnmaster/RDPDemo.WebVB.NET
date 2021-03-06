﻿Imports RDP.Client

Public Class ViewFile
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		Dim QueryString As NameValueCollection = Request.QueryString

		If QueryString.Count = 0 Then
			Response.Redirect("~/Demos/DocumentList.aspx")
		End If

		DocumentsMap.Load()

		Dim FileName As String

		Dim DocumentID As String = QueryString("id")
		Dim DocName As String = QueryString("name")
		Dim Extension As String = QueryString("ext")
		If Not FileExists(DocumentID) Then
			FileName = DownloadAndSaveFile(DocumentID, DocName & Extension)
		Else
			FileName = DocumentsMap.IDFileName(DocumentID)
		End If

		If Extension.ToLower.Equals(".text") OrElse Extension.ToLower.Equals(".txt") Then

			DocContent.Text = IO.File.ReadAllText(FileName)

			DocContent.Text &= <p>You may download the file.</p>.ToString

		Else

			DocContent.Text = "This document cannot be viewed directly. Instead you may download the file."

		End If

		DownloadDoc2.Visible = True
		DownloadDoc2.CommandArgument = DocName & Extension

		Title = DocName

	End Sub

	Private Function FileExists(ByVal DocumentID As String) As Boolean
		Return DocumentsMap.IDFileName.ContainsKey(DocumentID)
	End Function

	Private Function DownloadAndSaveFile(ByVal DocumentID As String, ByVal FileName As String) As String

		If FileExists(DocumentID) Then
			Return DocumentsMap.IDFileName(DocumentID)
		End If

		Dim FullFileName As String = Hosting.HostingEnvironment.MapPath("~/App_Data/Files/" & FileName)

		'Check if the file exists physically
		If IO.File.Exists(FullFileName) Then
			'No need to download... we know that file names are unique
			GoTo Downloaded
		End If

		Dim FileStream As IO.Stream =
		 RDPGateway.RDPClient.DocumentServer.DownloadOriginalDocument(DocumentID)

		'Note: About RDP.Client.RDPClient.DocumentServer.DownloadOriginalDocument(System.String) Mehod
		'The original document 'Name' and 'Extension' are contained in the HTTP ReST response headers
		'("Content-Disposition", "ContentType", "ContentLength").
		'We don't know if they were specified before the upload, so
		'it's not crucial in our design, but different needs would require
		'a different approach to upload/download the original file.

		'FileShare.None, File is not shared with other processes, throws I/O exceptions.
		Dim SW As New IO.FileStream(FullFileName,
		 IO.FileMode.OpenOrCreate, IO.FileAccess.Write, IO.FileShare.None)

		Dim BytesRead As Integer = 0

		Do
			Dim Buffer(32767) As Byte
			BytesRead = FileStream.Read(Buffer, 0, Buffer.Length)

			If BytesRead = 0 Then
				Exit Do
			End If

			SW.Write(Buffer, 0, BytesRead)

		Loop

		SW.Flush()
		SW.Close()
		SW.Dispose()

Downloaded:
		DocumentsMap.IDFileName.Add(DocumentID, FullFileName)
		DocumentsMap.Save()

		Return FullFileName

	End Function

	Private Sub DownloadDoc2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DownloadDoc2.Click

		Dim FullFileName As String =
		 Hosting.HostingEnvironment.MapPath("~/App_Data/Files/" & DownloadDoc2.CommandArgument)

		Response.AddHeader("Content-Disposition", "attachment; filename=" & DownloadDoc2.CommandArgument)
		Response.ContentType = "application/octet-stream"
		Response.TransmitFile(FullFileName)

	End Sub

End Class