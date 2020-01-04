using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Geomethod.Data;
using Geomethod.Web;
using Geomethod;

public partial class UserInfoUserControl : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
	}

	public void LoadData()
	{
		int userId = Utils.GetUserId(Context);
		if (userId == 0) return;
		UserInfo ui=null;
		using (GmConnection conn = Global.CreateConnection())
		{
			ui = UserInfo.GetUserInfo(conn, userId);
		}
		if (ui == null) return;
		hfId.Value=ui.Id.ToString();
//		tbDate.Text = Utils.ToString(userInfo.date);
		tbName.Text = ui.name;
		tbEmail.Text = ui.email;

//		tbDate.MaxLength = MaxLength.Input.dateString;
		tbName.MaxLength = MaxLength.UserInfo.Name;
		tbEmail.MaxLength = MaxLength.UserInfo.Email;
		tbPassword.MaxLength = MaxLength.UserInfo.Psw;
	}

	public UserInfo SaveData()
	{
		int userId = int.Parse(hfId.Value);
		if (userId == 0) return null;
		UserInfo userInfo = new UserInfo(userId);
		userInfo.picture=Upload(userId);
		userInfo.name = tbName.Text.Trim();
		userInfo.email = tbEmail.Text.Trim();
		userInfo.date = DateTime.Now;
		userInfo.psw = tbNewPassword.Text.Trim();
		using (GmConnection conn = Global.CreateConnection())
		{
			userInfo.Update(conn);
		}
		return userInfo;
	}

	string Hash(int n)
	{
		string s = (n+137).ToString("x");
		string res="";
		for (int i = 0; i < s.Length; i+=2)
		{
			if (i+1 < s.Length) res += s[i + 1];
			res += s[i];
		}
		return res;
	}

	private string Upload(int userId)
	{
		const int maxImageLength = 1000000;
		string fileName = "";
		string filePath = fileUpload.FileName;
		if (filePath.Trim().Length > 0)
		{
			PostedImage postedImage = new PostedImage(fileUpload, maxImageLength);
			System.Drawing.Image image = postedImage.FitImage(new Size(128, 128));
			string path = PathUtils.BaseDirectory + "Images\\Users\\";
			string ext = postedImage.Extension;
			ImageFormat imageFormat = ImageFormat.Gif;
/*			switch (ext)
			{
				case ".gif":
					imageFormat = ImageFormat.Gif;
					break;
				case ".png":
					imageFormat = ImageFormat.Png;
					break;
			}*/
			fileName = Hash(userId) + ext;
			image.Save(path + fileName, imageFormat);
			//			lblInfo.Text = string.Format("Файлы сохранены: {0}, {1}, {2}", fileName, fileName1, fileName2);
			lblPicture.Text = fileName;
		}
		return fileName;
	}

	private string ToString(int p)
	{
		return p > 0 ? p.ToString() : "";
	}
}
