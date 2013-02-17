using System;
using System.Web.Mvc;
using AspNet.NoMvc.Mvc4.Tests.TestUtils;
using Moq;
using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcViewEngineCollectionExtensions_is_told_to_RegisterNoMvcViewLocationFormats : NoMvcTest
    {
        [Fact]
        public void It_should_register_the_NoMvc_view_location_formats_for_all_ViewEngines_that_have_the_VirtualPathProviderViewEngine_as_base_class()
        {
            // Arrange
            var viewEngine1 = new Mock<IViewEngine>();
            var viewEngine2 = new Mock<WebFormViewEngine>();
            var viewEngine3 = new Mock<RazorViewEngine>();
            var viewEngineCollection = ViewEngines.Engines;
            viewEngineCollection.Clear();
            viewEngineCollection.Add(viewEngine1.Object);
            viewEngineCollection.Add(viewEngine2.Object);
            viewEngineCollection.Add(viewEngine3.Object);

            var viewEngine1Extensions = new Mock<INoMvcViewEngineExtensions>();
            var viewEngine2Extensions = new Mock<INoMvcViewEngineExtensions>();
            var viewEngine3Extensions = new Mock<INoMvcViewEngineExtensions>();
            NoMvcConfiguration.Current.NoMvcViewEngineExtensionsFunc = (ve, vlfp) =>
            {
                if (ve == viewEngine1.Object)
                    return viewEngine1Extensions.Object;

                if (ve == viewEngine2.Object)
                    return viewEngine2Extensions.Object;

                if (ve == viewEngine3.Object)
                    return viewEngine3Extensions.Object;

                throw new InvalidOperationException();
            };

            var viewEngineCollectionExtensions = new NoMvcViewEngineCollectionExtensions(viewEngineCollection);

            // Act
            viewEngineCollectionExtensions.RegisterNoMvcViewLocationFormats();

            // Assert
            viewEngine1Extensions.Verify(ext => ext.RegisterNoMvcViewLocationFormats(), Times.Never());
            viewEngine2Extensions.Verify(ext => ext.RegisterNoMvcViewLocationFormats());
            viewEngine3Extensions.Verify(ext => ext.RegisterNoMvcViewLocationFormats());
        }
    }
}