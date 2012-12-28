using System;
using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc3
{
    public class NoMvcControllerBuilderExtensions : INoMvcControllerBuilderExtensions
    {
        private readonly ControllerBuilder _controllerBuilder;

        public NoMvcControllerBuilderExtensions(ControllerBuilder controllerBuilder)
        {
            if (controllerBuilder == null)
                throw new ArgumentNullException("controllerBuilder");

            _controllerBuilder = controllerBuilder;
        }

        public ControllerBuilder ControllerBuilder
        {
            get { return _controllerBuilder; }
        }

        public void SetNoMvcControllerFactory()
        {
            _controllerBuilder.SetControllerFactory(new NoMvcControllerFactory());
        }

        public void SetNoMvcControllerFactory(INoMvcControllerNameResolver controllerNameResolver)
        {
            _controllerBuilder.SetControllerFactory(new NoMvcControllerFactory(controllerNameResolver));
        }
    }
}