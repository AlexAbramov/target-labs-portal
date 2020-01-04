<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchUserControl.ascx.cs" Inherits="SearchUserControl" EnableViewState="false" %>
        <asp:TextBox ID="tbSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="" CssClass="btn" CausesValidation="false" 
    onclick="btnSearch_Click" />