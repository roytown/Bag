using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskModule;
using Web;
using System.Collections;

namespace WebUI.Stock
{
    public partial class StatDetail : SecurityPage
    {
        protected string s1="[]";
        protected string Ticks="[]";
        protected string pie = "[[]]";
        protected int maxDays;
        protected string datearray = "[]";
        protected void Page_Load(object sender, EventArgs e)
        {
            int tid = RequestInt32("id");
            if (tid<=0)
            {
                WriteMessage("无法获取有效的任务信息", false);
            }

            Model.Task task = TaskBll.GetTask(tid,true);
            if (task==null)
            {
                WriteMessage("无法获取有效的任务信息", false);
            }

            LtCode.Text = task.Code;
            LtTitle.Text = task.Title;
            LtDescription.Text = task.Description;

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

            IDictionary<int, KeyValuePair<string, int>> dic = new Dictionary<int, KeyValuePair<string, int>>();
           
            int sum = 0;
            IList<Model.Log> logs = task.Logs.Where(m => m.Type == Model.LogType.Main && m.RangeEnd.HasValue).ToList();
            string temp="";
            if (logs.Count>0)
            {
                StringBuilder tickBuilder = new StringBuilder("[");
                StringBuilder s1Builder = new StringBuilder("[");
                StringBuilder dateBuilder = new StringBuilder("[");

                IEnumerable<Model.Log> first1 = logs.Where(m => m.Extend == 0 && ((int)m.Action) >= 3 && ((int)m.Action) <= 6);
                maxDays = 0;
                int days = 0;
                if (first1!=null)
                {
                    foreach (var item in first1)
                    {
                        temp=LogBll.GetAction(item.Action);
                        tickBuilder.Append("'" + temp + "',");
                        days = (item.RangeEnd.Value - item.RangeBegin.Value).Days;
                        dateBuilder.Append("'" + item.RangeBegin.Value.ToString("yyyy-MM-dd") + "至" + item.RangeEnd.Value.ToString("yyyy-MM-dd")+"',");
                        if (days>maxDays)
                        {
                            maxDays = days;
                        }
                        dic.Add(dic.Count, new KeyValuePair<string, int>(temp, days));
                      
                        sum += days;
                        s1Builder.Append("'" + days.ToString() + "',");
                    }

                    var seconds = logs.Where(m => m.Extend > 0 && ((int)m.Action) >= 3 && ((int)m.Action) <= 6).GroupBy(m => m.Extend).Select(g => new { g.Key,RangeEnd = g.Last().RangeEnd.Value,RangeBegin = g.First().RangeBegin.Value});
                    foreach (var item in seconds)
                    {
                        tickBuilder.Append("'修改(" + item.Key.ToString() + ")',");
                        dateBuilder.Append("'" + item.RangeBegin.ToString("yyyy-MM-dd") + "至" + item.RangeEnd.ToString("yyyy-MM-dd") + "',");
                        days = (item.RangeEnd - item.RangeBegin).Days;
                        if (days > maxDays)
                        {
                            maxDays = days;
                        }
                        dic.Add(dic.Count, new KeyValuePair<string, int>("修改(" + item.Key.ToString() + ")", days));
                     
                        sum += days;
                        s1Builder.Append("'" + days.ToString() + "',");
                    }

                    IEnumerable<Model.Log> thirds = logs.Where(m => m.Action==Model.LogAction.CustomConfirm|| m.Action == Model.LogAction.Order || m.Action == Model.LogAction.Stock);
                    foreach (var item in thirds)
                    {
                        temp = LogBll.GetAction(item.Action);
                        tickBuilder.Append("'" + temp + "',");
                        days = (item.RangeEnd.Value - item.RangeBegin.Value).Days;
                        if (days > maxDays)
                        {
                            maxDays = days;
                        }

                        dic.Add(dic.Count, new KeyValuePair<string, int>(temp, days));
                      
                        sum += days;
                        dateBuilder.Append("'" + item.RangeBegin.Value.ToString("yyyy-MM-dd") + "至" + item.RangeEnd.Value.ToString("yyyy-MM-dd") + "',");
                        s1Builder.Append("'" + (item.RangeEnd.Value - item.RangeBegin.Value).Days.ToString() + "',");
                    }
                }

                if (tickBuilder[tickBuilder.Length-1]==',')
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

                if (dic.Count>0)
                {
                    int total = sum;

                    StringBuilder pieBuilder = new StringBuilder();

                    for (int i = 0; i < dic.Count;++i )
                    {
                        pieBuilder.AppendFormat("['{0}',{1}],", dic[i].Key, (((double)dic[i].Value / total) * 100).ToString("0"));
                        
                    }
                    

                    pieBuilder.Remove(pieBuilder.Length - 1, 1);

                    pie = "[[" + pieBuilder.ToString() + "]]";
                }
            }
        }
    }
}