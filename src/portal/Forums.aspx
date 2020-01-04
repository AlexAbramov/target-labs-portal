<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Forums.aspx.cs" Inherits="ForumsPage" Title="Forums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
						<div class="block2">
       			<div class="inblock2">	
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
            <HeaderTemplate><table class="forum1 mainforum">
						<tr>
						<th class="first" style="width:auto"><div>Forum</div></th>
						<th style="width:auto">Themes</th>
						</tr>
            </HeaderTemplate>
            <ItemTemplate>
						<tr class="first">
						<td class="first"><p class="name">
						<a href='ForumTopics.aspx?fr=<%# Eval("ForumId")%>'><%# Eval("Name") %></a></p>
						</td>
						<td><b><%# Eval("TopicCount")%></b></td>
						</tr>
						</ItemTemplate>
						<FooterTemplate></table></FooterTemplate>
						</asp:Repeater>
          </div>
          <div class="clear">&nbsp;</div>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppConnectionString %>"
        SelectCommand="SELECT ForumTopics.ForumId, Forums.Name, COUNT(*) AS TopicCount FROM Forums LEFT OUTER JOIN ForumTopics ON Forums.Id = ForumTopics.ForumId WHERE (Forums.Status >= 0 and ForumTopics.Status >= 0) GROUP BY ForumTopics.ForumId, Forums.Name, CommunityId ORDER BY Forums.CommunityId, Forums.Name">
					<SelectParameters>
					</SelectParameters>
        </asp:SqlDataSource>

</asp:Content>

