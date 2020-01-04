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
using Geomethod.Data;

public enum RequestParam { id, cl, sp, cd, cm, tp, ar, at, mt, pr, md, cp, ind, smin, smax, ct, vc, fc, fs, gl, gi, bn, pg, bt, pl, pa, fr, ft, fm, tag, ag, ap }

public class RequestUtils
{
	public static int GetId(Control ctl) { return GetInt(ctl, RequestParam.id); }
	public static int GetForumId(Control ctl) { return GetInt(ctl, RequestParam.fr); }
	public static int GetForumTopicId(Control ctl) { return GetInt(ctl, RequestParam.ft); }
	public static int GetForumMessageId(Control ctl) { return GetInt(ctl, RequestParam.fm); }
	public static int GetPollId(Control ctl) { return GetInt(ctl, RequestParam.pl); }
	public static int GetPollAnswerId(Control ctl) { return GetInt(ctl, RequestParam.pa); }
	public static int GetPageId(Control ctl) { return GetInt(ctl, RequestParam.pg); }
	public static int GetBannerId(Control ctl) { return GetInt(ctl, RequestParam.bn); }
	public static int GetBannerTopicId(Control ctl) { return GetInt(ctl, RequestParam.bt); }
	public static int GetGalleryId(Control ctl) { return GetInt(ctl, RequestParam.gl); }
	public static int GetGalleryImageId(Control ctl) { return GetInt(ctl, RequestParam.gi); }
	public static int GetProfessionId(Control ctl) { return GetInt(ctl, RequestParam.pr); }
	public static int GetCollegeId(Control ctl) { return GetInt(ctl, RequestParam.cl); }
	public static int GetSpecialityId(Control ctl) { return GetInt(ctl, RequestParam.sp); }
	public static int GetCardId(Control ctl) { return GetInt(ctl, RequestParam.cd); }
	public static int GetCommunityId(Control ctl) { return GetInt(ctl, RequestParam.cm); }
	public static int GetTopicId(Control ctl) { return GetInt(ctl, RequestParam.tp); }
    public static int GetArticleId(Control ctl) { return GetInt(ctl, RequestParam.ar); }
    public static int GetArticleGroupId(Control ctl) { return GetInt(ctl, RequestParam.ag); }
    public static int GetArticleParamId(Control ctl) { return GetInt(ctl, RequestParam.ap); }
    public static int GetMediaId(Control ctl) { return GetInt(ctl, RequestParam.md); }
	public static int GetMediaTypeId(Control ctl) { return GetInt(ctl, RequestParam.mt); }
	public static int GetIndustryId(Control ctl) { return GetInt(ctl, RequestParam.ind); }
	public static int GetMinSalary(Control ctl) { return GetInt(ctl, RequestParam.smin); }
	public static int GetMaxSalary(Control ctl) { return GetInt(ctl, RequestParam.smax); }
	public static int GetCityId(Control ctl) { return GetInt(ctl, RequestParam.ct); }
	public static int GetVacancyId(Control ctl) { return GetInt(ctl, RequestParam.vc); }
	public static int GetFacultyId(Control ctl) { return GetInt(ctl, RequestParam.fc); }
    public static int GetFacultySpecialityId(Control ctl) { return GetInt(ctl, RequestParam.fs); }
    public static string GetTag(Control ctl) { return GetString(ctl, RequestParam.tag); }
    static int GetInt(Control ctl, RequestParam p) { return GetInt(ctl, p.ToString()); }
    static string GetString(Control ctl, RequestParam p) { return GetString(ctl, p.ToString()); }
    static int GetInt(Control ctl, string p) 
	{
		try
		{
			string s = ctl.Page.Request[p];
			return s != null ? int.Parse(s) : 0;
		}
		catch 
		{
			return 0;
		}
	}
    static string GetString(Control ctl, string p)
    {
        return ctl.Page.Request[p] ?? "";
    }

}