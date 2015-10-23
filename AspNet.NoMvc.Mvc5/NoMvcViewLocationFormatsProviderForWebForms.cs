using System.Collections.Generic;
using System.Linq;

namespace AspNet.NoMvc.Mvc5
{
    public class NoMvcViewLocationFormatsProviderForWebForms : INoMvcViewLocationFormatsProvider
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
                        "~/{1}/{0}.master", 
                        "~/Shared/{0}.master"
                    }).AsEnumerable();
                }
            }

            public static IEnumerable<string> ViewLocationFormats
            {
                get
                {
                    return (new List<string>
                    {
                        "~/{1}/{0}.aspx", 
                        "~/{1}/{0}.ascx", 
                        "~/Shared/{0}.aspx", 
                        "~/Shared/{0}.ascx"
                    }).AsEnumerable();
                }
            }

            public static IEnumerable<string> AreaMasterLocationFormats
            {
                get
                {
                    return (new List<string>
                    {
                        "~/{2}/{1}/{0}.master", 
                        "~/{2}/Shared/{0}.master"
                    }).AsEnumerable();
                }
            }

            public static IEnumerable<string> AreaViewLocationFormats
            {
                get
                {
                    return (new List<string>
                    {
                        "~/{2}/{1}/{0}.aspx",
                        "~/{2}/{1}/{0}.ascx",
                        "~/{2}/Shared/{0}.aspx",
                        "~/{2}/Shared/{0}.ascx"
                    }).AsEnumerable();
                }
            }
        }
    }
}