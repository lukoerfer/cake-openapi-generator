using System;
using System.IO;

namespace Cake.OpenApiGenerator.Maven
{
    /// <summary>
    /// Encapsulates the functionality to read resources from the web
    /// </summary>
    public interface IWebClient
    {
        /// <summary>
        /// Opens a stream that reads from a resource
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Stream OpenRead(string path);
    }

}
