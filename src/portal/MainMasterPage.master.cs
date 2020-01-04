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

public partial class MainMasterPage : System.Web.UI.MasterPage, IMasterPage
{
	PageInfo pageInfo;
	public PageInfo PageInfo { get { return pageInfo; }}
	public static Log InitPage(Page page)
	{
		PageInfo pageInfo = new PageInfo(page);
		MainMasterPage mp=(MainMasterPage)page.Master;
		mp.pageInfo = pageInfo;		
/*        string fileName=Path.GetFileName(page.Request.FilePath);
//		mp.ucLeft.InitControl(mi, fileName);

		mp.ucHeader.banner1 = pageInfo.GetBannerCode(1);
		mp.ucRight.banner2 = pageInfo.GetBannerCode(2);
		mp.ucLeft.banner3 = pageInfo.GetBannerCode(3);
		mp.ucLeft.banner4 = pageInfo.GetBannerCode(4);
		mp.ucLeft.banner5 = pageInfo.GetBannerCode(5);
		mp.ucRight.banner6 = pageInfo.GetBannerCode(6);
		mp.ucRight.banner7 = pageInfo.GetBannerCode(7);
		mp.ucRight.banner8 = pageInfo.GetBannerCode(8);
		mp.ucRight.banner9 = pageInfo.GetBannerCode(9);*/
		return pageInfo.Log;
	}
	protected void Page_Load(object sender, EventArgs e)
    {
	}

}
