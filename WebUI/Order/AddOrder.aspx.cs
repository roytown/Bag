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
        private int tid;
        private Model.Task task;
        protected void Page_Load(object sender, EventArgs e)
        {
            tid = RequestInt32("tid");
            if (tid<=0)
            {
                WriteMessage("无法获取任务信息", false);
            }

            task = TaskBll.GetTask(tid,false,true);
            if (task==null)
            {
                WriteMessage("无法获取任务信息", false);
            }

            if (!IsPostBack)
            {
                LtCode.Text = task.Code;
                LtTitle.Text = task.Title;
            }
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (task.Status==Model.TaskState.Ordering)
            {
                //在当前订单上追加订单
                Model.Order lastOrder = task.Orders.OrderBy(m=>m.Id).LastOrDefault();
                if (lastOrder==null)
                {
                     WriteMessage("无法追加订单", false);
                }

                Model.OrderExpand expandOrder = new Model.OrderExpand();
                expandOrder.AddTime = DateTime.Now;
                expandOrder.Description = tbDescription.Text;
                expandOrder.Num = tbNum.Text;
                expandOrder.UserName = RequestContext.Current.User.UserName;
                lastOrder.Expands.Add(expandOrder);
               
            }
            else
            {
                Model.Order order = new Model.Order();
                order.AddTime = DateTime.Now;
                order.Description = tbDescription.Text;
                order.Num = tbNum.Text;
                order.Time = tbTime.Text;
                order.UserName = RequestContext.Current.User.UserName;
                order.Task = new Model.Task { Id = RequestInt32("Id") };

                task.Status = Model.TaskState.WaitOrderConfirm;
            }

            flag = TaskBll.UpdateTask(task);
            WriteMessage(flag ? "操作成功" : "操作失败", flag);
        }
    }
}