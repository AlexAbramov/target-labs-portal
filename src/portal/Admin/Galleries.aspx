<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Galleries.aspx.cs" Inherits="GalleriesPage" Title="Galleries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
    <asp:GridView ID="gridView" runat="server" AllowSorting="True"
        AutoGenerateColumns="False" CellSpacing="3" PageSize="50">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Admin/Gallery.aspx?gl={0}" DataTextField="Id" HeaderText="Number"
                NavigateUrl="~/Admin/Gallery.aspx?gl={0}" Text="Id" SortExpression="Id" Target="_blank" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Admin/Gallery.aspx?gl={0}" DataTextField="Name" HeaderText="Title"
                Text="Name" SortExpression="Name" Target="_blank"/>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Admin/GalleryImages.aspx?gl={0}" HeaderText="Photos"
                Text="List" Target="_blank"/>
            <asp:BoundField DataField="Symbol" HeaderText="Status" SortExpression="Status" />
        </Columns>
    </asp:GridView>
    &nbsp;&nbsp;
    <br />
    <asp:HyperLink ID="hlAdd" NavigateUrl="Gallery.aspx" runat="server" Target="_blank">Add</asp:HyperLink>
</asp:Content>