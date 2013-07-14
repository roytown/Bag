using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Globalization;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Util;

namespace Web
{
    public sealed class WebUtility
    {
        // Methods
        private WebUtility()
        {
            
        }

        public static bool AccessingPath(string accessingurl, string path)
        {
            bool flag = accessingurl.StartsWith(path, StringComparison.CurrentCultureIgnoreCase);
            bool flag2 = accessingurl.EndsWith("aspx", StringComparison.CurrentCultureIgnoreCase);
            bool flag3 = accessingurl.EndsWith("/", StringComparison.CurrentCultureIgnoreCase);
            if (!flag)
            {
                return false;
            }
            if (!flag2)
            {
                return flag3;
            }
            return true;
        }

        public static string AppendSecurityCode(string currenturl)
        {
            if (!string.IsNullOrEmpty(currenturl))
            {
                if (currenturl.IndexOf("?", StringComparison.CurrentCultureIgnoreCase) < 0)
                {
                    currenturl = currenturl + "?sc=" + GetSecurityCode(currenturl);
                    return currenturl;
                }
                if ((currenturl.IndexOf("&sc=", StringComparison.CurrentCultureIgnoreCase) < 0) && (currenturl.IndexOf("?sc=", StringComparison.CurrentCultureIgnoreCase) < 0))
                {
                    currenturl = currenturl + "&sc=" + GetSecurityCode(currenturl);
                }
            }
            return currenturl;
        }

        public static string CombineRawUrl(string url)
        {
            if ((url[0] != '~') && (url.IndexOf(':') < 0))
            {
                string rawUrl = HttpContext.Current.Request.RawUrl;
                if (rawUrl.IndexOf('?') > 0)
                {
                    rawUrl = rawUrl.Split(new char[] { '?' })[0];
                }
                if (url.IndexOf('?') > 0)
                {
                    string[] strArray = url.Split(new char[] { '?' });
                    url = VirtualPathUtility.Combine(rawUrl, strArray[0]) + "?" + strArray[1];
                    return url;
                }
                url = VirtualPathUtility.Combine(rawUrl, url);
            }
            return url;
        }

        public static void ResponseFileNotFound()
        {
            HttpContext.Current.Server.Transfer("~/FileNotFound.aspx");
            HttpContext.Current.Response.End();
        }

        public static string EnumToHtml<T>(T enumValue) where T : struct
        {
            string str = enumValue.ToString();
            string name = enumValue.GetType().Name;
            if (!str.Contains(","))
            {
                return GetGlobalEnumString(name + "_" + str);
            }
            StringBuilder builder = new StringBuilder();
            foreach (string str3 in str.Split(new string[] { "," }, 0))
            {
                string resourceKey = name + "_" + str3.Trim();
                if (builder.Length > 0)
                {
                    builder.Append(",");
                }
                builder.Append(GetGlobalEnumString(resourceKey));
            }
            return builder.ToString();
        }

        public static string GetBasePath(HttpRequest request)
        {
            if (request == null)
            {
                return "/";
            }
            return VirtualPathUtility.AppendTrailingSlash(request.ApplicationPath);
        }

        public static string GetGlobalCacheString(string resourceKey)
        {
            return GetGlobalString("CacheResources", resourceKey);
        }

        public static string GetGlobalComment(string resourceKey)
        {
            return GetGlobalString("CommentResource", resourceKey);
        }

        public static string GetGlobalDynamicPage(string resourceKey)
        {
            return GetGlobalString("DynamicPageResources", resourceKey);
        }

        public static string GetGlobalEnumString(string resourceKey)
        {
            return GetGlobalString("EnumResources", resourceKey);
        }

        public static string GetGlobalErrorString(string resourceKey)
        {
            return GetGlobalString("ErrorMessage", resourceKey);
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

        public static string GetSecurityCode(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return string.Empty;
            }
            string str = string.Empty;
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
            int index = filePath.IndexOf("?", StringComparison.CurrentCultureIgnoreCase);
            if (index > 0)
            {
                NameValueCollection query = HttpUtility.ParseQueryString(filePath.Substring(index, filePath.Length - index));
                
                foreach (string key in query.AllKeys)
                {
                    if (string.Compare(key, "action", false) == 0)
                    {
                        str = query[key];
                        break;
                    }
                    //str += query[key];
                }
            }
            string s = fileNameWithoutExtension.ToLower(CultureInfo.CurrentCulture) + str.ToLower(CultureInfo.CurrentCulture) + HttpContext.Current.Session.SessionID;
            HMACSHA1 hmacsha = new HMACSHA1(Encoding.UTF8.GetBytes(s));
            return BitConverter.ToString(hmacsha.ComputeHash(Encoding.UTF8.GetBytes(s))).Replace("-", string.Empty).ToLower(CultureInfo.CurrentCulture);
        }

        public static int GetSelectedIndexByValue(ListControl listControl, string selectValue)
        {
            int index = -1;
            if (listControl != null)
            {
                index = listControl.Items.IndexOf(listControl.Items.FindByValue(selectValue));
            }
            return index;
        }


        public static string RebuildPageName(string filename, NameValueCollection query)
        {
            if (string.IsNullOrEmpty(filename))
            {
                return string.Empty;
            }
            string[] strArray = filename.Split(new char[] { '/' });
            if (strArray.Length > 0)
            {
                filename = strArray[strArray.Length - 1];
            }
            if (filename.IndexOf('?') > 0)
            {
                filename = filename.Substring(0, filename.IndexOf('?') - 1);
            }
            StringBuilder builder = new StringBuilder(filename);
            if (query.Count > 0)
            {
                bool flag = false;
                for (int i = 0; i < query.Count; i++)
                {
                    if (i == 0)
                    {
                        builder.Append("?");
                    }
                    else
                    {
                        builder.Append("&");
                    }
                    if (query.GetKey(i) == "page")
                    {
                        builder.Append("page={$pageid/}");
                        flag = true;
                    }
                    else
                    {
                        builder.Append(query.GetKey(i) + "=" + HttpUtility.UrlEncode(DataSecurity.FilterBadChar(query.Get(i))));
                    }
                }
                if (!flag)
                {
                    if (builder.Length > filename.Length)
                    {
                        builder.Append("&page={$pageid/}");
                    }
                    else
                    {
                        builder.Append("?page={$pageid/}");
                    }
                }
            }
            else
            {
                builder.Append("?page={$pageid/}");
            }
            return builder.ToString();
        }

        public static int RequestInt32(string queryItem, int defaultValue)
        {
            return DataConverter.ToLng(HttpContext.Current.Request.QueryString[queryItem], defaultValue);
        }

        public static string RequestString(string queryItem, string defaultValue)
        {
            string str = HttpContext.Current.Request.QueryString[queryItem];
            if (str == null)
            {
                return defaultValue;
            }
            return str.Trim();
        }

        public static string RequestStringToLower(string queryItem, string defaultValue)
        {
            string str = HttpContext.Current.Request.QueryString[queryItem];
            if (str == null)
            {
                return defaultValue.ToLower(CultureInfo.CurrentCulture);
            }
            return str.Trim().ToLower(CultureInfo.CurrentCulture);
        }

        public static void SetSelectedIndexByValue(ListControl listControl, string selectValue)
        {
            if (listControl != null)
            {
                listControl.SelectedIndex = listControl.Items.IndexOf(listControl.Items.FindByValue(selectValue));
            }
        }

        public static void WriteMessageWithLoginLink(string message)
        {
            LinkCollection links = new LinkCollection();
            links.Add("~/login.aspx","点此登录");
            WriteMessage(message, links,false);
        }

        public static void WriteMessage(string message)
        {
            WriteMessage(message, false);
        }

        public static void WriteMessage(string message,bool isSuccess)
        {
            LinkCollection links = new LinkCollection();
            links.Add("javascript:history.back();","返回");
            WriteMessage(message, links, isSuccess);
        }

        public static void WriteMessage(string message, LinkCollection links,bool isSuccess)
        {
            HttpContext.Current.Items["IsSuccess"] = isSuccess;
            HttpContext.Current.Items["Message"] = message;
            HttpContext.Current.Items["Links"] = links;
            HttpContext.Current.Server.Transfer("~/message.aspx");
        }

        public static void AddCssToPage(Page page,string css)
        {
            HtmlLink link = new HtmlLink();
            link.Attributes.Add("href", css);
            link.Attributes.Add("rel", "stylesheet");
            link.Attributes.Add("type", "text/css");

            page.Header.Controls.Add(link);
        }

        public static string GetApplicationName(HttpContext context)
        {
            if (context == null)
            {
                return string.Empty;
            }
            string host = context.Request.Url.Host;
            string applicationPath = context.Request.ApplicationPath;
            return (host + applicationPath);

        }

    }
}
