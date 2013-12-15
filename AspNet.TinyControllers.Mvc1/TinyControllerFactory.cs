using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNet.TinyControllers.Mvc1
{
	public class TinyControllerFactory : DefaultControllerFactory
	{
        protected override Type GetControllerType(string controllerName)
        {
            var requestContext = RequestContext;
            if (requestContext != null)
            {
                // First search in the current route's namespace collection
                var namespaces = requestContext.RouteData.DataTokens["Namespaces"] as IEnumerable<string>;
                if (namespaces != null)
                {
                    var namespacesList = new List<string>(namespaces);
                    if (namespacesList.Any())
                    {
                        // Inject the controller namespace
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

                        // Disable namespace fallback
                        var useNamespaceFallback = requestContext.RouteData.DataTokens["UseNamespaceFallback"];
                        requestContext.RouteData.DataTokens["UseNamespaceFallback"] = false;

                        // Get the controller type from the current route's namespace collection
                        var action = requestContext.RouteData.GetRequiredString("action");
                        var controllerActionTypeInRoutesNamespace = base.GetControllerType(action);
                        if (controllerActionTypeInRoutesNamespace != null)
                            return controllerActionTypeInRoutesNamespace;

                        var controllerTypeInRoutesNamespace = base.GetControllerType(controllerName);
                        if (controllerTypeInRoutesNamespace != null)
                            return controllerTypeInRoutesNamespace;

                        // No controller type found in the current route's namespace collection
                        // Check if we need to fallback on the application's default namespace collection
                        if (false.Equals(useNamespaceFallback))
                            return null;

                        // Restore namespace ballback
                        requestContext.RouteData.DataTokens["UseNamespaceFallback"] = useNamespaceFallback;
                    }
                }

                // Then search in the application's default namespace collection
                if (ControllerBuilder.Current.DefaultNamespaces != null && ControllerBuilder.Current.DefaultNamespaces.Count > 0)
                {
                    // Inject the controller namespace
                    var namespacesList = new List<string>(ControllerBuilder.Current.DefaultNamespaces);
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

                    // Get the controller type from the application's default namespace collection
                    var action = requestContext.RouteData.GetRequiredString("action");
                    var controllerTypeActionInDefaultNamespace = base.GetControllerType(action);
                    if (controllerTypeActionInDefaultNamespace != null)
                        return controllerTypeActionInDefaultNamespace;

                    var controllerTypeInDefaultNamespace = base.GetControllerType(controllerName);
                    if (controllerTypeInDefaultNamespace != null)
                        return controllerTypeInDefaultNamespace;
                }
            }

            return base.GetControllerType(controllerName);
        }
	}
}