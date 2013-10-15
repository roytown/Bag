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
            if (!IsPostBack)
            {
                int orderid = RequestInt32("orderid");
                if (orderid>0)
                {
                    epctable.Visible = false;
                    maindiv.Visible = true;

                    order = OrderBll.GetOrder(RequestInt32("orderid"));

                    if (order == null)
                    {
                        WriteMessage("无法获取有效订单信息", false);
                    }

                    HiddenField1.Value = order.Id.ToString();
                }
            }
        }

        protected void tbEcp_TextChanged(object sender, EventArgs e)
        {
            string ecp = tbEpc.Text.Trim();
            task = TaskBll.GetTaskByEpc(ecp,false,true);

            if (task == null)
            {
                WriteMessage("无法获取有效的任务信息", false);
            }

            order = task.Orders.LastOrDefault(m => m.Status == Model.OrderStatus.Running);
            if (order==null)
            {
                WriteMessage("无法获取有效的订单信息", false);
            }

            HiddenField1.Value = order.Id.ToString();

            maindiv.Visible = true;
            epctable.Visible = false;
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            int orderid = Util.DataConverter.ToLng(HiddenField1.Value);

            order = OrderBll.GetOrder(orderid,false,true);
            if (order == null)
            {
                WriteMessage("无法获取有效的订单信息", false);
            }

            Model.OrderCheckLog log = new Model.OrderCheckLog();
            log.AddTime = DateTime.Now;
            log.Description = tbDescription.Text;
            log.Type=(Model.CheckLogType)Util.DataConverter.ToLng(RblType.SelectedValue);
            log.UserName=RequestContext.Current.User.UserName;

            order.OrderCheckLogs.Add(log);

            bool flag = OrderBll.UpdateOrder(order);

            WriteMessage(flag ? "记录提交成功" : "记录提交失败", flag);

        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            Model.Log log = task.Logs.OrderByDescending(m => m.Id).FirstOrDefault(m => m.Action == Model.LogAction.Order && !m.RangeEnd.HasValue);
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