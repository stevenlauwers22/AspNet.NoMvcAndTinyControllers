﻿using System.Web.Mvc;

namespace AspNet.TinyControllers.Mvc4.Sample.Areas.Administration.Controllers.Home
{
	[HandleError]
    public class IndexController : TinyController
	{
		public ActionResult Get()
		{
            return View();
		}
	}
}