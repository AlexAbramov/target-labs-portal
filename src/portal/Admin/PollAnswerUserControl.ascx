<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PollAnswerUserControl.ascx.cs" Inherits="PollAnswerUserControl"%>
<table>
    <tr>
        <td style="width: 100px">
            </td>
        <td style="width: 100px"></td>
        <td style="width: 100px">
            </td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="Label4" runat="server" Text="Answer variant:"></asp:Label></td>
        <td style="width: 100px">
            <asp:TextBox ID="tbAnswer" runat="server" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox></td>
        <td style="width: 100px">
            <asp:RequiredFieldValidator ID="valAnswer" runat="server" ControlToValidate="tbQuestion"
                ErrorMessage="Required field" Visible="False"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="Label6" runat="server" Text="Record Status:"></asp:Label></td>
        <td style="width: 100px"><asp:DropDownList ID="ddlStatus" runat="server" DataTextField="Name" DataValueField="Id" Width="200px">
        </asp:DropDownList></td>
        <td style="width: 100px">
        </td>
    </tr>
</table>
&nbsp;
