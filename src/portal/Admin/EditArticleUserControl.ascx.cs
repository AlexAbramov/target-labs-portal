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

public partial class EditArticleUserControl : System.Web.UI.UserControl
{
	internal Article article;
	public void InitControl(Article article)
	{
		this.article = article;
		if (!IsPostBack)
		{
			using (GmConnection conn = Global.CreateConnection())
			{
				Utils.FillDDL(conn, ddlCity, "select Id, Name from Cities", article.cityId, "");
				Utils.FillDDL(conn, ddlArticleGroup, "select Id, Title from Articles where IsGroup=1", article.parentId, "Default");
				Utils.FillDDL(conn, ddlStatus, "select Id, Name from Statuses", (int)article.status);
			}
            calExt.SelectedDate = article.date;
			tbPerson.Text = article.person;
			tbTitle.Text = article.title;
			tbHeader.Text = article.header;
			tbPreview.Text = article.preview;
			tbText.Content = article.text;
			tbLink.Text = article.link;
			tbEmail.Text = article.email;
			tbCompany.Text = article.company;
			tbAddress.Text = article.address;
			tbPhone.Text = article.phone;
            tbTag.Text = article.tag;
            chkIsGroup.Checked = article.isGroup;
			tbDate.MaxLength = MaxLength.Input.dateString;
			tbPerson.MaxLength = MaxLength.Articles.Person;
			tbTitle.MaxLength = MaxLength.Articles.Title;
			tbHeader.MaxLength = MaxLength.Articles.Header;
			tbPreview.MaxLength = MaxLength.Articles.Preview;
			tbLink.MaxLength = MaxLength.Articles.Link;
			tbEmail.MaxLength = MaxLength.Articles.Email;
			tbCompany.MaxLength = MaxLength.Articles.Company;
			tbAddress.MaxLength = MaxLength.Articles.Address;
			tbPhone.MaxLength = MaxLength.Articles.Phone;
//			tbText.MaxLength = MaxLength.Articles.Text;
            tbTag.MaxLength = MaxLength.Articles.Tag;
            hlArticleParams.NavigateUrl = "ArticleParams.aspx?ar=" + article.Id;
		}
		else
		{
			article.parentId = int.Parse(ddlArticleGroup.SelectedValue);
			article.cityId = int.Parse(ddlCity.SelectedValue);
            article.date = calExt.SelectedDate ?? DateTime.Now;// Utils.ToDateTime(tbDate.Text.Trim());
			article.title = tbTitle.Text.Trim();
			article.person = tbPerson.Text.Trim();
			article.company = tbCompany.Text.Trim();
			article.preview = tbPreview.Text.Trim();
			article.header = tbHeader.Text.Trim();
            article.text = tbText.Content;
			article.address = tbAddress.Text.Trim();
			article.phone = tbPhone.Text.Trim();
			article.link = tbLink.Text.Trim();
            article.email = tbEmail.Text.Trim( );
            article.tag = tbTag.Text.Trim( );
            article.isGroup = chkIsGroup.Checked;
			article.status = (RecordStatus)int.Parse(ddlStatus.SelectedValue);
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
	}
}
