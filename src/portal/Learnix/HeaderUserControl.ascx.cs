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
using Geomethod.Web;

public partial class LearnixHeaderUserControl : System.Web.UI.UserControl
{
	public string banner1 = "";
	Log log;

    protected void Page_Load(object sender, EventArgs e)
    {
	    log = new Log(this);
        if (!IsPostBack && !DesignMode)
        {
            var menuBuilder = new MenuBuilder();
            lblMenu.Text = menuBuilder.Build(SiteMap.Providers["LearnixSiteMapProvider"].RootNode, Request);
        }
    }
}
