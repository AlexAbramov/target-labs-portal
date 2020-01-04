using System;
using System.IO;
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
using Geomethod.Web;

public partial class AdminLinkExchange : System.Web.UI.Page
{
	Log log;
	PageHelper pageHelper;
	[SessionObject]
	public LinkExchangePage page;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			log = AdminMasterPage.InitPage(this, "Links exchange");
			pageHelper = new PageHelper(this);
			if (!IsPostBack)
			{
				LoadData();
				BindData();
			}
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}

	}

	void LoadData()
	{
		int id  = RequestUtils.GetPageId(this);
		if (id != 0)
		{
			using (GmConnection conn = Global.CreateConnection())
			{
				page = LinkExchangePage.GetLinkExchangePage(conn, id);
			}
		}
		if (page == null)
		{
			WebUtils.Redirect(this, "Admin/LinkExchangePages.aspx");
		}
	}

	void BindData()
	{

		tbText.Text = page.text;

		tbText.MaxLength = MaxLength.LinkExchangePages.Text;
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			page.text = tbText.Text.Trim();
			page.date = DateTime.Now;

			using (GmConnection conn = Global.CreateConnection())
			{
				page.Save(conn);
			}
			lblResult.Text = string.Format("Data saved.");
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}
}
