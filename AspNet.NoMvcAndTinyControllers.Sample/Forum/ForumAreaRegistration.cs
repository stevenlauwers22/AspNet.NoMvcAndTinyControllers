using System.Web.Mvc;

namespace AspNet.NoMvcAndTinyControllers.Sample.Forum
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
                new { id = UrlParameter.Optional },
                new[] { "AspNet.NoMvcAndTinyControllers.Sample.Forum" }
            );
        }
    }
}