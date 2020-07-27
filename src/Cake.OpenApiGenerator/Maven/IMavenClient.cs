using Cake.Core.IO;

namespace Cake.OpenApiGenerator.Maven
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMavenClient
    {
        FilePath Resolve(MavenPackage package);
    }
}
