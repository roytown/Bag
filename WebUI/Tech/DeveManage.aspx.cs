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
namespace WebUI.Tech
{
    public partial class DeveManage : SecurityPage
    {
       
        private bool HasDevelopConfirmPurview;

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
            string developuser = Util.DataSecurity.FilterBadChar(RequestString("user"));
            string code = Util.DataSecurity.FilterBadChar(RequestString("code"));
            DateTime? ds = RequestDateTime("ds");
            DateTime? de = RequestDateTime("de");

            Expression<Func<Model.Task, bool>> expression = m => true;
            if (!string.IsNullOrEmpty(title))
            {
                PageStatus.Add("title", title);
                expression = expression.And(m => m.Title.Contains(title));
            }
            if (!string.IsNullOrEmpty(developuser))
            {
                PageStatus.Add("user", developuser);
                expression = expression.And(m => m.DevelopUserName.Contains(developuser));
            }
            if (!string.IsNullOrEmpty(code))
            {
                PageStatus.Add("code", code);
                expression = expression.And(m => m.Code.Contains(code));
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

            int s = RequestInt32("status", -1);
            if (s >= 0)
            {
                PageStatus.Add("status", s.ToString());
                Model.TaskState ts = (Model.TaskState)s;
                if (ts == Model.TaskState.PackageEndAndWaitConfirm)
                {
                    expression = expression.And(m => m.SaleUserName == RequestContext.Current.User.UserName);
                }

                expression = expression.And(m => m.Status == ts);
            }
            else
            {
                expression = expression.And(m => (int)m.Status >1);
            }

            int self = RequestInt32("self", -1);
            if (self == 1)
            {
                PageStatus.Add("self", "1");
                expression = expression.And(m => m.DevelopUserName == RequestContext.Current.User.UserName);
            }

            HasDevelopConfirmPurview = RequestContext.Current.User.HasPurview("tech_developconfirm");
           
            PageStatus.Add("page", pager1.CurrentIndex.ToString());
            Repeater1.DataSource = TaskBll.GetTaskList(pager1.CurrentIndex, pager1.PageSize, expression, out count);
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
                LinkButton lbDevelopConfirm = e.Item.FindControl("lbDevelopConfirm") as LinkButton;
                LinkButton lbAddlog = e.Item.FindControl("lbAddlog") as LinkButton;

                Model.Task t = e.Item.DataItem as Model.Task;
                lbDevelopConfirm.Visible = (t.Status == Model.TaskState.CanDevelop) && HasDevelopConfirmPurview;
                lbDevelopConfirm.OnClientClick = "javascript:OpenDialog('确认研发任务','/tech/deveconfirm.aspx?id=" + t.Id.ToString() + "',500,400);return false;";
                lbAddlog.OnClientClick = "javascript:OpenDialog('发布研发日志','/tech/adddevelog.aspx?id=" + t.Id.ToString() + "',500,400);return false;";
            }
        }
    }
}