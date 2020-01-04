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
using Geomethod.Data;
using Geomethod.Web;
using Geomethod;

public partial class CandidateUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
	{
    }

	public void LoadData()
	{
        int positionId = RequestUtils.GetArticleId(this);
        Article article = null;
		using (GmConnection conn = Global.CreateConnection())
		{
            if (positionId != 0)
			{
                article = Article.GetArticle(conn, positionId);
			}
		}
        if (article != null)
        {
            litDate.Text = article.date.ToShortDateString();//<%# Eval("Date", "{0:MM.dd.yyyy}")%>
            litTitle.Text = article.title;
        }
        tbName.MaxLength = MaxLength.Candidates.Name;
        tbSurname.MaxLength = MaxLength.Candidates.Surname;
        tbEmail.MaxLength = MaxLength.Candidates.Email;
        tbPhone.MaxLength = MaxLength.Candidates.Phone;
		tbComments.MaxLength = MaxLength.Candidates.Comments;
	}

	public void SaveData()
	{
        int positionId = RequestUtils.GetArticleId(this);
		Candidate candidate = new Candidate();
        candidate.positionId = positionId;
        candidate.name = tbName.Text.Trim();
        candidate.surname = tbSurname.Text.Trim();
		candidate.comments = tbComments.Text.Trim();
		candidate.phone = tbPhone.Text.Trim();
		candidate.email = tbEmail.Text.Trim();
		candidate.date = DateTime.Now;
		using (GmConnection conn = Global.CreateConnection())
		{
			candidate.Save(conn);
            candidate.resume=UploadResume(candidate.Id);
            candidate.UpdateResume(conn);
     	}
	}

    private string UploadResume(int candidateId)
    {
        string fileName = Path.GetFileName(fileUpload.FileName);
        if (fileName.Length > 0)
        {
            var fileExt=Path.GetExtension(fileName).ToLower();
            fileName = string.Format("{0}{1}", candidateId, fileExt);
            string dir = PathUtils.BaseDirectory + @"Resume\";
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            fileUpload.SaveAs( dir + fileName);
        }
        return fileName;
    }
}
