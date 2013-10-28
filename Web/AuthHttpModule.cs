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
using Security;
using Model;

namespace Web
{
    public class AuthHttpModule:IHttpModule
    {
        private static object _obj=new object();
        private static CheckPurviewElement checkPurviewElement;
        private static NoCheckLogOnElement noCheckLogOnSection;
        private static CheckSecurityCodeElement checkSecurityCode;

        private void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;

            string filePath = (context.Request.AppRelativeCurrentExecutionFilePath).ToLower(CultureInfo.CurrentCulture);
            if (filePath=="~/")
            {
                context.Response.Redirect("~/login.aspx");
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
                            principal3.UserId = principal3.UserInfo.UserId;
                            
                            principal3.Roles = principal3.UserInfo.Roles;
                            if (principal3.Roles != null)
                            {
                                principal3.Purviews = new List<string>();
                                foreach (Role r in principal3.Roles)
                                {
                                    if (string.IsNullOrEmpty(r.Purview))
                                    {
                                        continue;
                                    }
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
                if (noCheckLogOnSection.Page[filePath] == null)
                {
                    if (!RequestContext.Current.User.Identity.IsAuthenticated)
                    {
                        WebUtility.WriteMessageWithLoginLink("您未登录，请登录后重试！", context.Server.UrlEncode(context.Request.Url.AbsoluteUri));
                    }
                    else if (RequestContext.Current.User.LastPassword != RequestContext.Current.User.UserInfo.RndPassword)
                    {
                        CookieManager.RemoveCookie(FormsAuthentication.FormsCookieName);
                        WebUtility.WriteMessageWithLoginLink("该用户已在其他地方登陆，是否重新登录！", context.Server.UrlEncode(context.Request.Url.AbsoluteUri));
                    }
                }
            }
        }
        private void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;

            if (RequestContext.Current.User.Identity.IsAuthenticated && context.Session["UserName"] == null)
            {
                context.Session.Add("UserName", RequestContext.Current.User.UserName);
            }
            if (context.Request.Url.GetLeftPart(UriPartial.Path).EndsWith(".aspx", StringComparison.OrdinalIgnoreCase))
            {
                if (checkSecurityCode != null)
                {
                    string filePath = (context.Request.AppRelativeCurrentExecutionFilePath).ToLower(CultureInfo.CurrentCulture);

                    if (checkSecurityCode.Page[filePath] != null)
                    {
                        string code = WebUtility.GetSecurityCode(context.Request.Url.PathAndQuery);
                        if (context.Request.QueryString["sc"] == null || code != context.Request.QueryString["sc"])
                        {
                            WebUtility.WriteMessage("安全检验码检验失败，您当前的访问被阻止", false);
                        }
                    }
                }
            }
        }


        private void Application_AuthorizeRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;

            if (context.Request.Url.GetLeftPart(UriPartial.Path).EndsWith(".aspx", StringComparison.OrdinalIgnoreCase))
            {
                if (checkPurviewElement != null)
                {
                    string filePath = (context.Request.AppRelativeCurrentExecutionFilePath).ToLower(CultureInfo.CurrentCulture);

                    CheckPurviewPageElement element = checkPurviewElement.Page[filePath];
                    if (element != null && !string.IsNullOrEmpty(element.Purview))
                    {
                        if (!RequestContext.Current.User.HasPurview(element.Purview))
                        {
                            WebUtility.WriteMessage("您没有权限执行该操作", false);
                        }
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
                noCheckLogOnSection = section.NoCheckLogOn;
                checkSecurityCode = section.CheckSecurityCode;
            }

            AuthenticationSection section1 = (AuthenticationSection)WebConfigurationManager.GetSection("system.web/authentication");
            if (section1.Mode == AuthenticationMode.Forms)
            {
                context.BeginRequest += Application_BeginRequest;
                context.AuthenticateRequest += new EventHandler(this.Application_AuthenticateRequest);
                context.PostAuthenticateRequest += Application_PostAuthenticateRequest;
                context.AuthorizeRequest += Application_AuthorizeRequest;
                context.PreRequestHandlerExecute += Application_PreRequestHandlerExecute;
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
