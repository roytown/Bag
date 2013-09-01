using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using Database;
using Model;
using EntityFramework.Extensions;
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

        public Model.Task Get(int id)
        {
            return _context.Tasks.FirstOrDefault(m => m.Id == id);
        }

        public IList<Task> GetList(int page, int pageSize, System.Linq.Expressions.Expression<Func<Task, bool>> expresion, out int count)
        {
            var q = _context.Tasks.AsQueryable();
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
