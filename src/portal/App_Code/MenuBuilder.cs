using System;
using System.Text;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for MenuBuilder
/// </summary>
public class MenuBuilder
{
    SiteMapNode selectedNode = null;

	public MenuBuilder()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Build(SiteMapNode rootNode, HttpRequest request)
    {
        var sb = new StringBuilder(1024);
        if (rootNode.HasChildNodes)
        {
            string url = request.Url.OriginalString.ToLower();
            foreach (SiteMapNode childNode in rootNode.ChildNodes)
            {
                if (selectedNode == null && ContainsUrl(childNode, url)) selectedNode = childNode;
                AddMenuItem(childNode, sb, 1);
            }
        }
        return sb.ToString();
    }

    private void AddMenuItem(SiteMapNode siteNode, StringBuilder sb, int level)
    {
        if (siteNode == selectedNode) sb.Append("<li class='act'>");
        else sb.Append("<li>");
        string title = level == 1 ? string.Format("<span>{0}</span>", siteNode.Title) : siteNode.Title;
        var siteNodeUrl=GetUrl(siteNode);
        if (siteNodeUrl.Length > 0) sb.AppendFormat("<a href='{0}'>{1}</a>", siteNodeUrl, title);
        else sb.AppendFormat("<a>{0}</a>", title);
        if (siteNode.HasChildNodes)
        {
            sb.Append("<ul>");
            foreach (SiteMapNode childNode in siteNode.ChildNodes)
            {
                AddMenuItem(childNode, sb, level + 1);
            }
            sb.Append("</ul>");
        }
        sb.Append("</li>");
    }

    private string GetUrl(SiteMapNode siteNode)
    {
        var url = siteNode.Url;
        if(url==null) url=String.Empty;
        else if (url.Length > 0)
        {
            int pos = url.LastIndexOf('/');
            if (pos >= 0)
            {
                url = url.Substring(pos + 1);
            }
        }
        return url;
    }

    private bool ContainsUrl(SiteMapNode node, string url)
    {
        var nodeUrl = node.Url.Trim();
        if (nodeUrl.Length > 0 && url.Contains(nodeUrl.ToLower())) return true;
        if (node.HasChildNodes)
        {
            foreach (SiteMapNode siteNode in node.ChildNodes)
            {
                if (ContainsUrl(siteNode, url)) return true;
            }
        }
        return false;
    }

    void SetMenuItem()
    {
        /*		Image selImage=null;
                switch(mi)
                {
                    case MainMenuItem.About:
        //				selImage = imgAbout;
                        break;
                    case MainMenuItem.Contacts:
        //				selImage = imgContacts;
                        break;
                    case MainMenuItem.Gallery:
        //				selImage=imgGallery;
                        break;
                    case MainMenuItem.None:
        //				selImage=imgMain;
                        break;
                    case MainMenuItem.Services:
        //				selImage=imgServices;
                        break;
                }
                if (selImage != null)
                {
                    selImage.ImageUrl = "imgs/menu_sep_active.jpg";
                }*/
    }

}