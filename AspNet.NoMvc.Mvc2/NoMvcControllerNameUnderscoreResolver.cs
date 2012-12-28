namespace AspNet.NoMvc.Mvc2
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