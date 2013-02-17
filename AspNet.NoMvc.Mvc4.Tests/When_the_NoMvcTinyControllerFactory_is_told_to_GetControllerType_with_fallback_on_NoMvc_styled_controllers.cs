using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AspNet.NoMvc.Mvc4.Tests.TestHacks;
using AspNet.NoMvc.Mvc4.Tests.TestUtils;
using Moq;
using Xunit;

namespace AspNet.NoMvc.Mvc4.Tests
{
    public class When_the_NoMvcTinyControllerFactory_is_told_to_GetControllerType_with_fallback_on_NoMvc_styled_controllers : NoMvcTest
    {
        [Fact]
        public void It_should_retrieve_the_controller_type_from_the_route_namespace()
        {
            // Arrange
            var mvcApplicationName = Guid.NewGuid().ToString();
            var mvcApplication = MvcApplicationBuilder.Build(mvcApplicationName);
            var controllerType = mvcApplication.DefineControllerType(string.Format("{0}.Home", mvcApplicationName), "_Controller");
            mvcApplication.DefineControllerType(string.Format("{0}.Accounts", mvcApplicationName), "_Controller");

            var buildManagerMock = new Mock<IBuildManager>();
            var buildManager = BuildManagerBuilder.Build(buildManagerMock.Object);
            buildManagerMock.Setup(bm => bm.GetReferencedAssemblies()).Returns(new[] { mvcApplication.GetAssemby() });

            var controllerFactory = new NoMvcTinyControllerFactory(new NoMvcControllerNameUnderscoreResolver());
            controllerFactory.SetBuildManager(buildManager);
            controllerFactory.SetControllerTypeCache();

            var requestContext = new RequestContext(new Mock<HttpContextBase>().Object, new RouteData());
            requestContext.RouteData.DataTokens.Add("Namespaces", new[] { mvcApplicationName });
            requestContext.RouteData.Values.Add("Action", "Index");

            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            ControllerBuilder.Current.DefaultNamespaces.Clear();

            // Act
            var controller = controllerFactory.CreateController(requestContext, "Home");

            // Assert
            Assert.IsAssignableFrom(controllerType, controller);
        }

        [Fact]
        public void It_should_retrieve_the_controller_type_by_falling_back_on_the_application_namespaces_implicitely()
        {
            // Arrange
            var mvcApplicationName = Guid.NewGuid().ToString();
            var mvcApplication = MvcApplicationBuilder.Build(mvcApplicationName);
            var controllerType = mvcApplication.DefineControllerType(string.Format("{0}.Home", mvcApplicationName), "_Controller");
            mvcApplication.DefineControllerType(string.Format("{0}.Accounts", mvcApplicationName), "_Controller");

            var buildManagerMock = new Mock<IBuildManager>();
            var buildManager = BuildManagerBuilder.Build(buildManagerMock.Object);
            buildManagerMock.Setup(bm => bm.GetReferencedAssemblies()).Returns(new[] { mvcApplication.GetAssemby() });

            var controllerFactory = new NoMvcTinyControllerFactory(new NoMvcControllerNameUnderscoreResolver());
            controllerFactory.SetBuildManager(buildManager);
            controllerFactory.SetControllerTypeCache();

            var requestContext = new RequestContext(new Mock<HttpContextBase>().Object, new RouteData());
            requestContext.RouteData.DataTokens.Add("Namespaces", new[] { mvcApplicationName + "2" });
            requestContext.RouteData.Values.Add("Action", "Index");

            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            ControllerBuilder.Current.DefaultNamespaces.Clear();
            ControllerBuilder.Current.DefaultNamespaces.Add(mvcApplicationName);

            // Act
            var controller = controllerFactory.CreateController(requestContext, "Home");

            // Assert
            Assert.IsAssignableFrom(controllerType, controller);
        }

        [Fact]
        public void It_should_retrieve_the_controller_type_by_falling_back_on_the_application_namespaces_explicitely()
        {
            // Arrange
            var mvcApplicationName = Guid.NewGuid().ToString();
            var mvcApplication = MvcApplicationBuilder.Build(mvcApplicationName);
            var controllerType = mvcApplication.DefineControllerType(string.Format("{0}.Home", mvcApplicationName), "_Controller");
            mvcApplication.DefineControllerType(string.Format("{0}.Accounts", mvcApplicationName), "_Controller");

            var buildManagerMock = new Mock<IBuildManager>();
            var buildManager = BuildManagerBuilder.Build(buildManagerMock.Object);
            buildManagerMock.Setup(bm => bm.GetReferencedAssemblies()).Returns(new[] { mvcApplication.GetAssemby() });

            var controllerFactory = new NoMvcTinyControllerFactory(new NoMvcControllerNameUnderscoreResolver());
            controllerFactory.SetBuildManager(buildManager);
            controllerFactory.SetControllerTypeCache();

            var requestContext = new RequestContext(new Mock<HttpContextBase>().Object, new RouteData());
            requestContext.RouteData.DataTokens.Add("Namespaces", new[] { mvcApplicationName + "2" });
            requestContext.RouteData.DataTokens.Add("UseNamespaceFallback", true);
            requestContext.RouteData.Values.Add("Action", "Index");

            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            ControllerBuilder.Current.DefaultNamespaces.Clear();
            ControllerBuilder.Current.DefaultNamespaces.Add(mvcApplicationName);

            // Act
            var controller = controllerFactory.CreateController(requestContext, "Home");

            // Assert
            Assert.IsAssignableFrom(controllerType, controller);
        }

        [Fact]
        public void It_should_not_retrieve_the_controller_type()
        {
            // Arrange
            var mvcApplicationName = Guid.NewGuid().ToString();
            var mvcApplication = MvcApplicationBuilder.Build(mvcApplicationName);
            mvcApplication.DefineControllerType(string.Format("{0}.Home", mvcApplicationName), "_Controller");
            mvcApplication.DefineControllerType(string.Format("{0}.Accounts", mvcApplicationName), "_Controller");

            var buildManagerMock = new Mock<IBuildManager>();
            var buildManager = BuildManagerBuilder.Build(buildManagerMock.Object);
            buildManagerMock.Setup(bm => bm.GetReferencedAssemblies()).Returns(new[] { mvcApplication.GetAssemby() });

            var controllerFactory = new NoMvcTinyControllerFactory(new NoMvcControllerNameUnderscoreResolver());
            controllerFactory.SetBuildManager(buildManager);
            controllerFactory.SetControllerTypeCache();

            var requestContext = new RequestContext(new Mock<HttpContextBase>().Object, new RouteData());
            requestContext.RouteData.DataTokens.Add("Namespaces", new[] { mvcApplicationName + "2" });
            requestContext.RouteData.DataTokens.Add("UseNamespaceFallback", false);
            requestContext.RouteData.Values.Add("Action", "Index");

            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            ControllerBuilder.Current.DefaultNamespaces.Clear();
            ControllerBuilder.Current.DefaultNamespaces.Add(mvcApplicationName);

            try
            {
                // Act
                controllerFactory.CreateController(requestContext, "Home");

                // Assert
                Assert.True(false, "Expected exception was not thrown");
            }
            catch (NullReferenceException)
            {
                // Assert
                Assert.True(true, "Expected exception was thrown");
            }
            catch (Exception)
            {
                // Assert
                Assert.True(false, "Expected exception was not thrown");
            }
        }
    }
}