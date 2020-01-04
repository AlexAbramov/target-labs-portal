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

public partial class PositionsUserControl : System.Web.UI.UserControl
{
	public string page="Page.aspx?"; 
	protected void Page_Load(object sender, EventArgs e)
	{
	}
    private void InitPager(int parentId, int topNumber, bool enablePager)
	{
		ucPager.top = "@TopNumber";
		ucPager.fields="Id, Date, Title, Preview, Header, Link";
		ucPager.table="Articles";
        ucPager.cond = "(ParentId = @ParentId) and Articles.Status>=0";
		ucPager.order = "Date desc";
		if (enablePager)
		{
			int count = 0;
			string cmdText = ucPager.GetCountQuery();
 			using (GmConnection conn = Global.CreateConnection())
			{
				GmCommand cmd = conn.CreateCommand(cmdText);
				cmd.AddInt("ParentId", parentId);
				cmd.AddInt("TopNumber", topNumber);
				count = (int)conn.ExecuteScalar(cmd);
			}
			ucPager.GenerateControls(count);
			this.SqlDataSource1.SelectCommand = ucPager.GetPageQuery();
		}
		else
		{
			ucPager.Visible = false;
			this.SqlDataSource1.SelectCommand=ucPager.GetSelectQuery();
		}
		//SELECT TOP (@TopNumber) Id, Date, Title, Preview, Header, Link FROM Articles WHERE (ArticleTypeId = @ArticleTypeId) and Articles.Status>0 order by Date desc
	}
    public bool InitControl(string tag, int topNumber, bool enablePager)
    {
        Log log = new Log(this);
        try
        {
            int parentId = 0;
            using (GmConnection conn = Global.CreateConnection())
            {
                parentId = Article.GetArticleGroupId(conn, tag);
            }
            if (parentId > 0) return InitControl(parentId, topNumber, enablePager);
        }
        catch (Exception ex)
        {
            log.Exception(ex);
        }
        return false;
    }
	bool InitControl(int parentId, int topNumber, bool enablePager)
	{
		Log log = new Log(this);
        try
        {
            InitPager(parentId, topNumber, enablePager);
            this.SqlDataSource1.SelectParameters["ParentId"].DefaultValue = parentId.ToString();
            this.SqlDataSource1.SelectParameters["TopNumber"].DefaultValue = topNumber.ToString();
            return true;
        }
        catch (Exception ex)
        {
            log.Exception(ex);
        }
        return false;
	}

}
