using System;

namespace Cake.OpenApi
{
    /// <summary>
    /// 
    /// </summary>
    public class OpenApiGeneratorSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public string Tool { get; set; }

        internal bool IsToolRequested => string.IsNullOrWhiteSpace(Tool);

        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }

        internal bool IsVersionRequested => string.IsNullOrWhiteSpace(Version);

        /// <summary>
        /// 
        /// </summary>
        public Uri Endpoint { get; set; }

        internal bool IsEndpointRequested => Endpoint != null;

    }
}
