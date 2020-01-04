using System;
using System.Text;
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
/// Summary description for Article
/// </summary>
/// 

public class Article
{
    #region Fields
    int id;
	public int parentId;
	public DateTime date;
	public string person;
	public string title;
	public string preview;
	public string header;
	public string text;
	public string company;
	public int cityId;
	public string address;
	public string phone;
	public string link;
    public string email;
    public string tag;
	public RecordStatus status;
    public bool isGroup;
    #endregion

    #region Properties
    public int Id { get { return id; } }
    #endregion

    #region Static
    public static Article GetArticle(GmConnection conn, int id)
	{
		if (id == 0) return null;
		GmCommand cmd = conn.CreateCommand("select * from Articles where Id=@Id");
		cmd.AddInt("Id", id);
		using (GmDataReader dr = cmd.ExecuteReader())
		{
			if (dr.Read()) return new Article(dr);
		}
		return null;
	}
    public static Article GetArticle(GmConnection conn, string tag)
    {
        GmCommand cmd = conn.CreateCommand("select * from Articles where Tag=@Tag");
        cmd.AddString("Tag", tag);
        using (GmDataReader dr = cmd.ExecuteReader())
        {
            if (dr.Read()) return new Article(dr);
        }
        return null;
    }
    public static int GetArticleId(GmConnection conn, string tag)
    {
        int articleId = 0;
        if (!String.IsNullOrWhiteSpace(tag))
        {
            GmCommand cmd = conn.CreateCommand("select Id from Articles where Tag=@Tag");
            cmd.AddString("Tag", tag);
            articleId = cmd.ExecuteScalarInt32();
        }
        return articleId;
    }
    public static int GetArticleGroupId(GmConnection conn, string tag)
    {
        GmCommand cmd = conn.CreateCommand("select top(1) Id from Articles where IsGroup=1 and Tag=@Tag");
        cmd.AddString("Tag", tag);
        return cmd.ExecuteScalarInt32();
    }
    public static int Remove(GmConnection conn, int id)
	{
		GmCommand cmd = conn.CreateCommand("delete from Articles where Id=@Id");
		cmd.AddInt("Id", id);
		return cmd.ExecuteNonQuery();
	}
    #endregion

    #region Construction
    public Article()
		: this(0)
	{
	}

	public Article(int id)
	{
		this.id = id;
	    parentId=0;
	    date=DateTime.Today;
	    person="";
	    title="";
		preview = "";
		header = "";
		text = "";
	    company="";
	    cityId=0;
		address = "";
		phone = "";
		link = "";
		email = "";
        tag = "";
		status = RecordStatus.New;
        isGroup = false;
	}
	public Article(GmDataReader dr)
	{
		id = dr.GetInt();
		parentId = dr.GetInt();
		date = dr.GetDateTime();
		person = dr.GetString();
		title = dr.GetString();
		preview = dr.GetString();
		header = dr.GetString();
		text = dr.GetString();
		company = dr.GetString();
		cityId = dr.GetInt32();
		address = dr.GetString();
		phone = dr.GetString();
		link = dr.GetString();
        email = dr.GetString();
		status = (RecordStatus)dr.GetInt();
        tag = dr.GetString();
        isGroup = dr.GetBoolean();
    }
    #endregion

    #region Methods
    public void Save(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddInt("ParentId", (int)parentId);
		cmd.AddDateTime("Date", date);
		cmd.AddString("Person", person);
		cmd.AddString("Title", title);
		cmd.AddString("Preview", preview);
		cmd.AddString("Header", header);
		cmd.AddString("Text", text);
		cmd.AddString("Company", company);
		cmd.AddInt("CityId", cityId);
		cmd.AddString("Address", address);
		cmd.AddString("Phone", phone);
		cmd.AddString("Link", link);
        cmd.AddString( "Email", email );
		cmd.AddInt("Status", (int)status);
        cmd.AddString("Tag", tag);
        cmd.AddBoolean("IsGroup", isGroup);
        if (id == 0)
		{
            cmd.CommandText = "insert into Articles values (@ParentId,@Date,@Person,@Title,@Preview,@Header,@Text,@Company,@CityId,@Address,@Phone,@Link,@Email, @Status,@Tag,@IsGroup) select @@Identity";
			id = (int)(decimal)cmd.ExecuteScalar();
		}
		else
		{
            cmd.CommandText = "update Articles set ParentId=@ParentId,Date=@Date,Person=@Person,Title=@Title,Preview=@Preview,Header=@Header,Text=@Text,Company=@Company,CityId=@CityId,Address=@Address,Phone=@Phone,Link=@Link,Email=@Email,Status=@Status, Tag=@Tag, IsGroup=@IsGroup where Id=@Id";
			cmd.ExecuteNonQuery();
		}
    }
    #endregion

    public string GetParentTag(GmConnection conn)
    {
        if (parentId > 0)
        {
            GmCommand cmd = conn.CreateCommand("select Tag from Articles where Id=@Id");
            cmd.AddInt("Id", parentId);
            return cmd.ExecuteScalar() as string;
        }
        return null;
    }

    public string BriefInfo
    {
        get
        {
            var sb = new StringBuilder();
            sb.Append(date.ToShortDateString());
            if (!string.IsNullOrWhiteSpace(title)) sb.Append("  "+title);
            sb.AppendLine();
            if (!string.IsNullOrWhiteSpace(header)) sb.Append(header);
            else sb.Append(header);
            return sb.ToString();
        }
    }
}
