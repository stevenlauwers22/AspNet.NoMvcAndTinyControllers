﻿using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc4.Sample.Forum.Home
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