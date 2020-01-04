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
/// Summary description for Candidate
/// </summary>
/// 

public class Candidate
{
    #region Fields
    int id;
	public int positionId;
	public DateTime date;
	public string name;
	public string surname;
	public string address;
	public string phone;
	public string link;
    public string email;
    public string resume;
    public string comments;
	public RecordStatus status;
    #endregion

    #region Properties
    public int Id { get { return id; } }
    #endregion

    #region Static
    public static Candidate GetCandidate(GmConnection conn, int id)
	{
		if (id == 0) return null;
		GmCommand cmd = conn.CreateCommand("select * from Candidates where Id=@Id");
		cmd.AddInt("Id", id);
		using (GmDataReader dr = cmd.ExecuteReader())
		{
			if (dr.Read()) return new Candidate(dr);
		}
		return null;
	}
    public static int Remove(GmConnection conn, int id)
	{
		GmCommand cmd = conn.CreateCommand("delete from Candidates where Id=@Id");
		cmd.AddInt("Id", id);
		return cmd.ExecuteNonQuery();
	}
    #endregion

    #region Construction
    public Candidate()
		: this(0)
	{
	}

	public Candidate(int id)
	{
		this.id = id;
	    positionId=0;
	    date=DateTime.Today;
	    name="";
	    surname="";
		address = "";
		phone = "";
		link = "";
		email = "";
        resume = "";
        comments = "";
		status = RecordStatus.New;
	}
    public Candidate(GmDataReader dr)
	{
		id = dr.GetInt();
		positionId = dr.GetInt();
		date = dr.GetDateTime();
		name = dr.GetString();
		surname = dr.GetString();
		address = dr.GetString();
		phone = dr.GetString();
		link = dr.GetString();
        email = dr.GetString();
        resume = dr.GetString();
        comments = dr.GetString();
        status = (RecordStatus)dr.GetInt();
    }
    #endregion

    #region Methods
    public void Save(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
        cmd.AddInt("PositionId", positionId);
		cmd.AddDateTime("Date", date);
        cmd.AddString("Name", name);
        cmd.AddString("Surname", surname);
		cmd.AddString("Address", address);
		cmd.AddString("Phone", phone);
		cmd.AddString("Link", link);
        cmd.AddString("Email", email);
        cmd.AddString("Resume", resume);
        cmd.AddString("Comments", comments);
        cmd.AddInt("Status", (int)status);
        if (id == 0)
		{
            cmd.CommandText = "insert into Candidates values (@PositionId,@Date,@Name,@Surname,@Address,@Phone,@Link,@Email,@Resume,@Comments,@Status) select @@Identity";
			id = (int)(decimal)cmd.ExecuteScalar();
		}
		else
		{
//            cmd.CommandText = "update Competitors set PositionId=@PositionId,Date=@Date,Name=@Name,Surname=@Surname,Address=@Address,Phone=@Phone,Link=@Link,Email=@Email, Resume=@Resume, Comments=@Comments,Status=@Status where Id=@Id";
//			cmd.ExecuteNonQuery();
		}
    }
    public void UpdateResume(GmConnection conn)
    {
        GmCommand cmd = conn.CreateCommand();
        cmd.AddInt("Id", id);
        cmd.AddString("Resume", resume);
        if (id != 0)
        {
            cmd.CommandText = "update Candidates set Resume=@Resume where Id=@Id";
            cmd.ExecuteNonQuery();
        }
    }
    #endregion
}
