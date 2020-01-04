<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PositionsUserControl.ascx.cs"
    Inherits="PositionsUserControl" %>
<%@ Register Src="../PagerUserControl.ascx" TagName="PagerUserControl" TagPrefix="uc1" %>
<link id="LinkPositions" href="../res/css/style.css" rel="stylesheet" type="text/css"
    visible="false" runat="server" />    
<asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
    <HeaderTemplate>
        <table border="0" width="100%" cellpadding="0" cellspacing="0">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="caption" ForeColor="Gray"
            Text='<%# Eval("Id")%>' NavigateUrl='<%# "Candidates.aspx?ar="+Eval("Id")%>' />
            </td>
            <td> 
                <%# Eval("Date","{0:MM.dd.yyyy}")%>
            </td>
            <td>
                <%# Eval("CandidateCount")%>
            </td>
            <td>
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="caption" ForeColor="Gray"
                        Text='<%# Eval("Title")%>' NavigateUrl='<%# "Candidates.aspx?ar="+Eval("Id")%>' />
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<uc1:PagerUserControl ID="ucPager" runat="server" />
<br />
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppConnectionString %>"
    SelectCommand="">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="ParentId" Type="Int32" />
        <asp:Parameter DefaultValue="3" Name="TopNumber" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>
