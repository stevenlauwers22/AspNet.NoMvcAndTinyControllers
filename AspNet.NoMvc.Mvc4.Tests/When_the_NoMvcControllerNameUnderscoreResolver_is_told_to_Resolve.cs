using System;
using AspNet.NoMvc.Mvc4.Tests.TestUtils;
using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcControllerNameUnderscoreResolver_is_told_to_Resolve : NoMvcTest
    {
        [Fact]
        public void It_should_return_null_when_resolving_null()
        {
            // Arrange
            var controllerNameResolver = new NoMvcControllerNameUnderscoreResolver();

            // Act
            var result = controllerNameResolver.Resolve(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void It_should_return_null_when_resolving_an_empty_string()
        {
            // Arrange
            var controllerNameResolver = new NoMvcControllerNameUnderscoreResolver();

            // Act
            var result = controllerNameResolver.Resolve(string.Empty);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void It_should_return_the_resolved_controller_name()
        {
            // Arrange
            var controllerNameResolver = new NoMvcControllerNameUnderscoreResolver();
            var controllerName = Guid.NewGuid().ToString();

            // Act
            var result = controllerNameResolver.Resolve(controllerName);

            // Assert
            Assert.Equal("_", result);
        }
    }
}