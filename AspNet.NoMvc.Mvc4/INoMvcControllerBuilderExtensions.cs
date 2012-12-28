namespace AspNet.NoMvc.Mvc4
{
    public interface INoMvcControllerBuilderExtensions
    {
        void SetNoMvcControllerFactory();
        void SetNoMvcControllerFactory(INoMvcControllerNameResolver controllerNameResolver);
    }
}