﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNet.TinyControllers.Mvc1.Sample
{
	public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Configure();
        }

        public static void Configure()
        {
            RegisterRoutes();
            RegisterControllerFactory();
        }

        private static void RegisterRoutes()
        {
            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RouteTable.Routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            RouteTable.Routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { id = "" },
                new[] { "AspNet.TinyControllers.Mvc1.Sample.Controllers" });
            RouteTable.Routes.MapRoute(
                "Root",
                "",
                new { controller = "Home", action = "Index", id = "" },
                new[] { "AspNet.TinyControllers.Mvc1.Sample.Controllers" });

            // If you don't specify the namespace when registering your routes, you should register a default namespace with the current controller builder
            // ControllerBuilder.Current.DefaultNamespaces.Add("AspNet.TinyControllers.Mvc1.Sample.Controllers");
        }

        private static void RegisterControllerFactory()
        {
            ControllerBuilder.Current.SetControllerFactory(new TinyControllerFactory());
        }
	}
}