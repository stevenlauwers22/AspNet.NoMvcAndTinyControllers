using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc1
{
    public class NoMvcControllerFactory : DefaultControllerFactory
	{
        private readonly INoMvcControllerNameResolver _controllerNameResolver;

        public NoMvcControllerFactory()
            : this(null)
        {
        }

        public NoMvcControllerFactory(INoMvcControllerNameResolver controllerNameResolver)
        {
            _controllerNameResolver = controllerNameResolver ?? new NoMvcControllerNameDefaultResolver();
        }

        public INoMvcControllerNameResolver ControllerNameResolver
        {
            get { return _controllerNameResolver; }
        }

        protected override Type GetControllerType(string controllerName)
        {
            var requestContext = RequestContext;
            if (requestContext != null)
            {
                var namespaces = requestContext.RouteData.DataTokens["Namespaces"];
                if (namespaces != null)
                {
                    var namespacesList = new List<string>((IList<string>)namespaces);
                    for (var index = namespacesList.Count - 1; index >= 0; index--)
                    {
                        var defaultNamespace = namespacesList.ElementAt(index);
                        var namespaceForController = defaultNamespace + "." + controllerName;
                        if (!namespacesList.Contains(namespaceForController))
                        {
                            namespacesList.Add(namespaceForController);
                        }
                    }

                    requestContext.RouteData.DataTokens["Namespaces"] = namespacesList;
                }
                else if (ControllerBuilder.Current.DefaultNamespaces != null && ControllerBuilder.Current.DefaultNamespaces.Count > 0)
                {
                    var namespacesList = ControllerBuilder.Current.DefaultNamespaces;
                    for (var index = namespacesList.Count - 1; index >= 0; index--)
                    {
                        var defaultNamespace = namespacesList.ElementAt(index);
                        var namespaceForController = defaultNamespace + "." + controllerName;
                        if (!namespacesList.Contains(namespaceForController))
                        {
                            namespacesList.Add(namespaceForController);
                        }
                    }
                }
            }

            var controllerNameFormatted = _controllerNameResolver.Resolve(controllerName);
            var controllerType = base.GetControllerType(controllerNameFormatted);
            if (controllerType != null)
                return controllerType;

            return base.GetControllerType(controllerName);
        }
	}
}