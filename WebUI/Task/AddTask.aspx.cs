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
                    

                    WriteMessage("无法获取当前任务相关信息", c, false);
                }
            }
            if (!IsPostBack)
            {
                if (action == "modify")
                {
                    tbName.Text = task.Title;
                    tbDescription.Text = task.Description;
                    tbCode.Text = task.Code;
                    tbCustomer.Text = task.Customer;
                    tbTelephone.Text = task.TelePhone;
                    tbMobilePhone.Text = task.MobilePhone;
                    tbBigness.Text = task.Bigness;
                    tbBrand.Text = task.Brand;
                    tbCarryPart.Text = task.CarryPart;
                    tbColor.Text = task.Color;
                    tbEcp.Text = task.Ecp;
                    tbFineness.Text = task.Fineness;
                    tbHardness.Text = task.Hardness;
                    tbInternalStructure.Text = task.InternalStructure;
                    tbMaterail.Text = task.Materail;
                    tbModel.Text = task.Model;
                    tbPattern.Text = task.Pattern;
                    tbPopularElement.Text = task.PopularElement;
                    tbPrice.Text = task.Price;
                    tbQuality.Text = task.Quality;
                    tbSituation.Text = task.Situation;
                    tbSize.Text = task.Size;
                    tbStyle.Text = task.Style;
                    tbTexture.Text = task.Texture;
                    tbType.Text = task.Type;
                    WebUtility.SetSelectedIndexByValue(RblCollapse, task.Collapse ? "1" : "0");
                }
                else
                {
                    int loop = 10;
                    string str = Util.StringHelper.GetRadomString("0123456789ABCDEF", 24);
                    while (loop>0)
                    {
                        if (!TaskBll.CheckEcpInUse(str))
                        {
                            tbEcp.Text = str;
                            break;
                        }

                        str = Util.StringHelper.GetRadomString("0123456789ABCDEF", 24);
                        loop--;
                    }

                    if (loop==0)
                    {
                        WriteMessage("无法生成Ecp", false);
                    }
                }
            }
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            string code = tbCode.Text;
            string ecp = tbEcp.Text;
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

            task.Bigness = tbBigness.Text;
            task.Brand = tbBrand.Text;
            task.CarryPart = tbCarryPart.Text;
            task.Collapse = RblCollapse.SelectedValue == "1";
            task.Color = tbColor.Text;
            task.Ecp = tbEcp.Text;
            task.Fineness = tbFineness.Text;
            task.Hardness = tbHardness.Text;
            task.InternalStructure = tbInternalStructure.Text;
            task.Materail = tbMaterail.Text;
            task.Model = tbModel.Text;
            task.Pattern = tbPattern.Text;
            task.PopularElement = tbPopularElement.Text;
            task.Price = tbPrice.Text;
            task.Quality = tbQuality.Text;
            task.Situation = tbSituation.Text;
            task.Size = tbSize.Text;
            task.Style = tbStyle.Text;
            task.Texture = tbTexture.Text;
            task.Type = tbType.Text;
            

            bool result = action == "modify" ? TaskBll.UpdateTask(task) : TaskBll.AddTask(task);
            LinkCollection c = new LinkCollection();
            c.Add("~/task/addtask.aspx", "添加任务");

            if (result)
            {
                c.Add("~/task/addtask.aspx?action=modify&id=" + task.Id.ToString(), "修改当前任务"); 
            }
            

            WriteMessage(result ? "操作执行成功" : "当前操作失败，请选择下列操作", c, result);
        }
    }
}