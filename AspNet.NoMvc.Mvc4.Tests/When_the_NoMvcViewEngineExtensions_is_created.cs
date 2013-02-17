using System;
using System.Web.Mvc;
using AspNet.NoMvc.Mvc4.Tests.TestUtils;
using Moq;
using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcViewEngineExtensions_is_created : NoMvcTest
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
        public void Is_should_throw_an_argument_null_exception_when_no_ViewEngine_is_specified()
        {
            // Arrange
            var viewEngineExtensionsFunc = new Func<VirtualPathProviderViewEngine, INoMvcViewLocationFormatsProvider, NoMvcViewEngineExtensions>((ve, vlfp) => new NoMvcViewEngineExtensions(ve, vlfp));
            var viewLocationFormatsProvider = new Mock<INoMvcViewLocationFormatsProvider>();

            try
            {
                // Act
                viewEngineExtensionsFunc(null, viewLocationFormatsProvider.Object);

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

        [Fact]
        public void Is_should_throw_an_argument_null_exception_when_no_ViewLocationFormatsProvider_is_specified()
        {
            // Arrange
            var viewEngineExtensionsFunc = new Func<VirtualPathProviderViewEngine, INoMvcViewLocationFormatsProvider, NoMvcViewEngineExtensions>((ve, vlfp) => new NoMvcViewEngineExtensions(ve, vlfp));
            var viewEngine = new Mock<VirtualPathProviderViewEngine>();

            try
            {
                // Act
                viewEngineExtensionsFunc(viewEngine.Object, null);

                // Assert
                Assert.True(false, "Expected exception was not thrown");
            }
            catch (ArgumentNullException exception)
            {
                // Assert
                Assert.Equal("viewLocationFormatsProvider", exception.ParamName);
            }
            catch (Exception)
            {
                // Assert
                Assert.True(false, "Expected exception was not thrown");
            }
        }
    }
}