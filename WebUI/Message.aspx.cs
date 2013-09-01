using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;

namespace WebUI
{
    public partial class Message : SecurityPage
    {
        protected bool IsSuccess;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            string message = HttpContext.Current.Items["Message"] as string;
            IsSuccess = (bool)HttpContext.Current.Items["IsSuccess"];
            LinkCollection links = HttpContext.Current.Items["Links"] as LinkCollection;
          
            if (!string.IsNullOrEmpty(message))
            {
                Literal1.Text = message;
                Repeater1.DataSource = links;
                Repeater1.DataBind();
            }
        }
    }
}