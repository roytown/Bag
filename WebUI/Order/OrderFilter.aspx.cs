using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;

namespace WebUI.Order
{
    public partial class OrderFilter : SecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnFilter_Click(object sender, EventArgs e)
        {
            string url = "~/order/ordermanage.aspx?ds=" + date1.Text + "&de=" + date2.Text + "&code=" + tbCode.Text + "&publishusername=" + tbPublishUserName.Text + "&qualityusername=" + tbQualityUserName.Text + "&status=" + DdlStatus.SelectedValue;

            Response.Redirect(url);
        }
    }
}