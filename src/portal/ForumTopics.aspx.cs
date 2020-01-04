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

public partial class ForumTopicsPage : System.Web.UI.Page
{
	Log log;
	public string forumName = "";
	protected void Page_Load(object sender, EventArgs e)
	{
		log=MainMasterPage.InitPage(this);
		int forumId=RequestUtils.GetForumId(this);
		this.SqlDataSource1.SelectParameters["ForumId"].DefaultValue = forumId.ToString();
		try
		{
			Forum forum = null;
			using (GmConnection conn = Global.CreateConnection())
			{
				forum = Forum.GetForum(conn, forumId);
			}
			if (forum != null)
			{
				forumName = forum.name;
			}
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}
}
