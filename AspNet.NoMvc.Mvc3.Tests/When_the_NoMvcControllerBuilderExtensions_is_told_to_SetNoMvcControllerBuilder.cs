using System.Web.Mvc;
using Moq;
using Xunit;

namespace AspNet.NoMvc.Mvc3.Tests
{
    public class When_the_NoMvcControllerBuilderExtensions_is_told_to_SetNoMvcControllerBuilder
    {
        [Fact]
        public void It_should_set_the_current_ControllerFactory_to_an_instance_of_NoMvcControllerFactory()
        {
            // Arrange
            var controllerBuilder = ControllerBuilder.Current;
            var controllerBuilderExtensions = new NoMvcControllerBuilderExtensions(controllerBuilder);

            // Act
            controllerBuilderExtensions.SetNoMvcControllerFactory();

            // Assert
            var controllerFactory = controllerBuilder.GetControllerFactory();
            Assert.IsAssignableFrom<NoMvcControllerFactory>(controllerFactory);
        }

        [Fact]
        public void It_should_set_the_current_ControllerFactory_to_an_instance_of_NoMvcControllerFactory_with_the_specified_NoMvcControllerNameResolver()
        {
            // Arrange
            var controllerBuilder = ControllerBuilder.Current;
            var controllerBuilderExtensions = new NoMvcControllerBuilderExtensions(controllerBuilder);
            var controllerNameResolver = new Mock<INoMvcControllerNameResolver>();

            // Act
            controllerBuilderExtensions.SetNoMvcControllerFactory(controllerNameResolver.Object);

            // Assert
            var controllerFactory = controllerBuilder.GetControllerFactory();
            Assert.IsAssignableFrom<NoMvcControllerFactory>(controllerFactory);

            var controllerFactoryNoMvc = ((NoMvcControllerFactory)controllerFactory);
            Assert.Equal(controllerNameResolver.Object, controllerFactoryNoMvc.ControllerNameResolver);
        }
    }
}