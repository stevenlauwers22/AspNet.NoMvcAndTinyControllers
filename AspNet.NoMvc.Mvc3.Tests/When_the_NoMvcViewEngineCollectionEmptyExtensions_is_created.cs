using System;
using Xunit;

namespace AspNet.NoMvc.Mvc3.Tests
{
    public class When_the_NoMvcViewEngineCollectionEmptyExtensions_is_created
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