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

public partial class PollAnswerUserControl : System.Web.UI.UserControl
{
	internal PollAnswer pollAnswer;
	public void InitControl(PollAnswer pollAnswer)
	{
		this.pollAnswer = pollAnswer;
		if (!IsPostBack)
		{
			using (GmConnection conn = Global.CreateConnection())
			{
				Utils.FillDDL(conn, ddlStatus, "select Id, Name from Statuses", (int)pollAnswer.status);
			}
			tbAnswer.Text = pollAnswer.answer;
			tbAnswer.MaxLength = MaxLength.PollAnswers.Answer;
		}
		else
		{
			pollAnswer.answer = tbAnswer.Text.Trim();
			pollAnswer.status = (RecordStatus)int.Parse(ddlStatus.SelectedValue);
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
	}
}
