using System.Web.Mvc;

namespace AspNet.NoMvcAndTinyController.Sample.Testing.Home
{
    [HandleError]
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}