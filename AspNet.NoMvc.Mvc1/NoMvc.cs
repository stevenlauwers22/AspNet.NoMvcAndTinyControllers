namespace AspNet.NoMvc.Mvc1
{
    public static class NoMvc
    {
        public static INoMvcConfigurationBuilder Configure()
        {
            return new NoMvcConfigurationBuilder();
        }
    }
}