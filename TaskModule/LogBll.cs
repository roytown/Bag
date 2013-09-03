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

        public static string GetAction(Model.LogAction a)
        {
            switch (a)
            {
                case Model.LogAction.Design:
                    return "设计";
                case Model.LogAction.Plate:
                    return "制版";
                   
                case Model.LogAction.Sample:
                    return "打样";
                
                case Model.LogAction.Package:
                    return "样包制作";
                   
                case Model.LogAction.Order:
                    return "订单";
                    
                case Model.LogAction.Stock:
                    return "入库";
                case Model.LogAction.CustomConfirm:
                    return "客户确认";
            }

            return "";
        }
    }
}
