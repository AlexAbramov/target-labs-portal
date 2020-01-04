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

/// <summary>
/// Summary description for Forum
/// </summary>
/// 

public class Forum
{
	int id;
	public int communityId;
	public DateTime date;
	public string name;
	public string description;
	public RecordStatus status;

	public int Id { get { return id; } }

	public static Forum GetForum(GmConnection conn, int id)
	{
		if (id == 0) return null;
		GmCommand cmd = conn.CreateCommand("select * from Forums where Id=@Id");
		cmd.AddInt("Id", id);
		using (DbDataReader dr = cmd.ExecuteReader())
		{
			if (dr.Read()) return new Forum(dr);
		}
		return null;
	}
	public static int Remove(GmConnection conn, int id)
	{
		GmCommand cmd = conn.CreateCommand("delete from Forums where Id=@Id");
		cmd.AddInt("Id", id);
		return cmd.ExecuteNonQuery();
	}
	public Forum()
		: this(0)
	{
	}
	public Forum(int id)
	{
		this.id = id;
		communityId = 0;
	  date=DateTime.Now;
		name = "";
		description = "";
		status = RecordStatus.New;
	}
	public Forum(GmDataReader dr)
	{
		id = dr.GetInt32();
		communityId = dr.GetInt();
		date = dr.GetDateTime();
		name = dr.GetString();
		description = dr.GetString();
		status = (RecordStatus)dr.GetInt();
	}
	public void Save(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddInt("CommunityId", communityId);
		cmd.AddDateTime("Date", date);
		cmd.AddString("Name", name, MaxLength.Forums.Name);
		cmd.AddString("Description", description, MaxLength.Forums.Description);
		cmd.AddInt("Status", (int)status);
		if (id == 0)
		{
			cmd.CommandText = "insert into Forums values (@CommunityId,@Date,@Name,@Description,@Status) select @@Identity";
			id = (int)(decimal)cmd.ExecuteScalar();
		}
		else
		{
			cmd.CommandText = "update Forums set CommunityId=@CommunityId,Name=@Name,Description=@Description,Status=@Status where Id=@Id";
			cmd.ExecuteNonQuery();
		}
	}
/*	public void Update(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddInt("CommunityId", communityId);
		cmd.AddDateTime("Date", date);
		cmd.AddString("Name", name, MaxLength.Forums.Name);
		cmd.AddString("Description", description, MaxLength.Forums.Description);
		cmd.AddInt("Status", (int)status);
		cmd.CommandText = "update Forums set CommunityId=@CommunityId,Date=@Date,Name=@Name,Description=@Description,Status=@Status";
		cmd.CommandText +=" where Id=@Id";
		cmd.ExecuteNonQuery();
	}*/
}
