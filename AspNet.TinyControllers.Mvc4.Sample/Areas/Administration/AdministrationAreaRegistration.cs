using System.Web.Mvc;

namespace AspNet.TinyControllers.Mvc4.Sample.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Administration"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "AspNet.TinyControllers.Mvc4.Sample.Areas.Administration.Controllers" }
            );
        }
    }
}