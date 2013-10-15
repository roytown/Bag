using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskModule;
using Web;

namespace WebUI.Tech
{
    public partial class DeveConfirm : SecurityPage
    {
        private int id;
        private Model.Task t;
        protected string ecp;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = RequestInt32("id");
            if (id<=0)
            {
                WriteMessage("无法获取有效信息", false);
            }

            t = TaskBll.GetTask(id);
            if (t == null)
            {
                WriteMessage("无法获取有效信息", false);
            }


            if (!IsPostBack)
            {
                LtCode.Text = t.Code;
                LtTitle.Text = t.Title;
                LtDescription.Text = t.Description;

                LtBigness.Text = t.Bigness;
                LTBrand.Text = t.Brand;
                LtCarryPart.Text = t.CarryPart;
                LtCollapse.Text = t.Collapse ? "可折叠" : "不可折叠";
                LtColor.Text = t.Color;
                ecp=LtEcp.Text = t.Ecp;
                LtFineness.Text = t.Fineness;
                LtHardness.Text = t.Hardness;
                LtInternalStructure.Text = t.InternalStructure;
                LtMaterial.Text = t.Materail;
                LtModel.Text = t.Model;
                LtPattern.Text = t.Pattern;
                LtPopularElement.Text = t.PopularElement;
                LtPrice.Text = t.Price;
                LtQuality.Text = t.Quality;
                LtSituation.Text = t.Situation;
                LtSize.Text = t.Size;
                LtStyle.Text = t.Style;
                LtTexture.Text = t.Texture;
                LtType.Text = t.Type;


            }
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            //t.Code = tbCode.Text;
            t.DevelopUserName = tbDevelopUserName.Text;
            t.Status = Model.TaskState.DevelopConfirmed;
            Model.Log l = new Model.Log();
            l.Task = t;
            l.Title = "研发任务确认";
            l.Type = Model.LogType.Normal;
            l.StartUserName = RequestContext.Current.User.UserName;
            l.AddTime = DateTime.Now;
            l.Description = tbDescription.Text;
            l.Action = Model.LogAction.DevelopConfirm;
            t.Logs.Add(l);

            bool flag = TaskBll.UpdateTask(t, new string[] { "Code", "DevelopUserName","Status" });

            WriteMessage(flag ? "操作成功" : "操作失败", flag);
        }
    }
}