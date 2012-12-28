using System;
using System.Web.Mvc;
using Moq;
using Xunit;

namespace AspNet.NoMvc.Mvc3.Tests
{
    public class When_the_NoMvcControllerBuilderExtensions_is_created
    {
        [Fact]
        public void It_should_use_the_specified_ControllerBuilder()
        {
            // Arrange
            var controllerBuilderExtensionsFunc = new Func<ControllerBuilder, NoMvcControllerBuilderExtensions>(cb => new NoMvcControllerBuilderExtensions(cb));
            var controllerBuilder = new Mock<ControllerBuilder>();

            // Act
            var controllerBuilderExtensions = controllerBuilderExtensionsFunc(controllerBuilder.Object);

            // Assert
            Assert.Equal(controllerBuilder.Object, controllerBuilderExtensions.ControllerBuilder);
        }

        [Fact]
        public void Is_should_throw_an_argument_null_exception_when_no_ControllerBuilder_is_specified()
        {
            // Arrange
            var controllerBuilderExtensionsFunc = new Func<ControllerBuilder, NoMvcControllerBuilderExtensions>(cb => new NoMvcControllerBuilderExtensions(cb));

            try
            {
                // Act
                controllerBuilderExtensionsFunc(null);

                // Assert
                Assert.True(false, "Expected exception was not thrown");
            }
            catch (ArgumentNullException exception)
            {
                // Assert
                Assert.Equal("controllerBuilder", exception.ParamName);
            }
            catch (Exception)
            {
                // Assert
                Assert.True(false, "Expected exception was not thrown");
            }
        }
    }
}