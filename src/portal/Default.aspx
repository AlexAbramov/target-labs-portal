<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="DefaultPage" Title="Target Labs Inc" %>

<%--<%@ Register Src="GalleryPreviewUserControl.ascx" TagName="GalleryPreviewUserControl"
    TagPrefix="uc4" %>
<%@ Register Src="ArticlesUserControl.ascx" TagName="ArticlesUserControl" TagPrefix="uc3" %>--%>
<%@ Register Src="PositionsUserControl.ascx" TagName="PositionsUserControl" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" runat="Server">
    <div class="toptext">
    <a href="Learnix/Default.aspx">
        <img src="res/images/TLL.gif" alt="Learnix" />
    </a>
<%--        <%= GetValue("top_text1") %>--%>
    </div>
    <div class="mini_wrap">
        <h3 class="minihead">
            <%= GetValue("middle_header1") %></h3>
        <p class="minipara">
            <%= GetValue("middle_text1") %></p>
    </div>
    <div class="mini_wrap">
        <h3 class="minihead">
            <%= GetValue("middle_header2") %></h3>
        <p class="minipara">
            <%= GetValue("middle_text2") %></p>       
    </div>
    <div class="mini_wrap">
        <h3 class="minihead">
            <%= GetValue("middle_header3") %></h3>
            <p class="minipara">
        <uc3:PositionsUserControl ID="ucPositions" runat="server" />
        </p>
    </div>
    <div class="content">
        <div class="mini_wrap"><a href="Page.aspx?tag=Company" class="more"></a></div>
        <div class="mini_wrap"><a href="Page.aspx?tag=Services" class="more"></a></div>
        <div class="mini_wrap"><a href="Page.aspx?tag=Positions" class="more"></a>
        </div>
    </div>
<%--    <img src="res/images/imgtop.png" alt="" class="topimg" />
    <div class="textwrap">
        <div class="mini_wrap  bgline ">
            <h3 class="indexhead">
                <%= GetValue("bottom_header1") %></h3>
            <p class="indexpara">
                <%= GetValue("bottom_text1") %></p>
        </div>
        <div class="mini_wrap  bgline">
            <h3 class="indexhead">
                <%= GetValue("bottom_header2") %></h3>
            <p class="indexpara">
                <%= GetValue("bottom_text2") %></p>
        </div>
        <div class="mini_wrap  ">
            <h3 class="indexhead">
                <%= GetValue("bottom_header3") %></h3>
            <p class="indexpara">
                <%= GetValue("bottom_text3") %></p>
        </div>
    </div>
    <img src="res/images/img-btm.png" alt="" class="btmimg" />
--%>
</asp:Content>
