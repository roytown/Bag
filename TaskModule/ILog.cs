using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskModule
{
    public interface ILog
    {
        IList<Model.Log> GetList(Expression<Func<Model.Log, bool>> expresion);
    }
}
