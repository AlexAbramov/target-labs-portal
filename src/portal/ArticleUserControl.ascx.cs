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

public partial class ArticleUserControl : System.Web.UI.UserControl
{
    Article article;
	protected void Page_Load(object sender, EventArgs e)
	{

	}
    public void InitControl(Article article)
	{
        litDate.Text = article.date.ToShortDateString();//<%# Eval("Date", "{0:MM.dd.yyyy}")%>
        litDate.Visible = String.IsNullOrWhiteSpace(article.tag);
        litTitle.Text = article.title;
        litText.Text = article.text;
        if(!String.IsNullOrEmpty(article.link))
        {
            hlLink.NavigateUrl = Geomethod.Web.WebUtils.GetUrl(article.link);
            hlLink.Text=Geomethod.Web.WebUtils.GetHost(article.link);
        }
        else hlLink.Visible=false;
	}
}
