<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="PollAnswer.aspx.cs" Inherits="PollAnswerPage"  validateRequest="false" %>


<%@ Register Src="PollAnswerUserControl.ascx" TagName="PollAnswerUserControl" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
    <br />
    <uc1:PollAnswerUserControl id="ucPollAnswer" runat="server">
    </uc1:PollAnswerUserControl>
    <br />
    <br />
    <br />
    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" /><asp:Label
        ID="lblResult" runat="server" EnableViewState="False" ForeColor="Green"></asp:Label>
</asp:Content>

