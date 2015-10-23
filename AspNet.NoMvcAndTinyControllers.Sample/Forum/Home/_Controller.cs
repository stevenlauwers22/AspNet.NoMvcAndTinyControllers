using System.Web.Mvc;

namespace AspNet.NoMvcAndTinyControllers.Sample.Forum.Home
{
    [HandleError]
    public class _Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}