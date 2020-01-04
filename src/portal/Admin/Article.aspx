<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Article.aspx.cs" Inherits="ArticlePage" Title="Edit Article"  validateRequest="false" %>

<%@ Register Src="EditArticleUserControl.ascx" TagName="ArticleUserControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
    <br />
    &nbsp;<table cellpadding="3" cellspacing="3" style="width: 100%">
        <tr>
            <td style="width: 100px">
    <uc1:ArticleUserControl ID="ucArticle" runat="server" />
            </td>
            <td style="width: 100px">
							&nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" /><asp:Label
        ID="lblResult" runat="server" EnableViewState="False" ForeColor="Green"></asp:Label>
</asp:Content>

