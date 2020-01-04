<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PollAnswersUserControl.ascx.cs" Inherits="PollAnswersUserControl" %>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataMember="DefaultView"
    DataSourceID="SqlDataSource1">
    <Columns>
        <asp:HyperLinkField DataTextField="Id" HeaderText="Number" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="PollAnswer.aspx?pa={0}" NavigateUrl="~/Admin/PollAnswer.aspx" Target="_blank" />
        <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="PollAnswer.aspx?pa={0}"
            DataTextField="Answer" HeaderText="Answer variants" Target="_blank" />
        <asp:BoundField DataField="Symbol" HeaderText="Status" SortExpression="Symbol" />
    </Columns>
</asp:GridView>
<asp:HyperLink ID="hlAddPollAnswer" runat="server" NavigateUrl="PollAnswer.aspx" Target="_blank">Add answer</asp:HyperLink>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppConnectionString %>"
    SelectCommand="SELECT PollAnswers.*, Statuses.Symbol FROM PollAnswers INNER JOIN Statuses ON PollAnswers.Status = Statuses.Id where PollId=@PollId">
    <SelectParameters>
        <asp:Parameter DefaultValue="0" Name="PollId" />
    </SelectParameters>
</asp:SqlDataSource>
&nbsp;
