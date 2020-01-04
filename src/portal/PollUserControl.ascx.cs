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

public partial class PollUserControl : System.Web.UI.UserControl
{
	Log log=null;
	protected void Page_Load(object sender, EventArgs e)
  {
		Poll poll =null;
		try
		{
			log = new Log(this);
			if (!IsPostBack)
			{
				using (GmConnection conn = Global.CreateConnection())
				{
					poll = Poll.GetLastPoll(conn);
				}
				if (poll != null)
				{
					lblQuestion.Text = poll.question;
					SqlDataSource1.SelectParameters["PollId"].DefaultValue = poll.Id.ToString();
				}
			}
		}
		catch (Exception ex)
		{
			if(log!=null) log.Exception(ex);
		}
		finally
		{
			if(poll==null) this.Visible = false;
		}
  }
	protected void btnVote_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			int answerId=int.Parse(rblAnswers.SelectedValue);
			using (GmConnection conn = Global.CreateConnection())
			{
				PollAnswer.Vote(conn,answerId);
			}
		}
		catch (Exception ex)
		{
			if(log!=null) log.Exception(ex);
		}
		finally
		{
			WebUtils.Redirect(this,"PollResults.aspx");
		}
	}
}
