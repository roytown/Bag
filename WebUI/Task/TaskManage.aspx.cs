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
    public partial class TaskManage : SecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BtnFilter_Click(object sender, EventArgs e)
        {
            BindData();           
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
            Repeater1.DataSource = TaskBll.GetTaskList(pager1.CurrentIndex, pager1.PageSize, Util.DataSecurity.FilterBadChar(tbCode.Text), date1.SelectedDate, date2.SelectedDate, Util.DataSecurity.FilterBadChar(tbTitle.Text),Util.DataSecurity.FilterBadChar(tbUserName.Text), out count);
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
                
            }
        }
    }
}