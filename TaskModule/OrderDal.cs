using Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _context.SaveChanges() > 0;
        }

        public bool Update(Model.Order order)
        {
            _context.Orders.Attach(order);
            _context.Entry(order).State = System.Data.EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public Model.Order Get(int id, bool includeTask)
        {
            DbQuery<Model.Order> dbq = _context.Orders;
            if (includeTask)
            {
                dbq = dbq.Include("Task");
            }

            return dbq.FirstOrDefault(m => m.Id == id);
        }

        public IList<Model.Order> GetList(int tid)
        {
            return _context.Orders.Where(m => m.Task.Id == tid).ToList();
        }
    }
}
