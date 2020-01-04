<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Positions.aspx.cs" Inherits="Positions" Title="Positions" %>
<%@ Register Src="PositionsUserControl.ascx" TagName="PositionsUserControl" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
    <uc2:PositionsUserControl id="ucPositions" runat="server" />
</asp:Content>

