using System;

namespace AspNet.NoMvc.Mvc5
{
    public interface INoMvcConfigurationBuilder
    {
        INoMvcConfigurationBuilder SetControllerFactory(Action<INoMvcConfigurationBuilderForControllerFactory> controllerFactoryConfiguration);
        void Apply();
    }
}