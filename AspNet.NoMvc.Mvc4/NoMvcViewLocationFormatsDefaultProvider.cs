using System.Collections.Generic;
using System.Linq;

namespace AspNet.NoMvc.Mvc4
{
    public class NoMvcViewLocationFormatsDefaultProvider : INoMvcViewLocationFormatsProvider
    {
        public IEnumerable<string> GetMasterLocationFormats()
        {
            return NoMvcViewLocationFormats.MasterLocationFormats;
        }

        public IEnumerable<string> GetViewLocationFormats()
        {
            return NoMvcViewLocationFormats.ViewLocationFormats;
        }

        public IEnumerable<string> GetAreaMasterLocationFormats()
        {
            return NoMvcViewLocationFormats.AreaMasterLocationFormats;
        }

        public IEnumerable<string> GetAreaViewLocationFormats()
        {
            return NoMvcViewLocationFormats.AreaViewLocationFormats;
        }

        public static class NoMvcViewLocationFormats
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