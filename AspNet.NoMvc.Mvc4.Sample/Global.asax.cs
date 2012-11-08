using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNet.NoMvc.Mvc4.Sample
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			RegisterRoutes();
		    RegisterControllerFactory();
            RegisterViewEngine();
		}

        private static void RegisterRoutes()
        {
            AreaRegistration.RegisterAllAreas();
            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RouteTable.Routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            RouteTable.Routes.MapRoute("Default", "{controller}/{action}/{id}", new { id = UrlParameter.Optional });
            RouteTable.Routes.MapRoute("Root", "", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }

        private static void RegisterControllerFactory()
        {
            ControllerBuilder.Current.SetControllerFactory(new NoMvcControllerFactory("AspNet.NoMvc.Mvc4.Sample"));
        }

	    private static void RegisterViewEngine()
	    {
	        ViewEngines.Engines.Clear();
	        ViewEngines.Engines.Add(new NoMvcViewEngine());
	    }
	}
}