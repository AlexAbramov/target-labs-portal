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

public class GalleryImage
{
	int id;
	public int galleryId;
	public string filename;
	public string name;
	public string text;
	public RecordStatus status;

	public int Id { get { return id; } }

	public static GalleryImage GetGalleryImage(GmConnection conn, int id)
	{
		if (id == 0) return null;
		GmCommand cmd = conn.CreateCommand("select * from GalleryImages where Id=@Id");
		cmd.AddInt("Id", id);
		using (DbDataReader dr = cmd.ExecuteReader())
		{
			if (dr.Read()) return new GalleryImage(dr);
		}
		return null;
	}
	public static int Remove(GmConnection conn, int id)
	{
		GmCommand cmd = conn.CreateCommand("delete from GalleryImages where Id=@Id");//!!!
		cmd.AddInt("Id", id);
		return cmd.ExecuteNonQuery();
	}
	public GalleryImage()
		: this(0)
	{
	}
	public GalleryImage(int id)
	{
		this.id = id;
		galleryId = 0;
		filename = "";
		name = "";
		text = "";
		status = RecordStatus.New;
	}
	public GalleryImage(GmDataReader dr)
	{
		id = dr.GetInt32();
		galleryId = dr.GetInt32();
		filename = dr.GetString();
		name = dr.GetString();
		text = dr.GetString();
		status = (RecordStatus)dr.GetInt32();
	}
	public void Save(GmConnection conn)
	{
		GmCommand cmd = conn.CreateCommand();
		cmd.AddInt("Id", id);
		cmd.AddInt("GalleryId", galleryId);
		cmd.AddString("Filename", filename);
	    cmd.AddString("Name", name);
		cmd.AddString("Text", text);
		cmd.AddInt("Status", (int)status);
		if (id == 0)
		{
			cmd.CommandText = "insert into GalleryImages values (@GalleryId,@Filename,@Name,@Text,@Status) select @@Identity";
			id = (int)(decimal)cmd.ExecuteScalar();
		}
		else
		{
			cmd.CommandText = "update GalleryImages set GalleryId=@GalleryId,Filename=@Filename,Name=@Name,Text=@Text,Status=@Status where Id=@Id";
			cmd.ExecuteNonQuery();
		}
	}
}
