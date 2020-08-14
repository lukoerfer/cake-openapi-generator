using Cake.Core.IO;
using NUnit.Framework;
using System;
using System.Linq;

namespace Cake.OpenApiGenerator.Settings
{
    [TestFixture]
    class OpenApiValidateSettingsTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ShouldFailIfSpecificationNull()
        {
            var settings = new OpenApiGeneratorValidateSettings()
            {
                Specification = null
            };

            Assert.Throws<ArgumentNullException>(() =>
            {
                settings.AsArguments();
            });
        }

        [Test]
        public void ShouldHaveSpecificationInArguments()
        {

        }
    }
}
