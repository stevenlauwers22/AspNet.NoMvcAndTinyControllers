namespace AspNet.NoMvc.Mvc3
{
    public interface INoMvcControllerBuilderExtensions
    {
        void SetNoMvcControllerFactory();
        void SetNoMvcControllerFactory(INoMvcControllerNameResolver controllerNameResolver);
    }
}