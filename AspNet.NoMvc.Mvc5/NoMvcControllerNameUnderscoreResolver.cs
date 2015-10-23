namespace AspNet.NoMvc.Mvc5
{
    public class NoMvcControllerNameUnderscoreResolver : NoMvcControllerNameResolver
    {
        private const string ControllerNamePattern = "_";

        public NoMvcControllerNameUnderscoreResolver()
            : base(ControllerNamePattern)
        {
        }
    }
}