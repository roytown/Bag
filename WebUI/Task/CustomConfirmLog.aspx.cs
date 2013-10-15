using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskModule;
using Web;

namespace WebUI.Task
{
    public partial class CustomConfirmLog : SecurityPage
    {
        private int tid;
        private Model.Task task;
        private Model.Log customlog;
        protected void Page_Load(object sender, EventArgs e)
        {
            tid = RequestInt32("id");
            if (tid<=0)
            {
                WriteMessage("无法获取有效信息", false);
            }
            task = TaskBll.GetTask(tid);
            if (task == null)
            {
                WriteMessage("无法获取有效信息", false);
            }

            customlog = task.Logs.FirstOrDefault(m => m.Action == Model.LogAction.CustomConfirm && !m.RangeEnd.HasValue);
            if (customlog == null)
            {
                WriteMessage("当前任务状态不正确", false);
            }

            if (!IsPostBack)
            {
                LtCode.Text = task.Code;
                LtTitle.Text = task.Title;
                LtDescription.Text = task.Description;
            }
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            //更新确认记录时间
            customlog.RangeEnd = DateTime.Now;
            customlog.EndUserName = RequestContext.Current.User.UserName;
            string msg = "";

            //增加确认日志
            Model.Log confirmlog = new Model.Log();
            confirmlog.Action = Model.LogAction.CustomConfirm;
            confirmlog.AddTime = DateTime.Now;
            confirmlog.Task = task;
            confirmlog.Title = "任务（编码：" + task.Code + "）已完成客户确认";
            confirmlog.Description = "确认结果为" + RblResult.SelectedItem.Text;
            confirmlog.Type = Model.LogType.Normal;
            confirmlog.StartUserName = RequestContext.Current.User.UserName;
            task.Logs.Add(confirmlog);

            if (RblResult.SelectedValue=="1")
            {
                //增加订单
                task.Status = Model.TaskState.WaitOrderConfirm;
                Model.Order order=new Model.Order();
                order.AddTime=DateTime.Now;
                order.Description=tbOrderDesc.Text;
                order.Num = Util.DataConverter.ToLng(tbOrderNum.Text);
                order.Status = Model.OrderStatus.New;
                order.Time = date1.SelectedDate.HasValue?date1.SelectedDate.Value:DateTime.Now;
                order.UserName = RequestContext.Current.User.UserName;

                msg = "订单确认";
                task.Orders.Add(order);
              
            }
            else if (RblResult.SelectedValue == "0")
            {
                task.Status = Model.TaskState.DevelopConfirmed;
                task.ModifyTimes+=1;
                msg = "研发修改";
            }
            else if (RblResult.SelectedValue == "2")
            {
                task.Status = Model.TaskState.Stocking;

                Model.Log logstock = new Model.Log();
                logstock.Action = Model.LogAction.Stock;
                logstock.AddTime = DateTime.Now;
                logstock.Task = task;
                logstock.Title = "任务（编码：" + task.Code + "）待入库";
                logstock.Type = Model.LogType.Main;
                logstock.StartUserName = RequestContext.Current.User.UserName;
                logstock.RangeBegin = DateTime.Now;
                msg = "样包入库";
                task.Logs.Add(logstock);
            }

            bool flag = TaskBll.UpdateTask(task);
            if (flag)
            {
                WriteMessage("当前操作已执行，等待" + msg, true);
            }

            WriteMessage("当前操作无法执行，请核实信息后重试", false);
        }
    }
}