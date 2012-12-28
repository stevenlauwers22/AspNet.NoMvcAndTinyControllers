using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc4
{
    public class NoMvcRazorViewEngine : RazorViewEngine
    {
        public NoMvcRazorViewEngine()
        {
            this.NoMvc().RegisterNoMvcViewLocationFormats();
        }
    }
}