<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="GalleryImage.aspx.cs" Inherits="GalleryImagePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
						<div class="title"><h1>Фото</h1></div>
                   <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                   <ItemTemplate>
						<p class="path"><a href="Galleries.aspx">Photo gallery</a> / <a href='Gallery.aspx?gl=<%# Eval("GalleryId") %>'><%# Eval("GalleryName") %></a></p>
						<p style="text-align:center"><%# Eval("Name") %></p>
						<div style="text-align:center">
						<img src='Gallery/<%# Eval("Filename")%>' alt="<%# Eval("Name") %>" />
						</div>
						<div><%# Eval("Text") %></div>
                   </ItemTemplate>
                   </asp:Repeater>						

					
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppConnectionString %>"
        SelectCommand="SELECT top 1 GalleryImages.*, Galleries.Name as GalleryName FROM [GalleryImages] left join Galleries on Galleries.Id= GalleryId where GalleryImages.Id=@GalleryImageId">
    <SelectParameters>
        <asp:Parameter DefaultValue="0" Name="GalleryImageId" />
    </SelectParameters>
        </asp:SqlDataSource>
				
</asp:Content>

