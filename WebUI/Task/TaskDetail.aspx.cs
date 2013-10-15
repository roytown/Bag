using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskModule;
using Web;

namespace WebUI.Task
{
    public partial class TaskDetail : SecurityPage
    {
        protected string s1 = "[]";
        protected string Ticks = "[]";
        protected string pie = "[[]]";
        protected int maxDays;
        protected string datearray = "[]";
        protected void Page_Load(object sender, EventArgs e)
        {
            int tid = RequestInt32("tid");
            Model.Task task = TaskBll.GetTask(tid, true, true);
            if (task==null)
            {
                WriteMessage("无法获取任务信息", false);
            }

            LtCode.Text = task.Code;
            LtTitle.Text = task.Title;
            LtDescription.Text = task.Description;

            LtBigness.Text = task.Bigness;
            LTBrand.Text = task.Brand;
            LtCarryPart.Text = task.CarryPart;
            LtCollapse.Text = task.Collapse?"可折叠":"不可折叠";
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

            Repeater1.DataSource = task.Orders;
            Repeater1.DataBind();

            RptLogs.DataSource = task.Logs;
            RptLogs.DataBind();


            if (task.Status == Model.TaskState.Stocked)
            {
                stattr1.Visible = stattr2.Visible = true;
                IDictionary<string, int> dic = new Dictionary<string, int>();
                IList<Model.Log> logs = task.Logs.Where(m => m.Type == Model.LogType.Main).ToList();

                StringBuilder tickBuilder = new StringBuilder("[");
                StringBuilder s1Builder = new StringBuilder("[");
                StringBuilder dateBuilder = new StringBuilder("[");

                IEnumerable<Model.Log> first1 = logs.Where(m => m.Extend == 0 && ((int)m.Action) >= 3 && ((int)m.Action) <= 6);
                maxDays = 0;
                int days = 0;
                string temp = "";
                if (first1 != null)
                {
                    foreach (var item in first1)
                    {
                        temp = LogBll.GetAction(item.Action);
                        tickBuilder.Append("'" + temp + "',");
                        days = (item.RangeEnd.Value - item.RangeBegin.Value).Days;
                        dateBuilder.Append("'" + item.RangeBegin.Value.ToString("yyyy-MM-dd") + "至" + item.RangeEnd.Value.ToString("yyyy-MM-dd") + "',");
                        if (days > maxDays)
                        {
                            maxDays = days;
                        }
                        dic.Add(temp, days);
                        s1Builder.Append("'" + days.ToString() + "',");
                    }

                    var seconds = logs.Where(m => m.Extend > 0 && ((int)m.Action) >= 3 && ((int)m.Action) <= 6).GroupBy(m => m.Extend).Select(g => new { g.Key, RangeEnd = g.Last().RangeEnd.Value, RangeBegin = g.First().RangeBegin.Value });
                    foreach (var item in seconds)
                    {
                        tickBuilder.Append("'修改(" + item.Key.ToString() + ")',");
                        dateBuilder.Append("'" + item.RangeBegin.ToString("yyyy-MM-dd") + "至" + item.RangeEnd.ToString("yyyy-MM-dd") + "',");
                        days = (item.RangeEnd - item.RangeBegin).Days;
                        if (days > maxDays)
                        {
                            maxDays = days;
                        }
                        dic.Add("修改(" + item.Key.ToString() + ")", days);

                        s1Builder.Append("'" + days.ToString() + "',");
                    }

                    IEnumerable<Model.Log> thirds = logs.Where(m => m.Action == Model.LogAction.CustomConfirm || m.Action == Model.LogAction.Order || m.Action == Model.LogAction.Stock);
                    foreach (var item in thirds)
                    {
                        temp = LogBll.GetAction(item.Action);
                        tickBuilder.Append("'" + temp + "',");
                        days = (item.RangeEnd.Value - item.RangeBegin.Value).Days;
                        if (days > maxDays)
                        {
                            maxDays = days;
                        }
                        dic.Add(temp, days);
                        dateBuilder.Append("'" + item.RangeBegin.Value.ToString("yyyy-MM-dd") + "至" + item.RangeEnd.Value.ToString("yyyy-MM-dd") + "',");
                        s1Builder.Append("'" + (item.RangeEnd.Value - item.RangeBegin.Value).Days.ToString() + "',");
                    }
                }

                if (tickBuilder[tickBuilder.Length - 1] == ',')
                {
                    tickBuilder.Remove(tickBuilder.Length - 1, 1);
                    s1Builder.Remove(s1Builder.Length - 1, 1);
                    dateBuilder.Remove(dateBuilder.Length - 1, 1);
                }

                tickBuilder.Append("]");
                s1Builder.Append("]");
                dateBuilder.Append("]");
                s1 = s1Builder.ToString();
                Ticks = tickBuilder.ToString();
                datearray = dateBuilder.ToString();

                if (dic.Count > 0)
                {
                    int total = dic.Sum(m => m.Value);

                    StringBuilder pieBuilder = new StringBuilder();
                    foreach (var item in dic.Keys)
                    {
                        pieBuilder.AppendFormat("['{0}',{1}],", item, (((double)dic[item] / total) * 100).ToString("0"));
                    }

                    pieBuilder.Remove(pieBuilder.Length - 1, 1);

                    pie = "[[" + pieBuilder.ToString() + "]]";
                }
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