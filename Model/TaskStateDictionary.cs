using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TaskStateDictionary
    {
        private static IDictionary<Model.TaskState, string> dic;
        static TaskStateDictionary()
        {
            dic = new Dictionary<Model.TaskState, string>();
            dic.Add(Model.TaskState.CanDevelop, "已确认，可研发");
            dic.Add(Model.TaskState.DesignEnd, "设计技术，可制版");
            dic.Add(Model.TaskState.Designing, "设计进行中");
            dic.Add(Model.TaskState.DevelopConfirmed, "研发已确认，可开始研发");
            dic.Add(Model.TaskState.New, "新任务待确认");
            dic.Add(Model.TaskState.Ordering, "订单生产中");
            dic.Add(Model.TaskState.PackageEndAndWaitConfirm, "样包已完成，等待客户确认");
            dic.Add(Model.TaskState.Packageing, "样包生产中");
            dic.Add(Model.TaskState.PlateEnd, "制版结束，可打样");
            dic.Add(Model.TaskState.Plating, "制版中");
            dic.Add(Model.TaskState.SampleEnd, "打样结束，可进行样包生产");
            dic.Add(Model.TaskState.Sampling, "打样进行中");
            dic.Add(Model.TaskState.Stocked, "已入库");
            dic.Add(Model.TaskState.Stocking, "待入库");
            dic.Add(Model.TaskState.WaitOrderConfirm, "待订单确认");
        }

        public static IDictionary<Model.TaskState, string> Dic
        {
            get
            {
                return dic;
            }
        }
    }
}
