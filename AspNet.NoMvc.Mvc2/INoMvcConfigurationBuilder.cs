using System;

namespace AspNet.NoMvc.Mvc2
{
    public interface INoMvcConfigurationBuilder
    {
        INoMvcConfigurationBuilder SetControllerFactory(Action<INoMvcConfigurationBuilderForControllerFactory> controllerFactoryConfiguration);
        void Apply();
    }
}