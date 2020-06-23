using Cake.Core.IO;

using System;
using System.IO;
using System.Net;
using System.Xml;

namespace Cake.OpenApiGenerator
{
    internal class PackageProvider
    {
        private static readonly Uri RemotePackage = new Uri("https://repo1.maven.org/maven2/openapitools/openapi-generator-cli");

        private static readonly Uri UserProfile = new Uri(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
        private static readonly Uri LocalPackage = new Uri(UserProfile, ".m2/repository/org/openapitools/openapi-generator-cli");

        private readonly WebClient WebClient = new WebClient();

        public FilePath GetPackageFile(string version = null)
        {
            version = version ?? GetLatestVersion();
            var file = $"{version}/openapi-generator-cli-{version}.jar";
            var localFile = new Uri(LocalPackage, file);
            if (!File.Exists(localFile.LocalPath))
            {
                var remoteFile = new Uri(RemotePackage, file);
                WebClient.DownloadFile(remoteFile, localFile.LocalPath);
            }
            return new FilePath(localFile.LocalPath);
        }

        private string GetLatestVersion()
        {
            XmlDocument document = new XmlDocument();
            document.Load(new Uri(RemotePackage, "maven-metadata.xml").AbsoluteUri);
            return document.SelectSingleNode("/metadata/versioning/latest").InnerText;
        }

    }
}
