<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.vb" Inherits="RDPDemo._Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to "Real Data Project" Demo
    </h2>
    <p>
        <asp:Label ID="lblVersion" Text="Current version: 0.0.0.0" runat="server" />
    </p>
    <h3>
        Examples:
    </h3>
    <p>
        <ul>
            <li><a href="/Demos/TopicModeling.aspx">Topic Modeling</a></li>
            <li><a href="/Demos/FullTextSearch.aspx">Full Text Search</a></li>
        </ul>
       More examples are yet to come...
    </p>
</asp:Content>
