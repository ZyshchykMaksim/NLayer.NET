using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace NLayer.Common.Extensions
{
    /// <summary>
    /// Enum extensions.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns description of enum value.
        /// </summary>
        public static string Description(this Enum enumValue)
        {
            Type enumType = enumValue.GetType();
            FieldInfo field = enumType.GetField(enumValue.ToString());
            object[] attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length == 0 ?
                enumValue.ToString() :
                ((DescriptionAttribute)attributes[0]).Description;
        }

        /// <summary>
        /// Returns array of descriptions retrieved from flag enum values.
        /// </summary>
        public static IList<string> GetFlagEnumDescriptions(this Enum target)
        {
            return target.GetFlags().Select(f => f.Description()).ToList();
        }

        /// <summary>
        /// Gets the flags.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static IEnumerable<Enum> GetFlags(this Enum input)
        {
            return Enum.GetValues(input.GetType()).Cast<Enum>().Where(input.HasFlag);
        }

        /// <summary>
        /// Gets the collection enum.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static IList<string> ToList<T>(this Enum input)
        {
            if (!typeof(T).IsEnum)
            {
                return new List<string>();
            }
            return Enum.GetNames(typeof(T)).ToList();
        }

        /// <summary>
        /// Converted string value to enum.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="strEnumValue">The string value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static TEnum ToEnum<TEnum>(this string strEnumValue, TEnum defaultValue)
        {
            if (string.IsNullOrWhiteSpace(strEnumValue) || !Enum.IsDefined(typeof(TEnum), strEnumValue))
            {
                return defaultValue;
            }
            
            return (TEnum)Enum.Parse(typeof(TEnum), strEnumValue);
        }
    }
}
