namespace AspNet.NoMvc.Mvc3
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