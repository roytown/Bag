using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskModule
{
    public class StockLogBll
    {
        public static IList<Model.StockLog> GetStockLogList(int page, int pageSize, Expression<Func<Model.StockLog, bool>> expression, out int count, bool includeTask = false)
        {
            IStockLog provider = new StockLogDal(EFContext.Instance);

            return provider.GetList(page, pageSize, includeTask, expression, out count);
        }
    }
}
