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

public partial class ArticlePage : System.Web.UI.Page
{
	Log log;
	PageHelper pageHelper;
	[SessionObject]
	public Article article;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			log = AdminMasterPage.InitPage(this, "Edit article");
			pageHelper = new PageHelper(this);
			if (!IsPostBack)
			{
				LoadData();
				//				PrivateMasterPage.InitPage(this, user.Id == 0 ? "Add пользователя" : "Пользователь", false);
			}
			ucArticle.InitControl(article);
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}

	}
	void LoadData()
	{
		int id = RequestUtils.GetArticleId(this);
		if (id != 0)
		{
			using (GmConnection conn = Global.CreateConnection())
			{
				article = Article.GetArticle(conn, id);
			}
		}
		if (article == null)
		{
			article = new Article();
            int ag = RequestUtils.GetArticleGroupId(this);
            if (ag != 0)
            {
                article.parentId = ag;
            }
            else
            {
                article.isGroup = true;
            }
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			int id = article.Id;
			using (GmConnection conn = Global.CreateConnection())
			{
				article.Save(conn);
			}
			lblResult.Text = string.Format("Data saved.");
            WebUtils.Redirect(this, "Admin/Default.aspx?ar="+article.parentId.ToString());
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}
}
