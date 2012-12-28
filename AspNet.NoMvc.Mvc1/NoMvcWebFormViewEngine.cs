using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc1
{
    public class NoMvcWebFormViewEngine : WebFormViewEngine
    {
        public NoMvcWebFormViewEngine()
        {
            this.NoMvc().RegisterNoMvcViewLocationFormats();
        }
    }
}