<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Poll.aspx.cs" Inherits="PollPage"  validateRequest="false" Title="Poll" %>

<%@ Register Src="EditPollUserControl.ascx" TagName="PollUserControl"
    TagPrefix="uc1" %>

<%@ Register Src="PollAnswersUserControl.ascx" TagName="PollAnswersUserControl"
    TagPrefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
     <uc1:PollUserControl id="ucPoll" runat="server">
    </uc1:PollUserControl>
	<br />
	<br />
    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" /><asp:Label
        ID="lblResult" runat="server" EnableViewState="False" ForeColor="Green"></asp:Label><br />
	<br />
   <br />
    <uc2:PollAnswersUserControl id="ucPollAnswers" runat="server">
    </uc2:PollAnswersUserControl>
    <br />
</asp:Content>

