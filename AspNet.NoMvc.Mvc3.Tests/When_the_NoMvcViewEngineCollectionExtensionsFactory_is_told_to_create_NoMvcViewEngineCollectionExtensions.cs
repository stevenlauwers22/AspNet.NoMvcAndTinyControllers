using System;
using System.Web.Mvc;
using Moq;
using Xunit;

namespace AspNet.NoMvc.Mvc3.Tests
{
    public class When_the_NoMvcViewEngineCollectionExtensionsFactory_is_told_to_create_NoMvcViewEngineCollectionExtensions
    {
        [Fact]
        public void It_should_return_a_instance_of_NoMvcViewEngineCollectionExtensions_when_the_ViewEngineCollection_is_specified()
        {
            // Arrange
            var viewEngineCollectionExtensionsFunc = new Func<ViewEngineCollection, INoMvcViewEngineCollectionExtensions>(vec => vec.NoMvc());
            var viewEngineCollection = new Mock<ViewEngineCollection>();

            // Act
            var viewEngineCollectionExtensions = viewEngineCollectionExtensionsFunc(viewEngineCollection.Object);

            // Assert
            Assert.IsAssignableFrom<NoMvcViewEngineCollectionExtensions>(viewEngineCollectionExtensions);
        }

        [Fact]
        public void It_should_return_a_instance_of_NoMvcViewEngineCollectionExtensions_when_the_ViewEngineCollection_is_null()
        {
            // Arrange
            var viewEngineCollectionExtensionsFunc = new Func<ViewEngineCollection, INoMvcViewEngineCollectionExtensions>(vec => vec.NoMvc());

            // Act
            var viewEngineCollectionExtensions = viewEngineCollectionExtensionsFunc(null);

            // Assert
            Assert.IsAssignableFrom<NoMvcViewEngineCollectionEmptyExtensions>(viewEngineCollectionExtensions);
        }
    }
}