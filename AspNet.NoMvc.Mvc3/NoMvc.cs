namespace AspNet.NoMvc.Mvc3
{
    public static class NoMvc
    {
        public static INoMvcConfigurationBuilder Configure()
        {
            return new NoMvcConfigurationBuilder();
        }
    }
}