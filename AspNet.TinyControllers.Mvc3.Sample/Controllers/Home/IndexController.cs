﻿using System.Web.Mvc;
using AspNet.TinyControllers.Mvc3.Sample.Models.Home;

namespace AspNet.TinyControllers.Mvc3.Sample.Controllers.Home
{
    [HandleError]
    public class IndexController : TinyController
    {
        public ActionResult Get()
        {
            var model = new IndexModel { Message = "Welcome to ASP.NET MVC!" };
            return View(model);
        }
    }
}