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
/// Summary text for ForumMessage
/// </summary>
/// 

public class ForumMessage
{
	int id;
	public int messageId;
	public int forumTopicId;
	public DateTime date;
	public int userId;
	public string userName;
	public string text;
	public RecordStatus status;

	public int Id { get { return id; } }

	public static ForumMessage GetForumMessage(GmConnection conn, int id)
	{
		if (id == 0) return null;
		GmCommand cmd = conn.CreateCommand("select * from ForumMessages where Id=@Id");
		cmd.AddInt("Id", id);
		using (DbDataReader dr = cmd.ExecuteReader())
		{
			if (dr.Read()) return new ForumMessage(dr);
		}
		return null;
	}
	public static int Remove(GmConnection conn, int id)
	{
		GmCommand cmd = conn.CreateCommand("delete from ForumMessages where Id=@Id");
		cmd.AddInt("Id", id);
		return cmd.ExecuteNonQuery();
	}
	public ForumMessage()
		: this(0)
	{
	}
	public ForumMessage(int id)
	{
		this.id = id;
		messageId = 0;
		forumTopicId = 0;
		date = DateTime.Now;
		userId = 0;
		userName = "";
		text = "";
		status = RecordStatus.New;
	}
	public ForumMessage(GmDataReader dr)
	{
		id = dr.GetInt();
		messageId = dr.GetInt();
		forumTopicId = dr.GetInt();
		date = dr.GetDateTime();
		userId = dr.GetInt();
		userName = dr.GetString();
		text = dr.GetString();
		status = (RecordStatus)dr.GetInt();
	}
	public void Save(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddInt("MessageId", messageId);
		cmd.AddInt("ForumTopicId", forumTopicId);
		cmd.AddDateTime("Date", date);
		cmd.AddInt("UserId", userId);
		cmd.AddString("UserName", userName, MaxLength.ForumMessages.UserName);
		cmd.AddString("Text", text, MaxLength.ForumMessages.Text);
		cmd.AddInt("Status", (int)status);
		if (id == 0)
		{
			cmd.CommandText = "insert into ForumMessages values (@MessageId,@ForumTopicId,@Date,@UserId,@UserName,@Text,@Status) select @@Identity";
			id = (int)(decimal)cmd.ExecuteScalar();
		}
		else
		{
//			cmd.CommandText = "update ForumMessage set MessageId=@MessageId,ForumTopicId=@ForumTopicId,Date=@Date,UserId=@UserId,UserName=@UserName,Text=@Text,Status=@Status where Id=@Id";
			cmd.CommandText = "update ForumMessages set UserName=@UserName,Text=@Text,Status=@Status where Id=@Id";
			cmd.ExecuteNonQuery();
		}
	}
/*	public void Update(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddInt("MessageId", messageId);
		cmd.AddInt("ForumTopicId", forumTopicId);
		cmd.AddDateTime("Date", date);
		cmd.AddInt("UserId", userId);
		cmd.AddString("UserName", userName, MaxLength.ForumMessages.UserName);
		cmd.AddString("Text", text, MaxLength.ForumMessages.Text);
		cmd.AddInt("Status", (int)status);
		cmd.CommandText = "update ForumMessage set MessageId=@MessageId,ForumTopicId=@ForumTopicId,Date=@Date,UserName=@UserName,Text=@Text,Status=@Status";
		cmd.CommandText += " where Id=@Id";
		cmd.ExecuteNonQuery();
	}*/
}
