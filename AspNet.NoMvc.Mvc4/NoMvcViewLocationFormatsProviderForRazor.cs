using System.Collections.Generic;
using System.Linq;

namespace AspNet.NoMvc.Mvc4
{
    public class NoMvcViewLocationFormatsProviderForRazor : INoMvcViewLocationFormatsProvider
    {
        public IEnumerable<string> GetMasterLocationFormats()
        {
            return NoMvcWebFormViewLocationFormats.MasterLocationFormats;
        }

        public IEnumerable<string> GetViewLocationFormats()
        {
            return NoMvcWebFormViewLocationFormats.ViewLocationFormats;
        }

        public IEnumerable<string> GetAreaMasterLocationFormats()
        {
            return NoMvcWebFormViewLocationFormats.AreaMasterLocationFormats;
        }

        public IEnumerable<string> GetAreaViewLocationFormats()
        {
            return NoMvcWebFormViewLocationFormats.AreaViewLocationFormats;
        }

        public static class NoMvcWebFormViewLocationFormats
        {
            public static IEnumerable<string> MasterLocationFormats
            {
                get
                {
                    return (new List<string>
                    {
                        "~/{1}/{0}.cshtml", 
                        "~/{1}/{0}.vbhtml", 
                        "~/Shared/{0}.cshtml",
                        "~/Shared/{0}.vbhtml"
                    }).AsEnumerable();
                }
            }

            public static IEnumerable<string> ViewLocationFormats
            {
                get
                {
                    return (new List<string>
                    {
                        "~/{1}/{0}.cshtml", 
                        "~/{1}/{0}.vbhtml", 
                        "~/Shared/{0}.cshtml",
                        "~/Shared/{0}.vbhtml"
                    }).AsEnumerable();
                }
            }

            public static IEnumerable<string> AreaMasterLocationFormats
            {
                get
                {
                    return (new List<string>
                    {
                        "~/{2}/{1}/{0}.cshtml", 
                        "~/{2}/{1}/{0}.vbhtml", 
                        "~/{2}/Shared/{0}.cshtml",
                        "~/{2}/Shared/{0}.vbhtml"
                    }).AsEnumerable();
                }
            }

            public static IEnumerable<string> AreaViewLocationFormats
            {
                get
                {
                    return (new List<string>
                    {
                        "~/{2}/{1}/{0}.cshtml", 
                        "~/{2}/{1}/{0}.vbhtml", 
                        "~/{2}/Shared/{0}.cshtml",
                        "~/{2}/Shared/{0}.vbhtml"
                    }).AsEnumerable();
                }
            }
        }
    }
}