using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace TurnierverwaltungWeb
{
    public class Global : HttpApplication
    {
        private static Controller _verwalter;

        public static Controller Verwalter
        {
            get => _verwalter;
            set => _verwalter = value;
        }

        public Global() : base()
        {
            Verwalter = new Controller();
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Code, der beim Anwendungsstart ausgeführt wird
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}