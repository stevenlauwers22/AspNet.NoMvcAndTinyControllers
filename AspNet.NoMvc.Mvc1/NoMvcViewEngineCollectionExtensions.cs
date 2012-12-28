using System;
using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc1
{
    public class NoMvcViewEngineCollectionExtensions : INoMvcViewEngineCollectionExtensions
    {
        private readonly ViewEngineCollection _viewEngineCollection;

        public NoMvcViewEngineCollectionExtensions(ViewEngineCollection viewEngineCollection)
        {
            if (viewEngineCollection == null)
                throw new ArgumentNullException("viewEngineCollection");

            _viewEngineCollection = viewEngineCollection;
        }

        public ViewEngineCollection ViewEngineCollection
        {
            get { return _viewEngineCollection; }
        }

        public void RegisterNoMvcViewLocationFormats()
        {
            foreach (var viewEngine in _viewEngineCollection)
            {
                var virtualPathProviderViewEngine = viewEngine as VirtualPathProviderViewEngine;
                if (virtualPathProviderViewEngine != null)
                {
                    virtualPathProviderViewEngine.NoMvc().RegisterNoMvcViewLocationFormats();
                }
            }
        }
    }
}