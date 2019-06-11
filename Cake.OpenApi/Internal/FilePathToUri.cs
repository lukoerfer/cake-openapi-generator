using System;

using Cake.Core.IO;

namespace Cake.OpenApi.Internal
{
    internal static class FilePathToUri
    {
        public static Uri ToUri(this FilePath filePath)
        {
            return new Uri(filePath.FullPath, UriKind.RelativeOrAbsolute);
        }
    }
}
