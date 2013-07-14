using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Web;

namespace Controls
{
    public class CheckBoxEx:CheckBox
    {
        protected override void OnLoad(EventArgs e)
        {
            if ((this.Page is SecurityPage) && IsRequired&&!string.IsNullOrEmpty(RequiredErrorMessage))
            {
                SecurityPage p = this.Page as SecurityPage;
                p.ValidateRules.Add(new ValidateRule { ID = this.UniqueID, Message = "required:'" + RequiredErrorMessage + "'" });
            }
            base.OnLoad(e);
        }
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            if (IsRequired)
            {
                writer.AddAttribute("required", "true");
            }
            base.AddAttributesToRender(writer);
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
    }
}
