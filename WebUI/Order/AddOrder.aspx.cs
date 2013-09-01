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
    public partial class AddOrder : SecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            Model.Order order = new Model.Order();
            order.AddTime = DateTime.Now;
            order.Description = tbDescription.Text;
            order.Num = tbNum.Text;
            order.Time = tbTime.Text;
            order.UserName = RequestContext.Current.User.UserName;
            order.Task = new Model.Task { Id = RequestInt32("Id") };

            bool flag = OrderBll.AddOrder(order);
            LinkCollection cc = new LinkCollection();
            cc.Add("/order/addorder.aspx", "增加新订单");
            cc.Add("/order/addorder.aspx?action=modify&id="+order.Id.ToString(), "修改当前订单");
            WriteMessage(flag ? "操作成功" : "操作失败",cc, flag);
        }
    }
}