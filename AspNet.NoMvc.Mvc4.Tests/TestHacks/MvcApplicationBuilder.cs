using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace AspNet.NoMvc.Mvc4.Tests.TestHacks
{
    public static class MvcApplicationBuilder
    {
        public static MvcApplication Build(string applicationName)
        {
            var domain = Thread.GetDomain();
            var assemblyName = new AssemblyName(applicationName);
            var assemblyBuilder = domain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name, string.Format("{0}.dll", assemblyName.Name));
            var mvcApplication = new MvcApplication(moduleBuilder);
            return mvcApplication;
        }
    }
}