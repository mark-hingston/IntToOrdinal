using System;
using System.ComponentModel;
using System.Reflection;

namespace IntToOrdinal
{
    public static class UIntExtensions
    {
        public static string ToOrdinal(this uint number, string language = "en", FormatStyle formatStyle = FormatStyle.Short)
        {
            if (number > 99)
                throw new ArgumentOutOfRangeException(nameof(number), "Index out of range (0-99)");

            var instance = GetLanguage(language);

            var result = "";

            switch (formatStyle)
            {
                case FormatStyle.Short:
                    result = instance.GetOrdinal(number);
                    break;
                case FormatStyle.Full:
                    instance.GetFullOrdinal(number);
                    break;
                case FormatStyle.FullHyphenated:
                    instance.GetFullOrdinal(number, true);
                    break;
                default:
                    throw new InvalidEnumArgumentException($"Invalid {nameof(FormatStyle)}: {formatStyle}");
            }

            return result;
        }

        private static ILanguage GetLanguage(string language)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType($"{nameof(IntToOrdinal)}.{nameof(Languages)}.{language}", true, true);
            var instance = (ILanguage)Activator.CreateInstance(type);
            return instance;
        }
    }
}
