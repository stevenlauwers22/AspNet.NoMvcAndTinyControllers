using System;
using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcControllerNameResolver_is_created
    {
        [Fact]
        public void Is_should_use_the_specified_pattern()
        {
            // Arrange
            var controllerNameResolverFunc = new Func<string, NoMvcControllerNameResolver>(cnp => new NoMvcControllerNameResolver(cnp));
            var controllerNamePattern = Guid.NewGuid().ToString();

            // Act
            var controllerNameResolver = controllerNameResolverFunc(controllerNamePattern);

            // Assert
            Assert.Equal(controllerNamePattern, controllerNameResolver.Pattern);
        }

        [Fact]
        public void Is_should_throw_an_argument_null_exception_when_no_pattern_is_specified()
        {
            // Arrange
            var controllerNameResolverFunc = new Action<string>(cnp => new NoMvcControllerNameResolver(cnp));

            try
            {
                // Act
                controllerNameResolverFunc(null);

                // Assert
                Assert.True(false, "Expected exception was not thrown");
            }
            catch (ArgumentNullException exception)
            {
                // Assert
                Assert.Equal("pattern", exception.ParamName);
            }
            catch (Exception)
            {
                // Assert
                Assert.True(false, "Expected exception was not thrown");
            }
        }
    }
}