using Cake.Core.IO;

using System.Xml;

namespace Cake.OpenApiGenerator.Maven
{
    public class MavenClient : IMavenClient
    {
        private readonly IFileSystem fileSystem;
        private readonly DirectoryPath mavenLocal;
        private readonly IWebClient mavenCentral;

        public MavenClient(IFileSystem fileSystem, DirectoryPath mavenLocal, IWebClient mavenCentral)
        {
            this.fileSystem = fileSystem;
            this.mavenLocal = mavenLocal;
            this.mavenCentral = mavenCentral;
        }

        public FilePath GetJarFile(string group, string artifact, string version)
        {
            version = version ?? GetLatestVersion(group, artifact);
            var path = $"{group.Replace('.', '/')}/{artifact}/{version}/openapi-generator-cli-{version}.jar";
            var localJarFile = fileSystem.GetFile(mavenLocal.CombineWithFilePath(path));

            if (!localJarFile.Exists)
            {
                using (var source = mavenCentral.OpenRead(path))
                using (var target = localJarFile.OpenWrite())
                {
                    source.CopyTo(target);
                }
            }
            return localJarFile.Path;
        }

        private string GetLatestVersion(string group, string artifact)
        {
            var path = $"{group.Replace('.', '/')}/{artifact}/maven-metadata.xml";
            using (var stream = mavenCentral.OpenRead(path))
            {
                var document = new XmlDocument();
                document.Load(stream);
                return document.SelectSingleNode("/metadata/versioning/latest").InnerText;
            }
        }
    }
}
