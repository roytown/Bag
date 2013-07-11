using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;

namespace WebUI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateConfig c = ConfigBase.GetInstance(typeof(ValidateConfig)) as ValidateConfig;
            c.Messages.Add("email", "fsdf");

            c.Update(c);
        }
    }
}