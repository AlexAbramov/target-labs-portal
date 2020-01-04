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

public partial class Positions : System.Web.UI.Page
{
    Log log;
	protected void Page_Load(object sender, EventArgs e)
	{
        log=AdminMasterPage.InitPage(this, "Positions", true);
        try
        {
            int articleId=0;
            using (var conn = Global.CreateConnection())
            {
                articleId = Article.GetArticleId(conn, "Positions");
            }
            ucPositions.InitControl(articleId, 20, true);           
        }
        catch (Exception ex)
        {
            log.Exception(ex);
        }
	}
}
