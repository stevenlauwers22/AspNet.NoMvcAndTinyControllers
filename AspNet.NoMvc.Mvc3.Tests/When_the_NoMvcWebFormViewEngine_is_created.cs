﻿using System;
using Moq;
using Xunit;

namespace AspNet.NoMvc.Mvc3.Tests
{
    public class When_the_NoMvcWebFormViewEngine_is_created
    {
        [Fact]
        public void Is_should_tell_the_NoMvcViewEngineExtensions_to_RegisterNoMvcViewLocationFormats()
        {
            // Arrange
            var viewEngineExtensions = new Mock<INoMvcViewEngineExtensions>();
            NoMvcViewEngineExtensionsFactory.CreateNoMvcViewEngineExtensions = ve => viewEngineExtensions.Object;

            var viewEngineFunc = new Action(() => new NoMvcWebFormViewEngine());

            // Act
            viewEngineFunc();

            // Assert
            viewEngineExtensions.Verify(ext => ext.RegisterNoMvcViewLocationFormats());
        }
    }
}