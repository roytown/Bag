using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Controls
{
    public class ButtonEx:Button
    {
        protected override void OnPreRender(EventArgs e)
        {
            if (!string.IsNullOrEmpty(Purview))
            {
                if (!Web.RequestContext.Current.User.Identity.IsAuthenticated || !Web.RequestContext.Current.User.HasPurview(Purview))
                {
                    this.Visible = false;
                }
            }
            base.OnPreRender(e);
        }

        public string Purview
        {
            get;
            set;
        }
    }
}
