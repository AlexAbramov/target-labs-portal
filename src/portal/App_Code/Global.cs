using System;
using System.Security;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Web.SessionState;
using Geomethod;
using Geomethod.Web;
using Geomethod.Data;
using System.Security.Principal;

/// <summary>
/// Summary description for Global
/// </summary>
public class Global
{
	static Log log;
	static GmProviderFactory providerFactory;
    static ConnectionFactory connFactory;
	static System.Timers.Timer timer = new System.Timers.Timer();
	static string connStr = "";
	static App app;
	static AppCache appCache;

	public static GmConnection CreateConnection() { return connFactory.CreateConnection(); }
	public static App App { get { return app; } }
	public static Log Log { get { return log; } }
	public static AppCache AppCache { get { return appCache; } }
	public static object ExecuteScalar(string cmdText)
	{
		using (GmConnection conn = Global.CreateConnection())
		{
			return conn.ExecuteScalar(cmdText);
		}
	}
 
	public static void Application_Start()
	{
//		string connName = System.Diagnostics.Debugger.IsAttached ? "LocalConnectionString" : "AppConnectionString";
		connStr = ConfigurationManager.ConnectionStrings["AppConnectionString"].ConnectionString;
		providerFactory = new SqlServerProvider();
        connFactory=providerFactory.CreateConnectionFactory(connStr);
		log = new Log(null);
		log.Info("Application_Start");
		try
		{
            app = new App(connFactory);
			appCache = new AppCache();
			
//			app.hhImport.Import(log);//!!! test
			
			timer.Interval = double.Parse(WebConfigurationManager.AppSettings["timerIntervalSec"]) * 1000;
			timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
			timer.Enabled = true;
		}
		catch (Exception ex)
		{
			log.Exception(ex);
//			throw ex;
		}
	}

	public static bool ResetAppCache()
	{
		try
		{
			Global.appCache = new AppCache();
			return true;
		}
		catch (Exception ex)
		{
			log.Exception(ex);
			return false;
		}
	}

	public static void Application_End()
	{
	}

	public static void Application_Error()
	{
	}

	public static void Session_Start(HttpRequest httpRequest, HttpSessionState httpSessionState)
	{
		try
		{
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}

	public static void Session_End()
	{
	}

	static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
	{
		try
		{
/*			DateTime dt = DateTime.Now;
			if (2 <= dt.Hour && dt.Hour < 4 && dt.Day!=prevDay)
			{
				prevDay = dt.Day;
				app.rabotaRuImport.Import(log);
			}
			if (4 <= dt.Hour && dt.Hour < 6 && dt.Day != prevDay2)
			{
				prevDay2 = dt.Day;
				app.hhImport.Import(log);
			}*/
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}

	public static void Application_OnBeginRequest(HttpContext httpContext)
	{
		httpContext.Items.Add("StartTime", DateTime.Now);
	}

	public static void Application_OnEndRequest(HttpContext httpContext, HttpResponse httpResponse)
	{
/*		if (httpContext.Items.Contains("StartTime"))
		{
			object obj=httpContext.Items["StartTime"];
			if (obj is DateTime)
			{ 
				TimeSpan ts=DateTime.Now-(DateTime)obj;
				httpResponse.Write(ts.Milliseconds);
			}
		}*/
	}

/*		public static void Application_AuthorizeRequest(HttpContext httpContext, HttpRequest httpRequest)
		{
			HttpContext currentContext = HttpContext.Current;
			if (HttpContext.Current.User != null)
			{
				if (HttpContext.Current.User.Identity.IsAuthenticated)
				{
					if (HttpContext.Current.User.Identity is FormsIdentity)
					{
						FormsIdentity id = HttpContext.Current.User.Identity as FormsIdentity;
						FormsAuthenticationTicket ticket = id.Ticket;
						string userData = ticket.UserData;
						// Roles is a helper class which places the roles of the
						// currently logged on user into a string array
						// accessable via the value property.
	//					Roles userRoles = new Roles(userData);

						string[] ss ={ "Admin" };
						HttpContext.Current.User = new GenericPrincipal(id,ss);// CustomPrincipal(id);
					}
				}
			}
		}*/
}
