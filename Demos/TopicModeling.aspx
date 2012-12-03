<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="TopicModeling.aspx.vb"
    Inherits="RDPDemo.TopicModeling" Title="Topic Modeling" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <p>
        Topics:
    </p>
    <p>
        <asp:DataList ID="Datalist1" runat="server">
            <SeparatorTemplate>
            </SeparatorTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" Text='<%# Eval("Name") %>' runat="server" />
                - Importance:
                <asp:Label ID="Label2" Font-Italic="true" Text='<%# Eval("LinkDept") %>' runat="server" />
            </ItemTemplate>
        </asp:DataList>
    </p>
</asp:Content>
