using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class LearnixDefaultPage : System.Web.UI.Page
{
    StringDictionary sd = new StringDictionary();
    public string GetValue(string key) { return sd.ContainsKey(key)?sd[key]:"item not found"; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Log log = LearnixMasterPage.InitPage(this);
//			ucArticles.InitControl(ArticleType.Article, 3, false);
        try
        {            
//            ucPositions.InitControl("Positions", 6, false);
            Article article = null;
            using (var conn = Global.CreateConnection())
            {
                article=Article.GetArticle(conn, "LearnixDefaultPage");            
                if (article != null)
                {
                    ArticleParam.GetArticleParams(conn, article.Id, sd);
                }
            }

            //			ucDigests.InitControl(ArticleType.Digest, 2, false);
        }
        catch (Exception ex)
        {
            log.Exception(ex);
        }
    }
}
