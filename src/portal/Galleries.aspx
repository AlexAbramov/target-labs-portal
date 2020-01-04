<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Galleries.aspx.cs" Inherits="Galleries" Title="Galleries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
						<div class="title"><h1>Photo galleries</h1></div>
                   <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                   <HeaderTemplate><table>
                   </HeaderTemplate>
                   <ItemTemplate>
						<tr>
						<td><a href='Gallery.aspx?gl=<%# Eval("Id")%>'><img src='Gallery/<%# Eval("Logo")%>' alt='<%# Eval("Name") %>' /></a></td>
						<td style="width:90%"><p>&nbsp;&nbsp;<a href='Gallery.aspx?gl=<%# Eval("Id")%>'><%# Eval("Name") %></a></p>
						</td>						
						</tr>                   
						</ItemTemplate>
                   <FooterTemplate>
						</table>
                   </FooterTemplate>
                   </asp:Repeater>
						
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppConnectionString %>"
        SelectCommand="SELECT [Id], [Name], [Logo] FROM [Galleries]">
        </asp:SqlDataSource>
				
</asp:Content>

