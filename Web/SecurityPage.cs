using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace Web
{
    public class SecurityPage:Page
    {
        private List<ValidateRule> _rules;
     
        public SecurityPage()
        {
            _rules = new List<ValidateRule>();
        }
        protected override void OnPreInit(EventArgs e)
        {
            if (!RequestContext.Current.User.Identity.IsAuthenticated)
            {
                WebUtility.WriteMessageWithLoginLink("您未登录，请登录后重试", Server.UrlEncode(Request.Url.AbsoluteUri));
            }
            base.OnPreInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!this.ClientScript.IsClientScriptBlockRegistered("jquery"))
            {
                this.ClientScript.RegisterClientScriptBlock(typeof(Page), "jquery", "<script src=\"" + this.ResolveClientUrl("~/Scripts/jquery-1.8.2.min.js") + "\" type=\"text/javascript\"></script>");
            }
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("jquery-validator"))
            {
                this.ClientScript.RegisterClientScriptBlock(typeof(Page), "jquery-validator", "<script src=\"" + this.ResolveClientUrl("~/Scripts/jquery.validate.js") + "\" type=\"text/javascript\"></script>");
            }
            base.OnLoad(e);
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            if (!this.ClientScript.IsClientScriptBlockRegistered("form-validator"))
            {
                this.ClientScript.RegisterStartupScript(typeof(Page), "form-validator", GetValidtorJs());
            }

            base.OnLoadComplete(e);
        }

        private string GetValidtorJs()
        {
          
            StringBuilder builder = new StringBuilder("<script type='text/javascript'>");
            builder.Append("$(document).ready(function(){");

            ValidateConfig config = ConfigBase.GetInstance(typeof(ValidateConfig)) as ValidateConfig;
            if (config!=null)
            {
                builder.Append("jQuery.validator.setDefaults({");
                builder.AppendFormat("debug:{0}",
                 config.Debug.ToString().ToLower()
               
                 );
                if (!string.IsNullOrEmpty(config.ErrorCss))
                {
                    builder.AppendFormat(",errorClass:'{0}'", config.ErrorCss);
                }
               
                if (!string.IsNullOrEmpty(config.ErrorElement))
                {
                    builder.AppendFormat(",errorElement:'{0}'", config.ErrorElement);
                }
                if (!string.IsNullOrEmpty(config.ErrorContainer))
                {
                    builder.AppendFormat(",errorContainer:'{0}'", config.ErrorContainer);
                }
                if (!string.IsNullOrEmpty(config.ErrorLabelContainer))
                {
                    builder.AppendFormat(",errorLabelContainer:'{0}'", config.ErrorLabelContainer);
                }
                if (!string.IsNullOrEmpty(config.ErrorWrapper))
                {
                    builder.AppendFormat(",wrapper:'{0}'", config.ErrorWrapper);
                }
                builder.Append("});");
            }

            //消息设置
           
            builder.Append("$('#" + this.Form.ClientID + "').validate(");
            if (!string.IsNullOrEmpty(config.SuccessCss))
            {
                builder.Append("{");
                builder.AppendFormat("success:'{0}'", config.SuccessCss);
                if (_rules.Count>0)
                {
                    builder.Append(",messages:{");
                    foreach (ValidateRule o in _rules)
                    {
                        builder.Append(o.ID);
                        builder.Append(":{" + o.Message + "},");
                    }
                    builder.Remove(builder.Length - 1, 1);
                    builder.Append("}");
                }
                builder.Append("}");
            }
            builder.Append(");");
            builder.Append("});");
            builder.Append("</script>");
            return builder.ToString();
        }

        public int RequestInt32(string queryItem)
        {
            return WebUtility.RequestInt32(queryItem, 0);
        }

        public DateTime? RequestDateTime(string queryItem)
        {
            return WebUtility.RequestDateTime(queryItem);
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


        public void WriteMessage(string message,bool isSuccess)
        {
            WebUtility.WriteMessage(message, null, isSuccess);
        }

        public void WriteMessage(string message, LinkCollection links, bool isSuccess)
        {
            WebUtility.WriteMessage(message, links, isSuccess);
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

        public User CurrentUser
        {
            get { return RequestContext.Current.User.UserInfo; }
        }

        public List<ValidateRule> ValidateRules
        {
            get { return _rules; }
        }

        private Dictionary<string, string> _pageStatus;
        public Dictionary<string, string> PageStatus 
        {
            get 
            {
                if (_pageStatus == null)
                {
                    _pageStatus = new Dictionary<string, string>();
                }

                return _pageStatus;
            }
        }

    }
}
