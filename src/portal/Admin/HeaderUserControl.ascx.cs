using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_HeaderUserControl : System.Web.UI.UserControl
{
    Log log;
	public string Title { get { return lblTitle.Text; } set { lblTitle.Text = value; } } 
	protected void Page_Load(object sender, EventArgs e)
	{
        log = new Log(this);
        if (!IsPostBack && !DesignMode)
        {
            var menuBuilder = new MenuBuilder();
            lblMenu.Text = menuBuilder.Build(SiteMap.Providers["AdminSiteMapProvider"].RootNode, Request);
        }
	}
}
