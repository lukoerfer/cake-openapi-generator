using System;
using System.Collections.Generic;
using System.Linq;

using Cake.Core;
using Cake.Common.Diagnostics;

namespace Cake.OpenApi.Internal.Tools
{
    internal class ToolResolution
    {
        private readonly ICakeContext Context;

        private readonly OpenApiSettings Settings;

        private readonly Dictionary<string, Func<Tool>> Factory;

        private ToolResolution(ICakeContext context, OpenApiSettings settings)
        {
            Context = context;
            Settings = settings;
            Factory = new Dictionary<string, Func<Tool>>()
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

        public Tool GetTool()
        {
            Tool tool = Settings.IsToolRequested ? GetRequestedTool() : GetSuitableTool();
            if (Settings.IsVersionRequested && !tool.SupportsVersion)
            {
                Context.Warning("The selected OpenAPI tool may not fulfill the requested version!");
            }
            if (Settings.IsEndpointRequested && !tool.SupportsEndpoint)
            {
                Context.Warning("The selected OpenAPI tool won't use the requested endpoint!");
            }
            return tool;
        }

        private Tool GetRequestedTool()
        {
            if (Factory.TryGetValue(Settings.Tool, out Func<Tool> creator))
            {
                Context.Information($"Using requested OpenAPI generator tool '{Settings.Tool}'");
                return creator.Invoke();
            }
            else
            {
                throw new ArgumentOutOfRangeException("tool", Settings.Tool, "Unknown OpenAPI tool was requested");
            }
        }

        private Tool GetSuitableTool()
        {
            IEnumerable<Tool> generators = Factory.Values.Select(creator => creator.Invoke());
            if (Settings.IsEndpointRequested)
            {
                generators = generators.OrderBy(generator => generator.SupportsEndpoint);
            }
            if (Settings.IsVersionRequested)
            {
                generators = generators.OrderBy(generator => generator.SupportsVersion);
            }
            return generators.First(generator => generator.IsProvided);
        }

    }
}
