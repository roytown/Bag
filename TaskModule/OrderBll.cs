using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskModule
{
    public class OrderBll
    {
        public static bool AddOrder(Model.Order order)
        {
            IOrder orderProvider = new OrderDal(EFContext.Instance);
            return orderProvider.Add(order);
        }
    }
}
