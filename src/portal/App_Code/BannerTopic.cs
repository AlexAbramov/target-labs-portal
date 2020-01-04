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

public class BannerTopic
{
	int id;
	public string name;
	public int b1,b2,b3,b4,b5,b6,b7,b8,b9;

	public int Id { get { return id; } }

	public static BannerTopic GetBannerTopic(GmConnection conn, int id)
	{
		if (id == 0) return null;
		GmCommand cmd = conn.CreateCommand("select * from BannerTopics where Id=@Id");
		cmd.AddInt("Id", id);
		using (DbDataReader dr = cmd.ExecuteReader())
		{
			if (dr.Read()) return new BannerTopic(dr);
		}
		return null;
	}
	public static int Remove(GmConnection conn, int id)
	{
		GmCommand cmd = conn.CreateCommand("delete from BannerTopics where Id=@Id");//!!!
		cmd.AddInt("Id", id);
		return cmd.ExecuteNonQuery();
	}
	public BannerTopic()
		: this(0)
	{
	}
	public BannerTopic(int id)
	{
		this.id = id;
		name = "";
		b1=b2=b3=b4=b5=b6=b7=b8=b9=0;
	}
    public BannerTopic(GmDataReader dr)
	{
		id = dr.GetInt32();
		name = dr.GetString();
		b1 = dr.GetInt32();
		b2 = dr.GetInt32();
		b3 = dr.GetInt32();
		b4 = dr.GetInt32();
		b5 = dr.GetInt32();
		b6 = dr.GetInt32();
		b7 = dr.GetInt32();
		b8 = dr.GetInt32();
		b9 = dr.GetInt32();
	}
	public void Save(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddString("Name", name, MaxLength.BannerTopics.Name);
		cmd.AddInt("B1", b1);
		cmd.AddInt("B2", b2);
		cmd.AddInt("B3", b3);
		cmd.AddInt("B4", b4);
		cmd.AddInt("B5", b5);
		cmd.AddInt("B6", b6);
		cmd.AddInt("B7", b7);
		cmd.AddInt("B8", b8);
		cmd.AddInt("B9", b9);
		if (id == 0)
		{
			cmd.CommandText = "insert into BannerTopics values (@Name,@B1,@B2,@B3,@B4,@B5,@B6,@B7,@B8,@B9) select @@Identity";
			id = (int)(decimal)cmd.ExecuteScalar();
		}
		else
		{
			cmd.CommandText = "update BannerTopics set Name=@Name,B1=@B1,B2=@B2,B3=@B3,B4=@B4,B5=@B5,B6=@B6,B7=@B7,B8=@B8,B9=@B9 where Id=@Id";
			cmd.ExecuteNonQuery();
		}
	}
}