using Moq;
using Xunit;

namespace AspNet.NoMvc.Mvc3.Tests
{
    public class When_the_NoMvcControllerBuilderEmptyExtensions_is_told_to_SetNoMvcControllerBuilder
    {
        [Fact]
        public void It_should_not_throw_an_exception()
        {
            // Arrange
            var controllerBuilderExtensions = new NoMvcControllerBuilderEmptyExtensions();

            // Act, Assert
            Assert.DoesNotThrow(controllerBuilderExtensions.SetNoMvcControllerFactory);
        }

        [Fact]
        public void It_should_not_throw_an_exception2()
        {
            // Arrange
            var controllerBuilderExtensions = new NoMvcControllerBuilderEmptyExtensions();
            var controllerNameResolver = new Mock<INoMvcControllerNameResolver>();

            // Act, Assert
            Assert.DoesNotThrow(() => controllerBuilderExtensions.SetNoMvcControllerFactory(controllerNameResolver.Object));
        }
    }
}