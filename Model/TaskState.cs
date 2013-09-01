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
        DevelopConfirmed,//研发确认，可开始研发
        Designing,//设计中
        DesignEnd,//设计结束，可制版
        Plating,//制版中
        PlateEnd,//制版结束，可打样
        Sampling,//打样中
        SampleEnd,//打样结束，样包可生产
        Packageing,//样包生产中
        PackageEndAndWaitConfirm,//样包已完成，等待客户确认
       
        WaitOrderConfirm,
        Ordering,//订单生产中
        Stocking,//样包可入库
        Stocked//样包已入库
    }
}
