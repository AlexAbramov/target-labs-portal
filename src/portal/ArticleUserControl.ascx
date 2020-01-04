<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleUserControl.ascx.cs" Inherits="ArticleUserControl" %>
<link id="LinkArticlePreview" href="~/res/css/style.css" rel="stylesheet" type="text/css" visible="false" runat="server"/>
<div class="title2"><span><asp:Literal ID="litDate" runat="server" /></span>
<h3><asp:Literal ID="litTitle" runat="server" /></h3></div>
<br /><br />
<div class="text">
<p class="main">
<asp:Literal ID="litText" runat="server" />
</p>
</div>
<br />
<asp:HyperLink ID="hlLink" runat="server" Target="_blank" />

