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

public partial class PollAnswerPage : System.Web.UI.Page
{
	Log log;
	PageHelper pageHelper;
	[SessionObject]
	public PollAnswer pollAnswer;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			log = AdminMasterPage.InitPage(this, "Poll answer");
			pageHelper = new PageHelper(this);
			if (!IsPostBack)
			{
				LoadData();
			}
			ucPollAnswer.InitControl(pollAnswer);
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}

	}
	void LoadData()
	{
		int pa  = RequestUtils.GetPollAnswerId(this);
		if (pa != 0)
		{
			using (GmConnection conn = Global.CreateConnection())
			{
				pollAnswer = PollAnswer.GetPollAnswer(conn, pa);
			}
		}
		if (pollAnswer == null)
		{
			pollAnswer = new PollAnswer();
			int pl = RequestUtils.GetPollId(this);
			if (pl != 0)
			{
				pollAnswer.pollId = pl;
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			if (pollAnswer.pollId == 0) return;
			if (pollAnswer.Id == 0) pollAnswer.status = RecordStatus.Admin;
			using (GmConnection conn = Global.CreateConnection())
			{
				pollAnswer.Save(conn);
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
