using Cake.Core;

namespace Cake.OpenApi.Internal
{
    internal abstract class Tool
    {
        public abstract bool IsProvided { get; }

        public abstract bool SupportsVersion { get; }

        public abstract bool SupportsEndpoint { get; }


        protected readonly ICakeContext _context;

        protected readonly OpenApiSettings _settings;

        protected Tool(ICakeContext context, OpenApiSettings settings)
        {
            _context = context;
            _settings = settings;
        }

        public abstract void Generate(OpenApiGenerateOptions options);

        public abstract void Validate(OpenApiValidateOptions options);
    }
}
