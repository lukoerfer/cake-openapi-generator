using System;
using System.IO;

namespace Cake.OpenApiGenerator.Internal
{
    internal interface IWebClient
    {
        Stream OpenRead(string resource);
    }

}
