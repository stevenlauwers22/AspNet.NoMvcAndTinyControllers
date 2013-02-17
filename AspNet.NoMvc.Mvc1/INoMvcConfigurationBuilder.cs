namespace AspNet.NoMvc.Mvc1
{
    public interface INoMvcConfigurationBuilder
    {
        INoMvcConfigurationBuilder UsingDefaults();
        void Apply();
    }
}