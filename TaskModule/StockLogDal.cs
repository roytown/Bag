using Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionExtended;
using EntityFramework.Extensions;
namespace TaskModule
{
    public class StockLogDal:IStockLog
    {
        private EFContext _context;
        public StockLogDal(EFContext context)
        {
            _context = context;
        }
        public IList<Model.StockLog> GetList(int page, int pageSize, bool includeTask, System.Linq.Expressions.Expression<Func<Model.StockLog, bool>> expresion, out int count)
        {
            DbQuery<Model.StockLog> dbq = _context.StockLogs;
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
