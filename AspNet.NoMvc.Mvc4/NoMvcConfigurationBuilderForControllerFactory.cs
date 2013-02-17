namespace AspNet.NoMvc.Mvc4
{
    public class NoMvcConfigurationBuilderForControllerFactory : INoMvcConfigurationBuilderForControllerFactory
    {
        private INoMvcControllerFactory _controllerFactory;

        internal INoMvcControllerFactory GetResult()
        {
            return _controllerFactory;
        }

        public void DefaultNoMvc()
        {
            _controllerFactory = new NoMvcControllerFactory();
        }

        public void DefaultNoMvcWithControllerNameResolver(INoMvcControllerNameResolver controllerNameResolver)
        {
            _controllerFactory = new NoMvcControllerFactory(controllerNameResolver);
        }

        public void TinyNoMvc()
        {
            _controllerFactory = new NoMvcTinyControllerFactory();
        }

        public void TinyNoMvcWithControllerNameResolver(INoMvcControllerNameResolver controllerNameResolver)
        {
            _controllerFactory = new NoMvcTinyControllerFactory(controllerNameResolver);
        }

        public void Custom(INoMvcControllerFactory controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }
    }
}