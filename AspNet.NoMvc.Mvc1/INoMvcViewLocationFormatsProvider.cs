using System.Collections.Generic;

namespace AspNet.NoMvc.Mvc1
{
    public interface INoMvcViewLocationFormatsProvider
    {
        IEnumerable<string> GetMasterLocationFormats();
        IEnumerable<string> GetViewLocationFormats();
    }
}