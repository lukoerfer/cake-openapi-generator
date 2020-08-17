using Cake.Core.IO;

using NUnit.Framework;

using System;

namespace Cake.OpenApiGenerator.Settings
{
    [TestFixture]
    class OpenApiBatchSettingsTest
    {
        private OpenApiGeneratorBatchSettings settings;

        [SetUp]
        public void Setup()
        {
            settings = new OpenApiGeneratorBatchSettings()
            {
                ToolPackageFile = new FilePath("package.jar")
            };
            settings.ConfigurationFiles.Add("csharp-server.yaml");
        }

        [Test]
        public void ShouldRenderArgumentsFromRequiredParameters()
        {
            var arguments = settings.AsArguments().Render();

            Assert.AreEqual("-jar package.jar batch csharp-server.yaml", arguments);
        }

        [Test]
        public void ShouldFailIfToolPackageFileIsNull()
        {
            settings.ToolPackageFile = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                settings.AsArguments();
            });
        }

        [Test]
        public void ShouldFailIfConfigurationFilesIsNull()
        {
            settings.ConfigurationFiles = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                settings.AsArguments();
            });
        }

        [Test]
        public void ShouldFailIfConfigurationFilesIsEmpty()
        {
            settings.ConfigurationFiles = new FilePathCollection();

            Assert.Throws<ArgumentException>(() =>
            {
                settings.AsArguments();
            });
        }

        [Test]
        public void ShouldRenderAnotherConfigurationFileInArguments()
        {
            settings.ConfigurationFiles.Add("javascript-client.yaml");

            var arguments = settings.AsArguments().Render();

            Assert.IsTrue(arguments.Contains(" javascript-client.yaml"));
        }

        [Test]
        public void ShouldRenderFailFastInArguments()
        {
            settings.FailFast = true;

            var arguments = settings.AsArguments().Render();

            Assert.IsTrue(arguments.Contains(" --fail-fast "));
        }

        [Test]
        public void ShouldRenderIncludesBaseDirectoryInArguments()
        {
            settings.IncludesBaseDirectory = "./baseDir";

            var arguments = settings.AsArguments().Render();

            Assert.IsTrue(arguments.Contains(" --includes-base-dir baseDir "));
        }

        [Test]
        public void ShouldRenderThreadCountInArguments()
        {
            settings.ThreadCount = 4;

            var arguments = settings.AsArguments().Render();

            Assert.IsTrue(arguments.Contains(" -r 4 "));
        }

        [Test]
        public void ShouldRenderRootDirectoryInArguments()
        {
            settings.RootDirectory = "./rootDir";

            var arguments = settings.AsArguments().Render();

            Assert.IsTrue(arguments.Contains(" --root-dir rootDir "));
        }

        [Test]
        public void ShouldRenderTimeoutInArguments()
        {
            settings.Timeout = TimeSpan.FromMinutes(3);

            var arguments = settings.AsArguments().Render();

            Assert.IsTrue(arguments.Contains(" --timeout 3 "));
        }

        [Test]
        public void ShouldRenderVerboseModeInArguments()
        {
            settings.Verbose = true;

            var arguments = settings.AsArguments().Render();

            Assert.IsTrue(arguments.Contains(" -v "));
        }
    }
}
