using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNet.NoMvc.Mvc2
{
	public class NoMvcControllerFactory : DefaultControllerFactory
	{
		private readonly string _baseNamespace;
	    private readonly string _controllerNamingPattern;

        public NoMvcControllerFactory(string baseNamespace)
            : this(baseNamespace, null)
        {
        }

	    public NoMvcControllerFactory(string baseNamespace, string controllerNamingPattern)
		{
            if (string.IsNullOrEmpty(baseNamespace))
				throw new ArgumentNullException("baseNamespace");
            
			_baseNamespace = baseNamespace;
		    _controllerNamingPattern = controllerNamingPattern ?? "_";
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
				else
				{
					namespaces = new List<string> {_baseNamespace + "." + controllerName};
					requestContext.RouteData.DataTokens["Namespaces"] = namespaces;
				}
            }

            var controllerNameFormatted = string.Format(_controllerNamingPattern, controllerName);
            var controllerType = base.GetControllerType(requestContext, controllerNameFormatted);
            if (controllerType != null)
                return controllerType;

            var baseControllerType = base.GetControllerType(requestContext, controllerName);
            return baseControllerType;
		}
	}
}