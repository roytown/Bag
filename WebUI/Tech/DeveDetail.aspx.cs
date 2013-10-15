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
    public partial class DeveDetail : SecurityPage
    {
        private int tid;
        protected void Page_Load(object sender, EventArgs e)
        {
            tid = RequestInt32("id");

            if (!IsPostBack)
            {
                Model.Task task = TaskBll.GetTask(tid);

                if (task==null)
                {
                    WriteMessage("无法获取有效的任务信息", false);
                }

                LtCode.Text = task.Code;
                LtTitle.Text = task.Title;
                LtDescription.Text = task.Description.Replace("\r\n", "<br/>");

                LtBigness.Text = task.Bigness;
                LTBrand.Text = task.Brand;
                LtCarryPart.Text = task.CarryPart;
                LtCollapse.Text = task.Collapse ? "可折叠" : "不可折叠";
                LtColor.Text = task.Color;
                LtEcp.Text = task.Ecp;
                LtFineness.Text = task.Fineness;
                LtHardness.Text = task.Hardness;
                LtInternalStructure.Text = task.InternalStructure;
                LtMaterial.Text = task.Materail;
                LtModel.Text = task.Model;
                LtPattern.Text = task.Pattern;
                LtPopularElement.Text = task.PopularElement;
                LtPrice.Text = task.Price;
                LtQuality.Text = task.Quality;
                LtSituation.Text = task.Situation;
                LtSize.Text = task.Size;
                LtStyle.Text = task.Style;
                LtTexture.Text = task.Texture;
                LtType.Text = task.Type;


                LtSaleUserName.Text = task.SaleUserName;

                RptLogs.DataSource = task.Logs.Where(m => m.Type == Model.LogType.Main);
                RptLogs.DataBind();
            }
        }

        protected void RptLogs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Literal l1 = e.Item.FindControl("Literal1") as Literal;
                Literal l2 = e.Item.FindControl("Literal2") as Literal;
                Literal l3 = e.Item.FindControl("Literal3") as Literal;

                Model.Log log = e.Item.DataItem as Model.Log;
                l1.Text = log.RangeBegin.HasValue ? log.RangeBegin.Value.ToString("yyyy-MM-dd") : "";
                l2.Text = log.RangeEnd.HasValue ? log.RangeEnd.Value.ToString("yyyy-MM-dd") : "";

                if (log.RangeBegin.HasValue && log.RangeEnd.HasValue)
                {
                    TimeSpan ts = log.RangeEnd.Value - log.RangeBegin.Value;
                    if (ts.Days > 0)
                    {
                        l3.Text = ts.Days.ToString() + "天";
                    }
                    else if (ts.Hours > 0)
                    {
                        l3.Text = ts.Hours.ToString() + "小时";
                    }
                    else
                    {
                        l3.Text = ts.Minutes.ToString() + "分钟";
                    }
                    //l3.Text = (log.RangeEnd.Value - log.RangeBegin.Value).Days.ToString();
                }
            }
        }

    }
}