using System;
using System.Drawing;
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

public partial class UserControls_UploadUserControl : System.Web.UI.UserControl
{
	Log log;
	protected void Page_Load(object sender, EventArgs e)
	{
		log = new Log(this);
	}

	protected void btnUpload_Click(object sender, EventArgs e)
	{
		try { Upload(); }
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}

	private void Upload()
	{
		string fileName = Path.GetFileName(fileUpload.FileName);
		if (fileName.Length > 0)
		{
			fileName=Path.GetFileNameWithoutExtension(fileName) + Path.GetExtension(fileName).ToLower();
			fileUpload.SaveAs(PathUtils.BaseDirectory + "Images\\" + fileName);
			lblInfo.Text = "Uploaded: " + fileName;
		}
		else
		{
			lblInfo.ForeColor = Color.Red;
			lblInfo.Text = "Upload failed";
		}
	}
}
