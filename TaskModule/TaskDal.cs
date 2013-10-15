using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using Database;
using Model;
using EntityFramework.Extensions;
using System.Linq.Expressions;
namespace TaskModule
{
    public class TaskDal:ITask
    {
        private EFContext _context;
        public TaskDal(EFContext context)
        {
            _context = context;
        }
        public bool Add(Task info)
        {
            _context.Tasks.Add(info);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            Task t = new Task { Id = id };
            _context.Tasks.Attach(t);
            _context.Tasks.Remove(t);
            return _context.SaveChanges() > 0;
        }

        public bool Update(Task info, params string[] modifiedProperty)
        {
            if (modifiedProperty == null || modifiedProperty.Length == 0)
            {
                _context.Entry(info).State = System.Data.EntityState.Modified;
            }
            else
            {
                _context.Tasks.Attach(info);

                var entry = ((IObjectContextAdapter)_context).ObjectContext.ObjectStateManager.GetObjectStateEntry(info);

                if (modifiedProperty != null)
                {
                    foreach (string str in modifiedProperty)
                    {
                        entry.SetModifiedProperty(str);
                    }
                }
            }

            return _context.SaveChanges() > 0;
        }

        public Model.Task Get(int id, bool includeLog, bool includeOrder, bool includeStockLog)
        {
            DbQuery<Model.Task> dbq=_context.Tasks;
            if (includeLog)
            {
                dbq=dbq.Include("Logs");
            }

            if (includeOrder)
            {
		        dbq=dbq.Include("Orders");
            }

            if (includeOrder)
            {
                dbq = dbq.Include("StockLogs");
            }

            return dbq.FirstOrDefault(m => m.Id == id);
        }

        public Model.Task Get(string code, bool includeLog, bool includeOrder, bool includeStockLog)
        {
            DbQuery<Model.Task> dbq=_context.Tasks;
            if (includeLog)
            {
                dbq=dbq.Include("Logs");
            }

            if (includeOrder)
            {
		        dbq=dbq.Include("Orders");
            }
            if (includeOrder)
            {
                dbq = dbq.Include("StockLogs");
            }

            return dbq.FirstOrDefault(m => m.Code == code);
        }

        public Task Get(Expression<Func<Task, bool>> expresion, bool includeLog, bool includeOrder, bool includeStockLog)
        {
            DbQuery<Model.Task> dbq = _context.Tasks;
            if (includeLog)
            {
                dbq = dbq.Include("Logs");
            }

            if (includeOrder)
            {
                dbq = dbq.Include("Orders");
            }
            if (includeOrder)
            {
                dbq = dbq.Include("StockLogs");
            }
            var q = dbq.AsQueryable();
            if (expresion != null)
            {
                q = q.Where(expresion);
            }

            return q.FirstOrDefault();
        }

        public int Count(Expression<Func<Task, bool>> expresion)
        {
            var dbq = _context.Tasks.AsQueryable();
            if (expresion != null)
            {
                dbq = dbq.Where(expresion);
            }

            return dbq.Count();
        }

        public IList<Task> GetList(int page, int pageSize, bool includeLog, bool includeOrder, bool includeStockLog, System.Linq.Expressions.Expression<Func<Task, bool>> expresion, out int count)
        {
            DbQuery<Model.Task> dbq=_context.Tasks;
            if (includeLog)
            {
                dbq=dbq.Include("Logs");
            }

            if (includeOrder)
            {
		        dbq=dbq.Include("Orders");
            }
            if (includeOrder)
            {
                dbq = dbq.Include("StockLogs");
            }

            var q = dbq.OrderByDescending(m => m.Id).AsQueryable();
            if (expresion != null)
            {
                q = q.Where(expresion);
            }
            
            var qc = q.FutureCount();
            var q1 = q.Skip((page - 1) * pageSize).Take(pageSize);
            count = qc.Value;
            return q1.ToList();
        }
    }
}
