using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskModule
{
    public interface IOrder
    {
        bool Add(Model.Order order);
        bool AddLog(Model.OrderCheckLog log);
        bool Update(Model.Order order);
        Model.Order Get(int id,bool includeTask,bool includeLog);
        int Count(Expression<Func<Model.Order, bool>> expresion);
        IList<Model.Order> GetList(int tid);
        IList<Model.Order> GetList(int page, int pageSize, bool includeTask, Expression<Func<Model.Order, bool>> expresion, out int count);
    }
}
