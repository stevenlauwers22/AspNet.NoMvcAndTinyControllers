namespace AspNet.NoMvc.Mvc5
{
    public static class NoMvc
    {
        public static INoMvcConfigurationBuilder Configure()
        {
            return new NoMvcConfigurationBuilder();
        }
    }
}