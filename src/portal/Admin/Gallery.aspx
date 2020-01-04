<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="AdminGalleryPage" Title="Gallery"  validateRequest="false" %>
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
        <td style="width: 100px; height: 13px">
            <asp:Label ID="Label2" runat="server" Text="Logo:"></asp:Label></td>
        <td style="width: 100px; height: 13px">
            <asp:FileUpload ID="fileUpload" runat="server" Width="400px" /><br />
            <asp:Label ID="lblLogo" runat="server"></asp:Label></td>
        <td style="width: 100px; height: 13px">
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
            <asp:Label ID="lblText" runat="server" Text="Text:"></asp:Label></td>
        <td style="width: 100px">
            <asp:TextBox ID="tbText" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
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

