using Cake.Common.Diagnostics;
using Cake.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.OpenApi.Internal.Tools
{
    internal class ToolResolution
    {
        private readonly ICakeContext _context;

        private readonly OpenApiSettings _settings;

        private readonly Dictionary<string, Func<Tool>> _factory;

        private ToolResolution(ICakeContext context, OpenApiSettings settings)
        {
            _context = context;
            _settings = settings;
            _factory = new Dictionary<string, Func<Tool>>()
            {
                { "installed", () => new InstalledTool(context, settings) },
                { "bash", () => new BashScriptTool(context, settings) },
                { "node", () => new NodeTool(context, settings) },
                { "java", () => new JavaTool(context, settings) },
                { "rest", () => new RestApiTool(context, settings) },
                { "online", () => new OnlineTool(context, settings) }
            };
        }

        public static ToolResolution Setup(ICakeContext context, OpenApiSettings settings)
        {
            return new ToolResolution(context, settings);
        }

        public Tool Get()
        {
            Tool generator = _settings.IsToolRequested ? GetRequested() : GetSuitable();
            if (_settings.IsVersionRequested && !generator.SupportsVersion)
            {
                _context.Warning("The selected OpenAPI tool may not fulfill the requested version!");
            }
            if (_settings.IsEndpointRequested && !generator.SupportsEndpoint)
            {
                _context.Warning("The selected OpenAPI tool won't use the requested endpoint!");
            }
            return generator;
        }

        private Tool GetRequested()
        {
            if (_factory.TryGetValue(_settings.Tool, out Func<Tool> creator))
            {
                _context.Information($"Using requested OpenAPI generator tool '{_settings.Tool}'");
                return creator.Invoke();
            }
            else
            {
                throw new ArgumentOutOfRangeException("tool", _settings.Tool, "Unknown OpenAPI tool was requested");
            }
        }

        private Tool GetSuitable()
        {
            IEnumerable<Tool> generators = _factory.Values.Select(creator => creator.Invoke());
            if (_settings.IsEndpointRequested)
            {
                generators = generators.OrderBy(generator => generator.SupportsEndpoint);
            }
            if (_settings.IsVersionRequested)
            {
                generators = generators.OrderBy(generator => generator.SupportsVersion);
            }
            return generators.First(generator => generator.IsProvided);
        }

    }
}
