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
                ToolPackageFile = new FilePath("/path/to/package.jar")
            };
            settings.ConfigurationFiles.Add("configuration.json");
        }

        [Test]
        public void ShouldFailIfPackageFileNull()
        {
            settings.ToolPackageFile = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                settings.AsArguments();
            });
        }

        [Test]
        public void ShouldFailIfConfigurationFilesNull()
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
        public void ShouldHaveConfigurationFileInArguments()
        {
            var arguments = settings.AsArguments();


        }

        [Test]
        public void ShouldHaveConfigurationFilesInArguments()
        {
            settings.ConfigurationFiles.Add("secondConfig.json");

            var arguments = settings.AsArguments();
        }
    }
}
