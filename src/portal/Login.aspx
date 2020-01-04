<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LoginPage" %>
<%@ Register Src="LoginUserControl.ascx" TagName="LoginUserControl" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">

<%--               <h4 style="text-align: center">Authorization required.</h4>
--%>        <uc2:LoginUserControl ID="ucLogin" runat="server" />

</asp:Content>
