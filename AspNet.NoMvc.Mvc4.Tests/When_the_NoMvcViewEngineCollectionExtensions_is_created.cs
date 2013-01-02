using System;
using System.Web.Mvc;
using Moq;
using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcViewEngineCollectionExtensions_is_created
    {
        [Fact]
        public void It_should_use_the_specified_ViewEngineCollection()
        {
            // Arrange
            var viewEngineCollectionExtensionsFunc = new Func<ViewEngineCollection, NoMvcViewEngineCollectionExtensions>(vec => new NoMvcViewEngineCollectionExtensions(vec));
            var viewEngineCollection = new Mock<ViewEngineCollection>();

            // Act
            var viewEngineCollectionExtensions = viewEngineCollectionExtensionsFunc(viewEngineCollection.Object);

            // Assert
            Assert.Equal(viewEngineCollection.Object, viewEngineCollectionExtensions.ViewEngineCollection);
        }

        [Fact]
        public void Is_should_throw_an_argument_null_exception_when_no_ViewEngineCollection_is_specified()
        {
            // Arrange
            var viewEngineCollectionExtensionsFunc = new Func<ViewEngineCollection, NoMvcViewEngineCollectionExtensions>(vec => new NoMvcViewEngineCollectionExtensions(vec));
            
            try
            {
                // Act
                viewEngineCollectionExtensionsFunc(null);

                // Assert
                Assert.True(false, "Expected exception was not thrown");
            }
            catch (ArgumentNullException exception)
            {
                // Assert
                Assert.Equal("viewEngineCollection", exception.ParamName);
            }
            catch (Exception)
            {
                // Assert
                Assert.True(false, "Expected exception was not thrown");
            }
        }
    }
}