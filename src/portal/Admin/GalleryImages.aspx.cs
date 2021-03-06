using System;
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

public partial class GalleryImages : System.Web.UI.Page
{
	Log log;
	GridHelper gridHelper;
	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			log = AdminMasterPage.InitPage(this, "Album photos", true);
			gridHelper = new GridHelper(this, gridView);
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

	private void LoadData()
	{
		gridHelper.ClearDataTable();
		int gl = RequestUtils.GetGalleryId(this);
		hlAdd.NavigateUrl += "?gl=" + gl;
		string query = "select GalleryImages.*, Symbol from GalleryImages left join Statuses on Statuses.Id=Status";
		query += " where GalleryId=" + gl.ToString();
		using (GmConnection conn = Global.CreateConnection())
		{
			conn.Fill(gridHelper.DataTable, query);
		}
		gridHelper.DataTable.DefaultView.Sort = "Name";
	}
}
