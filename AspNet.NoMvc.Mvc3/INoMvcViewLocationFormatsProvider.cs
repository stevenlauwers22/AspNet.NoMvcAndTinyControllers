using System.Collections.Generic;

namespace AspNet.NoMvc.Mvc3
{
    public interface INoMvcViewLocationFormatsProvider
    {
        IEnumerable<string> GetMasterLocationFormats();
        IEnumerable<string> GetViewLocationFormats();
        IEnumerable<string> GetAreaMasterLocationFormats();
        IEnumerable<string> GetAreaViewLocationFormats();
    }
}