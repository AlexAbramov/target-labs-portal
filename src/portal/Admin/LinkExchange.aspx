<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="LinkExchange.aspx.cs" Inherits="AdminLinkExchange" ValidateRequest="false"  %>
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
            </td>
        <td style="width: 100px; height: 13px">
            </td>
        <td style="width: 100px; height: 13px">
            </td>
    </tr>
    <tr>
        <td style="width: 100px; height: 13px">
            </td>
        <td style="width: 100px; height: 13px">
            </td>
        <td style="width: 100px; height: 13px">
            </td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="lblText" runat="server" Text="Text:"></asp:Label></td>
        <td style="width: 100px">
            <asp:TextBox ID="tbText" runat="server" Width="350px" TextMode="MultiLine" Height="400px"></asp:TextBox></td>
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
            </td>
        <td style="width: 100px">
            </td>
        <td style="width: 100px">
            </td>
    </tr>
    <tr>
        <td style="width: 100px">
            </td>
        <td style="width: 100px"></td>
        <td style="width: 100px">
        </td>
    </tr>
</table>

    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" /><asp:Label
        ID="lblResult" runat="server" EnableViewState="False" ForeColor="Green"></asp:Label>
</asp:Content>