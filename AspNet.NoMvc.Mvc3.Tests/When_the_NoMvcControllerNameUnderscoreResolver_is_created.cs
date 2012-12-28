using System;
using Xunit;

namespace AspNet.NoMvc.Mvc3.Tests
{
    public class When_the_NoMvcControllerNameUnderscoreResolver_is_created
    {
        [Fact]
        public void Is_should_use_the_underscore_pattern()
        {
            // Arrange
            var controllerNameUnderscoreResolverFunc = new Func<NoMvcControllerNameUnderscoreResolver>(() => new NoMvcControllerNameUnderscoreResolver());

            // Act
            var controllerNameResolver = controllerNameUnderscoreResolverFunc();

            // Assert
            Assert.Equal("_", controllerNameResolver.Pattern);
        }
    }
}