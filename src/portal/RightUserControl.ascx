<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RightUserControl.ascx.cs" Inherits="RightUserControl" %>
<%@ Register Src="LoginUserControl.ascx" TagName="LoginUserControl" TagPrefix="uc2" %>
<%@ Register Src="PollUserControl.ascx" TagName="PollUserControl" TagPrefix="uc1" %>
<link id="Link4" href="~/res/css/style.css" rel="stylesheet" type="text/css" visible="false" runat="server"/>
<%--<div class="banner"><%=banner2 %></div>
<uc1:PollUserControl ID="ucPoll" runat="server" />
<div class="banner">
<%=banner6 %>
<%=banner7 %>
<%=banner8 %>
</div>
<br />
<div class="banner">
<%=banner9 %>
</div>
--%>
<uc2:LoginUserControl ID="ucLogin" runat="server" />

