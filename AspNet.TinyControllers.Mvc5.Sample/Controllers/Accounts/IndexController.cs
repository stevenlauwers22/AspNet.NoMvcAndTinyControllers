﻿using System.Web.Mvc;

namespace AspNet.TinyControllers.Mvc5.Sample.Controllers.Accounts
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