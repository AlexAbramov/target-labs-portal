<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UploadUserControl.ascx.cs" Inherits="UserControls_UploadUserControl" %>
<asp:FileUpload ID="fileUpload" runat="server" />
<asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Load" /><br />
<asp:Label ID="lblInfo" runat="server" EnableViewState="False"></asp:Label>
