<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfoUserControl.ascx.cs" Inherits="UserInfoUserControl" EnableViewState="true" %>
<link id="LinkUserInfoUserControl" href="~/res/css/style.css" rel="stylesheet" type="text/css" visible="false" runat="server"/>

		<table class="post_theme">
			<tr>
				<td class="pole" colspan="2" style="text-align: center">
					Profile</td>
				<td>
				</td>
			</tr>
    <tr>
        <td class="pole">
					Name:</td>
        <td >
            <asp:TextBox ID="tbName" runat="server"
                Width="300px"></asp:TextBox></td>
        <td >
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbName"
						ErrorMessage="Required field" Visible="False"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="pole">Email:</td>
        <td>
            <asp:TextBox ID="tbEmail" runat="server"  
                Width="300px"></asp:TextBox></td>
        <td >
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbEmail"
                ErrorMessage="Required field" Visible="False"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbEmail"
                ErrorMessage="Wrong email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Visible="False"></asp:RegularExpressionValidator></td>
    </tr>
			<tr>
				<td class="pole">
					(Picture):</td>
				<td>
					<asp:FileUpload ID="fileUpload" runat="server" Width="300px" /><br />
					<asp:Label ID="lblPicture" runat="server" EnableViewState="False"></asp:Label></td>
				<td>
				</td>
			</tr>
			<tr>
				<td class="pole">
				</td>
				<td>
				</td>
				<td>
				</td>
			</tr>
			<tr>
				<td class="pole" colspan="2" style="text-align: center">
					Change password</td>
				<td>
				</td>
			</tr>
    <tr>
        <td class="pole">
					</td>
        <td >
            <asp:TextBox ID="tbPassword" runat="server"
                Width="150px" TextMode="Password" Visible="False"></asp:TextBox></td>
        <td >
        </td>
    </tr>
    <tr>
        <td class="pole">
					New password:</td>
        <td >
            <asp:TextBox ID="tbNewPassword" runat="server"
                Width="150px" TextMode="Password"></asp:TextBox></td>
        <td >
        </td>
    </tr>
    <tr>
        <td class="pole">
					Confirm new password:</td>
        <td >
            <asp:TextBox ID="tbConfirmNewPassword" runat="server"
                Width="150px" TextMode="Password"></asp:TextBox></td>
        <td >
					<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbNewPassword"
						ControlToValidate="tbConfirmNewPassword" ErrorMessage="Should match the new password"></asp:CompareValidator></td>
    </tr>
        		</table>
<br />
<br />
            <asp:HiddenField ID="hfId" runat="server" />


