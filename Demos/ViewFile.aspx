<%@ Page Title="View Document File" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="ViewFile.aspx.vb" Inherits="RDPDemo.ViewFile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label ID="DocContent" Text="<Content>" runat="server" />
    
    <asp:LinkButton ID="DownloadDoc2"   runat="server"
        Text="Download Document" />

</asp:Content>
