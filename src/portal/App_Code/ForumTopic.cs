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
/// Summary description for ForumTopic
/// </summary>
/// 

public class ForumTopic
{
	int id;
	public int forumId;
	public DateTime date;
	public string name;
	public string description;
	public RecordStatus status;

	public int Id { get { return id; } }

	public static ForumTopic GetForumTopic(GmConnection conn, int id)
	{
		if (id == 0) return null;
		GmCommand cmd = conn.CreateCommand("select * from ForumTopics where Id=@Id");
		cmd.AddInt("Id", id);
		using (DbDataReader dr = cmd.ExecuteReader())
		{
			if (dr.Read()) return new ForumTopic(dr);
		}
		return null;
	}
	public static int Remove(GmConnection conn, int id)
	{
		GmCommand cmd = conn.CreateCommand("delete from ForumTopics where Id=@Id");
		cmd.AddInt("Id", id);
		return cmd.ExecuteNonQuery();
	}
	public ForumTopic()
		: this(0)
	{
	}
	public ForumTopic(int id)
	{
		this.id = id;
		forumId = 0;
	  date=DateTime.Now;
		name = "";
		description = "";
		status = RecordStatus.New;
	}
	public ForumTopic(GmDataReader dr)
	{
		id = dr.GetInt();
		forumId = dr.GetInt();
		date = dr.GetDateTime();
		name = dr.GetString();
		description = dr.GetString();
		status = (RecordStatus)dr.GetInt();
	}
	public void Save(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddInt("ForumId", forumId);
		cmd.AddDateTime("Date", date);
		cmd.AddString("Name", name, MaxLength.ForumTopics.Name);
		cmd.AddString("Description", description, MaxLength.ForumTopics.Description);
		cmd.AddInt("Status", (int)status);
		if (id == 0)
		{
			cmd.CommandText = "insert into ForumTopics values (@ForumId,@Date,@Name,@Description,@Status) select @@Identity";
			id = (int)(decimal)cmd.ExecuteScalar();
		}
		else
		{
			cmd.CommandText = "update ForumTopics set ForumId=@ForumId,Name=@Name,Description=@Description,Status=@Status where Id=@Id";
			cmd.ExecuteNonQuery();
		}
	}
/*	public void Update(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddInt("ForumId", forumId);
		cmd.AddDateTime("Date", date);
		cmd.AddString("Name", name, MaxLength.ForumTopics.Name);
		cmd.AddString("Description", description, MaxLength.ForumTopics.Description);
		cmd.AddInt("Status", (int)status);
		cmd.CommandText = "update ForumTopic set ForumId=@ForumId,Date=@Date,Name=@Name,Description=@Description,Status=@Status";
		cmd.CommandText +=" where Id=@Id";
		cmd.ExecuteNonQuery();
	}*/
}
