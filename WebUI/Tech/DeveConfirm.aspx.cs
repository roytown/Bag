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
    public partial class DeveConfirm : SecurityPage
    {
        private int id;
        private Model.Task t;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = RequestInt32("id");
            if (id<=0)
            {
                WriteMessage("无法获取有效信息", false);
            }

            t = TaskBll.GetTask(id);
            if (t == null)
            {
                WriteMessage("无法获取有效信息", false);
            }


            if (!IsPostBack)
            {
                LtTile.Text = t.Title;
                tbCode.Text = t.Code;
                LtDescription.Text = t.Description;
            }
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            t.Code = tbCode.Text;
            t.DevelopUserName = tbDevelopUserName.Text;
            t.Status = Model.TaskState.DevelopConfirmed;
            Model.Log l = new Model.Log();
            l.Task = t;
            l.Title = "研发任务确认";
            l.Type = Model.LogType.Normal;
            l.StartUserName = RequestContext.Current.User.UserName;
            l.AddTime = DateTime.Now;
            l.Description = tbDescription.Text;
            l.Action = Model.LogAction.DevelopConfirm;
            t.Logs.Add(l);

            bool flag = TaskBll.UpdateTask(t, new string[] { "Code", "DevelopUserName","Status" });

            WriteMessage(flag ? "操作成功" : "操作失败", flag);
        }
    }
}