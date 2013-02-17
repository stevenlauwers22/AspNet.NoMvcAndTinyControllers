namespace AspNet.NoMvc.Mvc2
{
    public static class NoMvc
    {
        public static INoMvcConfigurationBuilder Configure()
        {
            return new NoMvcConfigurationBuilder();
        }
    }
}