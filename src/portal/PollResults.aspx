<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="PollResults.aspx.cs" Inherits="PollResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
			    <div class="title"><h1>Poll results</h1></div>
    <asp:Repeater ID="Repeater1" runat="server" >
        <HeaderTemplate>
        <table>
        </HeaderTemplate>
        <ItemTemplate>
        <tr><td colspan='3'>
        <asp:Label ID="Label1" runat="server" Text='<%# CheckPollHeader((int)Eval("Id"),(int)Eval("PollId"))%>'></asp:Label>
        </td></tr>
        <tr>
        <td></td>
        <td><%# Eval("CountPercent")%>%&nbsp;&nbsp;</td>
        <td><%# Eval("Answer")%></td>
        </tr>
        <tr><td colspan='3'>
        <asp:Label ID="Label2" runat="server" Text='<%# CheckPollFooter((int)Eval("Id"),(int)Eval("PollId"))%>'></asp:Label>        
        </td></tr>
        <tr>

        </ItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
    </asp:Repeater>
				<p></p>
</asp:Content>