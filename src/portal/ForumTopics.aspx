<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="ForumTopics.aspx.cs" Inherits="ForumTopicsPage" Title="Forum Topics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
						<div class="block2">
       			<div class="inblock2">	
						<p class="path"><a href="Forums.aspx">Forums</a> / <%=forumName%></p>
						<p class="title2"><%=forumName%></p>
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
            <HeaderTemplate><table class="forum1 mainforum">
						<tr>
						<th class="first" style="width:auto"><div>Topic</div></th>
						<th style="width:auto">Messages</th>
						</tr>
            </HeaderTemplate>
            <ItemTemplate>
						<tr class="first">
						<td class="first"><p class="name">
						<a href='ForumMessages.aspx?ft=<%# Eval("Id")%>'><%# Eval("Name") %></a></p>
						</td>
						<td><b><%# Eval("MessageCount")%></b></td>
						</tr>
						</ItemTemplate>
						<FooterTemplate></table></FooterTemplate>
						</asp:Repeater>
          </div>
          <div class="clear">&nbsp;</div>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppConnectionString %>"
        SelectCommand="SELECT        ForumTopics.Id, ForumTopics.Name, COUNT(*) AS MessageCount FROM            ForumTopics LEFT OUTER JOIN    ForumMessages ON ForumTopics.Id = ForumMessages.ForumTopicId WHERE        (ForumTopics.ForumId = @ForumId) AND (ForumTopics.Status >= 0 and ForumMessages.Status >= 0) GROUP BY ForumTopics.Id, ForumTopics.Name">
					<SelectParameters>
					<asp:Parameter DefaultValue="0" Name="ForumId" Type="Int32" />
					</SelectParameters>
        </asp:SqlDataSource></asp:Content>

