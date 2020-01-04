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

public partial class Candidates : System.Web.UI.Page
{
    Log log;
	protected void Page_Load(object sender, EventArgs e)
	{
        log = AdminMasterPage.InitPage(this, "Candidates", true);
        try
        {
            int articleId=RequestUtils.GetArticleId(this);
            this.SqlDataSource1.SelectParameters["PositionId"].DefaultValue = articleId.ToString();  
        }
        catch (Exception ex)
        {
            log.Exception(ex);
        }
	}

    public string UrlEncode(object obj)
    {
        return Server.UrlPathEncode(obj.ToString());
    }
}
