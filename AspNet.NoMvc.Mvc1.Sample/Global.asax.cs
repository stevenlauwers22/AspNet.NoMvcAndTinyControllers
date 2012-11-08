using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNet.NoMvc.Mvc1.Sample
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			RegisterRoutes();
		    RegisterControllerFactory();
            RegisterViewEngine();
		}
        protected void Application_Error(object sender, EventArgs e)
        {
            
        }
        private static void RegisterRoutes()
        {
            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RouteTable.Routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            RouteTable.Routes.MapRoute("Default", "{controller}/{action}/{id}", new { id = "" });
            RouteTable.Routes.MapRoute("Root", "", new { controller = "Home", action = "Index", id = "" });
        }

        private static void RegisterControllerFactory()
        {
            ControllerBuilder.Current.SetControllerFactory(new NoMvcControllerFactory("AspNet.NoMvc.Mvc1.Sample"));
        }

	    private static void RegisterViewEngine()
	    {
	        ViewEngines.Engines.Clear();
	        ViewEngines.Engines.Add(new NoMvcViewEngine());
	    }
	}
}