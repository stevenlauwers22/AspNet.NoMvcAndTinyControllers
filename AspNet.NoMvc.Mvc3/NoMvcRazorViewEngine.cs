using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc3
{
    public class NoMvcRazorViewEngine : RazorViewEngine
    {
        public NoMvcRazorViewEngine()
        {
            this.NoMvc().RegisterNoMvcViewLocationFormats();
        }
    }
}