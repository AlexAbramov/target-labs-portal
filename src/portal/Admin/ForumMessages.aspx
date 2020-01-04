<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ForumMessages.aspx.cs" Inherits="ForumMessagesAdminPage" Title="Forum Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
    <asp:GridView ID="gridView" runat="server" AllowSorting="True"
        AutoGenerateColumns="False" CellSpacing="3" PageSize="50">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Admin/ForumMessage.aspx?fm={0}" DataTextField="Id" HeaderText="Number"
                NavigateUrl="~/Admin/ForumMessage.aspx?fm={0}" Text="Id" SortExpression="Id" Target="_blank" />
						<asp:TemplateField HeaderText="Date" SortExpression="Date">
							<ItemTemplate>
								<asp:Label ID="Label1" runat="server" Text='<%# Eval("Date", "{0:mm:hh dd.MM.yy}") %>'></asp:Label>
							</ItemTemplate>
						</asp:TemplateField>
            <asp:BoundField DataField="UserName" HeaderText="Author" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Admin/ForumMessage.aspx?fm={0}" DataTextField="Text" HeaderText="Message"
              Text="Text"  Target="_blank"/>
            <asp:BoundField DataField="Symbol" HeaderText="Status" SortExpression="Status" />
        </Columns>
    </asp:GridView>
    &nbsp;&nbsp;
    <br />
    <asp:HyperLink ID="hlAdd" NavigateUrl="ForumMessage.aspx" runat="server" Target="_blank">Add</asp:HyperLink>
</asp:Content>