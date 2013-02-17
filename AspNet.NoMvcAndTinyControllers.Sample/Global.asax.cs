using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AspNet.NoMvc.Mvc2;
using AspNet.TinyControllers.Mvc2;

namespace AspNet.NoMvcAndTinyController.Sample
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
            RouteTable.Routes.MapRoute("Root", "", new { controller = "Products", action = "Index", id = UrlParameter.Optional });
        }

        private static void RegisterControllerFactory()
        {
            ControllerBuilder.Current.SetControllerFactory(new TinyControllerFactory("AspNet.NoMvcAndTinyController.Sample"));
        }

	    private static void RegisterViewEngine()
	    {
	        ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new NoMvcWebFormViewEngine());
	    }
	}
}