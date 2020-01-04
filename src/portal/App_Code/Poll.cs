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

public class Poll
{
	int id;
	public DateTime date;
	public string question;
	public RecordStatus status;

	public int Id { get { return id; } }

	public static Poll GetPoll(GmConnection conn, int id)
	{
		if (id == 0) return null;
		GmCommand cmd = conn.CreateCommand("select * from Polls where Id=@Id");
		cmd.AddInt("Id", id);
		using (DbDataReader dr = cmd.ExecuteReader())
		{
			if (dr.Read()) return new Poll(dr);
		}
		return null;
	}
	public static Poll GetLastPoll(GmConnection conn)
	{
		using (DbDataReader dr = conn.ExecuteReader("select top(1) * from Polls where Status>0 order by Id desc"))
		{
			if (dr.Read()) return new Poll(dr);
		}
		return null;
	}
	public static int Remove(GmConnection conn, int id)
	{
		GmCommand cmd = conn.CreateCommand("delete from Polls where Id=@Id");//!!!
		cmd.AddInt("Id", id);
		return cmd.ExecuteNonQuery();
	}
	public Poll()
		: this(0)
	{
	}
	public Poll(int id)
	{
		this.id = id;
		date = DateTime.Now;
		question = "";
		status = RecordStatus.New;
	}
	public Poll(GmDataReader dr)
	{
		id = dr.GetInt();
		date = dr.GetDateTime();
		question = dr.GetString();
		status = (RecordStatus)dr.GetInt();
	}
	public void Save(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddDateTime("Date", date);
		cmd.AddString("Question", question);
		cmd.AddInt("Status", (int)status);
		if (id == 0)
		{
			cmd.CommandText = "insert into Polls values (@Date,@Question,@Status) select @@Identity";
			id = (int)(decimal)cmd.ExecuteScalar();
		}
		else
		{
			cmd.CommandText = "update Polls set Date=@Date,Question=@Question,Status=@Status where Id=@Id";
			cmd.ExecuteNonQuery();
		}
	}
}
