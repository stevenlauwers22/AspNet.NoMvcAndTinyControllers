using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNet.NoMvc.Mvc1
{
    public class NoMvcConfiguration
    {
        private static NoMvcConfiguration _configuration;

        public static NoMvcConfiguration Current { 
            get
            {
                if (_configuration == null)
                    throw new NoMvcConfigurationNotSetException();

                return _configuration;
            }
            internal set
            {
                if (value == null)
                    throw new NoMvcConfigurationNotSetException();

                if (!value.IsValid)
                    throw new NoMvcConfigurationNotValidException();

                _configuration = value;
            }
        }

        public bool IsValid
        {
            get
            {
                if (NoMvcControllerBuilderExtensionsFunc == null)
                    return false;
                if (NoMvcViewEngineCollectionExtensionsFunc == null)
                    return false;
                if (NoMvcViewEngineExtensionsFunc == null)
                    return false;

                return true;
            }
        }

        public void Apply()
        {
            Current = this;

            RouteTable.Routes.RouteExistingFiles = false;
            ControllerBuilder.Current.NoMvc().SetNoMvcControllerFactory(new NoMvcControllerNameUnderscoreResolver());
            ViewEngines.Engines.NoMvc().RegisterNoMvcViewLocationFormats();
        }

        public Func<ControllerBuilder, INoMvcControllerBuilderExtensions> NoMvcControllerBuilderExtensionsFunc { get; internal set; }
        public Func<ViewEngineCollection, INoMvcViewEngineCollectionExtensions> NoMvcViewEngineCollectionExtensionsFunc { get; internal set; }
        public Func<VirtualPathProviderViewEngine, INoMvcViewLocationFormatsProvider, INoMvcViewEngineExtensions> NoMvcViewEngineExtensionsFunc { get; internal set; }
        public IDictionary<Type, Func<INoMvcViewLocationFormatsProvider>> NoMvcViewLocationFormatsProvidersRegistry { get; internal set; }
    }
}