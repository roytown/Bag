using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;
using ExpressionExtended;
using TaskModule;
namespace WebUI.Order
{
    public partial class OrderManage : SecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            int count = 0;

            string qualityuser = Util.DataSecurity.FilterBadChar(RequestString("qualityuser"));
            string publishuser = Util.DataSecurity.FilterBadChar(RequestString("publishuser"));
            string code = Util.DataSecurity.FilterBadChar(RequestString("code"));
            DateTime? ds = RequestDateTime("ds");
            DateTime? de = RequestDateTime("de");

            Expression<Func<Model.Order, bool>> expression = m => true;
            if (!string.IsNullOrEmpty(qualityuser))
            {

                PageStatus.Add("qualityuser", qualityuser);
                expression = expression.And(m => m.QualityUserName.Contains(qualityuser));
            }
            if (!string.IsNullOrEmpty(publishuser))
            {

                PageStatus.Add("publishuser", publishuser);
                expression = expression.And(m => m.PublishUserName.Contains(publishuser));
            }
            if (!string.IsNullOrEmpty(code))
            {

                PageStatus.Add("code", code);
                expression = expression.And(m => m.Task.Code.Contains(code));
            }
            if (ds != null && ds.HasValue)
            {
                PageStatus.Add("ds", ds.Value.ToString("yyyy-MM-dd"));
                DateTime t1 = new DateTime(ds.Value.Year, ds.Value.Month, ds.Value.Day);
                expression = expression.And(m => m.AddTime >= t1);
            }
            if (de != null && de.HasValue)
            {
                PageStatus.Add("de", de.Value.ToString("yyyy-MM-dd"));
                DateTime dt = new DateTime(de.Value.Year, de.Value.Month, de.Value.Day + 1);
                expression = expression.And(m => m.AddTime <= dt);
            }

            int s = RequestInt32("status", -1);
            PageStatus.Add("status", s.ToString());
            if (s >= 0)
            {
                expression = expression.And(m => m.Status == (Model.OrderStatus)s);
            }
            else if (s == -2)
            {
                expression = expression.And(m => m.Status==Model.OrderStatus.Running);
            }

            int self = RequestInt32("self", -1);
            if (self == 1)
            {
                PageStatus.Add("self", "1");
                expression = expression.And(m => m.PublishUserName == RequestContext.Current.User.UserName);
            }
            else if (self == 2)
            {
                PageStatus.Add("self", "2");
                expression = expression.And(m => m.QualityUserName == RequestContext.Current.User.UserName);
            }

           
            PageStatus.Add("page", pager1.CurrentIndex.ToString());
            Repeater1.DataSource = OrderBll.GetOrders(pager1.CurrentIndex, pager1.PageSize, expression, out count);
            Repeater1.DataBind();
            pager1.ItemCount = count;

            if (count < pager1.PageSize)
            {
                pager1.Visible = false;
            }
        }

        public void pager_Command(object sender, CommandEventArgs e)
        {
            int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
            pager1.CurrentIndex = currnetPageIndx;
            BindData();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                LinkButton lbConfirm = e.Item.FindControl("lbConfirm") as LinkButton;
                
                LinkButton lbLast = e.Item.FindControl("lbLast") as LinkButton;
                LinkButton lbDetail = e.Item.FindControl("lbDetail") as LinkButton;

                Model.Order t = e.Item.DataItem as Model.Order;

                if (t.Status == Model.OrderStatus.New)
                {
                    lbLast.Visible = false;
                }
                else if (t.Status==Model.OrderStatus.Running)
                {
                    lbConfirm.Visible = false;
                    
                }
                else if (t.Status==Model.OrderStatus.End)
                {
                    lbConfirm.Visible = lbLast.Visible = false;
                }

                lbConfirm.OnClientClick = "javascript:OpenDialog('订单确认','/order/orderconfirm.aspx?orderid=" + t.Id.ToString() + "',700,400);return false;";
               lbDetail.OnClientClick = "javascript:OpenDialog('订单明细','/order/orderdetail.aspx?orderid=" + t.Id.ToString() + "',800,500);return false;";
                lbLast.OnClientClick = "javascript:OpenDialog('提交质检记录','/order/addchecklog.aspx?orderid=" + t.Id.ToString() + "',600,400);return false;";
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="Result")
            {
                Model.Order order = OrderBll.GetOrder(Util.DataConverter.ToLng(e.CommandArgument),true);
                if (order==null)
                {
                    WriteMessage("当前无可用数据", false);
                }
                Model.Task task = order.Task;
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
                if (flag)
                {
                    BindData();
                }
                else
                {
                    WriteMessage("更新操作失败,请重试", flag);
                }
                
            }
        }
    }
}