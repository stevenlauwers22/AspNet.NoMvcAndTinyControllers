using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc3.Sample.Forum.NewThread
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