using System;
using System.Collections.Generic;
using MvcIntegrationTestFramework.Hosting;
using Xunit;
using Xunit.Extensions;

namespace AspNet.NoMvc.Mvc3.Tests
{
    public class When_the_NoMvcApplication_is_told_to_handle_request
    {
        private readonly AppHost _appHost;

        public When_the_NoMvcApplication_is_told_to_handle_request()
        {
            // Arrange
            _appHost = AppHost.Simulate("AspNet.NoMvc.Mvc3.Sample");
        }

        [Theory]
        [InlineData(new object[] { "", "Index", typeof(Sample.Home._Controller) })]
        [InlineData(new object[] { "Home/Index", "Index", typeof(Sample.Home._Controller) })]
        [InlineData(new object[] { "Accounts/Index", "Index", typeof(Sample.Accounts._Controller) })]
        [InlineData(new object[] { "Administration/Home/Index", "Index", typeof(Sample.Administration.Home._Controller) })]
        [InlineData(new object[] { "Forum/Home/Index", "Index", typeof(Sample.Forum.Home._Controller) })]
        [InlineData(new object[] { "Forum/NewThread/Index", "Index", typeof(Sample.Forum.NewThread._Controller) })]
        public void Is_should_delegate_the_request_to_the_appropriate_action_method(string url, string expectedAction, Type expectedController)
        {
            _appHost.Start(browsingSession =>
            {
                // Act
                var result = browsingSession.Get(url);

                // Assert
                var actionDescriptor = result.ActionExecutedContext.ActionDescriptor;
                var controllerDescriptor = actionDescriptor.ControllerDescriptor;
                Assert.Equal(expectedAction, actionDescriptor.ActionName);
                Assert.Equal(expectedController, controllerDescriptor.ControllerType);
            });
        }

        public static IEnumerable<object[]> NoMvcTestData
        {
            get
            {
                yield return new object[] { "", "Index", typeof(Sample.Home._Controller) };
                yield return new object[] { "Home/Index", "Index", typeof(Sample.Home._Controller) };
                yield return new object[] { "Accounts/Index", "Index", typeof(Sample.Accounts._Controller) };
                yield return new object[] { "Administration/Home/Index", "Index", typeof(Sample.Administration.Home._Controller) };
                yield return new object[] { "Forum/Home/Index", "Index", typeof(Sample.Forum.Home._Controller) };
                yield return new object[] { "Forum/NewThread/Index", "Index", typeof(Sample.Forum.NewThread._Controller) };
            }
        }
    }
}