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

public partial class ArticlePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
			Log log=MainMasterPage.InitPage(this);
			try
			{
                int articleId = Utils.GetArticleId(this);

				if (articleId != 0)
				{
                    Article article = null;
//					string articleTitle=null;
                    string parentTag=null;
                    using (GmConnection conn = Global.CreateConnection())
					{
                        article=Article.GetArticle(conn, articleId);
                        if(article!=null) parentTag=article.GetParentTag(conn);
					}
                    if (article != null)
                    {
                        ucArticle.InitControl(article);
                        (this.Master as MainMasterPage).PageInfo.AddInfo(article.title, "", article.header);
                        if (article.isGroup)
                        {
                            ucArticles.InitControl(article.Id, 10, true);
                        }
                        else ucArticles.Visible = false;
                        ucArticleControls.InitControl(parentTag, articleId);
                    }
				}
			}
			catch (Exception ex)
			{
				log.Exception(ex);
			}
		}
}
