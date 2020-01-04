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

public class WebPage
{
	int id;
	public string name;
	public int bannerTopicId;
	public string title;
	public string description;
	public string keywords;

	public int Id { get { return id; } }
	public bool IsBannerTopicFixed { get { return bannerTopicId == 0 || Id<=100; } }

	public static WebPage GetWebPage(GmConnection conn, int id)
	{
		if (id == 0) return null;
		GmCommand cmd = conn.CreateCommand("select * from Pages where Id=@Id");
		cmd.AddInt("Id", id);
		using (DbDataReader dr = cmd.ExecuteReader())
		{
			if (dr.Read()) return new WebPage(dr);
		}
		return null;
	}
	public static int Remove(GmConnection conn, int id)
	{
		GmCommand cmd = conn.CreateCommand("delete from Pages where Id=@Id");//!!!
		cmd.AddInt("Id", id);
		return cmd.ExecuteNonQuery();
	}
	public WebPage()
		: this(0)
	{
	}
	public WebPage(int id)
	{
		this.id = id;
		name = "";
		bannerTopicId = 0;
		title = "";
		description = "";
		keywords = "";
	}
	public WebPage(GmDataReader dr)
	{
		id = dr.GetInt();
		name = dr.GetString();
		bannerTopicId = dr.GetInt();
		title = dr.GetString();
		description = dr.GetString();
		keywords = dr.GetString();
	}
	public void Save(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddString("Name", name, MaxLength.Pages.Name);
		cmd.AddInt("BannerTopicId", bannerTopicId);
		cmd.AddString("Title", title, MaxLength.Pages.Title);
		cmd.AddString("Description", description, MaxLength.Pages.Description);
		cmd.AddString("Keywords", keywords, MaxLength.Pages.Keywords);
		if (id == 0)
		{
			cmd.CommandText = "insert into Pages values (@Name,@BannerTopicId,@Title,@Description,@Keywords) select @@Identity";
			id = (int)(decimal)cmd.ExecuteScalar();
		}
		else
		{
			cmd.CommandText = "update Pages set Name=@Name,BannerTopicId=@BannerTopicId,Title=@Title,Description=@Description,Keywords=@Keywords where Id=@Id";
			cmd.ExecuteNonQuery();
		}
	}
}
