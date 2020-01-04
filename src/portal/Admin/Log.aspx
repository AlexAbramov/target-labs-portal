<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Log.aspx.cs" Inherits="LogPage" Title="Log" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCenter" Runat="Server">
    Filter:&nbsp;
    <asp:DropDownList ID="ddlLogType" runat="server" Width="185px">
    </asp:DropDownList>&nbsp;
    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" /><br />
    <br />
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellSpacing="3">
        <Columns>
            <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />
            <asp:BoundField DataField="LogTypeId" HeaderText="Type" SortExpression="LogType" />
            <asp:BoundField DataField="Page" HeaderText="Page" />
            <asp:BoundField DataField="Message" HeaderText="Message" SortExpression="Message" />
        </Columns>
    </asp:GridView>
</asp:Content>

