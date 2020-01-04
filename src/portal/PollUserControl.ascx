<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PollUserControl.ascx.cs" Inherits="PollUserControl" %>
<link id="LinkPollUserControl" href="~/res/css/style.css" rel="stylesheet" type="text/css" visible="false" runat="server"/>
  			<div class="vote">
					<p><strong><asp:Label ID="lblQuestion" runat="server"></asp:Label></strong></p>
					<asp:RadioButtonList ID="rblAnswers" runat="server" DataSourceID="SqlDataSource1" DataTextField="Answer" DataValueField="Id">
					</asp:RadioButtonList>
					<asp:ImageButton ID="btnVote" runat="server" ImageUrl="imgs/btn_vote.gif" OnClick="btnVote_Click" />
					<p><a href="PollResults.aspx">Poll results</a></p>
				</div>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppConnectionString %>"
	SelectCommand="SELECT [Id], [Answer] FROM [PollAnswers] WHERE (([Status] > 0) AND ([PollId] = @PollId))">
	<SelectParameters>
		<asp:Parameter Name="PollId" Type="Int32" />
	</SelectParameters>
</asp:SqlDataSource>
