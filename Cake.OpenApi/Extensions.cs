using System;

using Cake.Core.IO;

namespace Cake.OpenApi
{
    internal static class Extensions
    {
        public static Uri ToUri(this FilePath filePath)
        {
            return new Uri(filePath.FullPath, UriKind.RelativeOrAbsolute);
        }
    }
}
