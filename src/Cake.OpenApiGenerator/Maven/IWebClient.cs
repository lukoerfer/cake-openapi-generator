using System;
using System.IO;

namespace Cake.OpenApiGenerator.Maven
{
    public interface IWebClient
    {
        Stream OpenRead(string path);
    }

}
