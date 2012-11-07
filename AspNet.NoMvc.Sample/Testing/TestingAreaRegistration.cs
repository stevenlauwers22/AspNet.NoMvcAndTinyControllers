using System.Web.Mvc;

namespace AspNet.NoMvc.Sample.Testing
{
    public class TestingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Testing"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Testing_default",
                "Testing/{controller}/{action}/{id}",
                new { id = UrlParameter.Optional },
                new[] { "AspNet.NoMvc.Sample.Testing" }
            );
        }
    }
}
