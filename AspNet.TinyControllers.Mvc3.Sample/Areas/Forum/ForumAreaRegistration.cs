using System.Web.Mvc;

namespace AspNet.TinyControllers.Mvc3.Sample.Areas.Forum
{
    public class ForumAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Forum"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Forum_default",
                "Forum/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "AspNet.TinyControllers.Mvc3.Sample.Areas.Forum.Controllers" }
            );
        }
    }
}
