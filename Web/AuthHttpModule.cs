using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using Util;
using Database;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Security;

namespace Web
{
    public class AuthHttpModule:IHttpModule
    {
        private static object _obj=new object();
        private static CheckPurviewElement checkPurviewElement;

        private void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;

            string filePath = (context.Request.AppRelativeCurrentExecutionFilePath).ToLower(CultureInfo.CurrentCulture);
            if (filePath=="~/")
            {
                context.Response.Redirect("~/index.aspx");
            }
        }

        private void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            if (context.Request.Url.GetLeftPart(UriPartial.Path).EndsWith(".aspx", StringComparison.OrdinalIgnoreCase))
            {
                FormsAuthenticationTicket ticket = null;
                string formsCookieName = FormsAuthentication.FormsCookieName;
                string filePath = (context.Request.AppRelativeCurrentExecutionFilePath).ToLower(CultureInfo.CurrentCulture);
                HttpCookie cookie = context.Request.Cookies[formsCookieName];
                if (cookie == null)
                {
                    UserPrincipal principal = new UserPrincipal(new AnonymousAuthenticateIdentity());

                    RequestContext.Current.User = principal;
                }
                else
                {
                    try
                    {
                        ticket = FormsAuthentication.Decrypt(cookie.Value);
                    }
                    catch (ArgumentException)
                    {
                        context.Request.Cookies.Remove(formsCookieName);
                    }
                    catch (CryptographicException)
                    {
                        context.Request.Cookies.Remove(formsCookieName);
                    }
                    if (ticket == null)
                    {
                        UserPrincipal principal2 = new UserPrincipal(new AnonymousAuthenticateIdentity());
                        RequestContext.Current.User = principal2;
                    }
                    else
                    {
                        SlidingExpiration(context, ticket, formsCookieName);
                        UserPrincipal principal3 = UserPrincipal.CreatePrincipal(ticket);

                        if (principal3.Identity.IsAuthenticated)
                        {
                            principal3.UserInfo = UserBll.GetUser(principal3.UserName);
                            principal3.Roles = RoleBll.GetForUser(principal3.UserName);
                            if (principal3.Roles != null)
                            {
                                principal3.Purviews = new List<string>();
                                foreach (Role r in principal3.Roles)
                                {
                                    principal3.Purviews.AddRange(r.Purview.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                                }
                            }

                            RequestContext.Current.User = principal3;

                        }
                        else
                        {
                            UserPrincipal principal5 = new UserPrincipal(new AnonymousAuthenticateIdentity());

                            RequestContext.Current.User = principal5;
                        }
                    }
                }
            }
        }

        private void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            if (context.Request.Url.GetLeftPart(UriPartial.Path).EndsWith(".aspx", StringComparison.OrdinalIgnoreCase))
            {
                string filePath = (context.Request.AppRelativeCurrentExecutionFilePath).ToLower(CultureInfo.CurrentCulture);
                if (!filePath.StartsWith("~/login.aspx"))
                {
                    if (!RequestContext.Current.User.Identity.IsAuthenticated)
                    {
                        WebUtility.WriteMessageWithLoginLink("您未登录，请登录后重试！");
                    }
                    else if (RequestContext.Current.User.LastPassword != RequestContext.Current.User.UserInfo.RndPassword)
                    {
                        CookieManager.RemoveCookie(FormsAuthentication.FormsCookieName);
                        WebUtility.WriteMessageWithLoginLink("未知的用户状态，请重新登录！");
                    }
                }
            }
        }


        private void Application_AuthorizeRequest(object sender, EventArgs e)
        {
            if (checkPurviewElement!=null)
            {
                HttpApplication application = (HttpApplication)sender;
                HttpContext context = application.Context;
                string filePath = (context.Request.AppRelativeCurrentExecutionFilePath).ToLower(CultureInfo.CurrentCulture);

                CheckPurviewPageElement element = checkPurviewElement.Page[filePath];
                if (element!=null && !string.IsNullOrEmpty(element.Purview))
                {
                    if (!RequestContext.Current.User.HasPurview(element.Purview))
                    {

                    }
                }
            }
        }

        private void SlidingExpiration(HttpContext context, FormsAuthenticationTicket ticket, string cookieName)
        {
            FormsAuthenticationTicket ticket2 = null;
            if (FormsAuthentication.SlidingExpiration)
            {
                ticket2 = FormsAuthentication.RenewTicketIfOld(ticket);
            }
            else
            {
                ticket2 = ticket;
            }
            string str = FormsAuthentication.Encrypt(ticket2);
            HttpCookie cookie = context.Request.Cookies[cookieName];
            if (cookie == null)
            {
                cookie = new HttpCookie(cookieName, str);
                cookie.Path = ticket2.CookiePath;
            }
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket2.Expiration;
            }
            cookie.Value = str;
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.HttpOnly = true;
            if (!string.IsNullOrEmpty(FormsAuthentication.CookieDomain))
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }
            context.Response.Cookies.Remove(cookie.Name);
            context.Response.Cookies.Add(cookie);
        }

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            lock (_obj)
            {
                PageSecuritySection section = (PageSecuritySection)WebConfigurationManager.GetSection("PageSecurity");
                checkPurviewElement = section.CheckPurview;
               
            }

            AuthenticationSection section1 = (AuthenticationSection)WebConfigurationManager.GetSection("system.web/authentication");
            if (section1.Mode == AuthenticationMode.Forms)
            {
                context.BeginRequest += Application_BeginRequest;
                context.AuthenticateRequest += new EventHandler(this.Application_AuthenticateRequest);
                context.PostAuthenticateRequest += Application_PostAuthenticateRequest;
                context.AuthorizeRequest += Application_AuthorizeRequest;
            }
        }

        // Properties
        public static string ModuleName
        {
            get
            {
                return "AuthHttpModule";
            }
        }
    }
}
