using System;
using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc2
{
    public static class NoMvcViewEngineCollectionExtensionsFactory
    {
        internal static Func<ViewEngineCollection, INoMvcViewEngineCollectionExtensions> CreateNoMvcViewEngineCollectionExtensions = viewEngineCollection =>
        {
            if (viewEngineCollection == null)
                return new NoMvcViewEngineCollectionEmptyExtensions();

            return new NoMvcViewEngineCollectionExtensions(viewEngineCollection);
        };

        public static INoMvcViewEngineCollectionExtensions NoMvc(this ViewEngineCollection viewEngineCollection)
        {
            return CreateNoMvcViewEngineCollectionExtensions(viewEngineCollection);
        }
    }
}