using System;

namespace AspNet.NoMvc.Mvc1
{
    public interface INoMvcConfigurationBuilder
    {
        INoMvcConfigurationBuilder SetControllerFactory(Action<INoMvcConfigurationBuilderForControllerFactory> controllerFactoryConfiguration);
        void Apply();
    }
}