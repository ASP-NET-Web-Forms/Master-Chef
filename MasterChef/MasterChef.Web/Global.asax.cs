namespace MasterChef.Web
{
    using System;
    using System.Web;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class Global : HttpApplication
    {
        public const string APPLICATION_ERROR = "TheLastException";

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            DatabaseConfig.Initialize();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            Exception ex = Server.GetLastError();
            this.Application[APPLICATION_ERROR] = ex;
        }
    }
}