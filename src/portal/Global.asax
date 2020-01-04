<%@ Application Language="C#" %>

<script runat="server">
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        Global.Application_Start();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
        Global.Application_End();
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
        Global.Application_Error();
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        Global.Session_Start(this.Request,this.Session);
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        Global.Session_End();
    }

	void Application_OnBeginRequest(object sender, EventArgs e)
	{
		Global.Application_OnBeginRequest(this.Context);
	}

	protected void Application_OnEndRequest(object sender, EventArgs e)
	{
		Global.Application_OnEndRequest(this.Context,this.Response);
	}

/*	protected void Application_AuthorizeRequest(Object sender, EventArgs e)
	{
		Global.Application_AuthorizeRequest(this.Context, this.Request);
	}*/
</script>