using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc4.Tests.TestHacks
{
    public class MvcApplication
    {
        private readonly ModuleBuilder _moduleBuilder;

        public MvcApplication(ModuleBuilder moduleBuilder)
        {
            if (moduleBuilder == null)
                throw new ArgumentNullException("moduleBuilder");

            _moduleBuilder = moduleBuilder;
        }

        public Assembly GetAssemby()
        {
            return _moduleBuilder.Assembly;
        }

        public Type DefineControllerType(string controllerNamespace, string controllerName)
        {
            return DefineControllerType(controllerNamespace, controllerName, null);
        }

        public Type DefineControllerType(string controllerNamespace, string controllerName, IEnumerable<string> controllerActions)
        {
            var controllerTypeBuilder = _moduleBuilder.DefineType(string.Format("{0}.{1}", controllerNamespace, controllerName), TypeAttributes.Public | TypeAttributes.Class, typeof(Controller));
            if (controllerActions != null)
            {
                foreach (var controllerAction in controllerActions)
                {
                    var controllerActionBuilder = controllerTypeBuilder.DefineMethod(controllerAction, MethodAttributes.Public, typeof (ActionResult), Type.EmptyTypes);
                    controllerActionBuilder.GetILGenerator().Emit(OpCodes.Ret);
                }
            }

            var controllerType = controllerTypeBuilder.CreateType();
            return controllerType;
        }
    }
}