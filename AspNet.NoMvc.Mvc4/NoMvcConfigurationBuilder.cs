using System;

namespace AspNet.NoMvc.Mvc4
{
    public class NoMvcConfigurationBuilder : INoMvcConfigurationBuilder
    {
        private readonly NoMvcConfiguration _configuration;

        public NoMvcConfigurationBuilder()
        {
            _configuration = new NoMvcConfiguration();
        }

        public INoMvcConfigurationBuilder SetControllerFactory(Action<INoMvcConfigurationBuilderForControllerFactory> controllerFactoryConfiguration)
        {
            var controllerFactoryBuilder = new NoMvcConfigurationBuilderForControllerFactory();
            controllerFactoryConfiguration(controllerFactoryBuilder);

            var controllerFactory = controllerFactoryBuilder.GetResult();
            _configuration.ControllerFactory = controllerFactory;

            return this;
        }

        public void Apply()
        {
            _configuration.Apply();
        }
    }
}