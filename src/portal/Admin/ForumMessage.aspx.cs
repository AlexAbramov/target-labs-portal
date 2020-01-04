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

public partial class AdminForumMessagePage : System.Web.UI.Page
{
	Log log;
	PageHelper pageHelper;
	[SessionObject]
	public ForumMessage forumMessage;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			log = AdminMasterPage.InitPage(this, "Forum message");
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
		int id  = RequestUtils.GetForumMessageId(this);
		if (id != 0)
		{
			using (GmConnection conn = Global.CreateConnection())
			{
				forumMessage = ForumMessage.GetForumMessage(conn, id);
			}
		}
		if (forumMessage == null)
		{
			forumMessage = new ForumMessage();
			int ft = RequestUtils.GetForumTopicId(this);
			if (ft != 0)
			{
				forumMessage.forumTopicId = ft;
			}
			forumMessage.userName = "Модератор";
		}
	}

	void BindData()
	{
		using (GmConnection conn = Global.CreateConnection())
		{
			Utils.FillDDL(conn, ddlStatus, "select Id, Name from Statuses", (int)forumMessage.status);
		}
		tbName.Text = forumMessage.userName;
		tbText.Text = forumMessage.text;

		tbName.MaxLength = MaxLength.ForumMessages.UserName;
		tbText.MaxLength = MaxLength.ForumMessages.Text;
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			forumMessage.userName = tbName.Text.Trim();
			forumMessage.text = tbText.Text.Trim();
			forumMessage.status = (RecordStatus)int.Parse(ddlStatus.SelectedValue);

			using (GmConnection conn = Global.CreateConnection())
			{
				forumMessage.Save(conn);
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
