using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc3
{
    public class NoMvcWebFormViewEngine : WebFormViewEngine
    {
        public NoMvcWebFormViewEngine()
        {
            this.NoMvc().RegisterNoMvcViewLocationFormats();
        }
    }
}