<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" Title="Administration Start Page" %>
<%@ Register Src="ArticlesUserControl.ascx" TagName="ArticlesUserControl" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
    <uc2:ArticlesUserControl id="ucArticles" runat="server" />
</asp:Content>

