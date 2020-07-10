using Cake.Core.IO;

namespace Cake.OpenApiGenerator.Maven
{
    public interface IMavenClient
    {
        FilePath GetJarFile(string group, string artifact, string version);
    }
}
