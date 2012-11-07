using System.Collections.Generic;
using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc1
{
    public class NoMvcViewEngine : WebFormViewEngine
    {
        public NoMvcViewEngine()
        {
            var masterLocationFormats = new List<string>
            {
                "~/{1}/{0}.master", 
                "~/Shared/{0}.master"
            };
            masterLocationFormats.AddRange(MasterLocationFormats);
            MasterLocationFormats = masterLocationFormats.ToArray();

            var viewLocationFormats = new List<string>
            {
                "~/{1}/{0}.aspx", 
                "~/{1}/{0}.ascx", 
                "~/Shared/{0}.aspx", 
                "~/Shared/{0}.ascx"
            };
            viewLocationFormats.AddRange(ViewLocationFormats);
            ViewLocationFormats = viewLocationFormats.ToArray();

            var partialViewLocationFormats = new List<string>
            {
                "~/{1}/{0}.aspx",
                "~/{1}/{0}.ascx",
                "~/Shared/{0}.aspx",
                "~/Shared/{0}.ascx"
            };
            partialViewLocationFormats.AddRange(PartialViewLocationFormats);
            PartialViewLocationFormats = partialViewLocationFormats.ToArray();
        }
    }
}