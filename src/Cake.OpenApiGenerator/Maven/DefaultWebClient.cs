using System.Net;

namespace Cake.OpenApiGenerator.Maven
{
    /// <summary>
    /// Implements the functionality to read resources from the web using the default <see cref="WebClient"/>
    /// </summary>
    public class DefaultWebClient : WebClient, IWebClient { }
}
