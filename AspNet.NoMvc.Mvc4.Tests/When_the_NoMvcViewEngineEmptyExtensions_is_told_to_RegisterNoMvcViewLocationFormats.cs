using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcViewEngineEmptyExtensions_is_told_to_RegisterNoMvcViewLocationFormats
    {
        [Fact]
        public void It_should_not_throw_an_exception()
        {
            // Arrange
            var viewEngineExtensions = new NoMvcViewEngineEmptyExtensions();

            // Act, Assert
            Assert.DoesNotThrow(viewEngineExtensions.RegisterNoMvcViewLocationFormats);
        }
    }
}