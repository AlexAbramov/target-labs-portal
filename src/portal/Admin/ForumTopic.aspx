<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ForumTopic.aspx.cs" Inherits="AdminForumTopicPage" Title="Forum Topic"  validateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">

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
            <asp:Label ID="lblTitle" runat="server" Text="Title:"></asp:Label></td>
        <td style="width: 100px">
            <asp:TextBox ID="tbName" runat="server" Width="300px"></asp:TextBox></td>
        <td style="width: 100px">
            <asp:RequiredFieldValidator ID="valName" runat="server" ControlToValidate="tbName"
                ErrorMessage="Required field" Visible="False"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label></td>
        <td style="width: 100px">
            <asp:TextBox ID="tbDescription" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
        <td style="width: 100px">
        </td>
    </tr>
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
            <asp:Label ID="Label6" runat="server" Text="Record Status:"></asp:Label></td>
        <td style="width: 100px"><asp:DropDownList ID="ddlStatus" runat="server" DataTextField="Name" DataValueField="Id" Width="200px">
        </asp:DropDownList></td>
        <td style="width: 100px">
        </td>
    </tr>
</table>

    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" /><asp:Label
        ID="lblResult" runat="server" EnableViewState="False" ForeColor="Green"></asp:Label>
</asp:Content>

