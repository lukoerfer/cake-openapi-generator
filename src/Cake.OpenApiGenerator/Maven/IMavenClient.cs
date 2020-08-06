using Cake.Core.IO;

namespace Cake.OpenApiGenerator.Maven
{
    /// <summary>
    /// Encapsulates the functionality to resolve Maven package file
    /// </summary>
    public interface IMavenClient
    {
        /// <summary>
        /// Resolves a Maven package file
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        FilePath Resolve(MavenPackage package);
    }
}
