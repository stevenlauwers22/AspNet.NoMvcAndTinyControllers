using System;

namespace AspNet.NoMvc.Mvc3
{
    public class NoMvcConfigurationException : ApplicationException
    {
    }

    public class NoMvcConfigurationNotSetException : NoMvcConfigurationException
    {
    }

    public class NoMvcConfigurationNotValidException : NoMvcConfigurationException
    {
    }
}