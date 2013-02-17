using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc1
{
    public class NoMvcConfigurationWithDefaults : NoMvcConfiguration
    {
        public NoMvcConfigurationWithDefaults()
        {
            NoMvcControllerBuilderExtensionsFunc = controllerBuilder =>
            {
                if (controllerBuilder == null)
                    return new NoMvcControllerBuilderEmptyExtensions();

                return new NoMvcControllerBuilderExtensions(controllerBuilder);
            };

            NoMvcViewEngineCollectionExtensionsFunc = viewEngineCollection =>
            {
                if (viewEngineCollection == null)
                    return new NoMvcViewEngineCollectionEmptyExtensions();

                return new NoMvcViewEngineCollectionExtensions(viewEngineCollection);
            };

            NoMvcViewEngineExtensionsFunc = (viewEngine, viewLocationFormatsProvider) =>
            {
                if (viewEngine == null)
                    return new NoMvcViewEngineEmptyExtensions();

                if (viewLocationFormatsProvider == null)
                    return new NoMvcViewEngineEmptyExtensions();

                return new NoMvcViewEngineExtensions(viewEngine, viewLocationFormatsProvider);
            };

            NoMvcViewLocationFormatsProvidersRegistry = new Dictionary<Type, Func<INoMvcViewLocationFormatsProvider>>
            {
                {typeof(WebFormViewEngine), () => new NoMvcWebFormViewLocationFormatsProvider()}
            };
        }
    }
}