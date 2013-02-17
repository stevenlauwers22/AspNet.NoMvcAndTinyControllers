using System;
using AspNet.NoMvc.Mvc4.Tests.TestUtils;
using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcViewEngineCollectionEmptyExtensions_is_created : NoMvcTest
    {
        [Fact]
        public void It_should_not_throw_an_exception()
        {
            // Arrange
            var viewEngineCollectionEmptyExtensionsFunc = new Func<NoMvcViewEngineCollectionEmptyExtensions>(() => new NoMvcViewEngineCollectionEmptyExtensions());

            // Act, Assert
            Assert.DoesNotThrow(() => viewEngineCollectionEmptyExtensionsFunc());
        }
    }
}