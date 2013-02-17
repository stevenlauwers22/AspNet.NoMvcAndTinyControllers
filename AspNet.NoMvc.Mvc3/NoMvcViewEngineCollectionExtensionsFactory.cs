using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc3
{
    public static class NoMvcViewEngineCollectionExtensionsFactory
    {
        public static INoMvcViewEngineCollectionExtensions NoMvc(this ViewEngineCollection viewEngineCollection)
        {
            return NoMvcConfiguration.Current.NoMvcViewEngineCollectionExtensionsFunc(viewEngineCollection);
        }
    }
}