using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Geomethod;
using Geomethod.Data;

public class LinkExchangePage
{
	int id;
	public DateTime date;
	public string text;

	public int Id { get { return id; } }

	public static LinkExchangePage GetLinkExchangePage(GmConnection conn, int id)
	{
		if (id == 0) return null;
		GmCommand cmd = conn.CreateCommand("select * from LinkExchange where Id=@Id");
		cmd.AddInt("Id", id);
		using (DbDataReader dr = cmd.ExecuteReader())
		{
			if (dr.Read()) return new LinkExchangePage(dr);
		}
		return null;
	}
	public static int Remove(GmConnection conn, int id)
	{
		GmCommand cmd = conn.CreateCommand("delete from LinkExchange where Id=@Id");//!!!
		cmd.AddInt("Id", id);
		return cmd.ExecuteNonQuery();
	}
	public LinkExchangePage()
		: this(0)
	{
	}
	public LinkExchangePage(int id)
	{
		this.id = id;
		date = DateTime.Now;
		text = "";
	}
	public LinkExchangePage(GmDataReader dr)
	{
		id = dr.GetInt();
		date = dr.GetDateTime();
		text = dr.GetString();
	}
	public void Save(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddDateTime("Date", date);
		cmd.AddString("Text", text, MaxLength.LinkExchangePages.Text);
		if (id == 0)
		{
			cmd.CommandText = "insert into LinkExchange values (@Id,@Date,@Text)";
//			id = (int)(decimal)cmd.ExecuteScalar();
		}
		else
		{
			cmd.CommandText = "update LinkExchange set Date=@Date,Text=@Text where Id=@Id";
			cmd.ExecuteNonQuery();
		}
	}
}
