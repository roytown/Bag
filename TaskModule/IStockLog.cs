using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskModule
{
    public interface IStockLog
    {
        IList<Model.StockLog> GetList(int page, int pageSize,bool includeTask, Expression<Func<Model.StockLog, bool>> expresion, out int count);

    }
}
