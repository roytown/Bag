using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;

namespace WebUI
{
    public partial class LogOff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RequestContext.Current.User.Identity.IsAuthenticated)
            {
                Util.CookieManager.RemoveUserCookie();
            }

            Response.Redirect("~/login.aspx");
        }
    }
}