namespace AspNet.NoMvc.Mvc3
{
    public interface INoMvcConfigurationBuilder
    {
        INoMvcConfigurationBuilder UsingDefaults();
        void Apply();
    }
}