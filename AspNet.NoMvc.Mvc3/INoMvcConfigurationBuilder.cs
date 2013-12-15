using System;

namespace AspNet.NoMvc.Mvc3
{
    public interface INoMvcConfigurationBuilder
    {
        INoMvcConfigurationBuilder SetControllerFactory(Action<INoMvcConfigurationBuilderForControllerFactory> controllerFactoryConfiguration);
        void Apply();
    }
}