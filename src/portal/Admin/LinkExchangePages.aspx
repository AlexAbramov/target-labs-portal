<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="LinkExchangePages.aspx.cs" Inherits="LinkExchangePages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
    <asp:GridView ID="gridView" runat="server" AllowSorting="True"
        AutoGenerateColumns="False" CellSpacing="3" PageSize="50">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataTextField="Id" HeaderText="Number" SortExpression="Id" Target="_blank" DataNavigateUrlFormatString="~/Admin/LinkExchange.aspx?pg={0}" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
        </Columns>
    </asp:GridView>
</asp:Content>