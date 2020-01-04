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

public partial class GalleryPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
			Log log=MainMasterPage.InitPage(this);
			string gl=RequestUtils.GetGalleryId(this).ToString();
			SqlDataSource1.SelectParameters["GalleryId"].DefaultValue = gl;
			SqlDataSource2.SelectParameters["GalleryId"].DefaultValue = gl;
			try
			{
				string galleryName = null;
				using (GmConnection conn = Global.CreateConnection())
				{
					galleryName = conn.ExecuteScalar("select Name from Galleries where Id=" + gl) as string;
				}
				if (galleryName != null)
				{
					(this.Master as MainMasterPage).PageInfo.AddInfo(galleryName);
				}
			}
			catch (Exception ex)
			{
				log.Exception(ex);
			}
		}
}
