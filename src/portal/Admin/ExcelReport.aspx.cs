using System;
using System.IO;
using System.Threading;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Private_ExcelReport : System.Web.UI.Page
{
	Log log;
	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			log = new Log(this);
			GenerateResponse();
		}
		catch (ThreadAbortException ex)
		{
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
	}

	private void GenerateResponse()
	{
		DataTable dataTable = (DataTable)Utils.GetSessionObject(this, SessionObject.DataTable);
		if (dataTable == null) return;
		Title = dataTable.TableName;
		Response.ContentType = "application/vnd.ms-excel";

		using (StreamWriter sw = new StreamWriter(Response.OutputStream))
		{
			foreach (DataColumn dataColumn in dataTable.Columns)
			{
				sw.Write(dataColumn.Caption);
				sw.Write(Convert.ToChar(9));
			}
			sw.WriteLine();

			foreach (DataRow dataRow in dataTable.Rows)
			{
				if (dataRow.RowState == DataRowState.Deleted) continue;
				foreach (DataColumn dataColumn in dataTable.Columns)
				{
					object obj = dataRow[dataColumn];
					string s = obj.ToString();
					if (s != null)
					{
						if (s.IndexOf('\r') >= 0) s = s.Replace('\r', ' ');
						if (s.IndexOf('\n') >= 0) s = s.Replace('\n', ' ');
						sw.Write(s);
					}
					sw.Write(Convert.ToChar(9));
				}
				sw.WriteLine();
			}
		}
		Response.End();
	}
}
