using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskModule;
using Web;

namespace WebUI.Stock
{
    public partial class StatDetail : SecurityPage
    {
        protected string s1="[]";
        protected string Ticks="[]";
        protected int maxDays;
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
            LtDescription.Text = task.Description;
            LtTitle.Text = task.Title;

            IList<Model.Log> logs = task.Logs.Where(m => m.Type == Model.LogType.Main).ToList();

            if (logs.Count>0)
            {
                StringBuilder tickBuilder = new StringBuilder("[");
                StringBuilder s1Builder = new StringBuilder("[");

                IEnumerable<Model.Log> first1 = logs.Where(m => m.Extend == 0 && ((int)m.Action) >= 3 && ((int)m.Action) <= 6);
                maxDays = 0;
                int days = 0;
                if (first1!=null)
                {
                    foreach (var item in first1)
                    {
                        tickBuilder.Append("'"+LogBll.GetAction(item.Action)+"',");
                        days = (item.RangeEnd.Value - item.RangeBegin.Value).Days;
                        if (days>maxDays)
                        {
                            maxDays = days;
                        }
                        s1Builder.Append("'" + days.ToString() + "',");
                    }

                    var seconds = logs.Where(m => m.Extend > 0 && ((int)m.Action) >= 3 && ((int)m.Action) <= 6).GroupBy(m => m.Extend).Select(g => new { g.Key,(g.Last().RangeEnd.Value-g.First().RangeBegin.Value).Days});
                    foreach (var item in seconds)
                    {
                        tickBuilder.Append("'修改(" + item.Key.ToString() + ")',");
                       
                        if (item.Days > maxDays)
                        {
                            maxDays = item.Days;
                        }
                        s1Builder.Append("'" + item.Days.ToString() + "',");
                    }

                    IEnumerable<Model.Log> thirds = logs.Where(m => m.Action==Model.LogAction.CustomConfirm|| m.Action == Model.LogAction.Order || m.Action == Model.LogAction.Stock);
                    foreach (var item in thirds)
                    {
                        tickBuilder.Append("'" + LogBll.GetAction(item.Action) + "',");
                        days = (item.RangeEnd.Value - item.RangeBegin.Value).Days;
                        if (days > maxDays)
                        {
                            maxDays = days;
                        }
                        s1Builder.Append("'" + (item.RangeEnd.Value - item.RangeBegin.Value).Days.ToString() + "',");
                    }
                }

                if (tickBuilder[tickBuilder.Length-1]==',')
                {
                    tickBuilder.Remove(tickBuilder.Length - 1, 1);
                    s1Builder.Remove(s1Builder.Length - 1, 1);
                }

                tickBuilder.Append("]");
                s1Builder.Append("]");
                s1 = s1Builder.ToString();
                Ticks = tickBuilder.ToString();
            }
        }
    }
}