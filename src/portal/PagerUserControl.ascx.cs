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
using Geomethod.Data;

public partial class PagerUserControl : System.Web.UI.UserControl
{
    public string top = "";
    public string fields = "";
    public string table = "";
    public string join = "";
    public string cond = "";
    public string group = "";
    public string order = "";
    public int pageSize = 20;
    public int pageId = 1;

	protected void Page_Load(object sender, EventArgs e)
	{
		
	}

	public string GetSelectQuery()
	{ 
		var sb=new StringBuilder();
		sb.Append("select ");
		if(top.Length>0) sb.AppendFormat("top({0}) ",top);
		sb.AppendFormat("{0} from {1} ",fields, table);
        if (join.Length > 0) sb.AppendFormat("{0} ", join);
        if (cond.Length > 0) sb.AppendFormat("where {0} ", cond);
        if (group.Length > 0) sb.AppendFormat("group by {0} ", group);
        if (order.Length > 0) sb.AppendFormat("order by {0} ", order);
		return sb.ToString();
	}
	public string GetCountQuery()
	{
        var sb = new StringBuilder();
        if (group.Length > 0) sb.Append("select top(1) count(*) over() ");
        else sb.Append("select count(*) ");
        sb.AppendFormat("from {0} ", table);
        if (join.Length > 0) sb.AppendFormat("{0} ", join);
        if (cond.Length > 0) sb.AppendFormat("where {0} ", cond);
        if (group.Length > 0) sb.AppendFormat("group by {0} ", group);
        return sb.ToString();
	}
	public string GetPageQuery()
	{
		StringBuilder sb = new StringBuilder(1024);
		sb.AppendFormat("with t as (select Row_Number() over (order by {0}) as RowNum, {1} from {2} ", order, fields, table);
        if (join.Length > 0) sb.AppendFormat("{0} ", join);
        if (cond.Length > 0) sb.AppendFormat("where {0} ", cond);
        if (group.Length > 0) sb.AppendFormat("group by {0} ", group);
		sb.Append(") ");
		sb.Append("select * from t ");
		sb.AppendFormat("where RowNum>{0} and RowNum<={1} ", (pageId-1)*pageSize, pageId*pageSize);
//		if (order.Length > 0) sb.AppendFormat("order by {0} ", order);
		return sb.ToString();
	}
	public void GenerateControls(int count)
	{
		pageId = RequestUtils.GetPageId(this);
		if (pageId <= 0) pageId = 1;

		const int pagerCount = 10;
		if (pageSize <= 0 || pageId < 1) return;
		int pageCount = (count - 1 + pageSize) / pageSize;
		int startPage = ((pageId-1) / pagerCount) * pagerCount;
		int endPage = startPage + pagerCount;

		string url = base.Request.Url.OriginalString;
		if (url.Contains("?"))
		{
			int index = url.IndexOf("pg=");
			if (index > 0)
			{
				url = url.Substring(0, index);
			}
			else url += "&";
		}
		else url += "?";

		var sb = new StringBuilder();
		if (startPage >= pagerCount)
		{
			sb.AppendFormat("<a href='{0}pg={1}'>...</a> ",url,startPage-pagerCount);
		}
		for (int i = startPage + 1; i <= endPage && i <= pageCount; i++)
		{
			string styleStr = i == pageId ? " style='text-decoration:underline'" : "";
			sb.AppendFormat("<a href='{0}pg={1}'{2}>{1}</a> ", url, i, styleStr);
		}
		if (endPage < pageCount)
		{
			sb.AppendFormat("<a href='{0}pg={1}'>...</a> ", url, endPage+1);
		}
		lblContent.Text = sb.ToString();
	}
}
