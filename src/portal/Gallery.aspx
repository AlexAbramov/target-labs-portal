<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="GalleryPage" Title="Photo gallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
						<div class="title"><h1>Album</h1></div>
                   <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
                   <ItemTemplate>
						<p class="title2"><%# Eval("Name") %></p>
                   </ItemTemplate>                   
                   </asp:Repeater>

                   <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                   <HeaderTemplate>
							<table width="100%">
							<tr>
							</HeaderTemplate>
                   <ItemTemplate>
						</tr><tr>
							<td style="width: 50%">                   
    						
    						<a href='<%# "GalleryImage.aspx?gi="+Eval("Id") %>'><img src='<%# "Gallery/p2_"+Eval("Filename") %>' alt="<%# Eval("Name") %>"></a>
    						<p><%# Eval("Name") %><p/>
							</td>                   
							</ItemTemplate>
							<AlternatingItemTemplate>
							<td>
							<img src="imgs/1.gif" width="10" height="1" alt=""></td>
							<td style="width: 50%">
    						
    						<a href='<%# "GalleryImage.aspx?gi="+Eval("Id") %>'><img src='<%# "Gallery/p2_"+Eval("Filename") %>' alt="<%# Eval("Name") %>"></a>
    						<p><%# Eval("Name") %><p/>
							</td>
													</AlternatingItemTemplate>
                   <FooterTemplate></tr></table>  
                   </FooterTemplate>
						                  
				   </asp:Repeater>
					
          <div class="clear">&nbsp;</div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppConnectionString %>"
        SelectCommand="SELECT GalleryImages.* FROM [GalleryImages] where GalleryId=@GalleryId and GalleryImages.Status>=0 order by Id desc">
    <SelectParameters>
        <asp:Parameter DefaultValue="0" Name="GalleryId" />
    </SelectParameters>
        </asp:SqlDataSource>				
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:AppConnectionString %>"
        SelectCommand="SELECT Name FROM [Galleries] where Id=@GalleryId">
    <SelectParameters>
        <asp:Parameter DefaultValue="0" Name="GalleryId" />
    </SelectParameters>
        </asp:SqlDataSource>				
</asp:Content>

