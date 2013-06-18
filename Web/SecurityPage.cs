using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public class SecurityPage:Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            if (!RequestContext.Current.User.Identity.IsAuthenticated)
            {
                LinkCollection links = new LinkCollection();
                links.Add("~/login.aspx","点此登录");
                WriteMessage("您未登录，请登录后重试",links);
            }
            base.OnPreInit(e);
        }

        public int RequestInt32(string queryItem)
        {
            return WebUtility.RequestInt32(queryItem, 0);
        }

        public int RequestInt32(string queryItem, int defaultValue)
        {
            return WebUtility.RequestInt32(queryItem, defaultValue);
        }

        public string RequestString(string queryItem)
        {
            return WebUtility.RequestString(queryItem, string.Empty);
        }

        public string RequestString(string queryItem, string defaultValue)
        {
            return WebUtility.RequestString(queryItem, defaultValue);
        }

        public string RequestStringToLower(string queryItem)
        {
            return WebUtility.RequestStringToLower(queryItem, string.Empty);
        }

        public string RequestStringToLower(string queryItem, string defaultValue)
        {
            return WebUtility.RequestStringToLower(queryItem, defaultValue);
        }


        public void WriteMessage(string message)
        {
            LinkCollection links = new LinkCollection();
            links.Add("javascript:history.back();","返回");
            WriteMessage(message, links);
        }

        public void WriteMessage(string message, LinkCollection links)
        {
            HttpContext.Current.Items["Message"] = message;
            HttpContext.Current.Items["Links"] = links;
            HttpContext.Current.Server.Transfer(PromptMessagePageUrl);
        }

        public static void SetSelectedIndexByValue(ListControl listControl, string selectValue)
        {
            WebUtility.SetSelectedIndexByValue(listControl, selectValue);
        }


        // Properties
        public string BasePath
        {
            get
            {
                return WebUtility.GetBasePath(base.Request);
            }
        }

        public string FullBasePath
        {
            get
            {
                return (base.Request.Url.AbsoluteUri.Replace(base.Request.Url.PathAndQuery, string.Empty) + this.BasePath);
            }
        }

        public virtual string PromptMessagePageUrl
        {
            get
            {
                return "~/message.aspx";
            }
        }

    }
}
