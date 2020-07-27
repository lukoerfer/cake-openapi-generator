using System;
using System.IO;

namespace Cake.OpenApiGenerator.Maven
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWebClient
    {
        Stream OpenRead(string path);
    }

}
