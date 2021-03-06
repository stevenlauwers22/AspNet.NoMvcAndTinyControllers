namespace AspNet.NoMvc.Mvc2
{
    public interface INoMvcConfigurationBuilderForControllerFactory
    {
        void DefaultNoMvc();
        void DefaultNoMvcWithControllerNameResolver(INoMvcControllerNameResolver controllerNameResolver);
        void TinyNoMvc();
        void TinyNoMvcWithControllerNameResolver(INoMvcControllerNameResolver controllerNameResolver);
        void Custom(INoMvcControllerFactory controllerFactory);
    }
}