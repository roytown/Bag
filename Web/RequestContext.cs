using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Threading;
using System.Text.RegularExpressions;

namespace Web
{
    public class RequestContext
    {
        // Fields
        private Uri currentUrl;
        private string hostPath;
        private HttpContext httpContext;
        private UserPrincipal _userPrincipal;
        private NameValueCollection queryString;
        private string returnurl;

        // Methods
        private RequestContext(HttpContext context)
        {
            this.httpContext = context;
            this.Initialize(new NameValueCollection(context.Request.QueryString), context.Request.Url, context.Request.RawUrl);
        }

        public static RequestContext Create(HttpContext context)
        {
            return Create(context,false);
        }

        public static RequestContext Create(HttpContext context, bool isRewritten)
        {
            RequestContext context2 = new RequestContext(context);
            SaveContextToStore(context2);
            return context2;
        }

        private static LocalDataStoreSlot GetSlot()
        {
            return Thread.GetNamedDataSlot("ContextStore");
        }

        private void Initialize(NameValueCollection qs, Uri uri, string rawUrl)
        {
            this.queryString = qs;
            this.currentUrl = uri;
         
        }

        private static void SaveContextToStore(RequestContext context)
        {
            HttpContext current = HttpContext.Current;
            if (current!=null)
            {
                context.Context.Items["PWContextStore"] = context;
            }
            else
            {
                Thread.SetData(GetSlot(), context);
            }
           
        }

        public static void Unload()
        {
            Thread.FreeNamedDataSlot("ContextStore");
        }

        // Properties


        public HttpContext Context
        {
            get
            {
                return this.httpContext;
            }
        }

        public static RequestContext Current
        {
            get
            {
                HttpContext current = HttpContext.Current;
                RequestContext context = null;
                if (current != null)
                {
                    context = current.Items["ContextStore"] as RequestContext;
                }
                else
                {
                    context = Thread.GetData(GetSlot()) as RequestContext;
                }
                if (context == null)
                {
                    if (current == null)
                    {
                        throw new Exception("No RequestContext exists in the Current Application. AutoCreate fails since HttpContext.Current is not accessible.");
                    }
                    context = new RequestContext(current);
                    SaveContextToStore(context);
                }
                return context;
            }
        }

        public Uri CurrentUri
        {
            get
            {
                if (this.currentUrl == null)
                {
                    this.currentUrl = new Uri("http://localhost/");
                }
                return this.currentUrl;
            }
            set
            {
                this.currentUrl = value;
            }
        }

        public string HostPath
        {
            get
            {
                if (this.hostPath == null)
                {
                    string str = (this.CurrentUri.Port == 80) ? string.Empty : (":" + this.CurrentUri.Port.ToString());
                    this.hostPath = string.Format("{0}://{1}{2}", this.CurrentUri.Scheme, this.CurrentUri.Host, str);
                }
                return this.hostPath;
            }
        }

        public NameValueCollection QueryString
        {
            get
            {
                return this.queryString;
            }
        }

        public string Returnurl
        {
            get
            {
                if (this.returnurl == null)
                {
                    this.returnurl = this.QueryString["returnUrl"];
                }
                return this.returnurl;
            }
            set
            {
                this.returnurl = value;
            }
        }

        public UserPrincipal User
        {
            get
            {
                if (this._userPrincipal == null)
                {
                    this._userPrincipal = new UserPrincipal(new NoAuthenticateIdentity());
                }
                return this._userPrincipal;
            }
            set
            {
                this._userPrincipal = value;
            }
        }

        public string UserHostAddress
        {
            get
            {
                if(!string.IsNullOrEmpty(this.Context.Request.UserHostAddress) && Regex.IsMatch(this.Context.Request.UserHostAddress, @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$"))
                {
                    return this.Context.Request.UserHostAddress;
                }
               
                return "0.0.0.0";
            }
        }

    
    }
}
