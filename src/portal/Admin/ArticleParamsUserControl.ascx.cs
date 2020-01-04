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
using Geomethod.Web;
using Geomethod.Data;

public partial class ArticleParamsUserControl : System.Web.UI.UserControl
{
	public string page="Default.aspx?"; 
	protected void Page_Load(object sender, EventArgs e)
	{
	}
 	public void InitControl(int articleId)
	{
        this.SqlDataSource1.SelectParameters["ArticleId"].DefaultValue = articleId.ToString();
        hlAddParam.NavigateUrl = "ArticleParam.aspx?ar=" + articleId;
	}

}
