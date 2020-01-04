<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticlesUserControl.ascx.cs" Inherits="ArticlesUserControl" %>
<%@ Register Src="PagerUserControl.ascx" TagName="PagerUserControl" TagPrefix="uc1" %>
<link id="LinkArticles" href="~/res/css/style.css" rel="stylesheet" type="text/css" visible="false" runat="server"/>
<asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1"  >
<headertemplate>
  <table border="0" width="100%">
</headertemplate>
<ItemTemplate>
<tr><td>
    <p class="main">
    <span style="color:Blue"><%# Eval("Date","{0:MM.dd.yyyy}")%></span>&nbsp;
    <a class="caption" style=" color: Gray" href="<%= page %>ar=<%# Eval("Id")%>"><%# Eval("Title")%></a>
    </p>
    <p class="main">
    <asp:Image style="float:left;" runat="server" Visible='<%# Utils.IsVisible(Eval("Preview")) %>' ImageUrl='<%# "Images/"+Eval("Preview")%>' Height="100" Width="100" AlternateText='<%# Eval("Title")%>' />
    <%# Eval("Header") %>
    </p>
    </td></tr>
</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
</asp:Repeater>
<uc1:PagerUserControl ID="ucPager" runat="server" />
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppConnectionString %>" 
    SelectCommand="">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="ParentId" Type="Int32" />
        <asp:Parameter DefaultValue="3" Name="TopNumber" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>
