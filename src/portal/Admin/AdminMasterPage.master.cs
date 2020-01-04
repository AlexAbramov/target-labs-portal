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

public partial class AdminMasterPage : System.Web.UI.MasterPage
{
	Log log;
	public Log Log { get { return log; } }
//	public string Title { get { return title; } set { title = value; lblTitle.Text = value; } }
	public static Log InitPage(Page page, string title) { return InitPage(page, title, false); }
	public static Log InitPage(Page page, string title, bool enableExcelReport)
	{
		page.Title ="Administration - " + title;
		AdminMasterPage mp = page.Master as AdminMasterPage;
		mp.log = new Log(page);
		mp.ucHeader.Title = title;
//!!!		mp.hlExcelExport.Visible = enableExcelReport;
		return mp.Log;
	}
	protected void Page_Load(object sender, EventArgs e)
  {
	}
}
