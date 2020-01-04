<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="ForumMessages.aspx.cs" Inherits="ForumMessagesPage" Title="Forum Messages" %>

<%@ Register Src="ForumMessageUserControl.ascx" TagName="ForumMessageUserControl"
	TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
						<p class="path"><a href="Forums.aspx">Forums</a> / <a href="ForumTopics.aspx?fr=<%=forumId%>"><%=forumName%></a> / <%=forumTopicName%></p>
						<p class="title2"><%=forumTopicName%></p>
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
            <HeaderTemplate><table class="forum1 mainforum">
						<tr>
						<th class="first" style="width:auto"><div>Author</div></th>
						<th style="width:auto">Message</th>
						<th style="width:auto">Date</th>
						</tr>
            </HeaderTemplate>
            <ItemTemplate>
						<tr class="first">
						<td class="first">
						<%# Eval("UserName")%><br />
						<asp:Image ID="Image1" runat="server" Visible='<%# Utils.IsVisible(Eval("Picture")) %>' ImageUrl='<%# "Images/Users/"+Eval("Picture")%>' CssClass="news_pic" AlternateText='<%# Eval("UserName")%>' />
						</td>
						<td><%# Eval("Text")%></td>
						<td class="last_replic"><span><%# Eval("Date", "{0:MM.dd.yyyy}")%></span></td>
						</tr>
						</ItemTemplate>
						<FooterTemplate></table></FooterTemplate>
						</asp:Repeater>
							 <uc1:ForumMessageUserControl id="ucForumMessage" runat="server">
							 </uc1:ForumMessageUserControl>
          <div class="clear">&nbsp;</div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppConnectionString %>"
        SelectCommand="SELECT ForumMessages.Id, ForumMessages.Date, ForumMessages.UserName, ForumMessages.Text, Picture FROM ForumMessages left join UserInfo on UserInfo.Id=UserId WHERE (ForumTopicId = @ForumTopicId) AND (ForumMessages.Status >= 0) order by ForumMessages.Id desc">
					<SelectParameters>
					<asp:Parameter DefaultValue="0" Name="ForumTopicId" Type="Int32" />
					</SelectParameters>
        </asp:SqlDataSource>
        </asp:Content>

