using System.Drawing;
using System.Drawing.Imaging;
using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Geomethod;
using Geomethod.Data;
using Geomethod.Web;

public partial class AdminGalleryImage : System.Web.UI.Page
{
	Log log;
	PageHelper pageHelper;
	[SessionObject]
	public GalleryImage galleryImage;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			log = AdminMasterPage.InitPage(this, "Album photo");
			pageHelper = new PageHelper(this);
			if (!IsPostBack)
			{
				LoadData();
			}
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}

	}
	void LoadData()
	{
		int id  = RequestUtils.GetGalleryImageId(this);
		if (id != 0)
		{
			using (GmConnection conn = Global.CreateConnection())
			{
				galleryImage = GalleryImage.GetGalleryImage(conn, id);
			}
		}
		if (galleryImage == null)
		{
			galleryImage = new GalleryImage();
			int gl = RequestUtils.GetGalleryId(this);
			if (gl != 0)
			{
				galleryImage.galleryId = gl;
			}
		}
		using (GmConnection conn = Global.CreateConnection())
		{
			Utils.FillDDL(conn, ddlStatus, "select Id, Name from Statuses", (int)galleryImage.status);
		}
		tbFilename.Text = galleryImage.filename;
		tbName.Text = galleryImage.name;
		tbText.Text = galleryImage.text;

		tbName.MaxLength = MaxLength.GalleryImages.Name;
		tbFilename.MaxLength = MaxLength.GalleryImages.Filename;
		tbText.MaxLength = MaxLength.GalleryImages.Text;
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			lblInfo.Text = "";
			lblResult.Text = "";
			if (fileUpload.FileName.Trim().Length > 0)
			{
				Upload();
			}
			if (tbFilename.Text.Length > 0)
			{
				galleryImage.name = tbName.Text.Trim();
				galleryImage.filename = tbFilename.Text.Trim();
				galleryImage.text = tbText.Text.Trim();
				galleryImage.status = (RecordStatus)int.Parse(ddlStatus.SelectedValue);
				using (GmConnection conn = Global.CreateConnection())
				{
					galleryImage.Save(conn);
				}
				lblResult.Text = string.Format("Data saved.");
			}
//			WebUtils.Redirect(this, "Private/Users.aspx");
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}

	private bool Upload()
	{
		const int maxImageLength=15000000;
		string filePath = fileUpload.FileName;
		if (filePath.Trim().Length > 0)
		{
			PostedImage postedImage = new PostedImage(fileUpload, maxImageLength);

			System.Drawing.Image image = postedImage.FitImage(new Size(512, 512));
			System.Drawing.Image image1 = postedImage.FitImage(new Size(196, 196));
			System.Drawing.Image image2 = postedImage.FitImage(new Size(256, 256));
			string path = PathUtils.BaseDirectory + "Gallery\\";
			ImageFormat imageFormat=ImageFormat.Jpeg;
			string ext=postedImage.Extension;
			switch(ext)
			{
				case ".gif":
					imageFormat=ImageFormat.Gif;
					break;
				case ".png":
					imageFormat=ImageFormat.Png;
					break;
			}
			string fileName=postedImage.FileNameWithoutExtension+ext;
			string fileName1="p1_"+fileName;
			string fileName2="p2_"+fileName;
			image.Save(path + fileName, imageFormat);
			image1.Save(path + fileName1, imageFormat);
			image2.Save(path + fileName2, imageFormat);
//			lblInfo.Text = string.Format("Файлы сохранены: {0}, {1}, {2}", fileName, fileName1, fileName2);
			tbFilename.Text = fileName;
			return true;
		}
		else
		{
			lblInfo.ForeColor = Color.Red;
			lblInfo.Text = "Выберете файл для загрузки";
			return false;
		}
	}

}
