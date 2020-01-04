<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Polls.aspx.cs" Inherits="Polls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
    <asp:GridView ID="gridView" runat="server" AllowSorting="True"
        AutoGenerateColumns="False" CellSpacing="3" PageSize="50">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Admin/Poll.aspx?pl={0}" DataTextField="Id" HeaderText="Number"
                NavigateUrl="~/Admin/Poll.aspx?pl={0}" Text="Id" SortExpression="Id" Target="_blank" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Admin/Poll.aspx?pl={0}" DataTextField="Question" HeaderText="Question"
                Text="Question" SortExpression="Question" Target="_blank"/>
            <asp:BoundField DataField="Symbol" HeaderText="Status" SortExpression="Status" />
        </Columns>
    </asp:GridView>
    &nbsp;&nbsp;
    <br />
    <asp:HyperLink ID="hlAdd" runat="server" Target="_blank">Add</asp:HyperLink>
</asp:Content>