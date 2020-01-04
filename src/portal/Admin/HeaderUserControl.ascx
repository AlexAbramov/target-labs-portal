<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeaderUserControl.ascx.cs" Inherits="Admin_HeaderUserControl" %>
<link id="Link2" href="../res/css/style.css" rel="stylesheet" type="text/css" visible="false" runat="server"/>
<%@ Register Src="~/SearchUserControl.ascx" TagName="SearchUserControl" TagPrefix="uc3" %>
<%@ Register Src="~/LoginUserControl.ascx" TagName="LoginUserControl" TagPrefix="uc2" %>
<div id="fullwidth">
  <div class="main_wrap">
    <div class="main_wrap_support">
      <div class="serwrap">
      <table>
      <tr>
      <td><h3>WebSite Administration</h3></td>
      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
      <td><asp:LoginStatus ID="loginStatus" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/Default.aspx" LogoutText="Exit" /></td>
      </tr>
      </table>
      </div>
      <%--<a href="Default.aspx" class="logo"></a>--%>
      <div style="width:500">     
      <ul id="menu"> 
        <asp:Literal ID="lblMenu" runat="server" />
      </ul>      
      </div>
      <br />
      <h3 style="text-align: left"><asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label></h3>
    </div>
  </div>  
</div>

<%--                      <asp:Menu ID="menu" runat="server" Orientation="Horizontal" BackColor="#FFFBD6" 
                          DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="Small" 
                          ForeColor="#990000" StaticSubMenuIndent="10px" EnableTheming="False">
                          <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                          <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                          <DynamicMenuStyle BackColor="#FFFBD6" />
                          <DynamicSelectedStyle BackColor="#FFCC66" />
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Admin/Default.aspx" Text="Start" Value="Start"></asp:MenuItem>
                        <asp:MenuItem Text="Photo gallery">
                            <asp:MenuItem NavigateUrl="Galleries.aspx" Text="Albums" Value="List"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="Gallery.aspx" Text="Add album" Value="Add"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Web site">
                            <asp:MenuItem NavigateUrl="Pages.aspx" Text="Web site pages" Value="Web site pages">
                            </asp:MenuItem>
                            <asp:MenuItem NavigateUrl="Banners.aspx" Text="Banners" Value="List"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="Banner.aspx" Text="Add Banner" Value="Add"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="BannerTopics.aspx" Text="Banner topics" Value="Banner topics">
                            </asp:MenuItem>
                            <asp:MenuItem NavigateUrl="ControlPanel.aspx" Text="Control panel" Value="Control panel">
                            </asp:MenuItem>
                            <asp:MenuItem NavigateUrl="Polls.aspx" Text="Polls"></asp:MenuItem>
													<asp:MenuItem NavigateUrl="~/Admin/LinkExchangePages.aspx" Text="Links exchange"
														Value="Links exchange"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="System" Value="System">
                            <asp:MenuItem NavigateUrl="Log.aspx" Text="Messages log" Value="Log"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="Upload.aspx" Text="Load image" Value="Load image">
                        </asp:MenuItem>
                        </asp:MenuItem>
                    </Items>
                          <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                    <StaticMenuItemStyle VerticalPadding="2px" ItemSpacing="10px" HorizontalPadding="5px" />
                          <StaticSelectedStyle BackColor="#FFCC66" />
                </asp:Menu>

            --%>