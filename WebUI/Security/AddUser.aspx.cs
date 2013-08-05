using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Web;
using Security;

namespace WebUI.Security
{
    public partial class AddUser : SecurityPage
    {
        private User user;
        private string action;
        protected void Page_Load(object sender, EventArgs e)
        {
            action = RequestString("action");
            if (action == "modify")
            {
                user = UserBll.GetUser(RequestInt32("id"));
                if (user == null)
                {
                    LinkCollection c = new LinkCollection();
                    c.Add("~/security/addrole.aspx", "添加用户");
                    c.Add("~/security/rolemanage.aspx", "用户管理");

                    WriteMessage("无法获取相关用户信息", c, false);
                }
            }
            if (!IsPostBack)
            {
                cbRoles.DataSource = RoleBll.GetAll();
                cbRoles.DataBind();
                
                if (action == "modify")
                {
                    cbLocked.Checked = user.IsLocked;
                    tbUserName.Text = user.UserName;
                    tbEmial.Text = user.Email;
                    tbPhone.Text = user.Phone;
                    modifymsg.Visible = true;
                    tbUserName.Enabled = false;
                    if (user.Roles!=null)
                    {
                        foreach (Role r in user.Roles)
                        {
                            WebUtility.SetSelectedIndexByValue(cbRoles, r.RoleId.ToString());
                        }
                    }
                }
            }
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            LinkCollection c = new LinkCollection();
            c.Add("~/security/adduser.aspx", "添加用户");
            c.Add("~/security/usermanage.aspx", "用户管理");
            if (action != "modify")
            {
                if (UserBll.UserNameInUse(tbUserName.Text))
                { 
                    WriteMessage("当前用户名已被使用，请更换后重试", c, false);
                }
                user = new User();
                user.IsLocked = false;
                user.JoinTime = DateTime.Now;

            }

            user.UserName = tbUserName.Text;
            user.Email = tbEmial.Text;
            user.Phone = tbPhone.Text;
            user.IsLocked = cbLocked.Checked;
            if (!string.IsNullOrEmpty(tbPassword.Text))
            {
                user.Password = Util.StringHelper.MD5(tbPassword.Text);
            }

            bool result = action == "modify" ? UserBll.UpdateUser(user) : UserBll.AddUser(user);
           
            WriteMessage(result ? "操作执行成功" : "当前操作失败，请选择下列操作", c, result);

        }
    }
}