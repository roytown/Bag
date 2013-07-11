using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Util
{
    public class DataValidator
    {

        public static bool IsAreaCode(string input)
        {
            return ((IsNumber(input) && (input.Length >= 3)) && (input.Length <= 5));
        }

        public static bool IsDecimal(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return Regex.IsMatch(input, @"^[0-9]+(\.[0-9]+)?$");
        }

        public static bool IsDecimalSign(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return Regex.IsMatch(input, @"^[+-]?[0-9]+(\.[0-9]+)?$");
        }

        public static bool IsEmail(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return Regex.IsMatch(input, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

        public static bool IsIP(string input)
        {
            return (!string.IsNullOrEmpty(input) && Regex.IsMatch(input.Trim(), @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$"));
        }

        public static bool IsNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return Regex.IsMatch(input, "^[0-9]+$");
        }

        public static bool IsNumberSign(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return Regex.IsMatch(input, "^[+-]?[0-9]+$");
        }

        public static bool IsPostCode(string input)
        {
            return (IsNumber(input) && (input.Length == 6));
        }

        public static bool IsUrl(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return Regex.IsMatch(input, @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$", RegexOptions.IgnoreCase);
        }

        public static bool IsValidId(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            input = input.Replace("|", string.Empty).Replace(",", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty).Trim();
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return IsNumber(input);
        }

        public static bool IsValid(string input,string pattern)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern))
            {
                return false;
            }

            return Regex.IsMatch(input, pattern);
        }

    }
}
