using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Security;
using Web;

namespace WebUI.Security
{
    public partial class AddRole : SecurityPage
    {
        protected string currentResource;
        private Role role;
        private string[] purviews;
        private string action;
        protected void Page_Load(object sender, EventArgs e)
        {
            action = RequestString("action");
            if (action == "modify")
            {
                role = RoleBll.GetRole(RequestInt32("id"));
                if (role == null)
                {
                    LinkCollection c = new LinkCollection();
                    c.Add("~/security/addrole.aspx", "添加角色");
                    c.Add("~/security/rolemanage.aspx", "角色管理");

                    WriteMessage("无法获取相关角色信息", c, false);
                }
            }
            if (!IsPostBack)
            {
                if (action == "modify")
                {
                    tbName.Text = role.Name;
                    tbDescription.Text = role.Description;
                    if (string.IsNullOrEmpty(role.Purview))
                    {
                        purviews = new string[0];
                    }
                    else
                    {
                        purviews = role.Purview.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    }
                }

                PageSecuritySection section = (PageSecuritySection)WebConfigurationManager.GetSection("PageSecurity");
                RptResource.DataSource = section.Resources.Resources;
                RptResource.DataBind();
            }
        }

        protected string CheckedResult(string p)
        {
            if (action!="modify" || purviews.Length==0)
            {
                return "";                
            }

            return purviews.Any(m => m == p || m=="-1")?"checked='checked'":"";
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            if (action!="modify")
            {
                role = new Role();
            }

            role.Name = tbName.Text;
            role.Description = tbDescription.Text;
            role.Purview = Request.Form["purview"];

            bool result = action == "modify" ? RoleBll.UpdateRole(role) : RoleBll.AddRole(role);
            LinkCollection c = new LinkCollection();
            c.Add("~/security/addrole.aspx", "添加角色");
            c.Add("~/security/rolemanage.aspx", "角色管理");
            WriteMessage(result?"操作执行成功":"当前操作失败，请选择下列操作", c, result);
           
        }

        protected void RptResource_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType==ListItemType.AlternatingItem|| e.Item.ItemType==ListItemType.Item)
            {
                ResourceElement item = e.Item.DataItem as ResourceElement;
                currentResource = item.Value;

                Repeater r = e.Item.FindControl("RptPurview") as Repeater;
                r.DataSource = item.Purviews;
                r.DataBind();
            }
        }
    }
}