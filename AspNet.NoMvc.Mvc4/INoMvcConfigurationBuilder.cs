using System;

namespace AspNet.NoMvc.Mvc4
{
    public interface INoMvcConfigurationBuilder
    {
        INoMvcConfigurationBuilder SetControllerFactory(Action<INoMvcConfigurationBuilderForControllerFactory> controllerFactoryConfiguration);
        void Apply();
    }
}