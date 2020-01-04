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

public partial class AdminForumTopicPage : System.Web.UI.Page
{
	Log log;
	PageHelper pageHelper;
	[SessionObject]
	public ForumTopic forumTopic;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			log = AdminMasterPage.InitPage(this, "Forum topic");
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
		int id  = RequestUtils.GetForumTopicId(this);
		if (id != 0)
		{
			using (GmConnection conn = Global.CreateConnection())
			{
				forumTopic = ForumTopic.GetForumTopic(conn, id);
			}
		}
		if (forumTopic == null)
		{
			forumTopic = new ForumTopic();
			int fr = RequestUtils.GetForumId(this);
			if (fr != 0)
			{
				forumTopic.forumId = fr;
			}
		}
	}

	void BindData()
	{
		using (GmConnection conn = Global.CreateConnection())
		{
			Utils.FillDDL(conn, ddlStatus, "select Id, Name from Statuses", (int)forumTopic.status);
		}
		tbName.Text = forumTopic.name;
		tbDescription.Text = forumTopic.description;

		tbName.MaxLength = MaxLength.ForumTopics.Name;
		tbDescription.MaxLength = MaxLength.ForumTopics.Description;
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			forumTopic.name = tbName.Text.Trim();
			forumTopic.description = tbDescription.Text.Trim();
			forumTopic.status = (RecordStatus)int.Parse(ddlStatus.SelectedValue);

			using (GmConnection conn = Global.CreateConnection())
			{
				forumTopic.Save(conn);
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
