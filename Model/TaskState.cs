using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum TaskState
    {
        New,//新任务，待确认
        CanDevelop,//已确认，可研发
        Designing,//可设计
        Plate,//设计结束，可制版
        Sampling,//制版结束，可打样
        WaitCustomConfirm,//样包已完成，等待客户确认
        Ordering,//订单生产中
        Stocking,//样包可入库
        Stocked//样包已入库
    }
}
