namespace AspNet.NoMvc.Mvc4
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