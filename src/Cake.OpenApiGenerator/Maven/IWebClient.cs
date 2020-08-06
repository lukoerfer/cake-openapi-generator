using System;
using System.IO;

namespace Cake.OpenApiGenerator.Maven
{
    /// <summary>
    /// Encapsulates the functionality to read web resources
    /// </summary>
    public interface IWebClient
    {
        Stream OpenRead(string path);
    }

}
