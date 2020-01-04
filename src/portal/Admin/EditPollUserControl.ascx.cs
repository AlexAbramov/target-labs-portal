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

public partial class EditPollUserControl : System.Web.UI.UserControl
{
	internal Poll poll;
	public void InitControl(Poll poll)
	{
		this.poll = poll;
		if (!IsPostBack)
		{
			using (GmConnection conn = Global.CreateConnection())
			{
				Utils.FillDDL(conn, ddlStatus, "select Id, Name from Statuses", (int)poll.status);
			}
			tbQuestion.Text = poll.question;
			tbQuestion.MaxLength = MaxLength.Polls.Question;
		}
		else
		{
			poll.question = tbQuestion.Text.Trim();
			poll.status = (RecordStatus)int.Parse(ddlStatus.SelectedValue);
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
	}
}
