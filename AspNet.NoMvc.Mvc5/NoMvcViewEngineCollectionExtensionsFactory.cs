using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc5
{
    public static class NoMvcViewEngineCollectionExtensionsFactory
    {
        public static INoMvcViewEngineCollectionExtensions NoMvc(this ViewEngineCollection viewEngineCollection)
        {
            return NoMvcConfiguration.Current.NoMvcViewEngineCollectionExtensionsFunc(viewEngineCollection);
        }
    }
}