namespace AspNet.NoMvc.Mvc4.Tests.TestUtils
{
    public abstract class NoMvcTest
    {
        protected NoMvcTest()
        {
            ResetNoMvc();
        }

        private static void ResetNoMvc()
        {
            NoMvc
                .Configure()
                .SetControllerFactory(cf => cf.DefaultNoMvcWithControllerNameResolver(new NoMvcControllerNameUnderscoreResolver()))
                .Apply();
        }
    }
}