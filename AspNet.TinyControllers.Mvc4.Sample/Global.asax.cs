using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNet.TinyControllers.Mvc4.Sample
{
	public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            RegisterRoutes();
            RegisterControllerFactory();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            
        }

        private static void RegisterRoutes()
        {
            AreaRegistration.RegisterAllAreas();
            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RouteTable.Routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            RouteTable.Routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }

        private static void RegisterControllerFactory()
        {
            ControllerBuilder.Current.SetControllerFactory(new TinyControllerFactory("AspNet.TinyControllers.Mvc4.Sample.Controllers"));
        }
	}
}