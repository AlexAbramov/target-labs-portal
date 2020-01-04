<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FooterUserControl.ascx.cs" Inherits="LearnixFooterUserControl"  %>
<link id="Link2" href="~/res/css/style.css" rel="stylesheet" type="text/css" visible="false" runat="server"/>
 <div id="footer">
  <div class="main_wrap">
    <div class="main_wrap_support topline">
      <ul class="nav2">
        <li><a href="Default.aspx">Home</a></li>
        <li class="sep">|</li>
        <li><a href="Page.aspx?tag=TargetLabsLearnix">Company</a></li>
        <li class="sep">|</li>
        <li><a href="Page.aspx?tag=LearnixContacts">Contacts</a></li>
        <li class="sep">|</li>
        <li><a href="../Login.aspx">Login</a></li>
      </ul>
      <p>Copyright &copy; 2012 Target Labs Inc. All Rights Reserved.<br />
      <asp:Label ID="lblGenTime" runat="server" EnableTheming="False" EnableViewState="False" ForeColor="Silver" Width="400px"></asp:Label>
      </p>
      <p>
      </p>
    </div>
  </div>
</div>