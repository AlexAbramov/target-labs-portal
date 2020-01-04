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

public partial class Admin_ControlPanel : System.Web.UI.Page
{
	Log log;
	protected void Page_Load(object sender, EventArgs e)
	{
		log=AdminMasterPage.InitPage(this, "Control panel", false);
	}
	protected void btnResetAppCache_Click(object sender, EventArgs e)
	{
		bool res = false;
		try
		{
			res = Global.ResetAppCache();
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
		if(res)
		{ 
			lblResult.Text = "Application cache reloaded.";
		}
		else
		{
			lblResult.ForeColor = System.Drawing.Color.Red;
			lblResult.Text = "Failed to reload the application cache.";
		}
		btnResetAppCache.Enabled = false;
	}
}
