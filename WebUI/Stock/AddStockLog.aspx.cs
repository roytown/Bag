using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskModule;
using Web;

namespace WebUI.Stock
{
    public partial class AddStockLog : SecurityPage
    {
        private Model.Task task;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                task = TaskBll.GetTask(RequestInt32("id"), false, true);
                if (task == null)
                {
                    WriteMessage("无法获取有效的任务信息", false);
                }
                LtCode.Text = task.Code;
                LtDescription.Text = task.Description;
                LtSaleUserName.Text = task.SaleUserName;
                LtTitle.Text = task.Title;

                if ( task.Orders.Count > 0)
                {
                    LtOrderType.Text = "有订单";
                    RptOrder.DataSource = task.Orders;
                    RptOrder.DataBind();

                    ordertr.Visible = true;
                }

            }
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            task = TaskBll.GetTask(RequestInt32("id"),true, false,true);
            if (task == null)
            {
                WriteMessage("无法获取有效的任务信息", false);
            }

            Model.Log log=task.Logs.OrderBy(m => m.Id).FirstOrDefault(m => m.Action == Model.LogAction.Stock && !m.RangeEnd.HasValue);
            if (log==null)
            {
                WriteMessage("当前操作无法执行，无法获取有效的入库状态记录", false);
            }
            log.RangeEnd = DateTime.Now;
            log.EndUserName = RequestContext.Current.User.UserName;
            task.Status = Model.TaskState.Stocked;

            Model.StockLog stocklog = new Model.StockLog();
            stocklog.AddTime = DateTime.Now;
            stocklog.Description = tbDescription.Text;
            stocklog.UserName = RequestContext.Current.User.UserName;
            stocklog.HasOrder = task.Orders.Count > 0;
            task.StockLogs.Add(stocklog);

            if (TaskBll.UpdateTask(task,new string[]{"Status"}))
            {
                WriteMessage("入库操作执行成功", true);
            }

            WriteMessage("入库操作执行失败，请稍后重试", false);
        }
    }
}