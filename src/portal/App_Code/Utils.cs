using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Geomethod.Data;

/// <summary>
/// Summary description for Utils
/// </summary>
public class Utils
{
	static Random rand = new Random((int)DateTime.Now.Ticks);
	public static string GeneratePassword()
	{
		StringBuilder sb = new StringBuilder(10);
		for (int i = 0; i < 7; i++)
		{
			int r = rand.Next(36);
			if (r < 26) r += (int)'a';
			else r += (int)'0' - 26;
			char c = (char)r;
			sb.Append(c);
		}
		return sb.ToString();
	}
	public static string FixText(object obj) { return Geomethod.Web.WebUtils.FixText(obj); }
	public static string ToDateTimeString(DateTime dt)
	{
		if (dt == DateTime.MinValue) return "";
        return dt.ToString("MMM d yy hh:mm");
	}
    public static string ToDateString(DateTime dt)
    {
        if (dt == DateTime.MinValue) return "";
        return dt.ToString("MMM d yy");
    }
    public static string ToString(DateTime dt)
	{
		if (dt == DateTime.MinValue) return "";
		return dt.ToString("dd.MM.yy");
	}
	public static int GetInt(string s)
	{
		if (s.Trim().Length == 0) return 0;
		try
		{
			return int.Parse(s);
		}
		catch
		{
			return 0;
		}
	}
/*	public static User GetUser(Control ctl)
	{
		return GetSessionObject(ctl, SessionObject.User) as User;
	}

	public static Role GetRole(Control ctl)
	{
		return GetSessionObject(ctl, SessionObject.Role) as Role;
	}*/

	public static object GetSessionObject(Control ctl, SessionObject sessionObject)
	{
		return ctl.Page.Session[sessionObject.ToString()];
	}

	public static void SetSessionObject(Control ctl, SessionObject sessionObject, object obj)
	{
		ctl.Page.Session[sessionObject.ToString()] = obj;
	}

	public static DateTime ToDateTime(string s)
	{
		if (s.Trim().Length == 0) return DateTime.MinValue;
		return DateTime.Parse(s);
/*		string[] ss = s.Split("./\\ ,;:");
		int year = int.Parse(ss[0]);
		int month = int.Parse(ss[1]);
		int day = 0;
		int hour = 0;
		int min = 0;
		int sec = 0;
		return new DateTime(year, month, day, hour, min, second);*/
	}

	public static void FillDDL(GmConnection conn, DropDownList ddl, string cmdText, int selectedId)
	{ FillDDL(conn, ddl, cmdText, selectedId, null); }
	public static void FillDDL(GmConnection conn, DropDownList ddl, string cmdText, int selectedId, string zeroName)
	{
		if (zeroName != null)
		{
			ListItem li = new ListItem(zeroName, "0");
			if (0 == selectedId) li.Selected = true;
			ddl.Items.Add(li);
		}
		using (DbDataReader dr = conn.ExecuteReader(cmdText))
		{
			while (dr.Read())
			{
				int id = dr.GetInt32(0);
				string text = dr.GetString(1);
				ListItem li = new ListItem(text,id.ToString());
				if (id == selectedId) li.Selected = true;
				ddl.Items.Add(li);
			}
		}
	}
	public static int GetUserId(HttpContext ctx)
	{
		try
		{
			string s = ctx.User.Identity.Name;
			string[] ss = s.Split('_');
			if(ss.Length>1)	return int.Parse(ss[1]);
		}
		catch { }
		return 0;
	}

	public static UserRole GetUserRole(HttpContext ctx)
	{
		try
		{
			string s = ctx.User.Identity.Name;
			string [] ss=s.Split('_');
			return (UserRole)int.Parse(ss[0]);
		}
		catch { }
		return UserRole.None;
	}

    public static MenuItem GetMenuItem(SiteMapNode siteNode)
    {
        string url=siteNode.Url;
        if (url.EndsWith("#")) url = url.Remove(url.Length - 1);
        return new MenuItem(siteNode.Title,"","",url);
    }

    public static int GetArticleId(Page page)
    {
        int articleId = RequestUtils.GetArticleId(page);
        if (articleId == 0)
        {
            string tag = RequestUtils.GetTag(page);
            if (!String.IsNullOrWhiteSpace(tag))
            {
                using (var conn = Global.CreateConnection())
                {
                    articleId = Article.GetArticleId(conn, tag);
                }
            }
        }
        return articleId;
    }

    public static bool IsVisible(object obj)
    {
        return !String.IsNullOrEmpty(obj as string);
    }


    //public static string UrlEncode(object obj)
    //{
    //    var filename=obj.ToString();
    //    if(filename.Length>0)
    //    {
    //        UTF8Encoding utf8 = new UTF8Encoding();
    //        byte[] bytes = utf8.GetBytes(filename);
    //        char[] chars = new char[bytes.Length];
    //        for(int index=0; index<bytes.Length; index++)
    //        {
    //            chars[index] = Convert.ToChar(bytes[index]);
    //        }

    //        string s = new string(chars);
    //        return s;
    //    }
    //    return "";
    //}
}


