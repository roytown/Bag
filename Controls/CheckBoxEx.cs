using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Controls
{
    public class CheckBoxEx:CheckBox
    {
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
