<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ArticleParam.aspx.cs" Inherits="WebSitePage" Title="Web site pages" validateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">

<table>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Key:"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbKey" runat="server" Width="500px"></asp:TextBox>
        </td>
        <td>
            </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblFilename" runat="server" Text="Value:"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbValue" runat="server" Width="500px" Height="250px" 
                TextMode="MultiLine"></asp:TextBox>
        </td>
        <td>
            </td>
    </tr>
</table>

    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" /><asp:Label
        ID="lblResult" runat="server" EnableViewState="False" ForeColor="Green"></asp:Label>
</asp:Content>

