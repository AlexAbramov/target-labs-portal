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

public partial class LearnixFooterUserControl : System.Web.UI.UserControl
{
    StringDictionary sd = new StringDictionary();
    public string GetValue(string key) { return sd.ContainsKey(key) ? sd[key] : "item not found"; }

    protected void Page_Load(object sender, EventArgs e)
    {
			this.Page.PreRenderComplete += new EventHandler(Page_PreRenderComplete);
    }

	void Page_PreRenderComplete(object sender, EventArgs e)
	{
		HttpContext httpContext = this.Context;
		if (httpContext.Items.Contains("StartTime"))
		{
			object obj=httpContext.Items["StartTime"];
			if (obj is DateTime)
			{ 
				TimeSpan ts=DateTime.Now-(DateTime)obj;
				lblGenTime.Text = "Page generated: "+ts.Milliseconds.ToString()+"ms";
			}
		}
	}
}
