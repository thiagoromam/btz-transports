using System;
using System.Globalization;

namespace General.Helpers
{
    public static class IntHelper
    {
        public static bool TryParse(this string value, out int result, IFormatProvider provider = null)
        {
            return int.TryParse(value, NumberStyles.Integer, provider, out result);
        }

        public static int ToIntOrZero(this string value, IFormatProvider provider = null)
        {
            value.TryParse(out int result, provider);
            return result;
        }
    }
}
