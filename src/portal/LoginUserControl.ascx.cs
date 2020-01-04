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

public partial class LoginUserControl : System.Web.UI.UserControl
{
	Log log;
  protected void Page_Load(object sender, EventArgs e)
  {
		log = new Log(this);
		try
		{
			UserRole ur=Utils.GetUserRole(Context);
			int index=0;
			hlCab.NavigateUrl = GetTargetPath(ur);
			switch(ur)
			{
				case UserRole.Candidate:
					{
						index = 1;
						break;
					}
				case UserRole.Employer:
					{
						index = 1;
						break;
					}
			}
			MultiView1.ActiveViewIndex =index;
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}
	string GetTargetPath(UserRole ur)
	{
		switch (ur)
		{
			case UserRole.Candidate: return "CabProfile.aspx";
			case UserRole.Employer: return "EmployerVacancies.aspx";
		}
		return "Default.aspx";
	}
	protected void btnLogin_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			Login();
		}
		catch (System.Threading.ThreadAbortException ex)
		{
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
		finally
		{
		}
	}

	void Login()
	{
		string login = tbLogin.Text.Trim();
		string password = tbPassword.Text.Trim();
//        if (login == "target" && password == "labs")
        if (login == "tar" && password == "lab")
        {
			FormsAuthentication.SetAuthCookie("Admin", false);
			WebUtils.Redirect(this, "Admin/Default.aspx");
		}
		else
		{
			UserInfo ui=null;
			using (GmConnection conn = Global.CreateConnection())
			{
				ui = UserInfo.GetUserInfo(conn,tbLogin.Text.Trim(),tbPassword.Text.Trim());
			}
			if (ui != null)
			{
				int ri = (int)ui.userRole;
				FormsAuthentication.SetAuthCookie(ri.ToString()+'_'+ui.Id.ToString(), false);
				string url = GetTargetPath(ui.userRole);
				WebUtils.Redirect(this, url);
			}
			else
			{
				lblError.Visible = true;
			}
		}
		/*		User user;
				using (Proxy proxy = new Proxy())
				{
					user = proxy.GetUser(login, password);
				}
				if (user != null)
				{
					Session[SessionObject.User.ToString()] = user;
					switch (user.role)
					{
						case UserRole.Administrator:
							FormsAuthentication.SetAuthCookie("Admin", false);
							Utils.Redirect(this, "Admin/Leads.aspx");
							break;
						case UserRole.Manager:
							FormsAuthentication.SetAuthCookie("Manager", false);
							Utils.Redirect(this, "Manager/Leads.aspx");
							break;
						case UserRole.Agent:
							FormsAuthentication.SetAuthCookie("Agent", false);
							if (user.service == Service.AdsPosting) Utils.Redirect(this, "Agent/RealEstateAds.aspx");
							else Utils.Redirect(this, "Agent/Leads.aspx");
							break;
					}
				}
				else lblMessage.Text = "Wrong login or password";*/
	}

	protected void lbLogout_Click(object sender, EventArgs e)
	{
		FormsAuthentication.SignOut();
		//				Context.User.Identity.
		//				FormsAuthentication.GetAuthCookie("User").Value = ui.Id;
//		Server.Transfer("Default.aspx");
		WebUtils.RedirectHome(this);
	}
}
