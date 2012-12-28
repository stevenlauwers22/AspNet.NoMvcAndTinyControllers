using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNet.NoMvc.Mvc2
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

		protected override Type GetControllerType(RequestContext requestContext, string controllerName)
		{
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
            var controllerType = base.GetControllerType(requestContext, controllerNameFormatted);
            if (controllerType != null)
                return controllerType;

            var baseControllerType = base.GetControllerType(requestContext, controllerName);
            return baseControllerType;
		}
	}
}