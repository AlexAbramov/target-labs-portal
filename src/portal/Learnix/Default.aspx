<%@ Page Language="C#" MasterPageFile="LearnixMasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="LearnixDefaultPage" Title="Learnix" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" runat="Server">
    <div class="toptext">        
    <img src="../res/images/TLL.gif" alt="Learnix" />
<%--    <%= GetValue("top_text1") %>--%>
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
            <%= GetValue("middle_text3") %></p>       
    </div>
    <div class="content">
        <div class="mini_wrap"><a href="Page.aspx?tag=TargetLabsLearnix" class="more"></a></div>
        <div class="mini_wrap"><a href="Page.aspx?tag=Courses" class="more"></a></div>
        <div class="mini_wrap"><a href="Page.aspx?tag=BecomeTester" class="more"></a></div>
    </div>
</asp:Content>
