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

public partial class PollAnswersUserControl : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}
	public void InitControl(int pollId)
	{
		this.SqlDataSource1.SelectParameters["PollId"].DefaultValue = (pollId).ToString();
		hlAddPollAnswer.NavigateUrl = "PollAnswer.aspx?pl=" + pollId;
		Visible = pollId != 0;
	}
}
