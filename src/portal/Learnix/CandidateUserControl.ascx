<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CandidateUserControl.ascx.cs"
    Inherits="LearnixCandidateUserControl" EnableViewState="true" %>
<link id="LinkArticlePreview" href="~/res/css/style.css" rel="stylesheet" type="text/css" visible="false" runat="server"/>
 <table>
    <tr>
    <td></td>
        <td colspan="2" align="center">
<div class="title2"><span><asp:Literal ID="litDate" runat="server" /></span>
<h3><asp:Literal ID="litTitle" runat="server" /></h3></div>
        </td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
        <td><p class="content">Name:</p>
        </td>
        <td>
            <asp:TextBox ID="tbName" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbName"
                ErrorMessage="Required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
        <p class="content">Surname:</p>            
        </td>
        <td>
            <asp:TextBox ID="tbSurname" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbSurname"
                ErrorMessage="Required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <p class="content">Phone:</p>
        </td>
        <td>
            <asp:TextBox ID="tbPhone" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <p class="content">Email:</p>
        </td>
        <td>
            <asp:TextBox ID="tbEmail" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbEmail"
                ErrorMessage="Required" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbEmail"
                ErrorMessage="Wrong format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                />
        </td>
    </tr>
<%--    <tr>
        <td>
            <p class="content">Resume:</p>
        </td>
        <td colspan="2">
        <asp:FileUpload CssClass="btn" ID="fileUpload" runat="server" Width="400px" BackColor="White" />
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="fileUpload"
                ErrorMessage="Required"></asp:RequiredFieldValidator>
        </td>
    </tr>--%>
    <tr>
        <td>
            <p class="content">Comments:</p>
        </td>
        <td colspan="2">
            <asp:TextBox ID="tbComments" runat="server" Height="200px" TextMode="MultiLine" Width="400px"></asp:TextBox>
        </td>
    </tr>
</table>