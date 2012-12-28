using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNet.NoMvc.Mvc2
{
    public class NoMvcViewEngineExtensions : INoMvcViewEngineExtensions
    {
        private readonly VirtualPathProviderViewEngine _viewEngine;
        private readonly INoMvcViewLocationFormatsProvider _viewLocationFormatsProvider;

        public NoMvcViewEngineExtensions(VirtualPathProviderViewEngine viewEngine)
            : this(viewEngine, null)
        {
        }

        public NoMvcViewEngineExtensions(VirtualPathProviderViewEngine viewEngine, INoMvcViewLocationFormatsProvider viewLocationFormatsProvider)
        {
            if (viewEngine == null)
                throw new ArgumentNullException("viewEngine");

            _viewEngine = viewEngine;
            _viewLocationFormatsProvider = viewLocationFormatsProvider ?? new NoMvcViewLocationFormatsDefaultProvider();
        }

        public VirtualPathProviderViewEngine ViewEngine
        {
            get { return _viewEngine; }
        }

        public INoMvcViewLocationFormatsProvider ViewLocationFormatsProvider
        {
            get { return _viewLocationFormatsProvider; }
        }

        public void RegisterNoMvcViewLocationFormats()
        {
            // Register No MVC Master Location Formats
            var masterLocationFormats = _viewLocationFormatsProvider.GetMasterLocationFormats().ToList();
            RegisterNoMvcViewLocationFormats(() => _viewEngine.MasterLocationFormats, formats => _viewEngine.MasterLocationFormats = formats, masterLocationFormats);

            // Register No MVC View Location Formats
            var viewLocationFormats = _viewLocationFormatsProvider.GetViewLocationFormats().ToList();
            RegisterNoMvcViewLocationFormats(() => _viewEngine.ViewLocationFormats, formats => _viewEngine.ViewLocationFormats = formats, viewLocationFormats);
            RegisterNoMvcViewLocationFormats(() => _viewEngine.PartialViewLocationFormats, formats => _viewEngine.PartialViewLocationFormats = formats, viewLocationFormats);

            // Register No MVC Area Master Location Formats
            var areaMasterLocationFormats = _viewLocationFormatsProvider.GetAreaMasterLocationFormats().ToList();
            RegisterNoMvcViewLocationFormats(() => _viewEngine.AreaMasterLocationFormats, formats => _viewEngine.AreaMasterLocationFormats = formats, areaMasterLocationFormats);

            // Register No MVC Area View Location Formats
            var areaViewLocationFormats = _viewLocationFormatsProvider.GetAreaViewLocationFormats().ToList();
            RegisterNoMvcViewLocationFormats(() => _viewEngine.AreaViewLocationFormats, formats => _viewEngine.AreaViewLocationFormats = formats, areaViewLocationFormats);
            RegisterNoMvcViewLocationFormats(() => _viewEngine.AreaPartialViewLocationFormats, formats => _viewEngine.AreaPartialViewLocationFormats = formats, areaViewLocationFormats);
        }

        private static void RegisterNoMvcViewLocationFormats(Func<string[]> targetPropertyGetter, Action<string[]> targetPropertySetter, ICollection<string> viewLocationFormats)
        {
            var targetProperty = targetPropertyGetter();
            if (targetProperty != null)
            {
                foreach (var viewLocationFormat in targetProperty)
                {
                    if (!viewLocationFormats.Contains(viewLocationFormat))
                    {
                        viewLocationFormats.Add(viewLocationFormat);
                    }
                }
            }

            targetPropertySetter(viewLocationFormats.ToArray());
        }
    }
}