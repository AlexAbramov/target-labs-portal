<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Page.aspx.cs" Inherits="ArticlePage" Title=""  %>
<%@ Register Src="ArticleUserControl.ascx" TagName="ArticleUserControl" TagPrefix="uc1" %>
<%@ Register Src="ArticlesUserControl.ascx" TagName="ArticlesUserControl" TagPrefix="uc2" %>
<%@ Register Src="ArticleControls.ascx" TagName="ArticleControls" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
<img src="res/images/imgtop.png" alt="" class="topimg" /><div class="textwrap">
<uc1:ArticleUserControl id="ucArticle" runat="server" />
<uc2:ArticlesUserControl id="ucArticles" runat="server" />
<uc3:ArticleControls id="ucArticleControls" runat="server" />
</div>
<img src="res/images/img-btm.png" alt="" class="btmimg" />
</asp:Content>

