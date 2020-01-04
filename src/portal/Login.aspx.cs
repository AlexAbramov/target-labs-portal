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
using Geomethod;
using Geomethod.Data;

public partial class LoginPage : System.Web.UI.Page
{
	Log log;
	protected void Page_Load(object sender, EventArgs e)
	{
        log = MainMasterPage.InitPage(this);
	}
}
