using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.OpenApiGenerator.Maven;
using Cake.OpenApiGenerator.Settings;
using Cake.OpenApiGenerator.Util;
using Cake.Testing;

using FakeItEasy;

using NUnit.Framework;

using System.IO;

namespace Cake.OpenApiGenerator
{
    [TestFixture]
    public class OpenApiGeneratorTest
    {
        private readonly FilePath javaExecutable = new FilePath("/path/to/java.exe");

        private FakeEnvironment environment;
        private FakeFileSystem fileSystem;
        private IProcessRunner runner;
        private IToolLocator tools;
        private IMavenClient mavenClient;

        [SetUp]
        public void Setup()
        {
            environment = FakeEnvironmentHelper.CreateFromRuntime();
            fileSystem = new FakeFileSystem(environment);
            runner = A.Fake<IProcessRunner>();
            tools = A.Fake<IToolLocator>();
            mavenClient = A.Fake<IMavenClient>();

            fileSystem.CreateFile(javaExecutable, FileAttributes.Normal);
            A.CallTo(() => runner.Start(A<FilePath>._, A<ProcessSettings>._)).Returns(A.Fake<IProcess>());
            A.CallTo(() => tools.Resolve(A<string>._)).Returns(javaExecutable);
            A.CallTo(() => mavenClient.Resolve(A<MavenPackage>._)).Returns("/path/to/package.jar");
        }

        [Test]
        public void Generate_WithValidSettings_RunJavaProcess()
        {
            var generator = new OpenApiGenerator(fileSystem, environment, runner, tools, mavenClient);

            generator.Generate(new OpenApiGeneratorGenerateSettings()
            {
                Specification = "specification.yaml",
                Generator = "csharp",
                OutputDirectory = "./src"
            });

            A.CallTo(() => runner.Start(javaExecutable, A<ProcessSettings>._)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Generate_WithValidConfigurator_RunsJavaProcess()
        {
            var generator = new OpenApiGenerator(fileSystem, environment, runner, tools, mavenClient);

            generator.Generate(settings =>
            {
                settings.Specification = "specification.yaml";
                settings.Generator = "csharp";
                settings.OutputDirectory = "./src";
            });

            A.CallTo(() => runner.Start(javaExecutable, A<ProcessSettings>._)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Validate_WithValidParameters_RunsJavaProcess()
        {
            var generator = new OpenApiGenerator(fileSystem, environment, runner, tools, mavenClient);

            generator.Validate("specification.yaml");

            A.CallTo(() => runner.Start(javaExecutable, A<ProcessSettings>._)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Batch_WithValidParameters_RunsJavaProcess()
        {
            var generator = new OpenApiGenerator(fileSystem, environment, runner, tools, mavenClient);

            generator.Batch("csharp-server.yaml", "javascript-client.yaml");

            A.CallTo(() => runner.Start(javaExecutable, A<ProcessSettings>._)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Batch_WithValidSettings_RunsJavaProcess()
        {
            var generator = new OpenApiGenerator(fileSystem, environment, runner, tools, mavenClient);

            generator.Batch(new OpenApiGeneratorBatchSettings()
            {
                ConfigurationFiles = new FilePathCollection(new FilePath[] { "csharp-server.yaml", "javascript-client.yaml" })
            });

            A.CallTo(() => runner.Start(javaExecutable, A<ProcessSettings>._)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Batch_WithValidConfigurator_RunsJavaProcess()
        {
            var generator = new OpenApiGenerator(fileSystem, environment, runner, tools, mavenClient);

            generator.Batch(settings =>
            {
                settings.ConfigurationFiles.Add("csharp-server.yaml");
            });

            A.CallTo(() => runner.Start(javaExecutable, A<ProcessSettings>._)).MustHaveHappenedOnceExactly();
        }
    }
}
