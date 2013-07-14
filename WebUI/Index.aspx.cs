using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;

namespace WebUI
{
    public partial class Index : SecurityPage
    {
        protected string Title;
        protected void Page_Load(object sender, EventArgs e)
        {
            WebConfig config = ConfigFactory.GetWebConfig();
            if (config!=null)
            {
                Title = config.Title;
            }
        }
    }
}