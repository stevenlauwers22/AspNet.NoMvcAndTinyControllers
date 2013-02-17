using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc4.Tests.TestHacks
{
    public static class BuildManagerBuilder
    {
        public static BuildManager Build(IBuildManager buildManager)
        {
            // Locate the MVC assembly
            var mvcAssembly = Assembly.GetAssembly(typeof(Controller));

            // Locate the InternalsVisibleTo attribute and create a public key token that matches the one specified.
            var internalsVisisbleTo = mvcAssembly.GetCustomAttributes(typeof(InternalsVisibleToAttribute), true).Cast<InternalsVisibleToAttribute>().First();
            var internalsVisisbleToAssemblyName = internalsVisisbleTo.AssemblyName.Split(",".ToCharArray())[0];
            var internalsVisisbleToPublicKeyString = internalsVisisbleTo.AssemblyName.Split("=".ToCharArray())[1];
            var internalsVisisbleToPublicKey = ToBytes(internalsVisisbleToPublicKeyString);

            // Get the domain of our current thread to host the new fake assembly
            var domain = Thread.GetDomain();

            // Create a fake assembly name with the appropriate assembly name and public key token set
            var assemblyName = new AssemblyName(internalsVisisbleToAssemblyName);
            assemblyName.SetPublicKey(internalsVisisbleToPublicKey);

            // Define and host the assembly in the domain
            var assemblyBuilder = domain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name, string.Format("{0}.dll", assemblyName.Name));
            
            // Create a new type that inherits from our BuildManager class and implements the MVC IBuildManager interface
            var buildManagerInterface = mvcAssembly.GetType("System.Web.Mvc.IBuildManager", true);
            var buildManagerTypeBuilder = moduleBuilder.DefineType(Guid.NewGuid().ToString(), TypeAttributes.NotPublic | TypeAttributes.Class, typeof(BuildManager), new[] { buildManagerInterface });
            var buildManagerTypeCtorBuilder = buildManagerTypeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.ExplicitThis | CallingConventions.HasThis, new[] { typeof(IBuildManager) });
            buildManagerTypeCtorBuilder.DefineParameter(1, ParameterAttributes.None, "buildManager");

            // Call the base constructor with the mocked IBuildManager interface
            var buildManagerTypeCtorEmitter = buildManagerTypeCtorBuilder.GetILGenerator();
            buildManagerTypeCtorEmitter.Emit(OpCodes.Nop);
            buildManagerTypeCtorEmitter.Emit(OpCodes.Ldarg_0);
            buildManagerTypeCtorEmitter.Emit(OpCodes.Ldarg_1);
            buildManagerTypeCtorEmitter.Emit(OpCodes.Call, typeof(BuildManager).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).Single());
            buildManagerTypeCtorEmitter.Emit(OpCodes.Ret);
            
            var buildManagerMockType = buildManagerTypeBuilder.CreateType();

            // Magic!
            var buildManagerMock = Activator.CreateInstance(buildManagerMockType, new object[] { buildManager }) as BuildManager;
            return buildManagerMock;
        }

        private static byte[] ToBytes(string value)
        {
            var bytes = new List<byte>();
            while (value.Length > 0)
            {
                var byteValue = value.Substring(0, 2);
                bytes.Add(Convert.ToByte(byteValue, 16));
                value = value.Substring(2);
            }

            return bytes.ToArray();
        }
    }
}