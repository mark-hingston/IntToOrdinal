using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace IntToOrdinal.Languages
{
    public class En : ILanguage
    {
        private const string Th = "th";
        private const string Teenth = "teenth";
        private const string Thir = "thir";
        private const string Nine = "nine";
        private const string Twen = "twen";
        private const string Tieth = "tieth";
        private const string Ty = "ty";
        private const string Hyphen = "-";

        private readonly IDictionary<uint, string> _endings = new Dictionary<uint, string>()
        {
            {0, Th},
            {1, "st"},
            {2, "nd"},
            {3, "rd"},
            {4, Th},
            {5, Th},
            {6, Th},
            {7, Th},
            {8, Th},
            {9, Th}
        };

        private readonly IDictionary<uint, string> _prefixes = new Dictionary<uint, string>()
        {
            {0, "zero"},
            {1, "fir"},
            {2, "seco"},
            {3, "thi"},
            {4, "four"},
            {5, "fif"},
            {6, "six"},
            {7, "seven"},
            {8, "eigh"},
            {9, "nin"},
            {10, "ten"},
            {11, "eleven"},
            {12, "twelf"}
        };

        public string GetOrdinal(uint number)
        {
            var numberString = number.ToString();
            var ending = _endings[number % 10];

            if (Regex.IsMatch(numberString, "1[123]$"))
            {
                ending = Th;
            }

            return $"{number}{ending}";
        }

        public string GetFullOrdinal(uint number, bool hyphenate = false)
        {
            var hyphen = hyphenate ? Hyphen : "";
            var numberString = number.ToString();
            var prefix = _prefixes[number % 10];
            var ending = _endings[number % 10];

            if (Regex.IsMatch(numberString, @"1\d$"))
            {
                if (Regex.IsMatch(numberString, "1[0-2]$"))
                {
                    prefix = _prefixes[number];
                    ending = Th;
                }

                else if (Regex.IsMatch(numberString, "[13|19]$"))
                {
                    prefix = Regex.IsMatch(numberString, "13$") ? Thir : Nine;
                    ending = Teenth;
                }

                else
                {
                    prefix = _prefixes[number % 10];
                    ending = Teenth;
                }
            }

            else if (Regex.IsMatch(numberString, @"2\d$"))
            {
                if (Regex.IsMatch(numberString, @"20$"))
                {
                    prefix = Twen;
                    ending = Tieth;
                }

                else
                {
                    prefix = Regex.IsMatch(numberString, "9$") ? $"{Twen}{Ty}{hyphen}{Nine}" : $"{Twen}{Ty}{hyphen}{prefix}";
                }
            }

            else if (Regex.IsMatch(numberString, @"[3-9]\d$"))
            {
                if (Regex.IsMatch(numberString, @"[39]\d$"))
                {
                    prefix = Regex.IsMatch(numberString, @"3\d$") ? Thir : Nine;
                }

                else
                {
                    var substring = numberString.Substring(numberString.Length - 2, 1);
                    var index = uint.Parse(substring);
                    prefix = _prefixes[index];
                }

                if (Regex.IsMatch(numberString, @"\d0$"))
                {
                    ending = Tieth;
                }

                else
                {
                    var index = _prefixes[number % 10];
                    prefix = Regex.IsMatch(numberString, "9$") ? $"{prefix}{Ty}{hyphen}{Nine}" : $"{prefix}{Ty}{hyphen}{index}";
                }
            }

            return $"{prefix}{ending}";
        }
    }
}
