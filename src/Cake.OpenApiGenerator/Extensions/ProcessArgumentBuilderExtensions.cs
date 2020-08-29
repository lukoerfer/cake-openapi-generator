using Cake.Core;
using Cake.Core.IO;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Cake.OpenApiGenerator.Extensions
{
    internal static class ProcessArgumentBuilderExtensions
    {
        public static ProcessArgumentBuilder AppendOptionalSwitch(this ProcessArgumentBuilder arguments, string option, bool enabled)
        {
            if (enabled)
            {
                arguments.Append(option);
            }
            return arguments;
        }

        public static ProcessArgumentBuilder AppendOptionalSwitch<T>(this ProcessArgumentBuilder arguments, string @switch, T value, Converter<T, string> converter = null) where T : class
        {
            converter = converter ?? (input => input.ToString());
            if (value != null && !(value is ICollection collection && collection.Count == 0))
            {
                arguments.AppendSwitch(@switch, converter(value));
            }
            return arguments;
        }

        public static ProcessArgumentBuilder AppendOptionalSwitch<T>(this ProcessArgumentBuilder arguments, string @switch, T? optional, Converter<T, string> converter = null) where T : struct
        {
            converter = converter ?? (input => input.ToString());
            if (optional.HasValue)
            {
                arguments.AppendSwitch(@switch, converter(optional.Value));
            }
            return arguments;
        }

        public static ProcessArgumentBuilder AppendRange<T>(this ProcessArgumentBuilder arguments, IEnumerable<T> values, Converter<T, string> converter = null) where T : class
        {
            converter = converter ?? (input => input.ToString());
            if (values != null)
            {
                foreach (T value in values)
                {
                    arguments.Append(converter.Invoke(value));
                }
            }
            return arguments;
        }

    }
}
