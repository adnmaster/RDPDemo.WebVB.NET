<%@ Page Title="About RDP Demo Project" Language="vb" MasterPageFile="~/Site.Master"
    AutoEventWireup="false" CodeBehind="About.aspx.vb" Inherits="RDPDemo.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About
    </h2>
    <h4>
        Real Data Project Demo
    </h4>
    <p>
        This demo illustrates the basic use of the RDP API.<br />
        All data is read-only and hosted under the free plan.
    </p>
    <p>
        Seeking to concise a general-purpose demonstration some features may not be addressed.<br />
        For scenarios that are more sophisticated there is <a href="http://adnmaster.apphb.com/reference">
            documentation at our website</a>.
    </p>
    <%-- <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">
            www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>--%>
</asp:Content>
