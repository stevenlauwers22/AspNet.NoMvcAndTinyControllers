using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AspNet.NoMvc.Mvc4.Tests.TestUtils;
using Moq;
using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcViewEngineExtensions_is_told_to_RegisterNoMvcViewLocationFormats : NoMvcTest
    {
        [Fact]
        public void It_should_combine_the_NoMvc_view_location_formats_with_the_standard_view_location_formats_into_a_unique_list()
        {
            // Arrange
            var viewEngine = new Mock<VirtualPathProviderViewEngine>();
            var viewLocationFormatsProvider = new Mock<INoMvcViewLocationFormatsProvider>();

            var viewLocationFormat1Existing = Guid.NewGuid().ToString();
            var viewLocationFormat2Existing = Guid.NewGuid().ToString();
            var viewLocationFormat1 = Guid.NewGuid().ToString();
            var viewLocationFormat2 = Guid.NewGuid().ToString();

            var viewLocationFormatsMasterPagesExisting = new List<string> { viewLocationFormat1Existing, viewLocationFormat2Existing, viewLocationFormat2Existing };
            viewEngine.Object.MasterLocationFormats = viewLocationFormatsMasterPagesExisting.ToArray();

            var viewLocationFormatsViewPagesExisting = new List<string> { viewLocationFormat1Existing, viewLocationFormat2Existing, viewLocationFormat2Existing };
            viewEngine.Object.ViewLocationFormats = viewLocationFormatsViewPagesExisting.ToArray();

            var viewLocationFormatsAreaMasterPagesExisting = new List<string> { viewLocationFormat1Existing, viewLocationFormat2Existing, viewLocationFormat2Existing };
            viewEngine.Object.AreaMasterLocationFormats = viewLocationFormatsAreaMasterPagesExisting.ToArray();

            var viewLocationFormatsAreaViewPagesExisting = new List<string> { viewLocationFormat1Existing, viewLocationFormat2Existing, viewLocationFormat2Existing };
            viewEngine.Object.AreaViewLocationFormats = viewLocationFormatsAreaViewPagesExisting.ToArray();

            var viewLocationFormatsMasterPages = new List<string> { viewLocationFormat1, viewLocationFormat1Existing, viewLocationFormat2, viewLocationFormat1 };
            viewLocationFormatsProvider
                .Setup(vlfp => vlfp.GetMasterLocationFormats())
                .Returns(viewLocationFormatsMasterPages.ToArray());

            var viewLocationFormatsViewPages = new List<string> { viewLocationFormat1, viewLocationFormat1Existing, viewLocationFormat2, viewLocationFormat1 };
            viewLocationFormatsProvider
                .Setup(vlfp => vlfp.GetViewLocationFormats())
                .Returns(viewLocationFormatsViewPages.ToArray());

            var viewLocationFormatsAreaMasterPages = new List<string> { viewLocationFormat1, viewLocationFormat1Existing, viewLocationFormat2, viewLocationFormat1 };
            viewLocationFormatsProvider
                .Setup(vlfp => vlfp.GetAreaMasterLocationFormats())
                .Returns(viewLocationFormatsAreaMasterPages.ToArray());

            var viewLocationFormatsAreaViewPages = new List<string> { viewLocationFormat1, viewLocationFormat1Existing, viewLocationFormat2, viewLocationFormat1 };
            viewLocationFormatsProvider
                .Setup(vlfp => vlfp.GetAreaViewLocationFormats())
                .Returns(viewLocationFormatsAreaViewPages.ToArray());

            var viewEngineExtensions = new NoMvcViewEngineExtensions(viewEngine.Object, viewLocationFormatsProvider.Object);

            // Act
            viewEngineExtensions.RegisterNoMvcViewLocationFormats();

            // Assert
            viewLocationFormatsProvider.Verify(vlfp => vlfp.GetMasterLocationFormats());
            Assert.True(viewEngine.Object.MasterLocationFormats.Length == 4);
            Assert.True(viewEngine.Object.MasterLocationFormats.ElementAt(0).Equals(viewLocationFormat1));
            Assert.True(viewEngine.Object.MasterLocationFormats.ElementAt(1).Equals(viewLocationFormat1Existing));
            Assert.True(viewEngine.Object.MasterLocationFormats.ElementAt(2).Equals(viewLocationFormat2));
            Assert.True(viewEngine.Object.MasterLocationFormats.ElementAt(3).Equals(viewLocationFormat2Existing));

            viewLocationFormatsProvider.Verify(vlfp => vlfp.GetViewLocationFormats());
            Assert.True(viewEngine.Object.ViewLocationFormats.Length == 4);
            Assert.True(viewEngine.Object.ViewLocationFormats.ElementAt(0).Equals(viewLocationFormat1));
            Assert.True(viewEngine.Object.ViewLocationFormats.ElementAt(1).Equals(viewLocationFormat1Existing));
            Assert.True(viewEngine.Object.ViewLocationFormats.ElementAt(2).Equals(viewLocationFormat2));
            Assert.True(viewEngine.Object.ViewLocationFormats.ElementAt(3).Equals(viewLocationFormat2Existing));

            viewLocationFormatsProvider.Verify(vlfp => vlfp.GetAreaMasterLocationFormats());
            Assert.True(viewEngine.Object.AreaMasterLocationFormats.Length == 4);
            Assert.True(viewEngine.Object.AreaMasterLocationFormats.ElementAt(0).Equals(viewLocationFormat1));
            Assert.True(viewEngine.Object.AreaMasterLocationFormats.ElementAt(1).Equals(viewLocationFormat1Existing));
            Assert.True(viewEngine.Object.AreaMasterLocationFormats.ElementAt(2).Equals(viewLocationFormat2));
            Assert.True(viewEngine.Object.AreaMasterLocationFormats.ElementAt(3).Equals(viewLocationFormat2Existing));

            viewLocationFormatsProvider.Verify(vlfp => vlfp.GetAreaViewLocationFormats());
            Assert.True(viewEngine.Object.AreaViewLocationFormats.Length == 4);
            Assert.True(viewEngine.Object.AreaViewLocationFormats.ElementAt(0).Equals(viewLocationFormat1));
            Assert.True(viewEngine.Object.AreaViewLocationFormats.ElementAt(1).Equals(viewLocationFormat1Existing));
            Assert.True(viewEngine.Object.AreaViewLocationFormats.ElementAt(2).Equals(viewLocationFormat2));
            Assert.True(viewEngine.Object.AreaViewLocationFormats.ElementAt(3).Equals(viewLocationFormat2Existing));
        }
    }
}