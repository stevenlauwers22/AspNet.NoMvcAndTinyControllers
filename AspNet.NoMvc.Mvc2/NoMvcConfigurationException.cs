using System;

namespace AspNet.NoMvc.Mvc2
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