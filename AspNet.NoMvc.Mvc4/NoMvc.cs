namespace AspNet.NoMvc.Mvc4
{
    public static class NoMvc
    {
        public static INoMvcConfigurationBuilder Configure()
        {
            return new NoMvcConfigurationBuilder();
        }
    }
}