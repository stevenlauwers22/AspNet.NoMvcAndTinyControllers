namespace AspNet.NoMvc.Mvc3
{
    public interface INoMvcConfigurationBuilderForControllerFactory
    {
        void DefaultNoMvc();
        void DefaultNoMvcWithControllerNameResolver(INoMvcControllerNameResolver controllerNameResolver);
        void Custom(INoMvcControllerFactory controllerFactory);
    }
}