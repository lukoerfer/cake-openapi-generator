using FakeItEasy;

using NUnit.Framework;

using System;

namespace Cake.OpenApiGenerator.Settings
{
    [TestFixture]
    class OpenApiGeneratorGenerateSettingsTest
    {
        private OpenApiGeneratorGenerateSettings settings;

        [SetUp]
        public void Setup()
        {
            settings = new OpenApiGeneratorGenerateSettings()
            {
                ToolPackageFile = "package.jar",
                Specification = "petstore.yaml",
                Generator = "csharp",
                OutputDirectory = "./src"
            };
        }

        [Test]
        public void ShouldRenderArgumentsFromRequiredParameters()
        {
            var arguments = settings.AsArguments().Render();

            Assert.AreEqual("-jar package.jar generate -i petstore.yaml -g csharp -o src", arguments);
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
        public void ShouldFailIfSpecificationIsNull()
        {
            settings.Specification = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                settings.AsArguments();
            });
        }

        [Test]
        public void ShouldFailIfGeneratorIsNull()
        {
            settings.Generator = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                settings.AsArguments();
            });
        }

        [Test]
        public void ShouldFailIfOutputDirectoryIsNull()
        {
            settings.OutputDirectory = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                settings.AsArguments();
            });
        }

        [Test]
        public void ShouldRenderAuthorizationInArguments()
        {
            settings.Authorization = "Authorization%3A%20Basic%20QWxhZGRpbjpPcGVuU2VzYW1l";

            var arguments = settings.AsArguments().Render();

            Assert.IsTrue(arguments.Contains(" -a Authorization%3A%20Basic%20QWxhZGRpbjpPcGVuU2VzYW1l"));
        }

        [Test]
        public void ShouldRenderApiNameSuffixInArguments()
        {
            settings.ApiNameSuffix = "Api";

            var arguments = settings.AsArguments().Render();

            Assert.IsTrue(arguments.Contains(" --api-name-suffix Api"));
        }

        [Test]
        public void ShouldRenderApiPackageInArguments()
        {
            settings.ApiPackage = "ApiPackage";

            var arguments = settings.AsArguments().Render();

            Assert.IsTrue(arguments.Contains(" --api-package ApiPackage"));
        }

        [Test]
        public void ShouldRenderArtifactIdInArguments()
        {

        }
    }
}
