using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;

namespace WebUI.Tech
{
    public partial class DeveFilter : SecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void BtnFilter_Click(object sender, EventArgs e)
        {
            string url = "~/tech/devemanage.aspx?ds=" + date1.Text + "&de=" + date2.Text + "&code=" + tbCode.Text + "&title=" + tbTitle.Text + "&status=" + DdlStatus.SelectedValue + "&developusername=" + tbDevelopUserName.Text;

            Response.Redirect(WebUtility.AppendSecurityCode(url));
                
        }
    }
}