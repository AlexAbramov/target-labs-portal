<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="Candidates.aspx.cs" Inherits="Candidates" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" runat="Server">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <HeaderTemplate>
            <table border="0" width="100%">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("Date","{0:MM.dd.yy}")%>
                </td>
                <td>
                    <%# Eval("Name")%>
                </td>
                <td>
                    <%# Eval("Surname")%>
                </td>
                <td>
                    <%# Eval("Phone")%>
                </td>
                <td>
                    <%# Eval("Email")%>
                </td>
                <td>
                    <asp:HyperLink runat="server" Target="_blank" Visible='<%# Utils.IsVisible(Eval("Resume")) %>' NavigateUrl='<%# "~/Resume/"+Eval("Resume") %>' Text='<%# Eval("Resume")%>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppConnectionString %>"
        SelectCommand="select Id, Date, Name, Surname, Phone, Email, Resume from Candidates where PositionId=@PositionId">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="PositionId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
