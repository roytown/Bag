using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskModule;
using Web;

namespace WebUI.Tech
{
    public partial class DeveDetail : SecurityPage
    {
        private int tid;
        protected void Page_Load(object sender, EventArgs e)
        {
            tid = RequestInt32("id");

            if (!IsPostBack)
            {
                Model.Task task = TaskBll.GetTask(tid);

                if (task==null)
                {
                    WriteMessage("无法获取有效的任务信息", false);
                }


            }
        }
    }
}