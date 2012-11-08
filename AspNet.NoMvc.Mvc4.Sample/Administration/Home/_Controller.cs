using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc4.Sample.Administration.Home
{
    [HandleError]
    public class _Controller : Controller
    {
        #region Index

        public ActionResult Index()
        {
            return View();
        }

        #endregion
    }
}