using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Geomethod.Data;

public partial class ForumMessagesPage : System.Web.UI.Page
{
	Log log;
	public int forumId = 0;
	public string forumName = "";
	public string forumTopicName = "";
	protected void Page_Load(object sender, EventArgs e)
	{
		log = MainMasterPage.InitPage(this);
		int forumTopicId = RequestUtils.GetForumTopicId(this);
		this.SqlDataSource1.SelectParameters["ForumTopicId"].DefaultValue = forumTopicId.ToString();
		try
		{
			string cmdText = "SELECT Forums.Id AS ForumId, Forums.Name AS ForumName, ForumTopics.Name AS ForumTopicName FROM Forums INNER JOIN   ForumTopics ON Forums.Id = ForumTopics.ForumId WHERE (ForumTopics.Id = @ForumTopicId)";
			using (GmConnection conn = Global.CreateConnection())
			{
				GmCommand cmd=conn.CreateCommand(cmdText);
				cmd.AddInt("ForumTopicId", forumTopicId);
				using (GmDataReader dr=cmd.ExecuteReader())
				{
					if (dr.Read())
					{
						forumId = dr.GetInt();
						forumName = dr.GetString();
						forumTopicName = dr.GetString();
					}
					else return;
				}
			}
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}
}