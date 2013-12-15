using System.Web;
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
                new { id = "" });
            RouteTable.Routes.MapRoute(
                "Root",
                "",
                new { controller = "Home", action = "Index", id = "" });
        }

        private static void RegisterControllerFactory()
        {
            ControllerBuilder.Current.SetControllerFactory(new TinyControllerFactory());
        }
	}
}