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
namespace WebUI.Stock
{
    public partial class StockLogManage : SecurityPage
    {
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
            string user = Util.DataSecurity.FilterBadChar(RequestString("user"));
            string saleusername = Util.DataSecurity.FilterBadChar(RequestString("saleusername"));
            string code = Util.DataSecurity.FilterBadChar(RequestString("code"));
            DateTime? ds = RequestDateTime("ds");
            DateTime? de = RequestDateTime("de");

            Expression<Func<Model.StockLog, bool>> expression = m => true;
            if (!string.IsNullOrEmpty(saleusername))
            {

                PageStatus.Add("saleusername", saleusername);
                expression = expression.And(m => m.Task.SaleUserName.Contains(saleusername));
            }
            if (!string.IsNullOrEmpty(user))
            {

                PageStatus.Add("user", user);
                expression = expression.And(m => m.UserName.Contains(user));
            }
            if (!string.IsNullOrEmpty(code))
            {

                PageStatus.Add("code", code);
                expression = expression.And(m => m.Task.Code.Contains(code));
            }
            if (ds != null && ds.HasValue)
            {

                PageStatus.Add("ds", ds.Value.ToString("yyyy-MM-dd"));
                expression = expression.And(m => m.AddTime >= ds.Value);
            }
            if (de != null && de.HasValue)
            {

                PageStatus.Add("de", de.Value.ToString("yyyy-MM-dd"));
                DateTime dt = de.Value.AddDays(1);
                expression = expression.And(m => m.AddTime <= dt);
            }

            PageStatus.Add("page", pager1.CurrentIndex.ToString());
            Repeater1.DataSource = StockLogBll.GetStockLogList(pager1.CurrentIndex, pager1.PageSize, expression, out count,true);
            Repeater1.DataBind();
            pager1.ItemCount = count;

            if (count < pager1.PageSize)
            {
                pager1.Visible = false;
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                LinkButton lbDetail = e.Item.FindControl("lbDetail") as LinkButton;

                Model.StockLog log = e.Item.DataItem as Model.StockLog;

                lbDetail.OnClientClick = "javascript:OpenDialog('任务统计明细','/stock/statedetail.aspx?tid=" + log.Task.Id.ToString() + "',800,500);return false;";
            }
        }
    }
}