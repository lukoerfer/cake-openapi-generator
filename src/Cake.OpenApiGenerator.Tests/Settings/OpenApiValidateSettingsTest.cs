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
        public void ShouldFailIfSpecificationFileNull()
        {
            var settings = new OpenApiValidateSettings()
            {
                SpecificationFile = null
            };

            Assert.Throws<ArgumentNullException>(() =>
            {
                settings.AsArguments();
            });
        }

        [Test]
        public void ShouldHaveSpecificationFileInArguments()
        {
            var settings = new OpenApiValidateSettings()
            {
                SpecificationFile = specificationFile
            };

            var arguments = settings.AsArguments();

            
        }
    }
}
