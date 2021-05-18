using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Modules.Libraries.Web.Events;
using Telerik.Sitefinity.Services;
using TheTrainingboss.SFADVDev.Configuration;
using TheTrainingboss.SFADVDev.Mvc.Models;

namespace TheTrainingboss.SFADVDev
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Bootstrapper.Initialized += Bootstrapper_Initialized;
        }

        private void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs e)
        {
            if (e.CommandName == "Bootstrapped")
            {
                Config.RegisterSection<AnnabelleConfig>();
                EventHub.Subscribe<IMediaContentDownloadedEvent>(evt => MyMediaDownloaded(evt));
                EventHub.Subscribe<IRajaEvent>(evt => RajaRaizedEvent(evt));
            }
        }

        private void RajaRaizedEvent(IRajaEvent evt)
        {
            string path = "~/App_Data/Sitefinity/Temp/Lino.txt";
            File.AppendAllText(HttpContext.Current.Server.MapPath(path), evt.MyCustomMessage); 
        }

        private void MyMediaDownloaded(IMediaContentDownloadedEvent evt)
        {
            string path = "~/App_Data/Sitefinity/Temp/Lino.txt";
            string log = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                evt.LibraryId, evt.Title, evt.Type, evt.Url, evt.UserId, evt.Origin, evt.MimeType);
            File.AppendAllText(HttpContext.Current.Server.MapPath(path), log);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}