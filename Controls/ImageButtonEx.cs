﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Controls
{
    public class ImageButtonEx:ImageButton
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
            get
            {
                if (this.ViewState["Purview"] != null)
                {
                    return (string)this.ViewState["Purview"];
                }
                return string.Empty;
            }
            set
            {
                this.ViewState["Purview"] = value;
            }
        }
    }
}
