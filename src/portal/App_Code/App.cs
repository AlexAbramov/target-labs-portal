using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Geomethod;
using Geomethod.Web;
using Geomethod.Data;

public class TargetLabsException : Exception
{
	public TargetLabsException(string message) : base(message) { }
}

public class App
{
	public App(ConnectionFactory connFact)
	{
/*		using (GmConnection conn = Global.CreateConnection())
		{ 
			conn.Fill("select * from Permissions",dtPermissions);
		}*/
		try
		{
			// update database
//            UpdateScripts.UpdateDb(connFact, PathUtils.BaseDirectory + "App_Data\\UpdateScripts.txt");
		}
		catch (Exception ex)
		{
			Global.Log.Exception(ex);
            throw ex;
		}

	}
/*	public static Log InitPage(Page page, int communityId)
	{
		page.Title = "Администрирование сайта - "+title;
		IMasterPage mp = page.Master as IMasterPage;
		mp.Log = new Log(page);
		mp.ucHeader.Title = title;
		return mp.Log;
	}*/

}
