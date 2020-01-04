using System;
using System.Text;
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

public partial class SearchUserControl : System.Web.UI.UserControl
{

	protected void Page_Load(object sender, EventArgs e)
	{

	}
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(GetQuery());
    }

    private string GetQuery()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("http://www.google.com/search?sitesearch=www.targetlabs.com&q=");
        int count = 0;
        foreach (var s in tbSearch.Text.Split(" ,;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
        {
            if (count > 0) sb.Append('+');
            sb.Append(s);
            count++;
        }
        return sb.ToString();
    }
}
