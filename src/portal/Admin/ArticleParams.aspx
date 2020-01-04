<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ArticleParams.aspx.cs" Inherits="ArticleParams" Title="Article Params" validateRequest="false" %>

<%@ Register Src="ArticleParamsUserControl.ascx" TagName="ArticleParamsUserControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
<uc1:ArticleParamsUserControl ID="ucArticleParams" runat="server" />
</asp:Content>

