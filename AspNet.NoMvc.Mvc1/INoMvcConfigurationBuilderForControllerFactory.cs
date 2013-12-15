namespace AspNet.NoMvc.Mvc1
{
    public interface INoMvcConfigurationBuilderForControllerFactory
    {
        void DefaultNoMvc();
        void DefaultNoMvcWithControllerNameResolver(INoMvcControllerNameResolver controllerNameResolver);
        void Custom(INoMvcControllerFactory controllerFactory);
    }
}