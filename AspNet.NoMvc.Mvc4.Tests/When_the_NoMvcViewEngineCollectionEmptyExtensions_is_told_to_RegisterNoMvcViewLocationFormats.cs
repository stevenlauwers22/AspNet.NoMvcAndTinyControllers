using AspNet.NoMvc.Mvc4.Tests.TestUtils;
using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcViewEngineCollectionEmptyExtensions_is_told_to_RegisterNoMvcViewLocationFormats : NoMvcTest
    {
        [Fact]
        public void It_should_not_throw_an_exception()
        {
            // Arrange
            var viewEngineCollectionExtensions = new NoMvcViewEngineCollectionEmptyExtensions();

            // Act, Assert
            Assert.DoesNotThrow(viewEngineCollectionExtensions.RegisterNoMvcViewLocationFormats);
        }
    }
}