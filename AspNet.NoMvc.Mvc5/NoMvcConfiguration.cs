using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNet.NoMvc.Mvc5
{
    public class NoMvcConfiguration
    {
        public NoMvcConfiguration()
        {
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
                {typeof (WebFormViewEngine), () => new NoMvcViewLocationFormatsProviderForWebForms()},
                {typeof (RazorViewEngine), () => new NoMvcViewLocationFormatsProviderForRazor()}
            };
        }

        public Func<ViewEngineCollection, INoMvcViewEngineCollectionExtensions> NoMvcViewEngineCollectionExtensionsFunc { get; internal set; }
        public Func<VirtualPathProviderViewEngine, INoMvcViewLocationFormatsProvider, INoMvcViewEngineExtensions> NoMvcViewEngineExtensionsFunc { get; internal set; }
        public IDictionary<Type, Func<INoMvcViewLocationFormatsProvider>> NoMvcViewLocationFormatsProvidersRegistry { get; internal set; }
        public INoMvcControllerFactory ControllerFactory { get; internal set; }
        public static NoMvcConfiguration Current { get; private set; }
        
        public void Apply()
        {
            Current = this;

            RouteTable.Routes.RouteExistingFiles = false;
            ControllerBuilder.Current.SetControllerFactory(ControllerFactory);
            ViewEngines.Engines.NoMvc().RegisterNoMvcViewLocationFormats();
        }
    }
}