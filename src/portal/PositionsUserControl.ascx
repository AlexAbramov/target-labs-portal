<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PositionsUserControl.ascx.cs" Inherits="PositionsUserControl" %>
<%@ Register Src="PagerUserControl.ascx" TagName="PagerUserControl" TagPrefix="uc1" %>
<link id="LinkArticles" href="~/res/css/style.css" rel="stylesheet" type="text/css" visible="false" runat="server"/>
<asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1"  >
<headertemplate>
</headertemplate>
<ItemTemplate>
    <%--<span style="color:Blue"><%# Eval("Date","{0:MM.dd.yyyy}")%></span>&nbsp;--%>
    <a class="main" style="color: Gray;" href="<%= page %>ar=<%# Eval("Id")%>"><%# Eval("Title")%></a>
    <br />   
</ItemTemplate>
<FooterTemplate>
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
