using System.Collections.Generic;
using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc2
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

            var areaMasterLocationFormats = new List<string>
            {
                "~/{2}/{1}/{0}.master", 
                "~/{2}/Shared/{0}.master"
            };
            areaMasterLocationFormats.AddRange(AreaMasterLocationFormats);
            AreaMasterLocationFormats = areaMasterLocationFormats.ToArray();

            var viewLocationFormats = new List<string>
            {
                "~/{1}/{0}.aspx", 
                "~/{1}/{0}.ascx", 
                "~/Shared/{0}.aspx", 
                "~/Shared/{0}.ascx"
            };
            viewLocationFormats.AddRange(ViewLocationFormats);
            ViewLocationFormats = viewLocationFormats.ToArray();

            var areaViewLocationFormats = new List<string>
            {
                "~/{2}/{1}/{0}.aspx",
                "~/{2}/{1}/{0}.ascx",
                "~/{2}/Shared/{0}.aspx",
                "~/{2}/Shared/{0}.ascx"
            };
            areaViewLocationFormats.AddRange(AreaViewLocationFormats);
            AreaViewLocationFormats = areaViewLocationFormats.ToArray();

            var partialViewLocationFormats = new List<string>
            {
                "~/{1}/{0}.aspx",
                "~/{1}/{0}.ascx",
                "~/Shared/{0}.aspx",
                "~/Shared/{0}.ascx"
            };
            partialViewLocationFormats.AddRange(PartialViewLocationFormats);
            PartialViewLocationFormats = partialViewLocationFormats.ToArray();

            var areaPartialViewLocationFormats = new List<string>
            {
                "~/{2}/{1}/{0}.aspx",
                "~/{2}/{1}/{0}.ascx",
                "~/{2}/Shared/{0}.aspx",
                "~/{2}/Shared/{0}.ascx"
            };
            areaPartialViewLocationFormats.AddRange(AreaPartialViewLocationFormats);
            AreaPartialViewLocationFormats = areaPartialViewLocationFormats.ToArray();
        }
    }
}