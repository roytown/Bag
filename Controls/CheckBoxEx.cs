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
            get;
            set;
        }
        public string RequiredErrorMessage
        {
            get;
            set;
        }
    }
}
