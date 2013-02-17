using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc3
{
    public static class NoMvcControllerBuilderExtensionsFactory
    {
        public static INoMvcControllerBuilderExtensions NoMvc(this ControllerBuilder controllerBuilder)
        {
            return NoMvcConfiguration.Current.NoMvcControllerBuilderExtensionsFunc(controllerBuilder);
        }
    }
}