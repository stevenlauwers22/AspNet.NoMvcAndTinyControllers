using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNet.TinyControllers.Mvc1
{
	public class TinyControllerFactory : DefaultControllerFactory
	{
		private readonly string _defaultNamespace;

		public TinyControllerFactory(string defaultNamespace)
		{
            if (string.IsNullOrEmpty(defaultNamespace))
				throw new ArgumentNullException("defaultNamespace");

			_defaultNamespace = defaultNamespace;
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
                else
                {
                    namespaces = new List<string> { _defaultNamespace + "." + controllerName };
                    requestContext.RouteData.DataTokens["Namespaces"] = namespaces;
                }

                var action = requestContext.RouteData.GetRequiredString("action");
                var controllerType = base.GetControllerType(action);
                if (controllerType != null)
                    return controllerType;
            }

            var baseControllerType = base.GetControllerType(controllerName);
            return baseControllerType;
        }
	}
}