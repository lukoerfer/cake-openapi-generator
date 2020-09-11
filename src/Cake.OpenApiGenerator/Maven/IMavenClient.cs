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
        /// <param name="package">A Maven package descriptor</param>
        /// <returns>A path to a local file that contains the Maven package file</returns>
        FilePath Resolve(MavenPackage package);
    }
}
