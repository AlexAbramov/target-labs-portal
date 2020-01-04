<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleParamsUserControl.ascx.cs" Inherits="ArticleParamsUserControl" %>
<link id="LinkArticles" href="../res/css/style.css" rel="stylesheet" type="text/css" visible="false" runat="server"/>
<asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1"  >
<headertemplate>
  <table border="0" width="100%">
</headertemplate>
<ItemTemplate>
<tr>
<td><%# Eval("Id")%></td>
<td>
    <a class="caption" style="color: Gray" href="ArticleParam.aspx?ap=<%# Eval("Id")%>"><%# Eval("Key")%></a>
</td>
</tr>
</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
</asp:Repeater>
<br />
<asp:HyperLink ID="hlAddParam" runat="server" Text="Add param" />
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:AppConnectionString %>' 
    SelectCommand="select Id, [Key] from ArticleParams where ArticleId=@ArticleId">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="ArticleId" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>
