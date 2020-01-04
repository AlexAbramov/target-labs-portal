<%--<%@ OutputCache Duration="600" VaryByParam="none" %>--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeaderUserControl.ascx.cs" Inherits="HeaderUserControl" %>
<%@ Register Src="SearchUserControl.ascx" TagName="SearchUserControl" TagPrefix="uc3" %>
<div id="fullwidth">
  <div class="main_wrap">
    <div class="main_wrap_support">
      <div class="serwrap">
        <p class="links">
        <a href='https://www.facebook.com/pages/Target-Labs-Inc/164401020256149' target='_blank'><img src="res/images/l1.png" alt="Facebook" /></a>
        <a href='https://twitter.com/#!/Target_Labs' target='_blank'><img src="res/images/l2.png" alt="Twitter" /></a>
<%--        <a href='http://www.linkedin.com/company/122424' target='_blank'><img src="res/images/l3.png" alt="LinkedIn" /></a>--%>        
        <script src="//platform.linkedin.com/in.js" type="text/javascript"></script>
        <script type="IN/FollowCompany" data-id="122424" data-counter="right"></script>
        </p>    
        <uc3:SearchUserControl ID="ucSearch" runat="server"/>     
      </div>
      <a href="Default.aspx" class="logo"></a>
      <div style="width:500">     
      <ul id="menu"> 
        <asp:Literal ID="lblMenu" runat="server" />
      </ul>      
      </div>
    </div>
  </div>
</div>
