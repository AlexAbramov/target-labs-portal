<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GalleryPreviewUserControl.ascx.cs" Inherits="GalleryPreviewUserControl" %>
<link id="LinkGalleryPreviewUserControl" href="~/res/css/style.css" rel="stylesheet" type="text/css" visible="false" runat="server"/>
<asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
<HeaderTemplate>
<table width="100%">
<tbody valign="middle">
<tr>
<td></td>
</HeaderTemplate>
<ItemTemplate>
	<td style="width: 33%" align="center">
	<a href="Gallery.aspx?gl=1"><img src='<%# "Gallery/p1_"+Eval("Filename") %>' alt='<%# Eval("Name") %>' /></a>
	<br /><%# Eval("Name") %>
	</td>
</ItemTemplate>
<FooterTemplate>
<td></td>
</tr>
</tbody>
</table>
</FooterTemplate>
	                  
</asp:Repeater>


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppConnectionString %>"
        SelectCommand="SELECT top (3) GalleryImages.* FROM [GalleryImages] where GalleryId=@GalleryId order by Id desc">
    <SelectParameters>
        <asp:Parameter DefaultValue="0" Name="GalleryId" />
    </SelectParameters>
        </asp:SqlDataSource>				
