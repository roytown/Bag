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
    public partial class OrderConfirm : SecurityPage
    {
        private int id;
        private Model.Order t;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            id = RequestInt32("orderid");
            if (id <= 0)
            {
                WriteMessage("无法获取有效信息", false);
            }

            t = OrderBll.GetOrder(id, true);
            if (t == null)
            {
                WriteMessage("无法获取有效信息", false);
            }

            t.Status = Model.OrderStatus.Running;
            t.PublishUserName = tbPublishUserName.Text;
            t.QualityUserName = tbQualityUserName.Text;
            t.Task.Status = Model.TaskState.Ordering;

            Model.Log l = new Model.Log();
            l.Task = t.Task;
            l.Title = "任务（编码："+t.Task.Code+"）订单记录";
            l.Type = Model.LogType.Main;
            l.StartUserName = RequestContext.Current.User.UserName;
            l.AddTime = DateTime.Now;
            l.RangeBegin = DateTime.Now;
            l.Description = tbDescription.Text;
            l.Action = Model.LogAction.Order;
            t.Task.Logs.Add(l);

            bool flag = TaskBll.UpdateTask(t.Task, new string[] { "Status" });

            WriteMessage(flag ? "操作成功" : "操作失败", flag);
        }
    }
}