using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskModule;
using Web;
using ExpressionExtended;
using Controls;
namespace WebUI.Task
{
    public partial class TaskManage : SecurityPage
    {
        private bool HasDelPurview;
        private bool HasConfirmPurview;
       
        private bool HasModifyPurview;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                BindData();
            }
        }


        public void pager_Command(object sender, CommandEventArgs e)
        {
            int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
            pager1.CurrentIndex = currnetPageIndx;
            BindData();
        }

        private void BindData()
        {
            int count = 0;

            string title = Util.DataSecurity.FilterBadChar(RequestString("title"));
            string user = Util.DataSecurity.FilterBadChar(RequestString("user"));
            string code = Util.DataSecurity.FilterBadChar(RequestString("code"));
            DateTime? ds=RequestDateTime("ds");
            DateTime? de=RequestDateTime("de");

            Expression<Func<Model.Task, bool>> expression = m => true;
            if (!string.IsNullOrEmpty(title))
            {
               
                PageStatus.Add("title",title);
                expression = expression.And(m => m.Title.Contains(title));
            }
            if (!string.IsNullOrEmpty(user))
            {
                
                PageStatus.Add("user", user);
                expression = expression.And(m => m.UserName.Contains(user));
            }
            if (!string.IsNullOrEmpty(code))
            {
               
                PageStatus.Add("code", code);
                expression = expression.And(m => m.Code.Contains(code));
            }
            if (ds!=null && ds.HasValue)
            {
                PageStatus.Add("ds", ds.Value.ToString("yyyy-MM-dd"));
                DateTime t1 = new DateTime(ds.Value.Year, ds.Value.Month, ds.Value.Day);
                expression = expression.And(m => m.AddTime>=t1);
            }
            if (de!=null && de.HasValue)
            {
               
                PageStatus.Add("de", de.Value.ToString("yyyy-MM-dd"));
                DateTime dt =new DateTime(de.Value.Year,de.Value.Month,de.Value.Day+1);
                expression = expression.And(m => m.AddTime<=dt);
            }

            int s=RequestInt32("status",-1);
            PageStatus.Add("status", s.ToString());
            if (s>=0)
            {
                Model.TaskState ts = (Model.TaskState)s;
                if (ts == Model.TaskState.PackageEndAndWaitConfirm)
                {
                    expression = expression.And(m => m.SaleUserName == RequestContext.Current.User.UserName);
                }
                
                expression = expression.And(m => m.Status == ts);
            }

            int self = RequestInt32("self", -1);
            if (self==1)
            {
                PageStatus.Add("self", "1");
                expression = expression.And(m => m.SaleUserName == RequestContext.Current.User.UserName);
            }

            HasDelPurview = RequestContext.Current.User.HasPurview("task_delete");
            HasConfirmPurview = RequestContext.Current.User.HasPurview("task_confirm");
           
            HasModifyPurview = RequestContext.Current.User.HasPurview("task_update");
          
            PageStatus.Add("page", pager1.CurrentIndex.ToString());
            Repeater1.DataSource = TaskBll.GetTaskList(pager1.CurrentIndex, pager1.PageSize,expression, out count);
            Repeater1.DataBind();
            pager1.ItemCount = count;
            
            if (count < pager1.PageSize)
            {
                pager1.Visible = false;
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                int id = Util.DataConverter.ToLng(e.CommandArgument);
                if (TaskBll.DeleteTask(id))
                {
                    BindData();
                }
                else
                {
                    LinkCollection cc = new LinkCollection();
                    cc.Add("javascript:history.goback();", "返回");

                    WriteMessage("删除失败", cc, false);
                }
            }
            
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                LinkButton lbmodify = e.Item.FindControl("lbModify") as LinkButton;
                LinkButton lbdel = e.Item.FindControl("lbDel") as LinkButton;
                LinkButton lbconfirm = e.Item.FindControl("lbConfirm") as LinkButton;
                LinkButtonEx lbAddOrder = e.Item.FindControl("lbAddOrder") as LinkButtonEx;
                LinkButton lbOrderExpand = e.Item.FindControl("lbOrderExpand") as LinkButton;
                LinkButton lbDetail = e.Item.FindControl("lbDetail") as LinkButton;
                LinkButton lbStock = e.Item.FindControl("lbStock") as LinkButton;

                Model.Task t = e.Item.DataItem as Model.Task;

                if (t.Status != Model.TaskState.PackageEndAndWaitConfirm)
                {
                    lbAddOrder.Visible = false;
                }

                lbmodify.Visible = (t.Status == Model.TaskState.New) && HasModifyPurview;
                lbdel.Visible = (t.Status == Model.TaskState.New) && HasDelPurview;
                lbconfirm.Visible = (t.Status == Model.TaskState.New) && HasConfirmPurview;
                lbStock.Visible = t.Status == Model.TaskState.Stocking;
                lbOrderExpand.Visible = t.Status == Model.TaskState.Ordering || t.Status == Model.TaskState.Stocked;

                lbmodify.OnClientClick = "javascript:OpenDialog('修改任务信息','/task/addtask.aspx?action=modify&id=" + t.Id.ToString() + "',700,500);return false;";
                lbconfirm.OnClientClick = "javascript:OpenDialog('确认任务','/task/taskconfirm.aspx?id=" + t.Id.ToString() + "',500,400);return false;";
                lbAddOrder.OnClientClick = "javascript:OpenDialog('客户确认结果','/task/customconfirmlog.aspx?id=" + t.Id.ToString() + "',800,500);return false;";
                lbOrderExpand.OnClientClick = "javascript:OpenDialog('追加订单','/order/addorder.aspx?tid=" + t.Id.ToString() + "',800,500);return false;";
                lbDetail.OnClientClick = "javascript:OpenDialog('任务明细','/task/taskdetail.aspx?tid=" + t.Id.ToString() + "',800,500);return false;";
                lbStock.OnClientClick = "javascript:OpenDialog('入库记录','/stock/addstocklog.aspx?id=" + t.Id.ToString() + "',800,500);return false;";
            }
        }
    }
}