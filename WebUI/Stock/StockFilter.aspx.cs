using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(tbBigness.Text))
            {
                builder.Append("&bigness=" + tbBigness.Text);
            }
            if (!string.IsNullOrEmpty(tbBrand.Text))
            {
                builder.Append("&brand=" + tbBrand.Text);
            }
            if (!string.IsNullOrEmpty(tbCarryPart.Text))
            {
                builder.Append("&carrypart=" + tbCarryPart.Text);
            }
            if (!string.IsNullOrEmpty(tbColor.Text))
            {
                builder.Append("&color=" + tbColor.Text);
            }
            if (!string.IsNullOrEmpty(tbEcp.Text))
            {
                builder.Append("&ecp=" + tbEcp.Text);
            }
            if (!string.IsNullOrEmpty(tbFineness.Text))
            {
                builder.Append("&fineness=" + tbFineness.Text);
            }
            if (!string.IsNullOrEmpty(tbHardness.Text))
            {
                builder.Append("&hardness=" + tbHardness.Text);
            }
            if (!string.IsNullOrEmpty(tbInternalStructure.Text))
            {
                builder.Append("&internalstructure=" + tbInternalStructure.Text);
            }
            if (!string.IsNullOrEmpty(tbMaterail.Text))
            {
                builder.Append("&materail=" + tbMaterail.Text);
            }
            if (!string.IsNullOrEmpty(tbModel.Text))
            {
                builder.Append("&model=" + tbModel.Text);
            }
            if (!string.IsNullOrEmpty(tbPattern.Text))
            {
                builder.Append("&pattern=" + tbPattern.Text);
            }
            if (!string.IsNullOrEmpty(tbPopularElement.Text))
            {
                builder.Append("&popularelement=" + tbPopularElement.Text);
            }
            if (!string.IsNullOrEmpty(tbPrice.Text))
            {
                builder.Append("&price=" + tbPrice.Text);
            }
            if (!string.IsNullOrEmpty(tbQuality.Text))
            {
                builder.Append("&quality=" + tbQuality.Text);
            }
            if (!string.IsNullOrEmpty(tbSituation.Text))
            {
                builder.Append("&situation=" + tbSituation.Text);
            }
            if (!string.IsNullOrEmpty(tbSize.Text))
            {
                builder.Append("&size=" + tbSize.Text);
            }
            if (!string.IsNullOrEmpty(tbStyle.Text))
            {
                builder.Append("&style=" + tbStyle.Text);
            }
            if (!string.IsNullOrEmpty(tbTexture.Text))
            {
                builder.Append("&texture=" + tbTexture.Text);
            }
            if (!string.IsNullOrEmpty(tbType.Text))
            {
                builder.Append("&type=" + tbType.Text);
            }
            builder.Append("&collapse=" + RblCollapse.SelectedValue);
            
            Response.Redirect(url+builder.ToString());
        }
    }
}