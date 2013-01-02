using System;
using Moq;
using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcControllerFactory_is_created
    {
        [Fact]
        public void It_should_use_the_specified_NoMvcControllerNameResolver()
        {
            // Arrange, Act
            var controllerFactoryFunc = new Func<INoMvcControllerNameResolver, NoMvcControllerFactory>(cnr => new NoMvcControllerFactory(cnr));
            var controllerNameResolver = new Mock<INoMvcControllerNameResolver>();

            // Act
            var controllerFactory = controllerFactoryFunc(controllerNameResolver.Object);

            // Assert
            Assert.Equal(controllerNameResolver.Object, controllerFactory.ControllerNameResolver);
        }

        [Fact]
        public void It_should_use_the_default_NoMvcControllerNameResolver_when_none_is_specified()
        {
            // Arrange
            var controllerFactoryFunc = new Func<NoMvcControllerFactory>(() => new NoMvcControllerFactory());

            // Act
            var controllerFactory = controllerFactoryFunc();

            // Assert
            Assert.IsAssignableFrom<NoMvcControllerNameDefaultResolver>(controllerFactory.ControllerNameResolver);
        }

        [Fact]
        public void It_should_use_the_default_NoMvcControllerNameResolver_when_null_is_specified()
        {
            // Arrange
            var controllerFactoryFunc = new Func<INoMvcControllerNameResolver, NoMvcControllerFactory>(cnr => new NoMvcControllerFactory(cnr));
            
            // Act
            var controllerFactory = controllerFactoryFunc(null);

            // Assert
            Assert.IsAssignableFrom<NoMvcControllerNameDefaultResolver>(controllerFactory.ControllerNameResolver);
        }
    }
}