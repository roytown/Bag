using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Security;
using Web;

namespace WebUI.Security
{
    public partial class RoleManage : SecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater1.DataSource = RoleBll.GetAll();
                Repeater1.DataBind();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                int id = Util.DataConverter.ToLng(e.CommandArgument);
                if (RoleBll.RoleEnableDelete(id))
                {
                    bool flag = RoleBll.DeleteRole(id);
                    if (flag)
                    {
                        Repeater1.DataSource = RoleBll.GetAll();
                        Repeater1.DataBind();
                    }
                    else
                    {
                        LinkCollection c = new LinkCollection();
                        c.Add("~/security/rolemanage.aspx", "返回重试");

                        WriteMessage("删除角色失败，请重试", c, false);
                    }
                }
                else
                {
                    LinkCollection c = new LinkCollection();
                    c.Add("~/security/rolemanage.aspx", "角色管理");

                    WriteMessage("当前角色下已有用户，不能删除", c, false);
                }
            }
        }
    }
}