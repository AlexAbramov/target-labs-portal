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
using Geomethod.Data;

public partial class ForumMessageUserControl : System.Web.UI.UserControl
{
	Log log=null;
	int forumTopicId = 0;
	int userId = 0;
	protected void Page_Load(object sender, EventArgs e)
	{
		log=new Log(this);
		try
		{
			forumTopicId = RequestUtils.GetForumTopicId(this);
			userId = Utils.GetUserId(Context);
			if (!base.IsPostBack)
			{
				if (userId != 0)
				{
					using (GmConnection conn = Global.CreateConnection())
					{
						string s = conn.ExecuteScalar("select Name from UserInfo where Id=" + userId) as string;
						if (s != null) tbName.Text = s;
					}
				}
			}
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}
	protected void btnSave_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			ForumMessage forumMessage = new ForumMessage();
			forumMessage.userId = userId;
			forumMessage.forumTopicId = forumTopicId;
			forumMessage.userName = tbName.Text.Trim();
			forumMessage.text = tbText.Text.Trim();

			using (GmConnection conn = Global.CreateConnection())
			{
				forumMessage.Save(conn);
			}
			Server.Transfer("ForumMessages.aspx?ft=" + forumTopicId);
			//			lblResult.Text = string.Format("Message добавлено.");
			//			WebUtils.Redirect(this, "Private/Users.aspx");
		}
		catch (System.Threading.ThreadAbortException ex)
		{
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}
}
