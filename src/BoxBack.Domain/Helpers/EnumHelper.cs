using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BoxBack.Domain.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription<T>(this T enumValue) 
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return null;

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }

        public static IList<string> GetNames<T>() 
            where T : struct, Enum
        {
            return Enum.GetNames(typeof(T)).ToList();
        }

        public static T Parse<T>(string value)
            where T : struct, Enum
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}