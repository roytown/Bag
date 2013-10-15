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
                int tid = RequestInt32("id");
                if (tid>0)
                {
                    maindiv.Visible = true;
                    epcdiv.Visible = false;
                    task = TaskBll.GetTask(RequestInt32("id"), false, true);
                    if (task == null)
                    {
                        WriteMessage("无法获取有效的任务信息", false);
                    }
                   
                    InitTask(task);
                }
            }
        }

        private void InitTask(Model.Task task)
        {
            if (task.Status != Model.TaskState.Stocking)
            {
                WriteMessage("当前任务没有进入入库阶段，无法执行该操作", false);
            }

            LtSaleUserName.Text = task.SaleUserName;
            LtCode.Text = task.Code;
            LtTitle.Text = task.Title;
            LtDescription.Text = task.Description;

            LtBigness.Text = task.Bigness;
            LTBrand.Text = task.Brand;
            LtCarryPart.Text = task.CarryPart;
            LtCollapse.Text = task.Collapse ? "可折叠" : "不可折叠";
            LtColor.Text = task.Color;
            LtEpc.Text = task.Ecp;
            LtFineness.Text = task.Fineness;
            LtHardness.Text = task.Hardness;
            LtInternalStructure.Text = task.InternalStructure;
            LtMaterial.Text = task.Materail;
            LtModel.Text = task.Model;
            LtPattern.Text = task.Pattern;
            LtPopularElement.Text = task.PopularElement;
            LtPrice.Text = task.Price;
            LtQuality.Text = task.Quality;
            LtSituation.Text = task.Situation;
            LtSize.Text = task.Size;
            LtStyle.Text = task.Style;
            LtTexture.Text = task.Texture;
            LtType.Text = task.Type;

            if (task.Orders.Count > 0)
            {
                LtOrderType.Text = "有订单";
                RptOrder.DataSource = task.Orders;
                RptOrder.DataBind();

                ordertr.Visible = true;
            }
            HiddenField1.Value = task.Ecp;
        }

        protected void tbEcp_TextChanged(object sender, EventArgs e)
        {
            string ecp = tbEpc.Text.Trim();
            task = TaskBll.GetTaskByEpc(ecp, false, true);

            if (task == null)
            {
                WriteMessage("无法获取有效的任务信息", false);
            }

            maindiv.Visible = true;
            epcdiv.Visible = false;
            InitTask(task);
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            string epc = HiddenField1.Value;
            task = TaskBll.GetTaskByEpc(epc,true, false,true);
            if (task == null)
            {
                WriteMessage("无法获取有效的任务信息", false);
            }

            Model.Log log=task.Logs.OrderByDescending(m => m.Id).FirstOrDefault(m => m.Action == Model.LogAction.Stock && !m.RangeEnd.HasValue);
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