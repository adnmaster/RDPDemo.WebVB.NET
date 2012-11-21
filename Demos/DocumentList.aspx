<%@ Page Title="Document List" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="DocumentList.aspx.vb" Inherits="RDPDemo.DocumentList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DataList ID="DataList1" runat="server" RepeatLayout="Flow">
    <SeparatorTemplate>
    <hr />
    </SeparatorTemplate>
        <ItemTemplate>
            <asp:HyperLink ID="Hyperlink" NavigateUrl='<%# "~/Demos/ViewFile.aspx?id=" & Eval("ID") & "&name=" & Eval("Name") & "&ext=" & Eval("Extension") %>'
                runat="server"><%# Eval("Name")%></asp:HyperLink>
            <br />
            <br />
            <asp:Label ID="Label1" Text='<%# Eval("Excerpt")%>' runat="server" />
        </ItemTemplate>
        </asp:DataList>
 </asp:Content>
