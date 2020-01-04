<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleControls.ascx.cs" Inherits="ArticleControls" %>
<p></p>
<table cellpadding="10" cellspacing="10">
<tr>
<td>
<a href="https://twitter.com/share" class="twitter-share-button" data-count="none">Tweet</a>
<script>    !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "//platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
</td>
<td>
<script src="//platform.linkedin.com/in.js" type="text/javascript"></script>
<script type="IN/Share" data-counter="right"></script>
</td>
<td>
<script type="text/javascript">    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));</script>
    <div class="fb-like" data-send="false" data-width="100" data-show-faces="false"></div>
</td>
</tr></table>
<ul id="menu">
<li class='act'><a href='<% =applyLink %>'><span>Apply</span></a></li>
</ul>
