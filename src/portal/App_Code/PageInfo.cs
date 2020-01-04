using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Geomethod;
using Geomethod.Data;
using Geomethod.Web;

public interface IMasterPage
{
	PageInfo PageInfo { get;}
}

public class PageInfo
{
	Log log;
	string title="";
	string keywords="";
	string description="";
	Dictionary<int,Banner> banners=new Dictionary<int,Banner>();
	Page page;

	public string Title{get{return title;}}
	public string Keywords{get{return keywords;}}
	public string Description{get{return description;}}
	public Banner GetBanner(int index) { return banners.ContainsKey(index)?banners[index]:null; }
	public Log Log{get{return log;}}
	public string Meta { get { return GetMetaInfo(); } }

	private string GetMetaInfo()
	{
		StringBuilder sb=new StringBuilder(500);
//		sb.AppendFormat("<title>{0}</title>", title);
		sb.AppendFormat("<meta name='keywords' content='{0}' />", keywords);
		sb.AppendFormat("<meta name='description' content='{0}' />",description);
        sb.Append("<link href='http://www.targetlabs.com/Rss/RssExport.ashx' type='application/rss+xml' rel='alternate' title='RSS - TargetLabs.com' />");
		return sb.ToString();
	}
	
	string GetTitle(WebPage page){return page!=null?page.title:"";}
	string GetDescription(WebPage page){return page!=null?page.description:"";}
	string GetKeywords(WebPage page){return page!=null?page.keywords:"";}

	public PageInfo(Page page)
	{
		this.page = page;
		log = new Log(page);
		try
		{
			AppCache appCache=Global.AppCache;
			WebPage defaultPage=appCache.DefaultPage;
			WebPage communityPage=null;
			int cm=RequestUtils.GetCommunityId(page);
			if (cm > 0)
			{
				communityPage=appCache.GetWebPage(cm);
			}
			string pageName=WebUtils.GetPageNameWithoutExtension(page);
			if (pageName.Length == 0) pageName = Constants.defaultPageName;
			WebPage webPage=appCache.GetWebPage(pageName);
/*			title=GetString(GetTitle(webPage),GetTitle(communityPage),GetTitle(defaultPage)," - ");
			description=GetString(GetDescription(webPage),GetDescription(communityPage),GetDescription(defaultPage)," ");
			keywords=GetString(GetKeywords(webPage),GetKeywords(communityPage),GetKeywords(defaultPage),", ");*/
			AddInfo(defaultPage);
			AddInfo(webPage);
			AddInfo(communityPage);
			if (communityPage != null)
			{
				AddBanners(communityPage, appCache);
			}
			else AddBanners(webPage, appCache);
			AddBanners(defaultPage, appCache);
			page.PreRender += new EventHandler(page_PreRender);
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}

	void page_PreRender(object sender, EventArgs e)
	{
		if(page!=null) page.Title=title;
	}

	public void AddInfo(WebPage page)
	{
		if (page != null) AddInfo(page.title,page.keywords,page.description);
	}

	public void AddInfo(string s)
	{
		if (s != null)
		{
			AddInfo(s, GetKeywords(s), s);
		}
	}

	string GetKeywords(string text)
	{
		StringBuilder sb = new StringBuilder(512);
		string s = "";
		for (int i = 0; i < text.Length; i++)
		{
			char c = text[i];
			bool isLetterOrDigit=Char.IsLetterOrDigit(c);
			if (isLetterOrDigit)
			{
				s += c;
			}
			if(!isLetterOrDigit || i==text.Length-1)
			{
				if (s.Length > 2)
				{
					if (sb.Length > 0) sb.Append(',');
					sb.Append(s);
				}
				s = "";
			}
		}
		return sb.ToString();
	}

	public void AddInfo(string title, string keywords, string description)
	{
		AddInfo(ref this.title, title, " | ");
		AddInfo(ref this.keywords, keywords, ";");
		AddInfo(ref this.description, description, " ");
	}

	private void AddInfo(ref string s, string s2, string sep)
	{
		if (s2 != null)
		{
			s2=s2.Trim();
			if (s2.Length > 0)
			{
				if (s.Length == 0) s = s2;
				else
				{
					s = s2 + sep + s;
				}
			}
		}
	}

	private void AddBanners(WebPage webPage, AppCache appCache)
	{
		if (webPage != null && webPage.bannerTopicId>0)
		{ 
			BannerTopic bt = appCache.GetBannerTopic(webPage.bannerTopicId);
			if (bt != null)
			{
				int[] bannerIds={bt.b1,bt.b2,bt.b3,bt.b4,bt.b5,bt.b6,bt.b7,bt.b8,bt.b9};
				for (int i = 0; i < bannerIds.Length; i++)
				{
					int bannerIndex = i + 1;
					int bannerId = bannerIds[i];
					if (bannerId>0 && !banners.ContainsKey(bannerIndex))
					{
						Banner banner = appCache.GetBanner(bannerId);
						if (banner != null)
						{
							banners.Add(bannerIndex, banner);
						}
					}
				}
			}
		}
	}

/*	private string GetString(string s1, string s2, string s3, string sep)
	{
		string s=s1.Trim().Length>0 && s2.Trim().Length>0 ? s1+sep+s2 : s1+s2;
		return s.Trim().Length>0 ? s : s3;
	}*/

	public string GetBannerCode(int index)
	{
		Banner b = GetBanner(index);
		return b == null ? "" : b.GetHtmlCode();
	}
}
