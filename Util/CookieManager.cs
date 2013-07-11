using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using System.Web;
namespace Util
{
    public class CookieManager
    {
        public static void CreateCookie(string cookieName, string value, bool isPersistent,DateTime expirationTime)
        {
            HttpCookie cookie = new HttpCookie(cookieName, value);
            if (isPersistent)
            {
                cookie.Expires = expirationTime;
            }
            cookie.HttpOnly = true;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            cookie.Secure = FormsAuthentication.RequireSSL;
            if (!string.IsNullOrEmpty(FormsAuthentication.CookieDomain))
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void RemoveCookie(string cookieName)
        {
            string str = string.Empty;
            if (HttpContext.Current.Request.Browser["supportsEmptyStringInCookieValue"] == "false")
            {
                str = "NoCookie";
            }
            HttpCookie cookie = new HttpCookie(cookieName, str);
            cookie.HttpOnly = true;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            cookie.Expires = new DateTime(0x7cf, 10, 12);
            cookie.Secure = FormsAuthentication.RequireSSL;
            if (!string.IsNullOrEmpty(FormsAuthentication.CookieDomain))
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }
            HttpContext.Current.Response.Cookies.Remove(cookieName);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void CreateUserCookie(FormsAuthenticationTicket authTicket)
        {
            string str = FormsAuthentication.Encrypt(authTicket);
            CreateCookie(FormsAuthentication.FormsCookieName, str, authTicket.IsPersistent, authTicket.Expiration);
        }

        public static void RemoveUserCookie()
        {
            string str = string.Empty;
            string cookieName = FormsAuthentication.FormsCookieName;
            RemoveCookie(cookieName);
        }
    }
}
