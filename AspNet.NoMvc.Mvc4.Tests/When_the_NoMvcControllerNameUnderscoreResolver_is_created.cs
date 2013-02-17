using System;
using AspNet.NoMvc.Mvc4.Tests.TestUtils;
using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcControllerNameUnderscoreResolver_is_created : NoMvcTest
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