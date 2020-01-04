<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Forums.aspx.cs" Inherits="ForumsAdminPage" Title="Forums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
    <asp:GridView ID="gridView" runat="server" AllowSorting="True"
        AutoGenerateColumns="False" CellSpacing="3" PageSize="50">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Admin/Forum.aspx?fr={0}" DataTextField="Id" HeaderText="Number"
                NavigateUrl="~/Admin/Forum.aspx?fr={0}" Text="Id" SortExpression="Id" Target="_blank" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Admin/Forum.aspx?fr={0}" DataTextField="Name" HeaderText="Title"
                Text="Name" SortExpression="Name" Target="_blank"/>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Admin/ForumTopics.aspx?fr={0}" HeaderText="Themes"
                Text="List" SortExpression="Id" Target="_blank"/>
            <asp:BoundField DataField="Symbol" HeaderText="Status" SortExpression="Status" />
        </Columns>
    </asp:GridView>
    &nbsp;&nbsp;
    <br />
    <asp:HyperLink ID="hlAdd" NavigateUrl="Forum.aspx" runat="server" Target="_blank">Add</asp:HyperLink>
</asp:Content>