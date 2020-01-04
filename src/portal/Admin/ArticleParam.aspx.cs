using System;
using System.IO;
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

public partial class WebSitePage : System.Web.UI.Page
{
	Log log;
	PageHelper pageHelper;
    [SessionObject]
    public ArticleParam articleParam;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			log = AdminMasterPage.InitPage(this, "Article Param");
			pageHelper = new PageHelper(this);
			if (!IsPostBack)
			{
				LoadData();
				BindData();
			}
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}

	void LoadData()
	{
		int id  = RequestUtils.GetArticleParamId(this);
        if (id != 0)
        {
            using (GmConnection conn = Global.CreateConnection())
            {
                articleParam = ArticleParam.GetArticleParam(conn, id);
            }
        }
        else
        {
            int ar=RequestUtils.GetArticleId(this);
            articleParam = new ArticleParam(ar);
        }
	}

	void BindData()
	{
        if (articleParam != null)
        {
            tbKey.Text = articleParam.key;
            tbValue.Text = articleParam.value;

            tbKey.MaxLength = MaxLength.ArticleParam.Key;
            tbValue.MaxLength = MaxLength.ArticleParam.Value;
        }
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
            articleParam.key = tbKey.Text.Trim();
            articleParam.value = tbValue.Text;
			using (GmConnection conn = Global.CreateConnection())
			{
                articleParam.Save(conn);
			}
			lblResult.Text = string.Format("Data saved.");
            WebUtils.Redirect(this, "Admin/ArticleParams.aspx?ar=" + articleParam.articleId);
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}
}
