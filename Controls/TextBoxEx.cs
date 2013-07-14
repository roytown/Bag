﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;

namespace Controls
{
    public class TextBoxEx:TextBox
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("jquery"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "jquery", "<script src=\"" + this.ResolveClientUrl("~/Scripts/jquery-1.8.2.min.js") + "\" type=\"text/javascript\"></script>");
            }
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("jquery-validator"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "jquery-validator", "<script src=\"" + this.ResolveClientUrl("~/Scripts/jquery.validate.js") + "\" type=\"text/javascript\"></script>");
            }

            if (this.Page is SecurityPage)
            {
                SecurityPage p = this.Page as SecurityPage;
                string message = "";
                if (IsRequired && !string.IsNullOrEmpty(RequiredErrorMessage))
                {
                    message += ",required:'" + RequiredErrorMessage + "'";
                }
                if (!string.IsNullOrEmpty(EqualTo))
                {
                    message += ",equalTo:'" + ValueErrorMessage + "'";
                }

                switch (Type)
                {
                    case TextType.Normal:
                        if (!string.IsNullOrEmpty(FormatErrorMessage))
                        {
                            message += ",minlength:'" + FormatErrorMessage + "'";
                            message += ",maxlength:'" + FormatErrorMessage + "'";
                        }
                        break;
                    case TextType.Email:
                        if (!string.IsNullOrEmpty(FormatErrorMessage))
                        {
                            message += ",email:'" + FormatErrorMessage + "'";
                        }
                        break;
                    case TextType.Url:
                        if (!string.IsNullOrEmpty(FormatErrorMessage))
                        {
                            message += ",url:'" + FormatErrorMessage + "'";
                        }
                        break;
                    case TextType.Int:
                        if (!string.IsNullOrEmpty(FormatErrorMessage))
                        {
                            message += ",digits:'" + FormatErrorMessage + "'";
                        }
                        if (!string.IsNullOrEmpty(ValueErrorMessage))
                        {
                            message += ",min:'" + ValueErrorMessage + "'";
                            message += ",max:'" + ValueErrorMessage + "'";
                        }
                       
                        break;
                    case TextType.Number:
                        if (!string.IsNullOrEmpty(FormatErrorMessage))
                        {
                            message += ",number:'" + FormatErrorMessage + "'";
                        }
                        
                        break;

                }

                if (!string.IsNullOrEmpty(message))
                {
                    message = message.Remove(0, 1);

                    p.ValidateRules.Add(new ValidateRule { ID = this.UniqueID, Message = message });
                }
            }
            base.OnLoad(e);
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            if (!string.IsNullOrEmpty(EqualTo))
            {
                writer.AddAttribute("equalTo", EqualTo);
                return;
            }

            if (IsRequired)
            {
                writer.AddAttribute("required", "true");
            }
            switch (Type)
            {
                case TextType.Normal:
                    if (MinTextLength > 0)
                    {
                        writer.AddAttribute("minlength", MinTextLength.ToString());
                    }
                    if (MaxTextLength > 0)
                    {
                        writer.AddAttribute("maxlength", MaxTextLength.ToString());
                    }
                    break;
                case TextType.Email:
                    writer.AddAttribute("email", "true");
                    break;
                case TextType.Url:
                    writer.AddAttribute("url", "true");
                    break;
                case TextType.Int:
                    writer.AddAttribute("digits", "true");
                    if (MinValue > 0)
                    {
                        writer.AddAttribute("min", MinValue.ToString());
                    }
                    if (MaxValue > 0)
                    {
                        writer.AddAttribute("max", MaxValue.ToString());
                    }

                    break;
                case TextType.Number:
                    writer.AddAttribute("number", "true");
                    break;

            }
        }

        public TextType Type
        {
            get;
            set;
        }

        public int MinTextLength 
        {
            get
            {
                if (this.ViewState["MinTextLength"] != null)
                {
                    return (int)this.ViewState["MinTextLength"];
                }
                return 0;
            }
            set
            {
                this.ViewState["MinTextLength"] = value;
            }
        }
        public int MaxTextLength 
        {
            get
            {
                if (this.ViewState["MaxTextLength"] != null)
                {
                    return (int)this.ViewState["MaxTextLength"];
                }
                return 0;
            }
            set
            {
                this.ViewState["MaxTextLength"] = value;
            }
        }
        public int MinValue 
        {
            get
            {
                if (this.ViewState["MinValue"] != null)
                {
                    return (int)this.ViewState["MinValue"];
                }
                return 0;
            }
            set
            {
                this.ViewState["MinValue"] = value;
            }
        }
        public int MaxValue
        {
            get
            {
                if (this.ViewState["MaxValue"] != null)
                {
                    return (int)this.ViewState["MaxValue"];
                }
                return 0;
            }
            set
            {
                this.ViewState["MaxValue"] = value;
            }
        }
        public string EqualTo 
        {
            get
            {
                if (this.ViewState["EqualTo"] != null)
                {
                    return (string)this.ViewState["EqualTo"];
                }
                return string.Empty;
            }
            set
            {
                this.ViewState["EqualTo"] = value;
            }
        }

        public bool IsRequired 
        {
            get
            {
                if (this.ViewState["IsRequired"] != null)
                {
                    return (bool)this.ViewState["IsRequired"];
                }
                return false;
            }
            set
            {
                this.ViewState["IsRequired"] = value;
            }
        }

        public string RequiredErrorMessage
        {
            get
            {
                if (this.ViewState["RequiredErrorMessage"] != null)
                {
                    return (string)this.ViewState["RequiredErrorMessage"];
                }
                return string.Empty;
            }
            set
            {
                this.ViewState["RequiredErrorMessage"] = value;
            }
        }
        public string FormatErrorMessage
        {
            get
            {
                if (this.ViewState["FormatErrorMessage"] != null)
                {
                    return (string)this.ViewState["FormatErrorMessage"];
                }
                return string.Empty;
            }
            set
            {
                this.ViewState["FormatErrorMessage"] = value;
            }
        }
        public string ValueErrorMessage
        {
            get
            {
                if (this.ViewState["ValueErrorMessage"] != null)
                {
                    return (string)this.ViewState["ValueErrorMessage"];
                }
                return string.Empty;
            }
            set
            {
                this.ViewState["ValueErrorMessage"] = value;
            }
        }
    }
}
