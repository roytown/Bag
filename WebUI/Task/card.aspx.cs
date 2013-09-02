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
    public partial class card : SecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = RequestString("code");
            if (!string.IsNullOrEmpty(code))
            {
                //根据编码获取任务信息
                Model.Task task = TaskBll.GetTask(code);
                if (task==null)
                {
                    WriteMessage("无法获取有效任务信息", false);
                }

                switch (task.Status)
                {
                    case Model.TaskState.DevelopConfirmed:
                    case Model.TaskState.Designing:
                    case Model.TaskState.DesignEnd:
                    case Model.TaskState.Plating:
                    case Model.TaskState.PlateEnd:
                    case Model.TaskState.Sampling:
                    case Model.TaskState.SampleEnd:
                    case Model.TaskState.Packageing:
                    case Model.TaskState.PackageEndAndWaitConfirm:
                        //打开任务操作界面
                        Response.Redirect("~/tech/addevelog.aspx?id=" + task.Id.ToString());
                        break;
                    case Model.TaskState.WaitOrderConfirm:
                        //打开客户确认结果录入界面
                        Response.Redirect("~/task/customconfirmlog.aspx?id=" + task.Id.ToString());
                        break;
                    case Model.TaskState.Ordering:
                        //打开质检记录录入界面
                        Response.Redirect("~/order/addchecklog.aspx?id=" + task.Id.ToString());        
                        break;
                    case Model.TaskState.Stocking:
                        //打开入库记录操作界面
                        Response.Redirect("~/stock/addstocklog.aspx?id=" + task.Id.ToString());
                        break;
                    case Model.TaskState.Stocked:
                        //打开明细界面，含统计报表
                        Response.Redirect("~/stock/statdetail.aspx?id=" + task.Id.ToString());
                        break;
                }

                WriteMessage("当前无可进行的操作", false);
            }
            else
            {
                WriteMessage("无法获取有效任务信息", false);
            }
        }
    }
}