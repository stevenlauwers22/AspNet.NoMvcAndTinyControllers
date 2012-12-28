using System;
using System.Web.Mvc;
using Moq;
using Xunit;

namespace AspNet.NoMvc.Mvc3.Tests
{
    public class When_the_NoMvcViewEngineExtensions_is_created
    {
        [Fact]
        public void It_should_use_the_specified_ViewEngine_and_NoMvcViewLocationFormatsProvider()
        {
            // Arrange
            var viewEngineExtensionsFunc = new Func<VirtualPathProviderViewEngine, INoMvcViewLocationFormatsProvider, NoMvcViewEngineExtensions>((ve, vlfp) => new NoMvcViewEngineExtensions(ve, vlfp));
            var viewEngine = new Mock<VirtualPathProviderViewEngine>();
            var viewLocationFormatsProvider = new Mock<INoMvcViewLocationFormatsProvider>();

            // Act
            var viewEngineExtensions = viewEngineExtensionsFunc(viewEngine.Object, viewLocationFormatsProvider.Object);

            // Assert
            Assert.Equal(viewEngine.Object, viewEngineExtensions.ViewEngine);
            Assert.Equal(viewLocationFormatsProvider.Object, viewEngineExtensions.ViewLocationFormatsProvider);
        }

        [Fact]
        public void It_should_use_the_specified_ViewEngine_and_the_default_NoMvcViewLocationFormatsProvider_if_none_is_specified()
        {
            // Arrange
            var viewEngineExtensionsFunc = new Func<VirtualPathProviderViewEngine, NoMvcViewEngineExtensions>(ve => new NoMvcViewEngineExtensions(ve));
            var viewEngine = new Mock<VirtualPathProviderViewEngine>();

            // Act
            var viewEngineExtensions = viewEngineExtensionsFunc(viewEngine.Object);

            // Assert
            Assert.Equal(viewEngine.Object, viewEngineExtensions.ViewEngine);
            Assert.IsAssignableFrom<NoMvcViewLocationFormatsDefaultProvider>(viewEngineExtensions.ViewLocationFormatsProvider);
        }

        [Fact]
        public void It_should_use_the_specified_ViewEngine_and_the_default_NoMvcViewLocationFormatsProvider_if_null_is_specified()
        {
            // Arrange
            var viewEngineExtensionsFunc = new Func<VirtualPathProviderViewEngine, INoMvcViewLocationFormatsProvider, NoMvcViewEngineExtensions>((ve, vlfp) => new NoMvcViewEngineExtensions(ve, vlfp));
            var viewEngine = new Mock<VirtualPathProviderViewEngine>();

            // Act
            var viewEngineExtensions = viewEngineExtensionsFunc(viewEngine.Object, null);

            // Assert
            Assert.Equal(viewEngine.Object, viewEngineExtensions.ViewEngine);
            Assert.IsAssignableFrom<NoMvcViewLocationFormatsDefaultProvider>(viewEngineExtensions.ViewLocationFormatsProvider);
        }

        [Fact]
        public void Is_should_throw_an_argument_null_exception_when_no_ViewEngine_is_specified()
        {
            // Arrange
            var viewEngineExtensionsFunc = new Func<VirtualPathProviderViewEngine, NoMvcViewEngineExtensions>(ve => new NoMvcViewEngineExtensions(ve));
            
            try
            {
                // Act
                viewEngineExtensionsFunc(null);

                // Assert
                Assert.True(false, "Expected exception was not thrown");
            }
            catch (ArgumentNullException exception)
            {
                // Assert
                Assert.Equal("viewEngine", exception.ParamName);
            }
            catch (Exception)
            {
                // Assert
                Assert.True(false, "Expected exception was not thrown");
            }
        }
    }
}