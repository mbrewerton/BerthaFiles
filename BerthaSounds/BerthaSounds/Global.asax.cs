using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Configuration;
using System.Data.Entity;
using SquishIt.Framework;
using Bundle = SquishIt.Framework.Bundle;

namespace BerthaSounds
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static string Environment = ConfigurationManager.AppSettings["Environment"];
        public static string ApplicationName = ConfigurationManager.AppSettings["ApplicationName"];

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            /* Replaced with SquishIt in-memory bundling */
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application_Bundle();
        }

        protected void Application_Bundle()
        {
            Bundle.Css()
                .AddDirectory("~/Content/c")
                .AsCached("styles", "~/assets/css/style");
            
            Bundle.JavaScript()
                .Add("~/Content/j/common/jquery-1.10.2.min.js")
                .Add("~/Content/j/common/angular.min.js")
                .Add("~/Content/j/common/angular-route.min.js")
                .Add("~/Content/j/common/angular-resource.min.js")
                .Add("~/Content/j/common/angular-animate.min.js")
                .Add("~/Content/j/common/bootstrap.min.js")
                .Add("~/Content/j/common/jquery.validate.min.js")
                .AddDirectory("~/Content/j/custom")
                .AddDirectory("~/Content/j/angular")
                .AddDirectory("~/Content/j/directives")
                // Add each area individually
                .AddDirectory("~/Content/Areas/Admin/Controllers")
                .AddDirectory("~/Content/Areas/Admin/Resources")
                .AsCached("jslibs", "~/assets/js/jslibs");
        }
    }
}
