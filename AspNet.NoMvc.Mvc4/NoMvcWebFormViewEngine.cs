using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc4
{
    public class NoMvcWebFormViewEngine : WebFormViewEngine
    {
        public NoMvcWebFormViewEngine()
        {
            this.NoMvc().RegisterNoMvcViewLocationFormats();
        }
    }
}