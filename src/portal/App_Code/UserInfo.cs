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
/// Summary description for UserInfo
/// </summary>
/// 

public class UserInfo
{
	int id;
	public int recordId;
	public DateTime date;
	public string name;
	public string email;
	public string psw;
	public UserRole userRole;
	public RecordStatus status;
	public string picture;

	public int Id { get { return id; } }

	public static UserInfo GetUserInfo(GmConnection conn, int id)
	{
		if (id == 0) return null;
		GmCommand cmd = conn.CreateCommand("select * from UserInfo where Id=@Id");
		cmd.AddInt("Id", id);
		using (DbDataReader dr = cmd.ExecuteReader())
		{
			if (dr.Read()) return new UserInfo(dr);
		}
		return null;
	}
	public static int Remove(GmConnection conn, int id)
	{
		GmCommand cmd = conn.CreateCommand("delete from UserInfo where Id=@Id");
		cmd.AddInt("Id", id);
		return cmd.ExecuteNonQuery();
	}
	public UserInfo()
		: this(0)
	{
	}
	public UserInfo(int id)
	{
		this.id = id;
		recordId = 0;
	  date=DateTime.Now;
		name = "";
		email = "";
		psw = "";
		userRole = UserRole.None;
		status = RecordStatus.New;
		picture = "";
	}
	public UserInfo(GmDataReader dr)
	{
		recordId = dr.GetInt();
		date = dr.GetDateTime();
		name = dr.GetString();
		email = dr.GetString();
		psw = dr.GetString();
		userRole = (UserRole)dr.GetInt();
		status = (RecordStatus)dr.GetInt();
		picture = dr.GetString();
	}
	public static UserInfo GetUserInfo(GmConnection conn, string login, string psw)
	{
		GmCommand cmd = conn.CreateCommand();
		int pos = login.IndexOf('@');
		if (pos >= 0)
		{
			cmd.CommandText = "select * from UserInfo where Email=@Email and Psw=@Psw";
			cmd.AddString("@Email", login);
			cmd.AddString("@Psw", psw);
		}
		else
		{
			int userId;
			try
			{
				userId = int.Parse(login);
			}
			catch
			{
				return null;
			}
			cmd.CommandText = "select * from UserInfo where Id=@Id and Psw=@Psw";
			cmd.AddInt("@Id", userId);
			cmd.AddString("@Psw", psw);
		}
		UserInfo userInfo = null;
		using (DbDataReader dr = cmd.ExecuteReader())
		{
			if (dr.Read()) userInfo = new UserInfo(dr);
		}
		return userInfo;
	}
	public void Save(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddInt("RecordId", recordId);
		cmd.AddDateTime("Date", date);
		cmd.AddString("Name", name, MaxLength.UserInfo.Name);
		cmd.AddString("Email", email, MaxLength.UserInfo.Email);
		cmd.AddString("Psw", psw, MaxLength.UserInfo.Psw);
		cmd.AddInt("UserRole", (int)userRole);
		cmd.AddInt("Status", (int)status);
		cmd.AddString("Picture", picture, MaxLength.UserInfo.Picture);
		if (id == 0)
		{
			cmd.CommandText = "insert into UserInfo values (@RecordId,@Date,@Name,@Email,@Psw,@UserRole,@Status,@Picture) select @@Identity";
			id = (int)(decimal)cmd.ExecuteScalar();
		}
		else
		{
			cmd.CommandText = "update UserInfo set RecordId=@RecordId,Date=@Date,Name=@Name,Email=@Email,Psw=@Psw,UserRole=@UserRole,Status=@Status,Picture=@Picture where Id=@Id";
			cmd.ExecuteNonQuery();
		}
	}
	public void Update(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
//		cmd.AddInt("RecordId", recordId);
		cmd.AddDateTime("Date", date);
		cmd.AddString("Name", name, MaxLength.UserInfo.Name);
		cmd.AddString("Email", email, MaxLength.UserInfo.Email);
		cmd.CommandText = "update UserInfo set Date=@Date,Name=@Name,Email=@Email";
		if (psw.Length > 0)
		{
			cmd.CommandText += ",Psw=@Psw";
			cmd.AddString("Psw", psw, MaxLength.UserInfo.Psw);
		}
		if (picture.Length > 0)
		{
			cmd.CommandText += ",Picture=@Picture";
			cmd.AddString("Picture", picture, MaxLength.UserInfo.Picture);
		}
//		cmd.AddInt("UserRole", (int)userRole);
//		cmd.AddInt("Status", (int)status);
		cmd.CommandText += " where Id=@Id";
		cmd.ExecuteNonQuery();
	}
}
