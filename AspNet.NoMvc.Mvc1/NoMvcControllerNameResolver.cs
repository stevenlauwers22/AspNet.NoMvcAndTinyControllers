using System;

namespace AspNet.NoMvc.Mvc1
{
    public interface INoMvcControllerNameResolver
    {
        string Pattern { get; }
        string Resolve(string controllerName);
    }

    public class NoMvcControllerNameResolver : INoMvcControllerNameResolver
    {
        private readonly string _pattern;

        public NoMvcControllerNameResolver(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentNullException("pattern");

            _pattern = pattern;
        }

        public string Pattern
        {
            get { return _pattern; }
        }

        public string Resolve(string controllerName)
        {
            return string.Format(_pattern, controllerName);
        }
    }
}