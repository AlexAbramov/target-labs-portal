using System;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

public partial class SubContentUserControl : System.Web.UI.UserControl
{
    static Dictionary<string,int> articleIds = new Dictionary<string,int>();
    StringDictionary sd = new StringDictionary();
    public string GetValue(string key) { return sd.ContainsKey(key) ? sd[key] : "item not found"; }

    public string PageTag { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(PageTag))
        {
            int articleId = articleIds.ContainsKey(PageTag) ? articleIds[PageTag] : 0;
            using (var conn = Global.CreateConnection())
            {
                if (articleId == 0)
                {
                    var article = Article.GetArticle(conn, PageTag);
                    if (article != null)
                    {
                        articleId = article.Id;
                        articleIds[PageTag] = articleId;
                    }
                }
                if (articleId != 0)
                {
                    ArticleParam.GetArticleParams(conn, articleId, sd);
                }
            }
        }
    }


}
