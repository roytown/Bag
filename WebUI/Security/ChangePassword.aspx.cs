using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Security;
using Util;
using Web;

namespace WebUI.Security
{
    public partial class ChangePassword : SecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WebConfig config = ConfigFactory.GetWebConfig();
                if (config!=null)
                {
                    newPwd.MinTextLength = config.PasswordMinLength;
                    newPwd.MaxTextLength = config.PasswordMaxLength;
                    newPwd.FormatErrorMessage = "密码长度必须是" + config.PasswordMinLength.ToString() + "到" + config.PasswordMaxLength.ToString() + "个字符";
                    confirmPwd.EqualTo = "#"+newPwd.ClientID;
                }
            }
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            string old = oldPwd.Text;
            string newpassword = newPwd.Text;

            bool flag = UserBll.ChangePassword(RequestContext.Current.User.UserName, old, newpassword);
            if (flag)
            {
                LinkCollection c = new LinkCollection();
                c.Add("~/login.aspx", "登录",true);
                CookieManager.RemoveUserCookie();
                WriteMessage("密码修改成功，请点击下面的链接重新登录",c, true);
            }
            else
            {
                WriteMessage("您填写的旧密码错误，请重试", false);
            }
        }
    }
}