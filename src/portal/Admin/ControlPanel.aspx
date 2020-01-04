<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ControlPanel.aspx.cs" Inherits="Admin_ControlPanel" Title="Control Panel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
    <asp:Button ID="btnResetAppCache" runat="server" OnClick="btnResetAppCache_Click"
        Text="Reset app cache" />
    <asp:Label ID="lblResult" runat="server" EnableViewState="False" ForeColor="Green"></asp:Label>
</asp:Content>

