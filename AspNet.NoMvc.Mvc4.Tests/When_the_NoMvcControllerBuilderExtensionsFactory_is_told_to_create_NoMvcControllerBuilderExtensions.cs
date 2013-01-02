using System;
using System.Web.Mvc;
using Moq;
using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcControllerBuilderExtensionsFactory_is_told_to_create_NoMvcControllerBuilderExtensions
    {
        [Fact]
        public void It_should_return_an_instance_of_NoMvcControllerBuilderExtensions_when_the_ControllerBuilder_is_specified()
        {
            // Arrange
            var controllerBuilderExtensionsFunc = new Func<ControllerBuilder, INoMvcControllerBuilderExtensions>(cb => cb.NoMvc());
            var controllerBuilder = new Mock<ControllerBuilder>();

            // Act
            var controllerBuilderExtensions = controllerBuilderExtensionsFunc(controllerBuilder.Object);

            // Assert
            Assert.IsAssignableFrom<NoMvcControllerBuilderExtensions>(controllerBuilderExtensions);
        }

        [Fact]
        public void It_should_return_an_instance_of_NoMvcControllerBuilderEmptyExtensions_when_the_ControllerBuilder_is_null()
        {
            // Arrange
            var controllerBuilderExtensionsFunc = new Func<ControllerBuilder, INoMvcControllerBuilderExtensions>(cb => cb.NoMvc());

            // Act
            var controllerBuilderExtensions = controllerBuilderExtensionsFunc(null);

            // Assert
            Assert.IsAssignableFrom<NoMvcControllerBuilderEmptyExtensions>(controllerBuilderExtensions);
        }
    }
}