using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Geomethod.Data;

public enum LogType { Info=1, Warning=2, Error=3, Exception=4, Custom=5 };

public class Log
{
	Control ctl;
	string page;
	int sessionId;
	public Log(Control ctl)
	{
		this.ctl = ctl;
		page = ctl==null ? "" : ctl.Page.Request.Url.AbsoluteUri;
		sessionId = 0;
//		User user=Utils.GetUser(ctl);
//		sessionId = user!=null? user.Id : 0;
//!!!		if (ctl is Page || ctl is MasterPage) Info(!ctl.Page.IsPostBack ? "PageLoad" : "PostBack");
	}

	public void Info(string msg) { Write(LogType.Info, msg); }
	public void Warning(string msg) { Write(LogType.Warning, msg); }
	public void Error(string msg) { Write(LogType.Error, msg); }
	public void Exception(Exception ex) { Write(LogType.Exception, ex.Message); }
	public void Write(LogType logType, string msg)
	{
		try
		{
			using (GmConnection conn = Global.CreateConnection())
			{
				GmCommand cmd = conn.CreateCommand("insert into Log values (@Time,@SessionId,@LogTypeId,@Page,@Message)");
				cmd.AddDateTime("Time", DateTime.Now);
				cmd.AddInt("SessionId", (int)sessionId);
				cmd.AddInt("LogTypeId", (int)logType);
				cmd.AddString("Page", page);
				cmd.AddString("Message", msg, MaxLength.Log.Message);
				cmd.ExecuteNonQuery();
			}
		}
		catch
		{
		}
		switch (logType)
		{
			case LogType.Error:
			case LogType.Exception:
				if(ctl!=null) ctl.Page.Response.Write(string.Format("<p>{0}</p>",msg));
				break;
		}
	}
}
