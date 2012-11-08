using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc2.Sample.Administration
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
                new { id = UrlParameter.Optional },
                new[] { "AspNet.NoMvc.Mvc2.Sample.Administration" }
            );
        }
    }
}