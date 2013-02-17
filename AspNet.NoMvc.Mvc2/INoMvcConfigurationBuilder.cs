namespace AspNet.NoMvc.Mvc2
{
    public interface INoMvcConfigurationBuilder
    {
        INoMvcConfigurationBuilder UsingDefaults();
        void Apply();
    }
}