using System;
using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcControllerBuilderEmptyExtensions_is_created
    {
        [Fact]
        public void It_should_not_throw_an_exception()
        {
            // Arrange
            var controllerBuilderEmptyExtensionsFunc = new Func<NoMvcControllerBuilderEmptyExtensions>(() => new NoMvcControllerBuilderEmptyExtensions());

            // Act, Assert
            Assert.DoesNotThrow(() => controllerBuilderEmptyExtensionsFunc());
        }
    }
}