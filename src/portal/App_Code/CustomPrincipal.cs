using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Principal;

/// <summary>
/// Summary description for CustomPrincipal
/// </summary>
public class CustomPrincipal: IPrincipal
{
	IIdentity identity;
	public CustomPrincipal(IIdentity identity)
	{
		this.identity = identity;
	}

	#region IPrincipal Members

	public IIdentity Identity
	{
		get { return identity; }
	}

	public bool IsInRole(string role)
	{
		return true;//!!! identity.Name.StartsWith(role + "_");
	}

	#endregion
}
