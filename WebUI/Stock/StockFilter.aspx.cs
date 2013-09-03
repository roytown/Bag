using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;

namespace WebUI.Stock
{
    public partial class StockFilter : SecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnFilter_Click(object sender, EventArgs e)
        {
            string url = "~/stock/stocklogmanage.aspx?ds=" + date1.Text + "&de=" + date2.Text + "&code=" + tbCode.Text + "&saleusername=" + tbSaleUserName.Text + "&user=" + tbUserName.Text;

            Response.Redirect(url);
        }
    }
}