namespace AspNet.NoMvc.Mvc1
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