<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticlesUserControl.ascx.cs" Inherits="ArticlesUserControl" %>
<%@ Register Src="../PagerUserControl.ascx" TagName="PagerUserControl" TagPrefix="uc1" %>
<link id="LinkArticles" href="../res/css/style.css" rel="stylesheet" type="text/css" visible="false" runat="server"/>
<asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1"  >
<headertemplate>
  <table border="0" width="100%">
</headertemplate>
<ItemTemplate>
<tr>
<td><asp:HyperLink ID="HyperLink4" runat="server" CssClass="caption" ForeColor="Gray" Text='<%# Eval("Id")%>' NavigateUrl='<%# ((bool)Eval("IsGroup") ? "Default" : "Article")+".aspx?ar="+Eval("Id")%>' /></td>
<td>
    <p class="main">
    <span style="color:Blue"><%# Eval("Date","{0:MM.dd.yyyy}")%></span>&nbsp;
    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="caption" ForeColor="Gray" Text='<%# Eval("Title")%>' NavigateUrl='<%# ((bool)Eval("IsGroup") ? "Default" : "Article")+".aspx?ar="+Eval("Id")%>' />    
    </p>
</td>
<td>
    <asp:HyperLink runat="server" Text="edit" Visible='<%# Eval("IsGroup") %>' NavigateUrl='<%# "Article.aspx?ar="+Eval("Id")%>' />
</td>
<td>
    <asp:HyperLink ID="HyperLink1" runat="server" Text="Add item" Visible='<%# Eval("IsGroup") %>'  NavigateUrl='<%# "Article.aspx?ag="+Eval("Id")%>' />
</td>
<td>
    <asp:HyperLink ID="HyperLink2" runat="server" Text="par" NavigateUrl='<%# "ArticleParams.aspx?ar="+Eval("Id")%>' />
</td>
</tr>
</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
</asp:Repeater>
<uc1:PagerUserControl ID="ucPager" runat="server" />
<br />
<asp:HyperLink ID="HyperLink1" runat="server" Text="Add group" NavigateUrl="Article.aspx?ag=0" />
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppConnectionString %>" 
    SelectCommand="">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="ParentId" Type="Int32" />
        <asp:Parameter DefaultValue="3" Name="TopNumber" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>
