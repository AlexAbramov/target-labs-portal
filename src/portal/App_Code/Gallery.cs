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

public class Gallery
{
	int id;
	public int communityId;
	public string name;
	public string text;
	public RecordStatus status;
	public string logo;

	public int Id { get { return id; } }

	public static Gallery GetGallery(GmConnection conn, int id)
	{
		if (id == 0) return null;
		GmCommand cmd = conn.CreateCommand("select * from Galleries where Id=@Id");
		cmd.AddInt("Id", id);
		using (DbDataReader dr = cmd.ExecuteReader())
		{
			if (dr.Read()) return new Gallery(dr);
		}
		return null;
	}
	public static int Remove(GmConnection conn, int id)
	{
		GmCommand cmd = conn.CreateCommand("delete from Galleries where Id=@Id");//!!!
		cmd.AddInt("Id", id);
		return cmd.ExecuteNonQuery();
	}
	public Gallery()
		: this(0)
	{
	}
	public Gallery(int id)
	{
		this.id = id;
		communityId = 0;
		name = "";
		text = "";
		status = RecordStatus.New;
		logo = "";
	}
    public Gallery(GmDataReader dr)
	{

		id = dr.GetInt();
		communityId = dr.GetInt();
		name = dr.GetString();
		text = dr.GetString();
		status = (RecordStatus)dr.GetInt();
		logo = dr.GetString();
	}
	public void Save(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddInt("CommunityId", communityId);
		cmd.AddString("Name", name, MaxLength.Galleries.Name);
		cmd.AddString("Text", text, MaxLength.Galleries.Text);
		cmd.AddInt("Status", (int)status);
		cmd.AddString("Logo", logo, MaxLength.Galleries.Logo);
		if (id == 0)
		{
			cmd.CommandText = "insert into Galleries values (@CommunityId,@Name,@Text,@Status,@Logo) select @@Identity";
			id = (int)(decimal)cmd.ExecuteScalar();
		}
		else
		{
			cmd.CommandText = "update Galleries set CommunityId=@CommunityId,Name=@Name,Text=@Text,Status=@Status,Logo=@Logo where Id=@Id";
			cmd.ExecuteNonQuery();
		}
	}
}
