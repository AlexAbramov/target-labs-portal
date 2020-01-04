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

public partial class SubmitResume : System.Web.UI.Page
{
    Log log;
    protected void Page_Load(object sender, EventArgs e)
    {
		log=MainMasterPage.InitPage(this);
		try
		{
            if (!IsPostBack)
            {
                ucCandidate.LoadData();
            }
		}
		catch (Exception ex)
		{
			log.Exception(ex);
            lblResult.ForeColor = System.Drawing.Color.Red;
            lblResult.Text = ex.Message;
		}
	}

    protected void btnApply_Click(object sender, EventArgs e)
    {
        try
        {
            if (ucCandidate.Visible)
            {
                ucCandidate.SaveData();
                ucCandidate.Visible = false;
                btnApply.Visible = false;
                lblResult.ForeColor = System.Drawing.Color.Green;
                lblResult.Text = "Your resume successfully submitted!";
            }
        }
        catch (Exception ex)
        {
            log.Exception(ex);
            lblResult.ForeColor = System.Drawing.Color.Red;
            lblResult.Text = ex.Message;
        }

    }
}
