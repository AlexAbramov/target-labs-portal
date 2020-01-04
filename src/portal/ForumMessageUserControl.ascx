<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForumMessageUserControl.ascx.cs" Inherits="ForumMessageUserControl" EnableViewState="false" %>
<table>
    <tr>
        <td style="width: 100px">
            </td>
        <td style="width: 100px">
            </td>
        <td style="width: 100px">
            </td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="lblTitle" runat="server" Text="Name:"></asp:Label></td>
        <td style="width: 100px">
            <asp:TextBox ID="tbName" runat="server" Width="300px" EnableViewState="True"></asp:TextBox></td>
        <td style="width: 100px">
            <asp:RequiredFieldValidator ID="valName" runat="server" ControlToValidate="tbName"
                ErrorMessage="Required field"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="lblText" runat="server" Text="Message:"></asp:Label></td>
        <td style="width: 100px">
            <asp:TextBox ID="tbText" runat="server" Height="200px" TextMode="MultiLine" Width="300px" EnableViewState="True"></asp:TextBox></td>
        <td style="width: 100px">
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbText"
						ErrorMessage="Required field"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td style="width: 100px">
            </td>
        <td style="width: 100px" valign="middle">
<asp:ImageButton ID="btnSave" runat="server" AlternateText="Add" CssClass="btn"
	Height="26" ImageUrl="imgs/btn_add.gif" OnClick="btnSave_Click" Width="91" /><br />
					<br />
					<asp:Label ID="lblResult" runat="server" EnableViewState="False" ForeColor="Green"></asp:Label></td>
        <td style="width: 100px">
            </td>
    </tr>
</table>