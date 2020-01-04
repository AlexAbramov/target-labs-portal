<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SubContentUserControl.ascx.cs" Inherits="SubContentUserControl" %>
<link id="Link2" href="~/res/css/style.css" rel="stylesheet" type="text/css" visible="false" runat="server"/>
    <div class="textwrap">
        <div class="mini_wrap  bgline ">
            <h3 class="indexhead">
                <%= GetValue("bottom_header1") %></h3>
            <p class="indexpara">
                <%= GetValue("bottom_text1") %></p>
        </div>
        <div class="mini_wrap  bgline">
            <h3 class="indexhead">
                <%= GetValue("bottom_header2") %></h3>
            <p class="indexpara">
                <%= GetValue("bottom_text2") %></p>
        </div>
        <div class="mini_wrap  ">
            <h3 class="indexhead">
                <%= GetValue("bottom_header3") %></h3>
            <p class="indexpara">
                <%= GetValue("bottom_text3") %></p>
        </div>
    </div>