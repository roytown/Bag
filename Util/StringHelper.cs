using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Globalization;
using Microsoft.VisualBasic;
using System.Web;
using System.IO;
namespace Util
{
    public enum FilterOptions
    {
        HoldChinese = 4,
        HoldLetter = 2,
        HoldNumber = 1,
        SBCToDBC = 8
    }

    public static class StringHelper
    {
        
        private static readonly char[] RandChar = new char[] { 
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 
        'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 
        'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 
        'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };
        // Methods
        public static void AppendString(StringBuilder sb, string append)
        {
            AppendString(sb, append, ",");
        }

        public static void AppendString(StringBuilder sb, string append, string split)
        {
            if (sb.Length == 0)
            {
                sb.Append(append);
            }
            else
            {
                sb.Append(split);
                sb.Append(append);
            }
        }

        public static string Base64StringDecode(string input)
        {
            byte[] bytes = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string Base64StringEncode(string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        }

        public static string CollectionFilter(string conStr, string tagName, int filterType)
        {
            string input = conStr;
            switch (filterType)
            {
                case 1:
                    return Regex.Replace(input, "<" + tagName + "([^>])*>", string.Empty, RegexOptions.IgnoreCase);

                case 2:
                    return Regex.Replace(input, "<" + tagName + "([^>])*>.*?</" + tagName + "([^>])*>", string.Empty, RegexOptions.IgnoreCase);

                case 3:
                    return Regex.Replace(Regex.Replace(input, "<" + tagName + "([^>])*>", string.Empty, RegexOptions.IgnoreCase), "</" + tagName + "([^>])*>", string.Empty, RegexOptions.IgnoreCase);
            }
            return input;
        }

        public static string CopyString(string returnStr)
        {
            if (returnStr.Contains("£­¸´ÖÆ"))
            {
                if (returnStr.Contains("£­¸´ÖÆ("))
                {
                    Regex regex = new Regex(@"^.*[/£­]¸´ÖÆ[/(](\d)+[/)]$");
                    if (regex.IsMatch(returnStr))
                    {
                        return (CopyStringNum(returnStr.Remove(returnStr.Length - 1)) + ")");
                    }
                    return (returnStr + "£­¸´ÖÆ");
                }
                return (returnStr + "(2)");
            }
            return (returnStr + "£­¸´ÖÆ");
        }

        public static string CopyStringNum(string returnStr)
        {
            int length = 0;
            foreach (char ch in returnStr)
            {
                if (char.IsDigit(ch))
                {
                    length++;
                }
                else
                {
                    length = 0;
                }
            }
            if (length == 0)
            {
                return (returnStr + "1");
            }
            int num2 = DataConverter.ToLng(returnStr.Substring(returnStr.Length - length, length)) + 1;
            return (returnStr.Remove(returnStr.Length - length, length) + num2.ToString(CultureInfo.CurrentCulture));
        }

        public static string DecodeIP(long ip)
        {
            string[] strArray = new string[] { ((ip >> 0x18) & 0xffL).ToString(CultureInfo.CurrentCulture), ".", ((ip >> 0x10) & 0xffL).ToString(CultureInfo.CurrentCulture), ".", ((ip >> 8) & 0xffL).ToString(CultureInfo.CurrentCulture), ".", (ip & 0xffL).ToString(CultureInfo.CurrentCulture) };
            return string.Concat(strArray);
        }

        public static string DecodeLockIP(string lockIP)
        {
            StringBuilder builder = new StringBuilder(0x100);
            if (!string.IsNullOrEmpty(lockIP))
            {
                try
                {
                    string[] strArray = lockIP.Split(new string[] { "$$$" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        string[] strArray2 = strArray[i].Split(new string[] { "----" }, StringSplitOptions.RemoveEmptyEntries);
                        builder.Append(DecodeIP(Convert.ToInt64(strArray2[0], CultureInfo.CurrentCulture)) + "----" + DecodeIP(Convert.ToInt64(strArray2[1], CultureInfo.CurrentCulture)) + "\n");
                    }
                    return builder.ToString().TrimEnd(new char[] { '\n' });
                }
                catch (IndexOutOfRangeException)
                {
                    return builder.ToString();
                }
            }
            return builder.ToString();
        }

        public static double EncodeIP(string sip)
        {
            if (string.IsNullOrEmpty(sip))
            {
                return 0.0;
            }
            string[] strArray = sip.Split(new char[] { '.' });
            long num = 0L;
            foreach (string str in strArray)
            {
                byte num2;
                if (byte.TryParse(str, out num2))
                {
                    num = (num << 8) | num2;
                }
                else
                {
                    return 0.0;
                }
            }
            return (double)num;
        }

        public static string EncodeLockIP(string iplist)
        {
            StringBuilder builder = new StringBuilder(0x100);
            if (!string.IsNullOrEmpty(iplist.Trim()))
            {
                string[] strArray = iplist.Split(new char[] { '\n' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (!string.IsNullOrEmpty(strArray[i]) && strArray[i].Contains("----"))
                    {
                        string[] strArray2 = strArray[i].Split(new string[] { "----" }, StringSplitOptions.RemoveEmptyEntries);
                        if (strArray2.Length < 2)
                        {
                            throw new ArgumentException("ÇëÌîÐ´ÕýÈ·ÍøÕ¾ºÚ°×Ãûµ¥ÖÐµÄIPµØÖ·£¡");
                        }
                        if (!DataValidator.IsIP(strArray2[0]) || !DataValidator.IsIP(strArray2[1]))
                        {
                            throw new ArgumentException("ÇëÌîÐ´ÕýÈ·ÍøÕ¾ºÚ°×Ãûµ¥ÖÐµÄIPµØÖ·£¡");
                        }
                        if (i == 0)
                        {
                            builder.Append(EncodeIP(strArray2[0]) + "----" + EncodeIP(strArray2[1]));
                        }
                        else
                        {
                            builder.Append(string.Concat(new object[] { "$$$", EncodeIP(strArray2[0]), "----", EncodeIP(strArray2[1]) }));
                        }
                    }
                }
            }
            return builder.ToString();
        }

        public static string FilterInvalidChar(string str, FilterOptions options)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            StringBuilder builder = new StringBuilder(str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                int num2 = str[i];
                if (((num2 >= 0x30) && (num2 <= 0x39)) && ((FilterOptions.HoldNumber & options) == FilterOptions.HoldNumber))
                {
                    builder.Append(str[i]);
                }
                else if ((((num2 >= 0x41) && (num2 <= 90)) || ((num2 >= 0x61) && (num2 <= 0x7a))) && ((FilterOptions.HoldLetter & options) == FilterOptions.HoldLetter))
                {
                    builder.Append(str[i]);
                }
                else if (((num2 >= 0x4e00) && (num2 <= 0x9fa5)) && ((FilterOptions.HoldChinese & options) == FilterOptions.HoldChinese))
                {
                    builder.Append(str[i]);
                }
                else if (((((num2 >= 0xff10) && (num2 <= 0xff19)) || ((num2 >= 0xff21) && (num2 <= 0xff3a))) || ((num2 >= 0xff41) && (num2 <= 0xff5a))) && ((FilterOptions.SBCToDBC & options) == FilterOptions.SBCToDBC))
                {
                    builder.Append((char)(num2 - 0xfee0));
                }
            }
            return builder.ToString();
        }

        public static string FilterScript(string conStr, string filterItem)
        {
            string str = conStr.Replace("\r", "{$Chr13}").Replace("\n", "{$Chr10}");
            foreach (string str2 in filterItem.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                switch (str2)
                {
                    case "Iframe":
                        str = CollectionFilter(str, str2, 2);
                        break;

                    case "Object":
                        str = CollectionFilter(str, str2, 2);
                        break;

                    case "Script":
                        str = CollectionFilter(str, str2, 2);
                        break;

                    case "Style":
                        str = CollectionFilter(str, str2, 2);
                        break;

                    case "Div":
                        str = CollectionFilter(str, str2, 3);
                        break;

                    case "Span":
                        str = CollectionFilter(str, str2, 3);
                        break;

                    case "Table":
                        str = CollectionFilter(CollectionFilter(CollectionFilter(CollectionFilter(CollectionFilter(str, str2, 3), "Tbody", 3), "Tr", 3), "Td", 3), "Th", 3);
                        break;

                    case "Img":
                        str = CollectionFilter(str, str2, 1);
                        break;

                    case "Font":
                        str = CollectionFilter(str, str2, 3);
                        break;

                    case "A":
                        str = CollectionFilter(str, str2, 3);
                        break;

                    case "Html":
                        str = StripTags(str);
                        if (!string.IsNullOrEmpty(str))
                        {
                            str = str.Replace("{$Chr13}", string.Empty).Replace("{$Chr10}", string.Empty).Trim();
                        }
                        goto Label_022D;
                }
            }
        Label_022D:
            return str.Replace("{$Chr13}", "\r").Replace("{$Chr10}", "\n");
        }

        public static bool FoundCharInArr(string checkStr, string findStr)
        {
            return FoundCharInArr(checkStr, findStr, ",");
        }

        public static bool FoundCharInArr(string checkStr, string findStr, string split)
        {
            bool flag = false;
            if (string.IsNullOrEmpty(split))
            {
                split = ",";
            }
            if (!string.IsNullOrEmpty(checkStr))
            {
                if (string.IsNullOrEmpty(checkStr))
                {
                    return flag;
                }
                checkStr = split + checkStr + split;
                if (findStr.IndexOf(split, StringComparison.Ordinal) != -1)
                {
                    string[] strArray = findStr.Split(new char[] { Convert.ToChar(split, CultureInfo.CurrentCulture) });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (checkStr.Contains(split + strArray[i] + split))
                        {
                            return true;
                        }
                    }
                    return flag;
                }
                if (checkStr.Contains(split + findStr + split))
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static bool FoundStrInArr(string checkStr, string[] strArray,bool ignoreCase)
        {
            for (int i = 0; i < strArray.Length; i++)
            {
                if (string.Compare(checkStr,strArray[i],ignoreCase)==0)
                {
                    return true;
                }
            }
            return false;
        }

        private static string GetGbkX(char ch)
        {
            string strA = ch.ToString();
            if (string.Compare(strA, "ß¹", StringComparison.CurrentCulture) < 0)
            {
                return strA;
            }
            if (string.Compare(strA, "°Ë", StringComparison.CurrentCulture) < 0)
            {
                return "A";
            }
            if (string.Compare(strA, "àê", StringComparison.CurrentCulture) < 0)
            {
                return "B";
            }
            if (string.Compare(strA, "…ö", StringComparison.CurrentCulture) < 0)
            {
                return "C";
            }
            if (string.Compare(strA, "ŠŠ", StringComparison.CurrentCulture) < 0)
            {
                return "D";
            }
            if (string.Compare(strA, "·¢", StringComparison.CurrentCulture) < 0)
            {
                return "E";
            }
            if (string.Compare(strA, "ê¸", StringComparison.CurrentCulture) < 0)
            {
                return "F";
            }
            if (string.Compare(strA, "îþ", StringComparison.CurrentCulture) < 0)
            {
                return "G";
            }
            if (string.Compare(strA, "¼¥", StringComparison.CurrentCulture) < 0)
            {
                return "H";
            }
            if (string.Compare(strA, "ßÇ", StringComparison.CurrentCulture) < 0)
            {
                return "J";
            }
            if (string.Compare(strA, "À¬", StringComparison.CurrentCulture) < 0)
            {
                return "K";
            }
            if (string.Compare(strA, "‡`", StringComparison.CurrentCulture) < 0)
            {
                return "L";
            }
            if (string.Compare(strA, "’‚", StringComparison.CurrentCulture) < 0)
            {
                return "M";
            }
            if (string.Compare(strA, "àÞ", StringComparison.CurrentCulture) < 0)
            {
                return "N";
            }
            if (string.Compare(strA, "Šr", StringComparison.CurrentCulture) < 0)
            {
                return "O";
            }
            if (string.Compare(strA, "Æß", StringComparison.CurrentCulture) < 0)
            {
                return "P";
            }
            if (string.Compare(strA, "’", StringComparison.CurrentCulture) < 0)
            {
                return "Q";
            }
            if (string.Compare(strA, "Øí", StringComparison.CurrentCulture) < 0)
            {
                return "R";
            }
            if (string.Compare(strA, "Ëû", StringComparison.CurrentCulture) < 0)
            {
                return "S";
            }
            if (string.Compare(strA, "ÍÛ", StringComparison.CurrentCulture) < 0)
            {
                return "T";
            }
            if (string.Compare(strA, "Ï¦", StringComparison.CurrentCulture) < 0)
            {
                return "W";
            }
            if (string.Compare(strA, "Ñ¾", StringComparison.CurrentCulture) < 0)
            {
                return "X";
            }
            if (string.Compare(strA, "Ž‰", StringComparison.CurrentCulture) < 0)
            {
                return "Y";
            }
            if (string.Compare(strA, "…ø", StringComparison.CurrentCulture) < 0)
            {
                return "Z";
            }
            return strA.ToString();
        }

        public static string GetGlobalString(string classKey, string resourceKey)
        {
            string str = (string)HttpContext.GetGlobalResourceObject(classKey, resourceKey, CultureInfo.CurrentCulture);
            if (str == null)
            {
                str = string.Empty;
            }
            return str;
        }

        public static decimal GetHashKey(string input, FilterOptions options)
        {
            ulong num;
            if (string.IsNullOrEmpty(input))
            {
                return 0M;
            }
            input = FilterInvalidChar(input, options);
            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                num = BitConverter.ToUInt64(provider.ComputeHash(Encoding.UTF8.GetBytes(input)), 4);
            }
            return DataConverter.ToDecimal(num);
        }

        public static string GetInitial(string str)
        {
            str = FilterInvalidChar(str, FilterOptions.SBCToDBC | FilterOptions.HoldChinese | FilterOptions.HoldLetter | FilterOptions.HoldNumber);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                int num2 = str[i];
                if (num2 < 0x7b)
                {
                    builder.Append(str[i]);
                }
                else
                {
                    builder.Append(GetGbkX(str[i]));
                }
            }
            return builder.ToString();
        }

        public static double GetStringHashKey(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0.0;
            }
            input = FilterInvalidChar(input, FilterOptions.SBCToDBC | FilterOptions.HoldChinese | FilterOptions.HoldLetter);
            string s = MD5(input).Substring(8, 0x10);
            return BitConverter.ToDouble(Encoding.UTF8.GetBytes(s), 0);
        }

        public static bool IsIncludeChinese(string inputData)
        {
            Regex regex = new Regex("[\u4e00-\u9fa5]+");
            return regex.Match(inputData).Success;
        }

        public static string MD5(string input)
        {
            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                return BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(input))).Replace("-", string.Empty).ToLower(CultureInfo.CurrentCulture);
            }
        }

        public static string MD5(string input, Encoding encoding)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(encoding.GetBytes(input));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        public static int MD5D(string strText)
        {
            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                byte[] bytes = Encoding.Default.GetBytes(strText);
                bytes = provider.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                foreach (byte num in bytes)
                {
                    builder.Append(num.ToString("D", CultureInfo.CurrentCulture).ToLower(CultureInfo.CurrentCulture));
                }
                string input = builder.ToString();
                if (input.Length >= 9)
                {
                    input = "9" + input.Substring(1, 8);
                }
                else
                {
                    input = "9" + input;
                }
                provider.Clear();
                return DataConverter.ToLng(input);
            }
        }

        public static string MD5GB2312(string input)
        {
            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                return BitConverter.ToString(provider.ComputeHash(Encoding.GetEncoding("gb2312").GetBytes(input))).Replace("-", string.Empty).ToLower(CultureInfo.CurrentCulture);
            }
        }

        public static string DESEncrypt(string input, string key)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            provider.Key = Encoding.ASCII.GetBytes(key);
            provider.IV = Encoding.ASCII.GetBytes(key);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            StringBuilder builder = new StringBuilder();
            foreach (byte num in stream.ToArray())
            {
                builder.AppendFormat("{0:X2}", num);
            }
            return builder.ToString();

        }

        public static string RemoveXss(string input)
        {
            string str;
            string str2;
            do
            {
                str = input;
                input = Regex.Replace(input, @"(&#*\w+)[\x00-\x20]+;", "$1;");
                input = Regex.Replace(input, "(&#x*[0-9A-F]+);*", "$1;", RegexOptions.IgnoreCase);
                input = Regex.Replace(input, "&(amp|lt|gt|nbsp|quot);", "&amp;$1;");
                input = HttpUtility.HtmlDecode(input);
            }
            while (str != input);
            input = Regex.Replace(input, "(?<=(<[\\s\\S]*=\\s*\"[^\"]*))>(?=([^\"]*\"[\\s\\S]*>))", "&gt;", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"(?<=(<[\s\S]*=\s*'[^']*))>(?=([^']*'[\s\S]*>))", "&gt;", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"(?<=(<[\s\S]*=\s*`[^`]*))>(?=([^`]*`[\s\S]*>))", "&gt;", RegexOptions.IgnoreCase);
            do
            {
                str = input;
                input = Regex.Replace(input, @"(<[^>]+?style[\x00-\x20]*=[\x00-\x20]*[^>]*?)\\([^>]*>)", "$1/$2", RegexOptions.IgnoreCase);
            }
            while (str != input);
            input = Regex.Replace(input, @"[\x00-\x08\x0b-\x0c\x0e-\x19]", string.Empty);
            input = Regex.Replace(input, "(<[^>]+?[\\x00-\\x20\"'/])(on|xmlns)[^>]*>", "$1>", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, "([a-z]*)[\\x00-\\x20]*=[\\x00-\\x20]*([`'\"]*)[\\x00-\\x20]*j[\\x00-\\x20]*a[\\x00-\\x20]*v[\\x00-\\x20]*a[\\x00-\\x20]*s[\\x00-\\x20]*c[\\x00-\\x20]*r[\\x00-\\x20]*i[\\x00-\\x20]*p[\\x00-\\x20]*t[\\x00-\\x20]*:", "$1=$2nojavascript...", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, "([a-z]*)[\\x00-\\x20]*=[\\x00-\\x20]*([`'\"]*)[\\x00-\\x20]*v[\\x00-\\x20]*b[\\x00-\\x20]*s[\\x00-\\x20]*c[\\x00-\\x20]*r[\\x00-\\x20]*i[\\x00-\\x20]*p[\\x00-\\x20]*t[\\x00-\\x20]*:", "$1=$2novbscript...", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"(<[^>]+style[\x00-\x20]*=[\x00-\x20]*[^>]*?)/\*[^>]*\*/([^>]*>)", "$1$2", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, "(<[^>]+?)style[\\x00-\\x20]*=[\\x00-\\x20]*([`'\"]*).*?[e£å£Å][x£ø£Ø][p£ð£Ð][r£ò£Ò][e£å£Å][s£ó£Ó][s£ó£Ó][i£é£É][o£ï£Ï][n£î£Î][\\x00-\\x20]*[\\(\\£¨][^>]*>", "$1>", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, "(<[^>]+?)style[\\x00-\\x20]*=[\\x00-\\x20]*([`'\"]*).*?behaviour[^>]*>", "$1>", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, "(<[^>]+?)style[\\x00-\\x20]*=[\\x00-\\x20]*([`'\"]*).*?behavior[^>]*>", "$1>", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, "(<[^>]+?)style[\\x00-\\x20]*=[\\x00-\\x20]*([`'\"]*).*?s[\\x00-\\x20]*c[\\x00-\\x20]*r[\\x00-\\x20]*i[\\x00-\\x20]*p[\\x00-\\x20]*t[\\x00-\\x20]*:*[^>]*>", "$1>", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"</*\w+:\w[^>]*>", "¡¡");
            do
            {
                str2 = input;
                input = Regex.Replace(input, "</*(applet|meta|xml|blink|link|style|script|embed|object|iframe|frame|frameset|ilayer|layer|bgsound|title|base)[^>]*>?", "¡¡", RegexOptions.IgnoreCase);
            }
            while (str2 != input);
            input = Regex.Replace(input, @"<!--([\s\S]*?)-->", "&lt;!--$1--&gt;");
            input = input.Replace("<!--", "&lt;!--");
            return input;
        }

        public static string ReplaceDoubleChar(string source, char replace, char newchar)
        {
            StringBuilder builder = new StringBuilder();
            if (string.IsNullOrEmpty(source))
            {
                return builder.ToString();
            }
            source = source.Trim();
            if (source.Contains(replace.ToString()))
            {
                for (int i = 0; i < source.Length; i++)
                {
                    if (source[i] == replace)
                    {
                        if (i < (source.Length - 1))
                        {
                            if (source[i] != source[i + 1])
                            {
                                builder.Append(newchar);
                            }
                        }
                        else
                        {
                            builder.Append(newchar);
                        }
                    }
                    else
                    {
                        builder.Append(source[i]);
                    }
                }
            }
            else
            {
                builder.Append(source);
            }
            return builder.ToString().Trim();
        }

        public static string ReplaceIgnoreCase(string input, string oldValue, string newValue)
        {
            return Strings.Replace(input, oldValue, newValue, 1, -1, CompareMethod.Text);
        }

        public static string Sha1(string input)
        {
            using (SHA1CryptoServiceProvider provider = new SHA1CryptoServiceProvider())
            {
                return BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(input))).Replace("-", string.Empty).ToLower(CultureInfo.CurrentCulture);
            }
        }

        public static string StripTags(string input)
        {
            Regex regex = new Regex("<([^<]|\n)+?>");
            return regex.Replace(input, string.Empty);
        }

        public static string SubString(string demand, int length, string substitute)
        {
            demand = DataSecurity.HtmlDecode(demand);
            int len = demand.Length;
            if (len<=length)
            {
                return demand;
            }



            string t = demand.Substring(0, length);
            return t + substitute;

            //if (Encoding.Default.GetBytes(demand).Length <= length)
            //{
            //    return demand;
            //}
            //ASCIIEncoding encoding = new ASCIIEncoding();
            //length -= Encoding.Default.GetBytes(substitute).Length;
            //int num = 0;
            //StringBuilder builder = new StringBuilder();
            //byte[] bytes = encoding.GetBytes(demand);
            //for (int i = 0; i < bytes.Length; i++)
            //{
            //    if (bytes[i] == 0x3f)
            //    {
            //        num += 2;
            //    }
            //    else
            //    {
            //        num++;
            //    }
            //    if (num > length)
            //    {
            //        break;
            //    }
            //    builder.Append(demand.Substring(i, 1));
            //}
            //builder.Append(substitute);
            //return builder.ToString();
        }

        public static int SubStringLength(string demand)
        {
            if (string.IsNullOrEmpty(demand))
            {
                return 0;
            }
            ASCIIEncoding encoding = new ASCIIEncoding();
            int num = 0;
            byte[] bytes = encoding.GetBytes(demand);
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == 0x3f)
                {
                    num += 2;
                }
                else
                {
                    num++;
                }
            }
            return num;
        }

        public static string Trim(string returnStr)
        {
            if (!string.IsNullOrEmpty(returnStr))
            {
                return returnStr.Trim();
            }
            return string.Empty;
        }

        public static bool ValidateMD5(string password, string encryptedValue)
        {
            if (string.Compare(password, encryptedValue, StringComparison.Ordinal) != 0)
            {
                return (string.Compare(password, encryptedValue.Substring(8, 0x10), StringComparison.Ordinal) == 0);
            }
            return true;
        }

        public static string GetRadomString()
        {
            return GetRadomString(5);
        }

        public static string GetRadomString(int length)
        {
            string rs = "abcdefghigklmnopqrstuvwxyz0123456789";
            return GetRadomString(rs, length);
        }

        public static string GetRadomString(string rs,int length)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(rs) && length>0)
            {
                int r = rs.Length;
                Random random = new Random();
                for (int i = 0; i < length;++i )
                {
                    sb.Append(rs[random.Next(r)]);
                }
            }

            return sb.ToString();
        }

        public static string GetRandStringByPattern(string pattern)
        {
            if ((!pattern.Contains("#") && !pattern.Contains("?")) && !pattern.Contains("*"))
            {
                return pattern;
            }
            Random rand = rand = new Random((int)DateTime.Now.Ticks);
            char[] chArray = pattern.ToCharArray();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < chArray.Length; i++)
            {
                switch (chArray[i])
                {
                    case '#':
                        chArray[i] = GetRandNum(rand);
                        break;

                    case '*':
                        chArray[i] = GetRandChar(rand);
                        break;

                    case '?':
                        chArray[i] = GetRandWord(rand);
                        break;
                }
                builder.Append(chArray[i]);
            }
            return builder.ToString();
        }

        private static char GetRandNum(Random rand)
        {
            return RandChar[rand.Next(0, 10)];//Êý×Ö
        }

        private static char GetRandChar(Random rand)
        {
            return RandChar[rand.Next(0x3e)];//×ÖÄ¸ºÍÊý×Ö
        }

        private static char GetRandWord(Random rand)
        {
            return RandChar[rand.Next(10, 0x3e)];//×ÖÄ¸
        }

        public static string ClearIntStr(string input,string clearStr,char split)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            string[] str = clearStr.Split(new char[] { split }, StringSplitOptions.RemoveEmptyEntries);
            string[] str1 = input.Split(new char[] { split }, StringSplitOptions.RemoveEmptyEntries);
            StringCollection list = new StringCollection();
            for (int i = 0; i < str1.Length; ++i)
            {
                if (!FoundStrInArr(str1[i], str, true))
                {
                    list.Add(str1[i]);
                }
            }

            if (list.Count == 0)
            {
                return string.Empty;
            }

            string s = "";

            foreach (string intStr in list)
            {
                s += intStr + split;
            }

            return s.Remove(s.Length - 1);
        }

        public static string JoinArray(string[] arr,string split)
        {
            if (arr==null || arr.Length==0)
            {
                return "";
            }

            if (string.IsNullOrEmpty(split))
            {
                split = ",";
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < arr.Length;++i )
            {
                sb.AppendFormat("{0}{1}", split, arr[i]);
            }

            sb.Remove(0, split.Length);
            return sb.ToString();
        }

    }


}
