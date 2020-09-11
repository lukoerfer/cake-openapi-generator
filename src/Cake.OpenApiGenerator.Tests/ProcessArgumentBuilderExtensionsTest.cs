using Cake.Core.IO;

using NUnit.Framework;

namespace Cake.OpenApiGenerator
{
    public class ProcessArgumentBuilderExtensionsTest
    {
        private ProcessArgumentBuilder args;

        [SetUp]
        public void Setup()
        {
            args = new ProcessArgumentBuilder();
        }

        [Test]
        public void AppendOptionalSwitch_EnabledTrue_ContainsOption()
        {
            args.AppendOptionalSwitch("--option", true);

            Assert.IsTrue(args.Render().Contains("--option"));
        }

        [Test]
        public void AppendOptionalSwitch_EnabledFalse_DoesNotContainOption()
        {
            args.AppendOptionalSwitch("--option", false);

            Assert.IsFalse(args.Render().Contains("--option"));
        }

        [Test]
        public void AppendOptionalSwitch_StringValue_ContainsSwitchAndValue()
        {
            args.AppendOptionalSwitch("--switch", "value");

            Assert.IsTrue(args.Render().Contains("--switch value"));
        }

        [Test]
        public void AppendOptionalSwitch_FilePathValue_ContainsSwitchAndValue()
        {
            args.AppendOptionalSwitch("--switch", new FilePath("example.xml"));

            Assert.IsTrue(args.Render().Contains("--switch example.xml"));
        }

        [Test]
        public void AppendRange_NoArguments_RendersEmpty()
        {
            args.AppendRange(new string[0]);

            Assert.AreEqual(args.Render(), string.Empty);
        }

        [Test]
        public void AppendRange_OneArgument_RendersArgument()
        {
            args.AppendRange(new string[] { "switch1" });

            Assert.IsTrue(args.Render().Contains("switch"));
        }

        [Test]
        public void AppendRange_TwoArguments_RendersBothArguments()
        {
            args.AppendRange(new string[] { "switch1", "switch2" });

            Assert.IsTrue(args.Render().Contains("switch1 switch2"));
        }
    }
}
