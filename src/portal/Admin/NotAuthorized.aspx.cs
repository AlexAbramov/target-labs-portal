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

public partial class NotAuthorized : System.Web.UI.Page
{
	Log log;
	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			log = AdminMasterPage.InitPage(this, "You are not authorized to view the page.");
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}
}
