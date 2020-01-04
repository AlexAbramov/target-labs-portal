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

public class ArticleParam
{
	int id;
	public int articleId;
	public string key;
	public string value;
	public RecordStatus status;

	public int Id { get { return id; } }

	public static ArticleParam GetArticleParam(GmConnection conn, int id)
	{
		if (id == 0) return null;
		GmCommand cmd = conn.CreateCommand("select * from ArticleParams where Id=@Id");
		cmd.AddInt("Id", id);
		using (GmDataReader dr = cmd.ExecuteReader())
		{
			if (dr.Read()) return new ArticleParam(dr);
		}
		return null;
	}
	public static int Remove(GmConnection conn, int id)
	{
		GmCommand cmd = conn.CreateCommand("delete from ArticleParams where Id=@Id");
		cmd.AddInt("Id", id);
		return cmd.ExecuteNonQuery();
	}
    public ArticleParam()
    {
        id = 0;
        articleId = 0;
        key = "";
        value = "";
        status = RecordStatus.New;
    }
	public ArticleParam(int articleId)
	{
        id=0;
		this.articleId = articleId;
		key = "";
		value = "";
		status = RecordStatus.New;
	}
    public ArticleParam(GmDataReader dr)
	{
		id = dr.GetInt();
		articleId = dr.GetInt();
		key = dr.GetString();
        value = dr.GetString();
		status = (RecordStatus)dr.GetInt();
	}
	public void Save(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddInt("ArticleId", articleId);
		cmd.AddString("Key", key);
        cmd.AddString("Value", value);
		cmd.AddInt("Status", (int)status);
		if (id == 0)
		{
            cmd.CommandText = "insert into ArticleParams values (@ArticleId,@Key,@Value,@Status) select @@Identity";
			id = (int)(decimal)cmd.ExecuteScalar();
		}
		else
		{
            cmd.CommandText = "update ArticleParams set [Key]=@Key,Value=@Value,Status=@Status where Id=@Id";
			cmd.ExecuteNonQuery();
		}
	}

    public static void GetArticleParams(GmConnection conn, int articleId, System.Collections.Specialized.StringDictionary sd)
    {
        GmCommand cmd = conn.CreateCommand("select [Key], [Value] from ArticleParams where ArticleId=@ArticleId");
        cmd.AddInt("ArticleId", articleId);
        using (GmDataReader dr = cmd.ExecuteReader())
        {
            while (dr.Read())
            {
                var key=dr.GetString();
                var val=dr.GetString();
                sd[key] = val;
            }
        }
    }
}
