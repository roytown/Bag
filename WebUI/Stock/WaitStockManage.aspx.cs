using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskModule;
using Web;

namespace WebUI.Stock
{
    public partial class WaitStockManage : SecurityPage
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
            Expression<Func<Model.Task, bool>> expression = m => m.Status==Model.TaskState.Stocking;
            PageStatus.Add("page", pager1.CurrentIndex.ToString());
            Repeater1.DataSource = TaskBll.GetTaskList(pager1.CurrentIndex, pager1.PageSize, expression, out count);
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
               
                LinkButton lbStock = e.Item.FindControl("lbStock") as LinkButton;

                Model.Task t = e.Item.DataItem as Model.Task;

                lbStock.Visible = t.Status == Model.TaskState.Stocking;
                
                lbStock.OnClientClick = "javascript:OpenDialog('追加订单','/stock/addstocklog.aspx?id=" + t.Id.ToString() + "',800,500);return false;";
            }
        }
    }
}