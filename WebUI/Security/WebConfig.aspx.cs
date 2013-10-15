using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;

namespace WebUI.Security
{
    public partial class WebConfig : SecurityPage
    {
        private Web.WebConfig config;
        protected void Page_Load(object sender, EventArgs e)
        {
            config = ConfigFactory.GetWebConfig();
            if (!IsPostBack)
            {
                //DdlRoles.DataSource = RoleBll.GetAll();
                //DdlRoles.DataBind();

                tbTitle.Text = config.Title;
                tbCopyright.Text = config.Copyright;
                tbTickeTime.Text = config.TicketTime.ToString();
                tbMinLength.Text = config.PasswordMinLength.ToString();
                tbMaxLength.Text = config.PasswordMaxLength.ToString();
                tbSelLessonTimes.Text = config.SelLessonTimeLimit.ToString();
                tbHomeworkCommitTimes.Text = config.HomeworkCommitTimeLimit.ToString();
                //WebUtility.SetSelectedIndexByValue(DdlRoles, config.DefaultRole.ToString());
            }
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            config.Title = tbTitle.Text;
            config.Copyright = tbCopyright.Text;
            config.TicketTime = Util.DataConverter.ToLng(tbTickeTime.Text);
            config.PasswordMinLength = Util.DataConverter.ToLng(tbMinLength.Text);
            config.PasswordMaxLength = Util.DataConverter.ToLng(tbMaxLength.Text);
            config.SelLessonTimeLimit = Util.DataConverter.ToLng(tbSelLessonTimes.Text);
            config.HomeworkCommitTimeLimit = Util.DataConverter.ToLng(tbHomeworkCommitTimes.Text);
            //config.DefaultRole = Util.DataConverter.ToLng(DdlRoles.SelectedValue);
           
            try
            {
                config.Update(config);
            }
            catch
            {

                WriteMessage("修改失败，请检查是否有目录操作权限", false);
            }

            WriteMessage("修改成功", true);
        }
    }
}