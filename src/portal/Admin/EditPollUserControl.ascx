<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditPollUserControl.ascx.cs" Inherits="EditPollUserControl"%>
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
            <asp:Label ID="Label4" runat="server" Text="Question:"></asp:Label></td>
        <td style="width: 100px">
            <asp:TextBox ID="tbQuestion" runat="server" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox></td>
        <td style="width: 100px">
            <asp:RequiredFieldValidator ID="valQuestion" runat="server" ControlToValidate="tbQuestion"
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
