<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="GalleryImage.aspx.cs" Inherits="AdminGalleryImage" Title="Gallery Image"  validateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
    <br />
&nbsp;<table>
    <tr>
        <td style="width: 100px">
            </td>
        <td style="width: 100px">
<asp:FileUpload id="fileUpload" runat="server" Width="400px"></asp:FileUpload></td>
        <td style="width: 100px">
            </td>
    </tr>
    <tr>
        <td style="width: 100px">
            </td>
        <td style="width: 100px"><asp:Label id="lblInfo" runat="server" EnableViewState="False"></asp:Label></td>
        <td style="width: 100px">
            </td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="Label1" runat="server" Text="File name:"></asp:Label></td>
        <td style="width: 100px">
            <asp:TextBox ID="tbFilename" runat="server" ReadOnly="True" Width="400px"></asp:TextBox></td>
        <td style="width: 100px">
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="lblTitle" runat="server" Text="Title:"></asp:Label></td>
        <td style="width: 100px">
            <asp:TextBox ID="tbName" runat="server" Width="400px"></asp:TextBox></td>
        <td style="width: 100px">
            <asp:RequiredFieldValidator ID="valName" runat="server" ControlToValidate="tbName"
                ErrorMessage="Required field" Visible="False"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="Label4" runat="server" Text="Description:"></asp:Label></td>
        <td style="width: 100px">
            <asp:TextBox ID="tbText" runat="server" TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox></td>
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
    <br />
    <br />
    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" /><asp:Label
        ID="lblResult" runat="server" EnableViewState="False" ForeColor="Green"></asp:Label>
</asp:Content>

