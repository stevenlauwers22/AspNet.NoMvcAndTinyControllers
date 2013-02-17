using System;
using System.Reflection;
using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc4.Tests.TestHacks
{
    public static class DefaultControllerFactoryExtensions
    {
        public static void SetBuildManager(this DefaultControllerFactory controllerFactory, BuildManager buildManager)
        {
            controllerFactory
                .GetType()
                .GetProperty("BuildManager", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(controllerFactory, buildManager, null);
        }

        public static void SetControllerTypeCache(this DefaultControllerFactory controllerFactory)
        {
            var mvcAssembly = Assembly.GetAssembly(typeof(Controller));
            var controllerTypeCacheType = mvcAssembly.GetType("System.Web.Mvc.ControllerTypeCache", true);
            var controllerTypeCache = Activator.CreateInstance(controllerTypeCacheType);
            controllerFactory
                .GetType()
                .GetProperty("ControllerTypeCache", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(controllerFactory, controllerTypeCache, null);
        }
    }
}