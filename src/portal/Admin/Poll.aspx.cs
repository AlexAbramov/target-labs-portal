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
using Geomethod;
using Geomethod.Data;
using Geomethod.Web;

public partial class PollPage : System.Web.UI.Page
{
	Log log;
	PageHelper pageHelper;
	[SessionObject]
	public Poll poll;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			log = AdminMasterPage.InitPage(this, "Poll");
			pageHelper = new PageHelper(this);
			if (!IsPostBack)
			{
				LoadData();
			}
			ucPoll.InitControl(poll);
			ucPollAnswers.InitControl(poll.Id);
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}

	}
	void LoadData()
	{
		int id = RequestUtils.GetPollId(this);
		if (id!=0)
		{
			using (GmConnection conn = Global.CreateConnection())
			{
				poll = Poll.GetPoll(conn, id);
			}
		}
		if (poll == null)
		{
			poll = new Poll();
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			int id = poll.Id;
			if (id == 0) poll.status = RecordStatus.Admin;
			using (GmConnection conn = Global.CreateConnection())
			{
				poll.Save(conn);
			}
			lblResult.Text = string.Format("Data saved.");
			if (id == 0 && poll.Id > 0)
			{
				ucPollAnswers.InitControl(poll.Id);
			}
//			WebUtils.Redirect(this, "Private/Users.aspx");
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}
}
