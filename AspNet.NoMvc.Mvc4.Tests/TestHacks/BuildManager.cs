using System;
using System.Collections;
using System.IO;

namespace AspNet.NoMvc.Mvc4.Tests.TestHacks
{
    public interface IBuildManager
    {
        bool FileExists(string virtualPath);
        Type GetCompiledType(string virtualPath);
        ICollection GetReferencedAssemblies();
        Stream ReadCachedFile(string fileName);
        Stream CreateCachedFile(string fileName);
    }

    public abstract class BuildManager : IBuildManager
    {
        private readonly IBuildManager _buildManager;

        protected BuildManager(IBuildManager buildManager)
        {
            if (buildManager == null)
                throw new ArgumentNullException("buildManager");

            _buildManager = buildManager;
        }

        public virtual bool FileExists(string virtualPath)
        {
            return _buildManager.FileExists(virtualPath);
        }

        public virtual Type GetCompiledType(string virtualPath)
        {
            return _buildManager.GetCompiledType(virtualPath);
        }

        public virtual ICollection GetReferencedAssemblies()
        {
            return _buildManager.GetReferencedAssemblies();
        }

        public virtual Stream ReadCachedFile(string fileName)
        {
            return _buildManager.ReadCachedFile(fileName);
        }

        public virtual Stream CreateCachedFile(string fileName)
        {
            return _buildManager.CreateCachedFile(fileName);
        }
    }
}