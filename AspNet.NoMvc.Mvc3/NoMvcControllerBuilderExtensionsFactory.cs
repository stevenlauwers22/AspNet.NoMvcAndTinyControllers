using System;
using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc3
{
    public static class NoMvcControllerBuilderExtensionsFactory
    {
        internal static Func<ControllerBuilder, INoMvcControllerBuilderExtensions> CreateNoMvcControllerBuilderExtensions = controllerBuilder =>
        {
            if (controllerBuilder == null)
                return new NoMvcControllerBuilderEmptyExtensions();

            return new NoMvcControllerBuilderExtensions(controllerBuilder);
        };

        public static INoMvcControllerBuilderExtensions NoMvc(this ControllerBuilder controllerBuilder)
        {
            return CreateNoMvcControllerBuilderExtensions(controllerBuilder);
        }
    }
}