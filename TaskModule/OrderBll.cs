using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public static bool UpdateOrder(Model.Order order)
        {
            IOrder orderProvider = new OrderDal(EFContext.Instance);
            return orderProvider.Update(order);
        }

        public static Model.Order GetOrder(int id,bool includeTask=false)
        {
            IOrder orderProvider = new OrderDal(EFContext.Instance);
            return orderProvider.Get(id, includeTask);
        }

        public static IList<Model.Order> GetOrdersForTask(int tid)
        {
            if (tid<=0)
            {
                return null;
            }

            IOrder orderProvider = new OrderDal(EFContext.Instance);
            return orderProvider.GetList(tid);
        }

        public static IList<Model.Order> GetOrders(int page, int pageSize, Expression<Func<Model.Order, bool>> expresion, out int count,bool includeTask=false)
        {
            IOrder orderProvider = new OrderDal(EFContext.Instance);
            return orderProvider.GetList(page,pageSize,includeTask,expresion,out count);
        }

        public static string GetOrderStatus(Model.OrderStatus status)
        {
            switch (status)
            {
                case Model.OrderStatus.New:
                    return "新订单，待确认";
                case Model.OrderStatus.Running:
                    return "订单生产中";
                case Model.OrderStatus.End:
                    return "订单已完成";
            }

            return "";
        }
    }
}
