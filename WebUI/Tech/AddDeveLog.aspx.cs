using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskModule;
using Web;

namespace WebUI.Tech
{
    public partial class AddDeveLog : SecurityPage
    {
        private int tid;
        private Model.Task task;
        protected void Page_Load(object sender, EventArgs e)
        {
            tid = RequestInt32("id");
            task = TaskBll.GetTask(tid,true);

            if (task == null)
            {
                WriteMessage("无法获取有效的任务信息", false);
            }
            if (!IsPostBack)
            {
                LtCode.Text = task.Code;
                LtTitle.Text = task.Title;
                LtDescription.Text = task.Description.Replace("\r\n", "<br/>");
                LtDeveUserName.Text = task.DevelopUserName;
                LtSaleUserName.Text = task.SaleUserName;

                RptLogs.DataSource = task.Logs.Where(m => m.Type == Model.LogType.Main);
                RptLogs.DataBind();

                //初始化按钮
                switch (task.Status)
                {
                    case Model.TaskState.DevelopConfirmed:
                        btnDesign.Visible = true;
                        break;
                    case Model.TaskState.Designing:
                        btnDesign.Visible = true;
                        btnDesign.Text = "结束设计";
                        btnDesign.CommandName = "DesignEnd";
                        break;
                    case Model.TaskState.DesignEnd:
                        btnPlate.Visible = true;
                        break;
                    case Model.TaskState.Plating:
                        btnPlate.Visible = true;
                        btnPlate.Text = "结束制版";
                        btnPlate.CommandName = "PlateEnd";
                        break;
                    case Model.TaskState.PlateEnd:
                        btnSample.Visible = true;
                        break;
                    case Model.TaskState.Sampling:
                        btnSample.Visible = true;
                        btnSample.Text = "结束打样";
                        btnSample.CommandName = "SampleEnd";
                        break;
                    case Model.TaskState.SampleEnd:
                        btnPackage.Visible = true;
                        break;
                    case Model.TaskState.Packageing:
                        btnPackage.Visible = true;
                        btnPackage.Text = "样包完成";
                        btnPackage.CommandName = "PackageEnd";
                        break;
                   
                }
            }
        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            Model.Log log = null;
            string msg = "";
            Button btn = sender as Button;
            switch (btn.CommandName)
            {
                case "BeginDesign":
                    log = new Model.Log();
                    log.AddTime = DateTime.Now;
                    log.StartUserName = RequestContext.Current.User.UserName;
                    log.Type = Model.LogType.Main;
                    log.Action = Model.LogAction.Design;
                    log.RangeBegin = DateTime.Now;
                    log.Title = "任务（编码：" + task.Code + "）设计记录";
                    log.Extend = task.ModifyTimes;
                    task.Status = Model.TaskState.Designing;
                    task.Logs.Add(log);
                    msg = "任务进入设计阶段";
                    break;
                case "DesignEnd":
                    log = task.Logs.OrderBy(m => m.Id).FirstOrDefault(m => m.Action == Model.LogAction.Design && !m.RangeEnd.HasValue);
                    if (log == null)
                    {
                        WriteMessage("当前无可用数据", false);
                    }

                    log.RangeEnd = DateTime.Now;
                    log.EndUserName = RequestContext.Current.User.UserName;
                    task.Status = Model.TaskState.DesignEnd;
                    msg = "任务设计阶段结束，等待制版";
                    break;
                case "BeginPlate":
                    log = new Model.Log();
                    log.AddTime = DateTime.Now;
                    log.StartUserName = RequestContext.Current.User.UserName;
                    log.Type = Model.LogType.Main;
                    log.Action = Model.LogAction.Plate;
                    log.RangeBegin = DateTime.Now;
                    log.Title = "任务（编码：" + task.Code + "）制版记录";
                    task.Status = Model.TaskState.Plating;
                    log.Extend = task.ModifyTimes;
                    task.Logs.Add(log);
                    msg = "任务进入制版阶段";
                    break;
                case "PlateEnd":
                    log = task.Logs.OrderBy(m => m.Id).FirstOrDefault(m => m.Action == Model.LogAction.Plate && !m.RangeEnd.HasValue);
                    if (log == null)
                    {
                        WriteMessage("当前无可用数据", false);
                    }

                    log.RangeEnd = DateTime.Now;
                    log.EndUserName = RequestContext.Current.User.UserName;
                    task.Status = Model.TaskState.PlateEnd;
                    msg = "任务制版阶段结束，等待打样";
                    break;
                case "BeginSample":
                    log = new Model.Log();
                    log.AddTime = DateTime.Now;
                    log.StartUserName = RequestContext.Current.User.UserName;
                    log.Type = Model.LogType.Main;
                    log.Action = Model.LogAction.Sample;
                    log.RangeBegin = DateTime.Now;
                    log.Title = "任务（编码：" + task.Code + "）打样记录";
                    task.Status = Model.TaskState.Sampling;
                    log.Extend = task.ModifyTimes;
                    task.Logs.Add(log);

                    msg = "任务进入打样阶段";
                    break;
                case "SampleEnd":
                    log = task.Logs.OrderBy(m => m.Id).FirstOrDefault(m => m.Action == Model.LogAction.Sample && !m.RangeEnd.HasValue);
                    if (log == null)
                    {
                        WriteMessage("当前无可用数据", false);
                    }

                    log.RangeEnd = DateTime.Now;
                    log.EndUserName = RequestContext.Current.User.UserName;
                    task.Status = Model.TaskState.SampleEnd;
                    msg = "任务打样阶段结束，可进行样包制作";
                    break;
                case "BeginPackage":
                    log = new Model.Log();
                    log.AddTime = DateTime.Now;
                    log.StartUserName = RequestContext.Current.User.UserName;
                    log.Type = Model.LogType.Main;
                    log.Action = Model.LogAction.Package;
                    log.RangeBegin = DateTime.Now;
                    log.Title = "任务（编码：" + task.Code + "）样包制作记录";
                    task.Status = Model.TaskState.Packageing;
                    log.Extend = task.ModifyTimes;
                    task.Logs.Add(log);
                    msg = "任务进入样包制作阶段";
                    break;
                case "PackageEnd":
                    log = task.Logs.OrderBy(m => m.Id).FirstOrDefault(m => m.Action == Model.LogAction.Package && !m.RangeEnd.HasValue);
                    if (log == null)
                    {
                        WriteMessage("当前无可用数据", false);
                    }

                    log.RangeEnd = DateTime.Now;
                    log.EndUserName = RequestContext.Current.User.UserName;

                    //客户确认操作记录
                    Model.Log customLog = new Model.Log();
                    customLog.Action = Model.LogAction.CustomConfirm;
                    customLog.AddTime = DateTime.Now;
                    customLog.Extend = task.ModifyTimes;
                    customLog.RangeBegin = DateTime.Now;
                    customLog.Title = "任务（编码：" + task.Code + "）客户确认记录";
                    customLog.Type = Model.LogType.Main;
                    customLog.StartUserName = RequestContext.Current.User.UserName;
                    task.Logs.Add(customLog);

                    task.Status = Model.TaskState.PackageEndAndWaitConfirm;
                    msg = "任务样包制作阶段结束，等待客户确认";
                    break;
                default:
                    WriteMessage("无法确定当前任务状态", false);
                    break;
            }

            bool flag = TaskBll.UpdateTask(task);

            if (flag)
            {
                WriteMessage(msg, true);
            }
            WriteMessage("操作过程中发生问题", false);
        }

        protected void RptLogs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType==ListItemType.AlternatingItem||e.Item.ItemType==ListItemType.Item)
            {
                Literal l1 = e.Item.FindControl("Literal1") as Literal;
                Literal l2 = e.Item.FindControl("Literal2") as Literal;
                Literal l3 = e.Item.FindControl("Literal3") as Literal;

                Model.Log log = e.Item.DataItem as Model.Log;
                l1.Text = log.RangeBegin.HasValue ? log.RangeBegin.Value.ToString("yyyy-MM-dd") : "";
                l2.Text = log.RangeEnd.HasValue ? log.RangeEnd.Value.ToString("yyyy-MM-dd") : "";

                if (log.RangeBegin.HasValue&&log.RangeEnd.HasValue)
                {
                    TimeSpan ts = log.RangeEnd.Value - log.RangeBegin.Value;
                    if (ts.Days>0)
                    {
                        l3.Text = ts.Days.ToString() + "天";
                    }
                    else if (ts.Hours > 0)
                    {
                        l3.Text = ts.Hours.ToString() + "小时";
                    }
                    else
                    {
                        l3.Text = ts.Minutes.ToString() + "分钟";
                    }
                    //l3.Text = (log.RangeEnd.Value - log.RangeBegin.Value).Days.ToString();
                }
            }
        }
    }
}