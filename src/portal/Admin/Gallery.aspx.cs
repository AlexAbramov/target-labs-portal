using System;
using System.Drawing;
using System.Drawing.Imaging;
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

public partial class AdminGalleryPage : System.Web.UI.Page
{
	Log log;
	PageHelper pageHelper;
	[SessionObject]
	public Gallery gallery;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			log = AdminMasterPage.InitPage(this, "Photo gallery");
			pageHelper = new PageHelper(this);
			if (!IsPostBack)
			{
				LoadData();
				BindData();
			}
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}

	}

	void LoadData()
	{
		int id  = RequestUtils.GetGalleryId(this);
		if (id != 0)
		{
			using (GmConnection conn = Global.CreateConnection())
			{
				gallery = Gallery.GetGallery(conn, id);
			}
		}
		if (gallery == null)
		{
			gallery = new Gallery();
			int cm = RequestUtils.GetCommunityId(this);
			if (cm != 0)
			{
				gallery.communityId = cm;
			}
		}
	}

	void BindData()
	{
		using (GmConnection conn = Global.CreateConnection())
		{
			Utils.FillDDL(conn, ddlStatus, "select Id, Name from Statuses", (int)gallery.status);
		}
		tbName.Text = gallery.name;
		tbText.Text = gallery.text;
		lblLogo.Text = gallery.logo;

		tbName.MaxLength = MaxLength.Galleries.Name;
		tbText.MaxLength = MaxLength.Galleries.Text;
//		tbLogo.MaxLength = MaxLength.Galleries.Logo;
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			Upload();
			gallery.name = tbName.Text.Trim();
			gallery.text = tbText.Text.Trim();
			gallery.status = (RecordStatus)int.Parse(ddlStatus.SelectedValue);
			gallery.logo = lblLogo.Text.Trim();

			using (GmConnection conn = Global.CreateConnection())
			{
				gallery.Save(conn);
			}
			lblResult.Text = string.Format("Data saved.");
//			WebUtils.Redirect(this, "Private/Users.aspx");
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}

	private void Upload()
	{
		const int maxImageLength = 15000000;
		string fileName = Path.GetFileName(fileUpload.FileName);
		if (fileName.Trim().Length > 0)
		{
			PostedImage postedImage = new PostedImage(fileUpload, maxImageLength);
			System.Drawing.Image image = postedImage.FitImage(new Size(196, 196));
			ImageFormat imageFormat = ImageFormat.Jpeg;
			string ext = postedImage.Extension;
			switch (ext)
			{
				case ".gif":
					imageFormat = ImageFormat.Gif;
					break;
				case ".png":
					imageFormat = ImageFormat.Png;
					break;
			}
			fileName = postedImage.FileNameWithoutExtension + ext;
			image.Save(PathUtils.BaseDirectory + "Gallery\\" + fileName, imageFormat);
			lblLogo.Text = fileName;
		}
	}
}
