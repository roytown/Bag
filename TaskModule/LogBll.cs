using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ExpressionExtended;
namespace TaskModule
{
    public class LogBll
    {
        public static IList<Model.Log> GetTaskLogs(int tid, Expression<Func<Model.Log, bool>> expression)
        {
            if (tid <= 0)
            {
                return null;
            }
            Expression<Func<Model.Log, bool>> where = m => m.Task.Id == tid;
            if (expression != null)
            {
                where = where.And(expression);
            }
            ILog logDal = new LogDal(EFContext.Instance);
            return logDal.GetList(where);
        }

        public static bool AddLog(Model.Log log)
        {
            ILog logDal = new LogDal(EFContext.Instance);
            return logDal.Add(log);
        }

        public static Model.Log GetLog(int tid, Model.LogAction action, int ex)
        {
            ILog logDal = new LogDal(EFContext.Instance);
            return logDal.Get(tid, action, ex);
        }
    }
}
