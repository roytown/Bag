using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LogActionDictionary
    {
        private static IDictionary<Model.LogAction, string> dic;
        static LogActionDictionary()
        {
            dic = new Dictionary<Model.LogAction, string>();
            dic.Add(Model.LogAction.Design, "设计");
            dic.Add(Model.LogAction.DevelopConfirm, "研发确认");
            dic.Add(Model.LogAction.NewTaskConfirm, "新任务确认");
            dic.Add(Model.LogAction.Order, "订单");
            dic.Add(Model.LogAction.Package, "样包制作");
            dic.Add(Model.LogAction.Plate, "制版");
            dic.Add(Model.LogAction.Sample, "打样");
            dic.Add(Model.LogAction.Stock, "入库");
        }

        public static IDictionary<Model.LogAction, string> Dic
        {
            get
            {
                return dic;
            }
        }
    }
}
