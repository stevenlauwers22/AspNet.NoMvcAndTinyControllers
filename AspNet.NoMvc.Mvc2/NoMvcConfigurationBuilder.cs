namespace AspNet.NoMvc.Mvc2
{
    public class NoMvcConfigurationBuilder : INoMvcConfigurationBuilder
    {
        private NoMvcConfiguration _configuration;

        public NoMvcConfigurationBuilder()
        {
            _configuration = new NoMvcConfiguration();
        }

        public INoMvcConfigurationBuilder UsingDefaults()
        {
            _configuration = new NoMvcConfigurationWithDefaults();
            return this;
        }

        public void Apply()
        {
            _configuration.Apply();
        }
    }
}