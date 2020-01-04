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

public partial class ArticleParams : System.Web.UI.Page
{
	Log log;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			log = AdminMasterPage.InitPage(this, "Edit article");
            int ar = RequestUtils.GetArticleId(this);
            if (ar != 0)
            {
                ucArticleParams.InitControl(ar);
            }
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}

	}
}
