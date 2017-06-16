using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using CNT.Models;

namespace CNT
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RegisterUnityContainer();
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }

        private void RegisterUnityContainer()
        {
            try
            {
                var container = new UnityContainer();
                UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                section.Configure(container);
                Registry.DependencyLocator = new UnityDependencyLocator(container);
                //Storm.Models.Mappers.Mapper.Configure();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }
        public void LogError(string error)
        {
            if (error == "There is no record available") { }
            else if (error == "There are no relevant records available") { }
            else
            {
                string path = HttpContext.Current.Server.MapPath("~/Log/LogErrors.txt");
                System.IO.File.AppendAllLines(path, new List<string> { DateTime.Now.ToString() + " - " + error });
            }
        }
    }
}