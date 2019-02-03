using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W2.Web.Portal.Utils;

namespace W2.Web.Portal.Http_Modules
{
    public class GAnalyticsModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(HandlerAnalytics); 
        }

        public void HandlerAnalytics(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;

            application.Response.Filter = new GAnalyticsStream(application.Response.Filter); 

        }

    }
}