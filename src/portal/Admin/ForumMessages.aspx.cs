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
using Geomethod.Web;

public partial class ForumMessagesAdminPage : System.Web.UI.Page
{
	Log log;
	GridHelper gridHelper;
	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			log = AdminMasterPage.InitPage(this, "Forum messages", true);
			gridHelper = new GridHelper(this, gridView);
			if (!IsPostBack)
			{
				LoadData();
			}
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}

	private void LoadData()
	{
		int forumTopicId=RequestUtils.GetForumTopicId(this);
		hlAdd.NavigateUrl += "?ft=" + forumTopicId;
		gridHelper.ClearDataTable();
		string query = "select ForumMessages.Id,Date,UserName,SUBSTRING(Text,0,50) as Text, Symbol from ForumMessages left join Statuses on Statuses.Id=Status where ForumTopicId=" + forumTopicId;
		using (GmConnection conn = Global.CreateConnection())
		{
			conn.Fill(gridHelper.DataTable, query);
		}
		gridHelper.DataTable.DefaultView.Sort = "Id desc";
	}
}
