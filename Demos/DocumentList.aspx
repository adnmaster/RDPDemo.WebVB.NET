<%@ Page Title="Document List" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="DocumentList.aspx.vb" Inherits="RDPDemo.DocumentList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DataList ID="DataList1" runat="server" RepeatLayout="Flow">
        <SeparatorTemplate>
            <br />
            <hr />
        </SeparatorTemplate>
        <ItemTemplate>
            <asp:HyperLink ID="Hyperlink" NavigateUrl='<%# "~/Demos/ViewFile.aspx?id=" & Eval("ID") & "&name=" & Eval("Name") & "&ext=" & Eval("Extension") %>'
                runat="server"><%# Eval("Name")%></asp:HyperLink>
            <br />
            <br />
            <asp:Label ID="Label1" Text='<%# Eval("Excerpt")%>' runat="server" />
            <br />
            <br />
            <asp:Label ID="Label2" Font-Italic="true" Text='<%# Eval("DocTypeExt") %>' runat="server" />
            /
            <asp:Label ID="Label3" Font-Italic="true" Text='<%# "Words: " & Eval("Words") %>'
                runat="server" />
            /
            <asp:Label ID="Label4" Font-Italic="true" Text='<%# "Possible Topic: " & Eval("Topic") %>'
                runat="server" />
        </ItemTemplate>
    </asp:DataList>
    <br />
    <br />
</asp:Content>
