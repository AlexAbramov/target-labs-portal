using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ArticleControls : System.Web.UI.UserControl
{
    public string applyLink = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void InitControl(string parentTag, int articleId)
    {
        bool vis=parentTag=="Positions";
        this.Visible = vis;
        if (vis)
        {
            applyLink = "SubmitResume.aspx?ar=" + articleId;
        }
    }
}