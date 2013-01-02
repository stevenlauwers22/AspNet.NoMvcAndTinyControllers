using System;
using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcControllerNameDefaultResolver_is_created
    {
        [Fact]
        public void Is_should_use_the_default_pattern()
        {
            // Arrange
            var controllerNameDefaultResolverFunc = new Func<NoMvcControllerNameDefaultResolver>(() => new NoMvcControllerNameDefaultResolver());

            // Act
            var controllerNameResolver = controllerNameDefaultResolverFunc();

            // Assert
            Assert.Equal("{0}", controllerNameResolver.Pattern);
        }
    }
}