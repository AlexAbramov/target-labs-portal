<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginUserControl.ascx.cs"
    Inherits="LoginUserControl" %>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <table style="width: 100px;">
            <tr>
                <td style="vertical-align: middle; text-align: right; color: Silver;">login:&nbsp;</td>
                <td style="vertical-align: middle">
                    <asp:TextBox ID="tbLogin" CssClass='textbox' runat="server" Width="100px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblError" runat="server" EnableTheming="False" EnableViewState="False"
                        ForeColor="Red" Text="Wrong&nbsp;credentials" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: middle; text-align: right; color: Silver;">password:&nbsp;</td>
                <td style="vertical-align: middle">
                    <asp:TextBox ID="tbPassword" CssClass='textbox' Text="" runat="server" TextMode="Password" Width="100px"></asp:TextBox>
                </td>
                <td style="vertical-align: middle">
                    <asp:ImageButton ImageUrl="imgs/arrow.gif" AlternateText="Login" ID="btnLogin" Width="13"
                        Height="6" CssClass="btn_go" runat="server" OnClick="btnLogin_Click" CausesValidation="False" />
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:HyperLink ID="hlCab" runat="server">My cabinet</asp:HyperLink><br />
        <asp:LinkButton ID="lbLogout" runat="server" OnClick="lbLogout_Click" CausesValidation="False">Exit</asp:LinkButton>
    </asp:View>
    <asp:View ID="View3" runat="server">
    </asp:View>
</asp:MultiView>
