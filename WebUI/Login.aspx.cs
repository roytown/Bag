using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Security;

namespace WebUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //  UserBll.AddUser(new User { UserName = "fff", Password = "fsdf", JoinTime = DateTime.Now, Roles = new List<Role> { new Role(){ Name="管理员"}} });
        }
    }
}