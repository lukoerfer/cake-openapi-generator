using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.OpenApiGenerator.Maven;
using Cake.Testing;
using FakeItEasy;
using NUnit.Framework;
using System.IO;

namespace Cake.OpenApiGenerator
{
    [TestFixture]
    public class OpenApiGeneratorTest
    {
        private FakeEnvironment environment;
        private FakeFileSystem fileSystem;
        private IProcessRunner runner;
        private IToolLocator tools;
        private IMavenClient mavenClient;

        [SetUp]
        public void Setup()
        {
            environment = FakeEnvironment.CreateWindowsEnvironment();
            fileSystem = new FakeFileSystem(environment);
            runner = A.Fake<IProcessRunner>();
            tools = A.Fake<IToolLocator>();
            mavenClient = A.Fake<IMavenClient>();

            var javaExecutable = new FilePath("/path/to/java.exe");
            fileSystem.CreateFile(javaExecutable, FileAttributes.Normal);
            A.CallTo(() => runner.Start(A<FilePath>._, A<ProcessSettings>._)).Returns(A.Fake<IProcess>());
            A.CallTo(() => tools.Resolve(A<string>._)).Returns(javaExecutable);
            A.CallTo(() => mavenClient.Resolve(A<MavenPackage>._)).Returns("/path/to/package.jar");
        }

        [Test]
        public void Test()
        {
            var generator = new OpenApiGenerator(fileSystem, environment, runner, tools, mavenClient);

            generator.Validate("specification.yaml");

            A.CallTo(() => runner.Start(A<FilePath>._, A<ProcessSettings>._)).MustHaveHappenedOnceExactly();
        }
    }
}
