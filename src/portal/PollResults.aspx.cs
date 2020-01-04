using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Geomethod.Data;
using Geomethod.Web;

public partial class PollResults : System.Web.UI.Page
{
	Log log = null;
	DataTable dataTable = new DataTable("PollAnswers");
	Hashtable pollQuestions = new Hashtable();
	Dictionary<int, int> pollCounts = new Dictionary<int, int>();
	Dictionary<int, int> firstIds = new Dictionary<int, int>();
	Dictionary<int, int> lastIds = new Dictionary<int, int>();
	protected void Page_Load(object sender, EventArgs e)
  {
		log=MainMasterPage.InitPage(this);
		try
		{
			log = new Log(this);
			if (!IsPostBack)
			{
				using (GmConnection conn = Global.CreateConnection())
				{
					conn.Fill(dataTable, "select PollAnswers.* from PollAnswers where PollAnswers.Status>0 order by PollId desc, Count desc");
					conn.Fill(pollQuestions, "select Id, Question from Polls");
				}
				DataColumn dcId=dataTable.Columns["Id"];
				DataColumn dcPollId=dataTable.Columns["PollId"];
				DataColumn dcCount=dataTable.Columns["Count"];
				DataColumn dcPercent=dataTable.Columns.Add("CountPercent",typeof(int));
				foreach (DataRow dr in dataTable.Rows)
				{
					int id = (int)dr[dcId];
					int pollId = (int)dr[dcPollId];
					int count = (int)dr[dcCount];
					if (pollCounts.ContainsKey(pollId))
					{
						pollCounts[pollId] += count;
					}
					else pollCounts[pollId] = count;
					if(!firstIds.ContainsKey(pollId)) firstIds[pollId] = id;
					lastIds[pollId] = id;
				}
				foreach (DataRow dr in dataTable.Rows)
				{
					int pollId=(int)dr[dcPollId];
					int count =(int) dr[dcCount];
					int pollCount = pollCounts[pollId];
					int countPercent = pollCount>0?100*count/pollCount:0;
					dr[dcPercent] = countPercent;
				}
				Repeater1.DataSource = dataTable;
				Repeater1.DataBind();
			}
		}
		catch (Exception ex)
		{
			log.Exception(ex);
		}
		finally
		{
		}
	}
	public string CheckPollHeader(int id, int pollId)
	{
		if (firstIds[pollId] == id)
		{
		  string question=pollQuestions[pollId] as string;
			if (question != null) return string.Format("<p><strong>{0}</strong></p>",question);
		}
		return "";
	}
	public string CheckPollFooter(int id, int pollId)
	{
		if (lastIds[pollId] == id)
		{
			int count=pollCounts[pollId];
			return string.Format("<br/><p>Всего проголосовало: {0}</p> <div class='line'></div>",count);
		}
		return "";
	}

	
}
