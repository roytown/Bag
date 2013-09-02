using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskModule
{
    public class LogDal : ILog
    {
        private EFContext _context;
        public LogDal(EFContext context)
        {
            _context = context;
        }

        public IList<Model.Log> GetList(Expression<Func<Model.Log, bool>> expresion)
        {
            return _context.Logs.Where(expresion).ToList();
        }


        public bool Add(Model.Log log)
        {
            _context.Logs.Add(log);
            return _context.SaveChanges() > 0;
        }

        public Model.Log Get(int tid, Model.LogAction action,int ex)
        {
            return _context.Logs.FirstOrDefault(m => m.Action == action && m.Task.Id == tid && m.Extend==ex);
        }
    }
}
