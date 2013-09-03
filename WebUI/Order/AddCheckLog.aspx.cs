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
    public partial class AddCheckLog : SecurityPage
    {
        private Model.Order order;
        private Model.Task task;
        protected void Page_Load(object sender, EventArgs e)
        {
            int tid = RequestInt32("tid");
            if (tid > 0)
            {
                task = TaskBll.GetTask(tid,false,true);
                if (task==null)
                {
                    WriteMessage("无法获取有效订单信息", false);
                }

                order = task.Orders.OrderByDescending(m=>m.Id).FirstOrDefault(m => m.Status == Model.OrderStatus.Running);
            }
            else
            {
                order = OrderBll.GetOrder(RequestInt32("orderid"),true);
                task = order.Task;
            }

            if (order == null)
            {
                WriteMessage("无法获取有效订单信息", false);
            }
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
          
            Model.OrderCheckLog log = new Model.OrderCheckLog();
            log.AddTime = DateTime.Now;
            log.Description = tbDescription.Text;
            log.Order=order;
            log.Type=(Model.CheckLogType)Util.DataConverter.ToLng(RblType.SelectedValue);
            log.UserName=RequestContext.Current.User.UserName;

            order.OrderCheckLogs.Add(log);

            bool flag = OrderBll.UpdateOrder(order);

            WriteMessage(flag ? "记录提交成功" : "记录提交失败", flag);

        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            Model.Log log = task.Logs.OrderBy(m => m.Id).FirstOrDefault(m => m.Action == Model.LogAction.Order && !m.RangeEnd.HasValue);
            if (log == null)
            {
                WriteMessage("当前无可用数据", false);
            }

            log.RangeEnd = DateTime.Now;
            log.EndUserName = RequestContext.Current.User.UserName;
            task.Status = Model.TaskState.Stocking;

            order.Status = Model.OrderStatus.End;

            Model.Log stocklog = new Model.Log();
            stocklog.Action = Model.LogAction.Stock;
            stocklog.AddTime = DateTime.Now;
            stocklog.RangeBegin = DateTime.Now;
            stocklog.StartUserName = RequestContext.Current.User.UserName;
            stocklog.Title = "任务（编码：" + task.Code + "）入库记录";
            stocklog.Type = Model.LogType.Main;
            task.Logs.Add(stocklog);

            bool flag = TaskBll.UpdateTask(task, new string[] { "Status" });

            WriteMessage(flag ? "订单已完成，等待入库" : "更新操作失败,请重试", flag);
        }
    }
}