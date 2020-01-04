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

public partial class AdminForumPage : System.Web.UI.Page
{
	Log log;
	PageHelper pageHelper;
	[SessionObject]
	public Forum forum;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			log = AdminMasterPage.InitPage(this, "Forum");
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
		int id  = RequestUtils.GetForumId(this);
		if (id != 0)
		{
			using (GmConnection conn = Global.CreateConnection())
			{
				forum = Forum.GetForum(conn, id);
			}
		}
		if (forum == null)
		{
			forum = new Forum();
			int cm = RequestUtils.GetCommunityId(this);
			if (cm != 0)
			{
				forum.communityId = cm;
			}
		}
	}

	void BindData()
	{
		using (GmConnection conn = Global.CreateConnection())
		{
			Utils.FillDDL(conn, ddlStatus, "select Id, Name from Statuses", (int)forum.status);
		}
		tbName.Text = forum.name;
		tbDescription.Text = forum.description;

		tbName.MaxLength = MaxLength.Forums.Name;
		tbDescription.MaxLength = MaxLength.Forums.Description;
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			forum.name = tbName.Text.Trim();
			forum.description = tbDescription.Text.Trim();
			forum.status = (RecordStatus)int.Parse(ddlStatus.SelectedValue);

			using (GmConnection conn = Global.CreateConnection())
			{
				forum.Save(conn);
			}
			lblResult.Text = string.Format("Data saved.");
//			WebUtils.Redirect(this, "Private/Users.aspx");
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}
}
