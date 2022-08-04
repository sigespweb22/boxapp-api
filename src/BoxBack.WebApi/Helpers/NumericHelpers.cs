using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace BoxBack.WebApi.Helpers
{
    public static class NumericHelpers
    {
        public static bool IsNumericType(this object o)
        {   
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                return true;
                default:
                return false;
            }
        }

        public static bool HasNumber(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    return true;
                }
            }

            return false;
        }

        private static (int Start, int Length) GetNumberPosition(string s)
        {
            var start = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    start = i;
                    break;
                }
            }

            for (int i = start + 1; i < s.Length; i++)
            {
                if (!char.IsDigit(s[i]))
                {
                    return (start, i - start);
                }
            }

            return (start, s.Length - start);
            
        }
    }
}