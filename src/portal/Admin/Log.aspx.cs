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
using Geomethod.Web;
using Geomethod.Data;

public partial class LogPage : System.Web.UI.Page
{
	Log log;
	GridHelper gridHelper;
	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			log = AdminMasterPage.InitPage(this, "Messages log", true);
			gridHelper = new GridHelper(this, gridView);
			if (!IsPostBack)
			{
				LoadData();
			}
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}

	private void LoadData()
	{
		foreach(LogType lt in Enum.GetValues(typeof(LogType)))
		{
			ListItem li=new ListItem(lt.ToString(),((int)lt).ToString());
			ddlLogType.Items.Add(li);
		}
		ddlLogType.SelectedValue = ((int)LogType.Exception).ToString();
		UpdateGrid();
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
	{
		try
		{
			UpdateGrid();
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}

	private void UpdateGrid()
	{
		gridHelper.ClearDataTable();

		LogType lt = (LogType)int.Parse(ddlLogType.SelectedValue);
		string query=string.Format("select * from [Log] where LogTypeId={0}",(int)lt);
		using (GmConnection conn = Global.CreateConnection())
		{
			conn.Fill(gridHelper.DataTable,query);
		}
		gridHelper.DataTable.DefaultView.Sort = "Time desc";
	}
}
