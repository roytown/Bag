using Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
namespace TaskModule
{
    public class OrderDal:IOrder
    {
        private EFContext _context;
        public OrderDal(EFContext context)
        {
            _context = context;
        }
        public bool Add(Model.Order order)
        {
            _context.Orders.Add(order);
            _context.Tasks.Attach(order.Task);
            _context.Entry<Model.Task>(order.Task).State = System.Data.EntityState.Unchanged;
            return _context.SaveChanges() > 0;
        }
        public int Count(Expression<Func<Model.Order, bool>> expresion)
        {
            var dbq = _context.Orders.AsQueryable();
            if (expresion != null)
            {
                dbq = dbq.Where(expresion);
            }

            return dbq.Count();
        }
        public bool AddLog(Model.OrderCheckLog log)
        {
            _context.OrderCheckLogs.Add(log);
            
            return _context.SaveChanges() > 0;
        }

        public bool Update(Model.Order order)
        {
            _context.Orders.Attach(order);
            _context.Entry(order).State = System.Data.EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public Model.Order Get(int id, bool includeTask, bool includeLog)
        {
            DbQuery<Model.Order> dbq = _context.Orders;
            if (includeTask)
            {
                dbq = dbq.Include("Task");
            }
            if (includeLog)
            {
                dbq = dbq.Include("OrderCheckLogs");
            }
            return dbq.FirstOrDefault(m => m.Id == id);
        }

        public IList<Model.Order> GetList(int tid)
        {
            return _context.Orders.Where(m => m.Task.Id == tid).ToList();
        }

        public IList<Model.Order> GetList(int page, int pageSize, bool includeTask, Expression<Func<Model.Order, bool>> expresion, out int count)
        {
            DbQuery<Model.Order> dbq = _context.Orders;
            if (includeTask)
            {
                dbq = dbq.Include("Task");
            }


            var q = dbq.AsQueryable();
            if (expresion != null)
            {
                q = q.Where(expresion);
            }
            var qc = q.FutureCount();
            var q1 = q.OrderBy(u => u.Id).Skip((page - 1) * pageSize).Take(pageSize);
            count = qc.Value;
            return q1.ToList();
        }
    }
}
