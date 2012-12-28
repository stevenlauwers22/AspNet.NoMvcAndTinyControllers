namespace AspNet.NoMvc.Mvc2
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