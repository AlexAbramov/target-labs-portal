using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

//public enum ArticleType { Article=1, Digest = 2, News = 3, Page=4, Project=5, Product=6 }
public enum SessionObject { User, MenuItems, DataTable, Role, PageSessionObjects }
public enum RecordStatus { Removed=-2,Hidden = -1, New = 0, Admin=1, Moderator=2, Trusted = 3, Imported=4 }
public enum CityId { Federal = -1, Null=0, Rostov = 3 }
public enum MediaType { Newspaper = 1, Journal = 2, Book = 3, WebSite = 4 }
public enum UserRole { None=0, Candidate=1, Employer=2, Admin=3, Moderator=4}

//public enum TextId {About=1 }
//public enum BannerTopicId { Newspaper = 1, Journal = 2, Book = 3, WebSite = 4 }

public class Constants
{
	public static readonly Version programVersion = new Version(1, 0, 1);
	public const int maxVarChar = 1 << 20;
	public const int defaultPageId = 100;
	public const string defaultPageName = "default";
	public const int defaultBannerTopicId = 1;
}

public class MaxLength
{
	public class UserInfo
	{
		public const int Name = 200;
		public const int Email = 100;
		public const int Psw = 50;
		public const int Picture = 50;
	}

	public class Galleries
	{
		public const int Name = 200;
		public const int Text = 1000;
		public const int Logo = 50;
	}

	public class GalleryImages
	{
		public const int Filename = 50;
		public const int Name = 200;
		public const int Text = 1000;
	}

	public class BannerGroups
	{
		public const int Name = 200;
	}

	public class BannerTopics
	{
		public const int Name = 200;
	}

	public class Banners
	{
		public const int Filename = 50;
		public const int Link = 200;
		public const int Name = 200;
		public const int Code = 8000;
	}

	public class Pages
	{
		public const int Name = 200;
		public const int Title = 200;
		public const int Description = 500;
		public const int Keywords = 500;
	}

    public class ArticleParam
    {
        public const int Key = 50;
        public const int Value = 4000;
    }

	public class LinkExchangePages
	{
		public const int Text = 500000;
	}
		
	public class Companies
	{
		public const int Name = 50;
		public const int ContactPerson = 50;
		public const int Phone = 50;
		public const int Email = 50;
		public const int Link = 50;
	}

    public class Candidates
    {
        public const int Name = 50;
        public const int Surname = 50;
        public const int Phone = 50;
        public const int Email = 200;
        public const int Link = 200;
        public const int Address = 200;
        public const int Comments = 8000;
    }

	public class LogTypes
	{
		public const int Name = 50;
	}

	public class Log
	{
		public const int Page = 200;
		public const int Message = 4000;
	}

	public class Statuses
	{
		public const int Name = 50;
	}

	public class Cities
	{
		public const int Name = 50;
	}

	public class Articles
	{
		public const int Person = 50;
		public const int Title = 500;
		public const int Preview = 50;
		public const int Header = 1000;
		public const int Text = Constants.maxVarChar;
		public const int Company = 100;
		public const int Address = 100;
		public const int Phone = 100;
		public const int Link = 200;
        public const int Email = 100;
        public const int Tag = 50;
	}

	public class Topics
	{
		public const int Name = 200;
	}

	public class MediaTypes
	{
		public const int Name = 200;
	}

	public class Mediae
	{
		public const int Name = 200;
		public const int Header = 8000;
		public const int Link = 200;
		public const int Email = 100;
		public const int Publisher = 200;
		public const int Author = 200;
		public const int Periodicity = 100;
	}

	public class Industries
	{
		public const int Name = 200;
	}

	public class Polls
	{
		public const int Question = 500;
	}

	public class PollAnswers
	{
		public const int Answer = 200;
	}

	public class Input
	{
		public const int dateString = 50;
		public const int salary = 9;
	}

	public class Forums
	{
		public const int Name = 200;
		public const int Description = 5000;
	}

	public class ForumTopics
	{
		public const int Name = 200;
		public const int Description = 5000;
	}

	public class ForumMessages
	{
		public const int UserName = 200;
		public const int Text = 8000;
	}
}
