namespace AspNet.NoMvc.Mvc2
{
    public interface INoMvcControllerBuilderExtensions
    {
        void SetNoMvcControllerFactory();
        void SetNoMvcControllerFactory(INoMvcControllerNameResolver controllerNameResolver);
    }
}