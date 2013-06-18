using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    public class DataConverter
    {
        public static bool ToBoolean(string input)
        {
            bool flag = false;
            if (string.IsNullOrEmpty(input))
            {
                return flag;
            }
            input = input.Trim();
            if (((string.Compare(input, "true", StringComparison.OrdinalIgnoreCase) != 0) && (string.Compare(input, "yes", StringComparison.OrdinalIgnoreCase) != 0)) && (string.Compare(input, "1", StringComparison.OrdinalIgnoreCase) != 0))
            {
                return flag;
            }
            return true;
        }

        public static DateTime ToDate(object input)
        {
            if (!Convert.IsDBNull(input) && !object.Equals(input, null))
            {
                return ToDate(input.ToString());
            }
            return DateTime.Now;
        }

        public static DateTime ToDate(string input)
        {
            DateTime now;
            if (!DateTime.TryParse(input, out now))
            {
                now = DateTime.Now;
            }
            return now;
        }

        public static DateTime? ToDate(string input, DateTime? outTime)
        {
            DateTime time;
            if (!DateTime.TryParse(input, out time))
            {
                return outTime;
            }
            return new DateTime?(time);
        }

        public static string ToDateString(string input)
        {
            DateTime time;
            if (!DateTime.TryParse(input, out time))
            {
                return string.Empty;
            }
            return time.ToString("yyyy-MM-dd");
        }

        public static decimal ToDecimal(object input)
        {
            return ToDecimal(input, 0M);
        }

        public static decimal ToDecimal(string input)
        {
            return ToDecimal(input, 0M);
        }

        public static decimal ToDecimal(object input, decimal defaultValue)
        {
            if (!Convert.IsDBNull(input) && !object.Equals(input, null))
            {
                return ToDecimal(input.ToString(), defaultValue);
            }
            return 0M;
        }

        public static decimal ToDecimal(string input, decimal defaultValue)
        {
            decimal num;
            if (!decimal.TryParse(input, out num))
            {
                num = defaultValue;
            }
            return num;
        }

        public static double ToDouble(object input)
        {
            return ToDouble(input, 0.0);
        }

        public static double ToDouble(string input)
        {
            return ToDouble(input, 0.0);
        }

        public static double ToDouble(object input, double defaultValue)
        {
            if (!Convert.IsDBNull(input) && !object.Equals(input, null))
            {
                return ToDouble(input.ToString(), defaultValue);
            }
            return 0.0;
        }

        public static double ToDouble(string input, double defaultValue)
        {
            double num;
            if (!double.TryParse(input, out num))
            {
                return defaultValue;
            }
            return num;
        }

        public static int ToLng(object input)
        {
            return ToLng(input, 0);
        }

        public static int ToLng(string input)
        {
            return ToLng(input, 0);
        }

        public static int ToLng(object input, int defaultValue)
        {
            if (!Convert.IsDBNull(input) && !object.Equals(input, null))
            {
                return ToLng(input.ToString(), defaultValue);
            }
            return defaultValue;
        }

        public static int ToLng(string input, int defaultValue)
        {
            int num;
            if (!int.TryParse(input, out num))
            {
                num = defaultValue;
            }
            return num;
        }

        public static float ToSingle(object input)
        {
            return ToSingle(input, 0f);
        }

        public static float ToSingle(string input)
        {
            return ToSingle(input, 0f);
        }

        public static float ToSingle(object input, float defaultValue)
        {
            if (!Convert.IsDBNull(input) && !object.Equals(input, null))
            {
                return ToSingle(input.ToString(), defaultValue);
            }
            return 0f;
        }

        public static float ToSingle(string input, float defaultValue)
        {
            float num;
            if (!float.TryParse(input, out num))
            {
                num = defaultValue;
            }
            return num;
        }
    }


}
