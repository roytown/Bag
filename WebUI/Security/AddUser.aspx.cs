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

                Web.WebConfig config = ConfigFactory.GetWebConfig();
                
                tbPassword.MinTextLength = config.PasswordMinLength>0?config.PasswordMinLength:6;
                tbPassword.MaxTextLength = config.PasswordMaxLength>0?config.PasswordMaxLength:10;
                tbPassword.FormatErrorMessage = "密码长度为" + tbPassword.MinTextLength.ToString() + "到" + tbPassword.MaxTextLength.ToString() + "位";
                
                if (action == "modify")
                {
                    cbLocked.Checked = user.IsLocked;
                    tbUserName.Text = user.UserName;
                    tbEmial.Text = user.Email;
                    tbPhone.Text = user.Phone;
                    modifymsg.Visible = true;
                    tbUserName.Enabled = false;
                    tbPassword.IsRequired = false;
                    if (user.Roles != null)
                    {

                        for (int i = 0; i < cbRoles.Items.Count; ++i)
                        {
                            cbRoles.Items[i].Selected = user.Roles.Any(m => m.RoleId.ToString() == cbRoles.Items[i].Value);
                        }

                    }
                }
            }
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            IList<Role> roles = RoleBll.GetAll();
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
                user.Roles = new List<Model.Role>();
            }
            else
            {
                user.Roles.Clear();
            }

            user.UserName = tbUserName.Text;
            user.Email = tbEmial.Text;
            user.Phone = tbPhone.Text;
            user.IsLocked = cbLocked.Checked;
            if (!string.IsNullOrEmpty(tbPassword.Text))
            {
                user.Password = Util.StringHelper.MD5(tbPassword.Text);
            }

            foreach (ListItem item in cbRoles.Items)
            {
                if (item.Selected)
                {
                    user.Roles.Add(roles.First(m=>m.RoleId== Util.DataConverter.ToLng(item.Value) ));
                }
            }

            bool result = action == "modify" ? UserBll.UpdateUser(user) : UserBll.AddUser(user);
           
            WriteMessage(result ? "操作执行成功" : "当前操作失败，请选择下列操作", c, result);

        }
    }
}