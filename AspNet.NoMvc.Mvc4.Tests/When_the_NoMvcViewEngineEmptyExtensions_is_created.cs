using System;
using AspNet.NoMvc.Mvc4.Tests.TestUtils;
using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcViewEngineEmptyExtensions_is_created : NoMvcTest
    {
        [Fact]
        public void It_should_not_throw_an_exception()
        {
            // Arrange
            var viewEngineEmptyExtensionsFunc = new Func<NoMvcViewEngineEmptyExtensions>(() => new NoMvcViewEngineEmptyExtensions());

            // Act, Assert
            Assert.DoesNotThrow(() => viewEngineEmptyExtensionsFunc());
        }
    }
}