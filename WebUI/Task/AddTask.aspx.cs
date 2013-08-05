using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;
using TaskModule;

namespace WebUI.Task
{
    public partial class AddTask : SecurityPage
    {
        private string action;
        private Model.Task task;
        protected void Page_Load(object sender, EventArgs e)
        {
            action = RequestString("action");

            if (action == "modify")
            {
                task = TaskBll.GetTask(RequestInt32("id"));
                if (task == null)
                {
                    LinkCollection c = new LinkCollection();
                    c.Add("~/task/addtask.aspx", "添加新任务");
                    c.Add("~/task/taskmanage.aspx", "所有任务记录");

                    WriteMessage("无法获取当前任务相关信息", c, false);
                }
            }
            if (!IsPostBack)
            {
                if (action == "modify")
                {
                    codetr.Visible = true;
                    tbName.Text = task.Title;
                    tbDescription.Text = task.Description;
                    tbCode.Text = task.Code;
                    tbCustomer.Text = task.Customer;
                    tbTelephone.Text = task.TelePhone;
                    tbMobilePhone.Text = task.MobilePhone;
                }
            }
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            if (action != "modify")
            {
                task = new Model.Task();
                task.AddTime = DateTime.Now;
                task.UserName = RequestContext.Current.User.UserName;
            }

            task.Title = tbName.Text;
            task.Description = tbDescription.Text;
            task.Code = tbCode.Text;
            task.Customer = tbCustomer.Text;
            task.MobilePhone = tbMobilePhone.Text;
            task.TelePhone = tbTelephone.Text;

            bool result = action == "modify" ? TaskBll.UpdateTask(task,new string[]{"Title","Description","Code","Customer","MobilePhone","Telephone"}) : TaskBll.AddTask(task);
            LinkCollection c = new LinkCollection();
            c.Add("~/task/addtask.aspx", "添加任务");
            c.Add("~/task/taskmanage.aspx", "所有任务");

            WriteMessage(result ? "操作执行成功" : "当前操作失败，请选择下列操作", c, result);
        }
    }
}