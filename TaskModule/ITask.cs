using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Linq.Expressions;

namespace TaskModule
{
    public interface ITask
    {
        bool Add(Task info);
        bool Delete(int id);
        bool Update(Task info, params string[] modifiedProperty);
        Task Get(int id,bool includeLog,bool includeOrder);
        Task Get(string code,bool includeLog,bool includeOrder);
        IList<Task> GetList(int page, int pageSize,bool includeLog,bool includeOrder, Expression<Func<Task, bool>> expresion, out int count);
    }
}
