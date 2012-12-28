using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc2
{
    public class NoMvcWebFormViewEngine : WebFormViewEngine
    {
        public NoMvcWebFormViewEngine()
        {
            this.NoMvc().RegisterNoMvcViewLocationFormats();
        }
    }
}