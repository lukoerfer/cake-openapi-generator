using Cake.Core;

namespace Cake.CodeGen.OpenApi.Internal.Tools
{
    internal abstract class Tool
    {
        public abstract bool IsProvided { get; }

        public abstract bool SupportsVersion { get; }

        public abstract bool SupportsEndpoint { get; }

        protected readonly ICakeContext Context;

        protected readonly OpenApiGeneratorSettings Settings;

        protected Tool(ICakeContext context, OpenApiGeneratorSettings settings)
        {
            Context = context;
            Settings = settings;
        }

        public abstract void Generate(OpenApiGenerateOptions options);

        public abstract void Validate(OpenApiValidateOptions options);
    }
}
