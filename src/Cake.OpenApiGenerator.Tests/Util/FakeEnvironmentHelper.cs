using Cake.Testing;

using System.Runtime.InteropServices;

namespace Cake.OpenApiGenerator.Util
{
    internal static class FakeEnvironmentHelper
    {
        public static FakeEnvironment CreateFromRuntime()
        {
            var architecture = RuntimeInformation.OSArchitecture;
            var is64Bit = architecture == Architecture.Arm64 || architecture == Architecture.X64;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return FakeEnvironment.CreateWindowsEnvironment(is64Bit);
            }
            else
            {
                return FakeEnvironment.CreateUnixEnvironment(is64Bit);
            }
        }
    }
}
