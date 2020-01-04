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

public class PollAnswer
{
	int id;
	public int pollId;
	public string answer;
	public int count;
	public RecordStatus status;

	public int Id { get { return id; } }

	public static PollAnswer GetPollAnswer(GmConnection conn, int id)
	{
		if (id == 0) return null;
		GmCommand cmd = conn.CreateCommand("select * from PollAnswers where Id=@Id");
		cmd.AddInt("Id", id);
		using (GmDataReader dr = cmd.ExecuteReader())
		{
			if (dr.Read()) return new PollAnswer(dr);
		}
		return null;
	}
	public static int Remove(GmConnection conn, int id)
	{
		GmCommand cmd = conn.CreateCommand("delete from PollAnswers where Id=@Id");//!!!
		cmd.AddInt("Id", id);
		return cmd.ExecuteNonQuery();
	}
	public PollAnswer()
		: this(0)
	{
	}
	public PollAnswer(int id)
	{
		this.id = id;
		pollId = 0;
		answer = "";
		count = 0;
		status = RecordStatus.New;
	}
	public PollAnswer(GmDataReader dr)
	{
		id = dr.GetInt();
		pollId = dr.GetInt();
		answer = dr.GetString();
		count = dr.GetInt();
		status = (RecordStatus)dr.GetInt();
	}
	public void Save(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddInt("PollId", pollId);
		cmd.AddString("Answer", answer);
		cmd.AddInt("Count", count);
		cmd.AddInt("Status", (int)status);
		if (id == 0)
		{
			cmd.CommandText = "insert into PollAnswers values (@PollId,@Answer,@Count,@Status) select @@Identity";
			id = (int)(decimal)cmd.ExecuteScalar();
		}
		else
		{
			cmd.CommandText = "update PollAnswers set PollId=@PollId,Answer=@Answer,Count=@Count,Status=@Status where Id=@Id";
			cmd.ExecuteNonQuery();
		}
	}

	public static void Vote(GmConnection conn, int pollAnswerId)
	{
		GmCommand cmd = conn.CreateCommand("update PollAnswers set Count=Count+1 where Id=@Id");
		cmd.AddInt("Id", pollAnswerId);
		cmd.ExecuteNonQuery();
	}
}
