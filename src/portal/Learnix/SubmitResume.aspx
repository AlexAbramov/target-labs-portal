<%@ Page Language="C#" MasterPageFile="LearnixMasterPage.master" AutoEventWireup="true" CodeFile="SubmitResume.aspx.cs" Inherits="LearnixSubmitResume" Title=""  %>
<%@ Register src="CandidateUserControl.ascx" tagname="CandidateUserControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
    <img src="../res/images/imgtop.png" alt="" class="topimg" /><div class="textwrap">

        <uc1:CandidateUserControl ID="ucCandidate" runat="server" />
        <asp:Label ID="lblResult" runat="server" EnableViewState="false" Text=""></asp:Label>
        <br />
        <ul id="menu"> 
        <li class='act'>
            <asp:LinkButton ID="btnApply" runat="server" onclick="btnApply_Click"><span>Apply</span></asp:LinkButton>
        </li>
        </ul>

</div><img src="../res/images/img-btm.png" alt="" class="btmimg" />
</asp:Content>

