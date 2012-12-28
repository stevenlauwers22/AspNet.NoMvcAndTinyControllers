namespace AspNet.NoMvc.Mvc1
{
    public interface INoMvcControllerBuilderExtensions
    {
        void SetNoMvcControllerFactory();
        void SetNoMvcControllerFactory(INoMvcControllerNameResolver controllerNameResolver);
    }
}