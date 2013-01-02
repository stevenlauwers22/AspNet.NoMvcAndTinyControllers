using System;
using System.Web.Mvc;
using Moq;
using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcViewEngineExtensionsFactory_is_told_to_create_NoMvcViewEngineExtensions
    {
        [Fact]
        public void It_should_return_a_instance_of_NoMvcViewEngineExtensions_when_the_ViewEngine_is_specified()
        {
            // Arrange
            var viewEngineExtensionsFunc = new Func<VirtualPathProviderViewEngine, INoMvcViewEngineExtensions>(ve => ve.NoMvc());
            var viewEngine = new Mock<VirtualPathProviderViewEngine>();

            // Act
            var viewEngineExtensions = viewEngineExtensionsFunc(viewEngine.Object);

            // Assert
            Assert.IsAssignableFrom<NoMvcViewEngineExtensions>(viewEngineExtensions);
        }

        [Fact]
        public void It_should_return_a_instance_of_NoMvcViewEngineExtensions_when_the_ViewEngine_is_null()
        {
            // Arrange
            var viewEngineExtensionsFunc = new Func<VirtualPathProviderViewEngine, INoMvcViewEngineExtensions>(ve => ve.NoMvc());

            // Act
            var viewEngineExtensions = viewEngineExtensionsFunc(null);

            // Assert
            Assert.IsAssignableFrom<NoMvcViewEngineEmptyExtensions>(viewEngineExtensions);
        }
    }
}