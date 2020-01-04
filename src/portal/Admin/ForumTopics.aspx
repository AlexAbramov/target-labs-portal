<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ForumTopics.aspx.cs" Inherits="ForumTopicsAdminPage" Title="Forum Topics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
    <asp:GridView ID="gridView" runat="server" AllowSorting="True"
        AutoGenerateColumns="False" CellSpacing="3" PageSize="50">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Admin/ForumTopic.aspx?ft={0}" DataTextField="Id" HeaderText="Number"
                NavigateUrl="~/Admin/ForumTopic.aspx?ft={0}" Text="Id" SortExpression="Id" Target="_blank" />
						<asp:TemplateField HeaderText="Date" SortExpression="Date">
							<ItemTemplate>
								<asp:Label ID="Label1" runat="server" Text='<%# Eval("Date", "{0:dd.MM.yy}") %>'></asp:Label>
							</ItemTemplate>
						</asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Admin/ForumTopic.aspx?ft={0}" DataTextField="Name" HeaderText="Title"
                Text="Name" SortExpression="Name" Target="_blank"/>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Admin/ForumMessages.aspx?ft={0}" HeaderText="Messages"
                Text="List" SortExpression="Id" Target="_blank"/>
            <asp:BoundField DataField="Symbol" HeaderText="Status" SortExpression="Status" />
        </Columns>
    </asp:GridView>
    &nbsp;&nbsp;
    <br />
    <asp:HyperLink ID="hlAdd" NavigateUrl="ForumTopic.aspx" runat="server" Target="_blank">Add</asp:HyperLink>
</asp:Content>