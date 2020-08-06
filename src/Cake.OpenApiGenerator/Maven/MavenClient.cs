using Cake.Core.IO;

using System.Xml;

namespace Cake.OpenApiGenerator.Maven
{
    /// <summary>
    /// Provides a Maven client that uses both a local and a remote repository
    /// </summary>
    public class MavenClient : IMavenClient
    {
        private readonly IFileSystem fileSystem;
        private readonly DirectoryPath localRepository;
        private readonly IWebClient remoteRepository;

        /// <summary>
        /// Creates a new Maven client
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="localRepository"></param>
        /// <param name="remoteRepository"></param>
        public MavenClient(IFileSystem fileSystem, DirectoryPath localRepository, IWebClient remoteRepository)
        {
            this.fileSystem = fileSystem;
            this.localRepository = localRepository;
            this.remoteRepository = remoteRepository;
        }

        public FilePath Resolve(MavenPackage package)
        {
            var version = package.Version ?? GetLatestVersion(package.Group, package.Artifact);
            var path = $"{package.Group.Replace('.', '/')}/{package.Artifact}/{version}/{package.Artifact}-{version}.jar";
            var localJarFile = fileSystem.GetFile(localRepository.CombineWithFilePath(path));

            if (!localJarFile.Exists)
            {
                using (var source = remoteRepository.OpenRead(path))
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
            using (var stream = remoteRepository.OpenRead(path))
            {
                var document = new XmlDocument();
                document.Load(stream);
                return document.SelectSingleNode("/metadata/versioning/latest").InnerText;
            }
        }

    }
}
