using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskModule
{
    public class LogDal:ILog
    {
        private EFContext _context;
        public LogDal(EFContext context)
        {
            _context = context;
        }

        public IList<Model.Log> GetList(Expression<Func<Task, bool>> expresion)
        {
            return _context.Logs.Where(expresion).ToList();
        }
    }
}
