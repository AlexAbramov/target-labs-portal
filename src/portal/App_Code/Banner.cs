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

public class Banner
{
	int id;
	public int bannerGroupId;
	public string filename;
	public string link;
	public RecordStatus status;
	public string name;
	public string code;

	public int Id { get { return id; } }
	public string GetHtmlCode()
	{
		if (code.Length > 0) return code;
		string res="";
		if(filename.Trim().Length>0)
		{
		  res=string.Format("<img src='Bns/{0}' alt=''/>",filename);
			if(link.Trim().Length>0)
			{
		    res=string.Format("<a target='_blank' href='{0}'>", link)+res+"</a>";
			}		
		}
		return res;
	}

	public static Banner GetBanner(GmConnection conn, int id)
	{
		if (id == 0) return null;
		GmCommand cmd = conn.CreateCommand("select * from Banners where Id=@Id");
		cmd.AddInt("Id", id);
		using (DbDataReader dr = cmd.ExecuteReader())
		{
			if (dr.Read()) return new Banner(dr);
		}
		return null;
	}
	public static int Remove(GmConnection conn, int id)
	{
		GmCommand cmd = conn.CreateCommand("delete from Banners where Id=@Id");
		cmd.AddInt("Id", id);
		return cmd.ExecuteNonQuery();
	}
	public Banner()
		: this(0)
	{
	}
	public Banner(int id)
	{
		this.id = id;
		bannerGroupId = 0;
		filename = "";
		link = "";
		status = RecordStatus.Admin;
		name = "";
		code = "";
	}
	public Banner(GmDataReader dr)
	{
		id = dr.GetInt();
		bannerGroupId = dr.GetInt();
		filename = dr.GetString();
		link = dr.GetString();
		status = (RecordStatus)dr.GetInt();
		name = dr.GetString();
		code = dr.GetString();
	}
	public void Save(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddInt("BannerGroupId", bannerGroupId);
		cmd.AddString("Filename", filename, MaxLength.Banners.Filename);
		cmd.AddString("Link", link, MaxLength.Banners.Link);
		cmd.AddInt("Status", (int)status);
		cmd.AddString("Name", name, MaxLength.Banners.Name);
		cmd.AddString("Code", code, MaxLength.Banners.Code);
		if (id == 0)
		{
			cmd.CommandText = "insert into Banners values (@BannerGroupId,@Filename,@Link,@Status,@Name,@Code) select @@Identity";
			id = (int)(decimal)cmd.ExecuteScalar();
		}
		else
		{
			cmd.CommandText = "update Banners set BannerGroupId=@BannerGroupId,Filename=@Filename,Link=@Link,Status=@Status,Name=@Name,Code=@Code where Id=@Id";
			cmd.ExecuteNonQuery();
		}
	}
}
