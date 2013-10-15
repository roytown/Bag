using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskModule;
using Web;

namespace WebUI.Order
{
    public partial class OrderDetail : SecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int orderId = RequestInt32("orderid");
            Model.Order order = OrderBll.GetOrder(orderId,true,true);
            if (order==null)
            {
                WriteMessage("无法获取订单信息", true);
            }
            Model.Task task = order.Task;
            LtCode.Text = task.Code;
            LtTitle.Text = task.Title;
            LtDescription.Text = task.Description;

            LtBigness.Text = task.Bigness;
            LTBrand.Text = task.Brand;
            LtCarryPart.Text = task.CarryPart;
            LtCollapse.Text = task.Collapse ? "可折叠" : "不可折叠";
            LtColor.Text = task.Color;
            LtEcp.Text = task.Ecp;
            LtFineness.Text = task.Fineness;
            LtHardness.Text = task.Hardness;
            LtInternalStructure.Text = task.InternalStructure;
            LtMaterial.Text = task.Materail;
            LtModel.Text = task.Model;
            LtPattern.Text = task.Pattern;
            LtPopularElement.Text = task.PopularElement;
            LtPrice.Text = task.Price;
            LtQuality.Text = task.Quality;
            LtSituation.Text = task.Situation;
            LtSize.Text = task.Size;
            LtStyle.Text = task.Style;
            LtTexture.Text = task.Texture;
            LtType.Text = task.Type;


            ltqualityusername.Text = order.QualityUserName;
            LtTime.Text = order.Time.ToString("yyyy-MM-dd");
            Ltpublishusername.Text = order.PublishUserName;
            LtNum.Text = order.Num.ToString();
            LtDescription.Text = order.Description;

            //Repeater1.DataSource = order.Expands;
            //Repeater1.DataBind();

            if (RequestContext.Current.User.HasPurview(tr1.Attributes["purivew"]))
            {
                Repeater2.DataSource = order.OrderCheckLogs;
                Repeater2.DataBind();
            }
            else
            {
                tr1.Visible = tr2.Visible = false;
            }
            
        }
    }
}