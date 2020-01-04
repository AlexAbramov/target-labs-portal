using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Geomethod;
using Geomethod.Web;
using Geomethod.Data;

/// <summary>
/// Summary description for PageInfoCache
/// </summary>
public class AppCache
{
	Dictionary<int, Banner> banners;
	Dictionary<int, BannerTopic> bannerTopics;
	Dictionary<int, WebPage> pages;
	Dictionary<string, WebPage> pagesByName;
	BannerTopic defaultBannerTopic;
	WebPage defaultPage;

	public Banner GetBanner(int id) { return banners.ContainsKey(id) ? banners[id] : null; }
	public BannerTopic GetBannerTopic(int id) { return bannerTopics.ContainsKey(id) ? bannerTopics[id] : null; }
	public WebPage GetWebPage(int id) { return pages.ContainsKey(id) ? pages[id] : null; }
	public WebPage GetWebPage(string name) { name = name.Trim().ToLower(); return pagesByName.ContainsKey(name) ? pagesByName[name] : null; }
	public WebPage DefaultPage { get { return defaultPage; } }
	public BannerTopic DefaultBannerTopic { get { return defaultBannerTopic; } }

	public AppCache()
	{
		using (GmConnection conn = Global.CreateConnection())
		{
			// Banners
			int count = (int)conn.ExecuteScalar("select count(*) from Banners where Status>0");
			banners = new Dictionary<int, Banner>(count);
			using (DbDataReader dr = conn.ExecuteReader("select * from Banners where Status>0"))
			{
				while (dr.Read())
				{
					Banner banner = new Banner(dr);
					banners.Add(banner.Id, banner);
				}
			}

			// BannerTopics
			count = (int)conn.ExecuteScalar("select count(*) from BannerTopics");
			bannerTopics = new Dictionary<int, BannerTopic>(count);
			using (DbDataReader dr = conn.ExecuteReader("select * from BannerTopics"))
			{
				while (dr.Read())
				{
					BannerTopic bannerTopic = new BannerTopic(dr);
					bannerTopics.Add(bannerTopic.Id, bannerTopic);
				}
			}
			if (bannerTopics.ContainsKey(Constants.defaultBannerTopicId))
			{
				defaultBannerTopic = bannerTopics[Constants.defaultBannerTopicId];
			}
			//if (defaultBannerTopic == null) throw new TargetLabsException("defaultBannerTopic not found.");

			// Pages
			count = (int)conn.ExecuteScalar("select count(*) from Pages");
			pages = new Dictionary<int, WebPage>(count);
			pagesByName = new Dictionary<string, WebPage>(count);
			using (DbDataReader dr = conn.ExecuteReader("select * from Pages"))
			{
				while (dr.Read())
				{
					WebPage page = new WebPage(dr);
					pages.Add(page.Id, page);
					pagesByName.Add(page.name.Trim().ToLower(), page);
				}
			}
			if (pages.ContainsKey(Constants.defaultPageId))
			{
				defaultPage = pages[Constants.defaultPageId];
			}
			//if (defaultPage == null) throw new TargetLabsException("defaultPage not found.");
		}
	}
}
