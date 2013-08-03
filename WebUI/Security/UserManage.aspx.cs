using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Security;
using Web;
using Util;

namespace WebUI.Security
{
    public partial class UserManage : SecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DdlRoles.DataSource = RoleBll.GetAll();
                DdlRoles.DataBind();
                DdlRoles.Items.Insert(0, new ListItem("不限", ""));
                BindData();
            }
        }

        private void BindData()
        {
           
            int roleId =  DataConverter.ToLng(DdlRoles.SelectedValue);
            int count = 0;
            Repeater1.DataSource = UserBll.GetUsers(pager1.CurrentIndex, pager1.PageSize, roleId,DataSecurity.FilterBadChar(TbUserName.Text),out count);
            Repeater1.DataBind();

            pager1.ItemCount = count;
            
        }

        public void pager_Command(object sender, CommandEventArgs e)
        {
            int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
            pager1.CurrentIndex = currnetPageIndx;
            BindData();
        }


        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                int userId = Util.DataConverter.ToLng(e.CommandArgument);
                if (UserBll.DeleteUser(userId))
                {
                    BindData();
                }
                else
                {
                    LinkCollection cc=new LinkCollection();
                    cc.Add("~/security/adduser.aspx","增加新用户");
                    cc.Add("~/security/usermanage.aspx?page="+RequestInt32("page"),"用户管理");
                    this.WriteMessage("删除操作失败", cc, false);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string idList = Request.Form["usercheck"];
            if (string.IsNullOrEmpty(idList))
            {
                this.WriteMessage("请选择要操作的用户",false);
            }
            bool s = false;
            Button btn = sender as Button;
            if (btn.CommandName=="Lock")
            {
                s = true;
            }
            else if (btn.CommandName == "UnLock")
            {
                s = false;
            }
            else
            {
                this.WriteMessage("操作无效", false);
            }


            bool r = UserBll.SetUserStatus(idList, s);
            if (r)
            {
                BindData();
            }
            else
            {
                this.WriteMessage("当前操作失败，请重试", false);
            }
        }

        protected void BtnFilter_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}