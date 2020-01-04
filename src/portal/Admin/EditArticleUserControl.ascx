<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditArticleUserControl.ascx.cs" Inherits="EditArticleUserControl"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxControlToolkit" %>
<table>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            </td>
        <td>
            </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Group:"></asp:Label></td>
        <td>
            <asp:DropDownList ID="ddlArticleGroup" runat="server" DataTextField="Title" DataValueField="Id" Width="300px">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Date:"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbDate" runat="server" Width="150px" ReadOnly="true"></asp:TextBox>
            <ajaxControlToolkit:CalendarExtender ID="calExt" runat="server" TargetControlID="tbDate" Format="MMM d yy" />    
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label8" runat="server" Text="Person:"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbPerson" runat="server"
                Width="300px"></asp:TextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            </td>
        <td>&nbsp;</td>
        <td>
            </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblTitle" runat="server" Text="Title:"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbTitle" runat="server" Width="300px"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="valTitle" runat="server" ControlToValidate="tbTitle"
                ErrorMessage="Required field" Visible="False"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Picture:"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbPreview" runat="server"
                Width="300px"></asp:TextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Brief info:"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbHeader" runat="server" TextMode="MultiLine" Width="500px" 
                Height="70px"></asp:TextBox>            
            </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblText" runat="server" Text="Text:"></asp:Label></td>
        <td colspan="2">
            <ajaxControlToolkit:HtmlEditor.Editor ID="tbText" runat="server" Height="400px" Width="600px" />
        </td>
        <td>
            </td>
    </tr>
    <tr>
        <td>
            </td>
        <td>
            &nbsp;</td>
        <td>
            </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label7" runat="server" Text="Company:"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbCompany" runat="server" 
                Width="300px"></asp:TextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="City:"></asp:Label></td>
        <td>
            <asp:DropDownList ID="ddlCity" runat="server" DataTextField="Name" DataValueField="Id" Width="300px">
        </asp:DropDownList></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label10" runat="server" Text="Address:"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbAddress" runat="server" 
                Width="300px"></asp:TextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label9" runat="server" Text="Phone:"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbPhone" runat="server"
                Width="300px"></asp:TextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label11" runat="server" Text="Link:"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbLink" runat="server" 
                Width="300px"></asp:TextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label12" runat="server" Text="Email:"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbEmail" runat="server"  
                Width="300px"></asp:TextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label13" runat="server" Text="Tag:"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbTag" runat="server" Width="300px"></asp:TextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:CheckBox ID="chkIsGroup" runat="server" Text="IsGroup" />
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label6" runat="server" Text="Record Status:"></asp:Label></td>
        <td><asp:DropDownList ID="ddlStatus" runat="server" DataTextField="Name" DataValueField="Id" Width="200px">
        </asp:DropDownList></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:HyperLink ID="hlArticleParams" runat="server">Article Parameters</asp:HyperLink>
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
&nbsp;
