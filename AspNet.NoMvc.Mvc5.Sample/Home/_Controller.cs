using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc5.Sample.Home
{
    [HandleError]
    public class _Controller : Controller
    {
        #region Index

        public ActionResult Index()
        {
            var model = new IndexModel { Message = "Welcome to ASP.NET MVC!" };
            return View(model);
        }

        #endregion

        #region About

        public ActionResult About()
        {
            return View();
        }

        #endregion
    }
}