using Cake.Core;
using Cake.Core.IO;

using System;
using System.Collections.Generic;

namespace Cake.OpenApiGenerator
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

        public static ProcessArgumentBuilder AppendOptionalSwitch<T>
        (
            this ProcessArgumentBuilder arguments,
            string @switch,
            T value,
            string separator = " ",
            Predicate<T> condition = null,
            Converter<T, string> converter = null
        )
            where T : class
        {
            converter = converter ?? (input => input.ToString());
            condition = condition ?? (input => true);
            if (value != null && condition(value))
            {
                arguments.AppendSwitch(@switch, separator, converter(value));
            }
            return arguments;
        }

        public static ProcessArgumentBuilder AppendOptionalSwitch<T>
        (
            this ProcessArgumentBuilder arguments,
            string @switch,
            T? optional,
            string separator = " ",
            Predicate<T> isDefined = null,
            Converter<T, string> converter = null
        )
            where T : struct
        {
            converter = converter ?? (input => input.ToString());
            isDefined = isDefined ?? (input => true);
            if (optional.HasValue && isDefined(optional.Value))
            {
                arguments.AppendSwitch(@switch, separator, converter(optional.Value));
            }
            return arguments;
        }

        public static ProcessArgumentBuilder AppendRange<T>
        (
            this ProcessArgumentBuilder arguments,
            IEnumerable<T> values,
            Converter<T, string> converter = null
        )
            where T : class
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
