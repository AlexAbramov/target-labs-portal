<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="UploadPage" Title="Upload" %>
<%@ Register Src="UploadUserControl.ascx" TagName="UploadUserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
    <uc1:UploadUserControl ID="ucUpload" runat="server"  />
</asp:Content>

