using System;

namespace IntToOrdinal
{
    public static class IntExtensions
    {
        public static string ToOrdinal(this int number, string language = "en", FormatStyle formatStyle = FormatStyle.Short)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number), "Index out of range (0-99)");

            return Convert.ToUInt32(number).ToOrdinal(language, formatStyle);
        }
    }
}