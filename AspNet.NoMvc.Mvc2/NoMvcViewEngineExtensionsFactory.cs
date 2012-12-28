using System;
using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc2
{
    public static class NoMvcViewEngineExtensionsFactory
    {
        internal static Func<VirtualPathProviderViewEngine, INoMvcViewEngineExtensions> CreateNoMvcViewEngineExtensions = viewEngine =>
        {
            if (viewEngine == null)
                return new NoMvcViewEngineEmptyExtensions();

            return new NoMvcViewEngineExtensions(viewEngine);
        };

        public static INoMvcViewEngineExtensions NoMvc(this VirtualPathProviderViewEngine viewEngine)
        {
            return CreateNoMvcViewEngineExtensions(viewEngine);
        }
    }
}