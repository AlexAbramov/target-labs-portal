using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class LeftUserControl : System.Web.UI.UserControl
{
	public string banner3 = "";
	public string banner4 = "";
	public string banner5 = "";

//	string submenuItem = "";
//	bool itemSelected = false;

	protected void Page_Load(object sender, EventArgs e)
    {
        // &amp;
        if (!IsPostBack)
        {
/*    		string url = base.Request.Url.OriginalString.ToLower();
            foreach (SiteMapNode siteNode in SiteMap.RootNode.ChildNodes)
            {
                if (ContainsUrl(siteNode, url))
                {
                    GenerateMenu(siteNode);
                    break;
                }
            }*/

        }
    }



 /*   void GenerateMenu(SiteMapNode node)
    {
        StringBuilder sb = new StringBuilder();
        if (node.HasChildNodes)
        {
            foreach (SiteMapNode siteNode in node.ChildNodes)
            {
                sb.AppendFormat("<p><a href='{0}'>{1}</a></p>", siteNode.Url, siteNode.Title);
                //                MenuItem mi = Utils.GetMenuItem(siteNode);
            }
        }
        lblMenu.Text = sb.ToString();
    }

	public void InitControl(MainMenuItem mi, string submenuItem)
	{       
		this.submenuItem = submenuItem;
		menu.Items.Clear();
		switch (mi)
		{
			case MainMenuItem.Corporate:
				AddMenuItem("Corporate", PageTag.Corporate);
				AddMenuItem("Our Mission", PageTag.OurMission);
				AddMenuItem("How We Work", PageTag.HowWeWork);
				AddMenuItem("Our Team", PageTag.OurTeam);
				AddMenuItem("Employment", PageTag.Employment);
				break;
			case MainMenuItem.Services:
                AddMenuItem("Services", PageTag.Services);
                AddMenuItem("ECommerce", PageTag.ECommerce);
                AddMenuItem("SystemIntegration", PageTag.SystemIntegration);
                AddMenuItem("DB Management", PageTag.DBManagement);
                AddMenuItem("Network Support", PageTag.NetworkSupport);
                AddMenuItem("IT Consulting", PageTag.ITConsulting);
				break;
			case MainMenuItem.Clients:
                AddMenuItem("Clients", "Clients.aspx");
                AddMenuItem("Partners", "Partners.aspx");
				break;
			case MainMenuItem.About:
                AddMenuItem("Company overview", PageTag.About);
                AddMenuItem("Contacts", PageTag.Contacts);
				break;			
		}
		if (menu.Items.Count == 0) menu.Visible = false;
	}

    private MenuItem AddMenuItem(string caption, PageTag pageTag)
    {
        string navigateUrl = "Article.aspx?tag=" + pageTag.ToString();
        return AddMenuItem(caption, navigateUrl);
    }

    private MenuItem AddMenuItem(string caption, string navigateUrl)
	{
		MenuItem mi=new MenuItem(caption);
		mi.NavigateUrl=navigateUrl;
		menu.Items.Add(mi);
		if (!itemSelected && submenuItem.Length > 0 && navigateUrl.StartsWith(submenuItem))
		{
			mi.Selected = true;
			itemSelected = true;
		}
		return mi;
	}*/
}
