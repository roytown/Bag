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
                        btnPackage.Text = "样包制作完成";
                        btnPackage.CommandName = "PackageEnd";
                        break;
                    case Model.TaskState.PackageEndAndWaitConfirm:
                        break;
                    case Model.TaskState.WaitOrderConfirm:
                        break;
                    case Model.TaskState.Ordering:
                        break;
                    case Model.TaskState.Stocking:
                        break;
                    case Model.TaskState.Stocked:
                        break;
                    default:
                        break;
                }
            }
        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            Model.Log log = new Model.Log();
            log.AddTime = DateTime.Now;
            log.UserName = RequestContext.Current.User.UserName;
            log.Type = Model.LogType.Main;
            log.Task = task;
           
            Button btn = sender as Button;
            switch (btn.CommandName)
            {
                case "BeginDesign":
                    log.Action = Model.LogAction.Design;
                    log.RangeBegin = DateTime.Now;
                    log.Title = "任务（编码：" + task.Code + "）开始进行设计";
                    
                    break;
                case "DesignEnd":

                    log.Action = Model.LogAction.Design;
                    log.RangeBegin = DateTime.Now;
                    log.Title = "任务（编码：" + task.Code + "）设计结束";
                    break;
                default:
                    break;
            }

            bool flag = LogBll.AddLog(log);
        }
    }
}