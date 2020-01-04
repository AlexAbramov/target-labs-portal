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
using Geomethod;
using Geomethod.Data;
using Geomethod.Web;

public partial class GalleryImagePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
			Log log=MainMasterPage.InitPage(this);
			int id = RequestUtils.GetGalleryImageId(this);
			this.SqlDataSource1.SelectParameters["GalleryImageId"].DefaultValue = id.ToString();
			try
			{
				if (id != 0)
				{
					string name = null;
					using (GmConnection conn = Global.CreateConnection())
					{
						name = conn.ExecuteScalar("select Name from GalleryImages where Id=" + id) as string;
					}
					if (name != null)
					{
						(this.Master as MainMasterPage).PageInfo.AddInfo(name);
					}
				}
			}
			catch (Exception ex)
			{
				log.Exception(ex);
			}
		}
}
