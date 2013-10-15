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
        protected int CurrentNum;
        protected string CurrentDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tid = RequestInt32("tid");
                if (tid>0)
                {
                    task = TaskBll.GetTask(tid, false, true);
                    if (task == null)
                    {
                        WriteMessage("无法获取任务信息", false);
                    }

                    tbEpc.Text = task.Ecp;
                    epcdiv.Visible = false;
                    HiddenField1.Value = task.Ecp;
                    if (task.Status==Model.TaskState.Ordering)
                    {
                        Model.Order lastOrder = task.Orders.OrderBy(m => m.Id).LastOrDefault();
                        if (lastOrder==null)
                        {
                            WriteMessage("当前任务状态不符合要求", false);
                        }
                        date2.Text = lastOrder.Time.ToString("yyyy年MM月dd");
                        PnChange.Visible = true;
                        PnNew.Visible = false;
                        LtCurrentNum.Text = LtCurrentNum1.Text = lastOrder.Num.ToString();
                        tbAddNum.Attributes.Add("currentnum", lastOrder.Num.ToString());
                       
                    }
                    else if (task.Status==Model.TaskState.Stocked)
                    {
                        PnNew.Visible = true;
                        PnChange.Visible = false;
                    }
                }

            }
        }

        protected void tbEcp_TextChanged(object sender, EventArgs e)
        {
            string epc = tbEpc.Text.Trim();
            if (string.IsNullOrEmpty(epc))
            {
                WriteMessage("当前EPC信息无效", false);
            }

            Model.Task task = TaskBll.GetTaskByEpc(epc, false, true);
            if (task == null)
            {
                WriteMessage("当前EPC信息无效", false);
            }
            HiddenField1.Value = task.Ecp;
            epcdiv.Visible = false;
            if (task.Status == Model.TaskState.Ordering)
            {
                Model.Order lastOrder = task.Orders.OrderBy(m => m.Id).LastOrDefault();
                if (lastOrder == null)
                {
                    WriteMessage("当前任务状态不符合要求", false);
                }
                date2.Text = lastOrder.Time.ToString("yyyy年MM月dd");
                PnChange.Visible = true;
                PnNew.Visible = false;
                LtCurrentNum.Text = LtCurrentNum1.Text = lastOrder.Num.ToString();
                tbAddNum.Attributes.Add("currentnum", lastOrder.Num.ToString());
            }
            else if (task.Status == Model.TaskState.Stocked)
            {
                PnNew.Visible = true;
                PnChange.Visible = false;
            }
            else
            {
                WriteMessage("当前任务状态不能进行订单追加", false);
            }
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            string epc =  HiddenField1.Value.Trim();
            if (string.IsNullOrEmpty(epc))
            {
                WriteMessage("当前EPC信息无效", false);
            }

            Model.Task task = TaskBll.GetTaskByEpc(epc,true,true);
            if (task==null)
            {
                WriteMessage("当前EPC信息无效", false);
            }

            bool flag = false;
            if (task.Status==Model.TaskState.Ordering)
            {
                //在当前订单上追加订单
                Model.Order lastOrder = task.Orders.OrderBy(m=>m.Id).LastOrDefault();
                if (lastOrder==null)
                {
                     WriteMessage("无法追加订单", false);
                }

                bool change = false;
                int n = Util.DataConverter.ToLng(tbAddNum.Text);
                change = n > 0 || date2.SelectedDate.HasValue;

                
                if (change)
                {
                    lastOrder.Num += n;
                    if (date2.SelectedDate.HasValue)
                    {
                        lastOrder.Time = date2.SelectedDate.Value;
                    }
                    Model.Log stocklog = new Model.Log();
                    stocklog.Action = Model.LogAction.Order;
                    stocklog.AddTime = DateTime.Now;
                    stocklog.RangeBegin = DateTime.Now;
                    stocklog.StartUserName = RequestContext.Current.User.UserName;
                    stocklog.Title = "追加任务订单（编码：" + task.Code + "）";
                    stocklog.Description=(n>0?("数量增加"+n.ToString()):"")+" "+(date2.SelectedDate.HasValue?("日期调整至"+date2.Text):"");
                    stocklog.Type = Model.LogType.Normal;
                    task.Logs.Add(stocklog);

                   
                }
                else
                {
                    WriteMessage("当前没有进行任何操作", true);
                }
                
            }
            else
            {
                Model.Order order = new Model.Order();
                order.AddTime = DateTime.Now;
                order.Description = tbDescription.Text;
                order.Num = Util.DataConverter.ToLng(tbNum.Text);
                order.Time = date1.SelectedDate.HasValue?date1.SelectedDate.Value:DateTime.Now;
                order.UserName = RequestContext.Current.User.UserName;
                task.Orders.Add(order);
                task.Status = Model.TaskState.WaitOrderConfirm;

                Model.Log stocklog = new Model.Log();
                stocklog.Action = Model.LogAction.Order;
                stocklog.AddTime = DateTime.Now;
                stocklog.RangeBegin = DateTime.Now;
                stocklog.StartUserName = RequestContext.Current.User.UserName;
                stocklog.Title = "增加任务订单（编码：" + task.Code + "）";
                stocklog.Type = Model.LogType.Normal;
                task.Logs.Add(stocklog);

              
            }
            flag = TaskBll.UpdateTask(task);
           
            WriteMessage(flag ? "操作成功" : "操作失败", flag);
        }
    }
}