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
using API.Mapping;
using API.Models.DbContexts;
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
            AutoMapperConfig.Configure();

            //Database.SetInitializer(new DropCreateDatabaseAlways<BerthaContext>());
            //var db = new BerthaContext();
            //db.Database.Initialize(true);

            /* Replaced with SquishIt in-memory bundling */
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application_Bundle();
        }

        protected void Application_Bundle()
        {
            if (Environment == "Local")
            {
                Bundle.JavaScript()
                    .Add("~/Content/j/common/jquery-1.10.2.min.js")
                    .Add("~/Content/j/common/angular.min.js")
                    .Add("~/Content/j/common/angular-route.min.js")
                    .Add("~/Content/j/common/angular-resource.min.js")
                    .Add("~/Content/j/common/angular-animate.min.js")
					//.Add("~/Content/j/common/bootstrap.min.js")
                    .Add("~/Content/j/common/jquery.validate.min.js")
					.Add("~/Content/j/common/ui-bootstrap-tpls-0.12.1.min.js")
					.AddDirectory("~/Content/Offline/j")
                    .AddDirectory("~/Content/j/custom")
                    .AddDirectory("~/Content/j/angular")
                    .AddDirectory("~/Content/j/directives")
                    .AddDirectory("~/Content/j/resources")
                    .AddDirectory("~/Content/j/services")
					.AddDirectory("~/Content/j/filters")
                    // Add each area individually
                    .AddDirectory("~/Content/Areas")
                    .AsCached("jslibs", "~/assets/js/jslibs");

	            Bundle.Css()
					.AddDirectory("~/Content/c")
					.AddDirectory("~/Content/Offline/c")
		            .AsCached("styles", "~/assets/css/styles");
            }
            else
            {
				Bundle.Css()
					.AddMinified("~/Content/c/Styles.min.css")
					//.AddDirectory("~/Content/c")
					.Add("~/Content/Offline/c/Fontawesome/font-awesome.css")
					//.AddRemote("~/Content/c", "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.3.0/css/font-awesome.min.css")
					.AsCached("styles", "~/assets/css/styles");

                Bundle.JavaScript()
					.Add("~/Content/j/common/jquery-1.10.2.min.js")
					.Add("~/Content/j/common/angular.min.js")
					.Add("~/Content/j/common/angular-route.min.js")
					.Add("~/Content/j/common/angular-resource.min.js")
					.Add("~/Content/j/common/angular-animate.min.js")
					.Add("~/Content/j/common/bootstrap.min.js")
					.Add("~/Content/j/common/jquery.validate.min.js")
					.Add("~/Content/j/common/ui-bootstrap-tpls-0.12.1.min.js")
					.Add("~/Content/j/common/moment.min.js")
					//.AddRemote("~/Content/j/common", "https://cdnjs.cloudflare.com/ajax/libs/jquery/1.11.3/jquery.min.js")
					//.AddRemote("~/Content/j/common", "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.3.15/angular.min.js")
					//.AddRemote("~/Content/j/common", "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.3.15/angular-route.min.js")
					//.AddRemote("~/Content/j/common", "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.3.15/angular-resource.min.js")
					//.AddRemote("~/Content/j/common", "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.3.15/angular-animate.min.js")
					//.AddRemote("~/Content/j/common", "https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.4/js/bootstrap.min.js")
					//.AddRemote("~/Content/j/common", "http://ajax.aspnetcdn.com/ajax/jquery.validate/1.13.1/jquery.validate.min.js")
					//.AddRemote("~/Content/j/common", "https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.6/moment.min.js")
                    .AddDirectory("~/Content/j/custom")
                    .AddDirectory("~/Content/j/angular")
                    .AddDirectory("~/Content/j/directives")
                    .AddDirectory("~/Content/j/resources")
                    .AddDirectory("~/Content/j/services")
					.AddDirectory("~/Content/j/filters")
                    // Add each area individually
                    .AddDirectory("~/Content/Areas")
					.ForceDebug()
                    .AsCached("jslibs", "~/assets/js/jslibs");
            }
        }
    }
}
