using System.Linq;
using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc2
{
    public static class NoMvcViewEngineExtensionsFactory
    {
        public static INoMvcViewEngineExtensions NoMvc(this VirtualPathProviderViewEngine viewEngine)
        {
            INoMvcViewLocationFormatsProvider viewLocationFormatsProvider = null;
            if (viewEngine != null && NoMvcConfiguration.Current.NoMvcViewLocationFormatsProvidersRegistry != null)
            {
                var viewLocationFormatsProviderFunc = NoMvcConfiguration.Current.NoMvcViewLocationFormatsProvidersRegistry
                    .FirstOrDefault(kvp => kvp.Key.IsInstanceOfType(viewEngine))
                    .Value;

                if (viewLocationFormatsProviderFunc != null)
                    viewLocationFormatsProvider = viewLocationFormatsProviderFunc();
            }

            return NoMvcConfiguration.Current.NoMvcViewEngineExtensionsFunc(viewEngine, viewLocationFormatsProvider);
        }
    }
}