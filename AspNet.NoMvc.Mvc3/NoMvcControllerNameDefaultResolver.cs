namespace AspNet.NoMvc.Mvc3
{
    public class NoMvcControllerNameDefaultResolver : NoMvcControllerNameResolver
    {
        private const string ControllerNamePattern = "{0}";

        public NoMvcControllerNameDefaultResolver()
            : base(ControllerNamePattern)
        {
        }
    }
}