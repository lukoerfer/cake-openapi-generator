using Cake.Core.IO;
using Cake.Testing;
using Moq;
using NUnit.Framework;
using System.IO;

namespace Cake.OpenApiGenerator.Maven
{
    [TestFixture]
    class MavenClientTest
    {
        private IFileSystem fileSystem;
        private IWebClient mavenCentral;

        [SetUp]
        public void Setup()
        {
            var environment = FakeEnvironment.CreateWindowsEnvironment();
            fileSystem = new FakeFileSystem(environment);
            mavenCentral = Mock.Of<IWebClient>();
        }

        [Test]
        public void ShouldQueryMetadataForMissingVersion()
        {
            
        }
    }
}
