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
        Task Get(int id);
        IList<Task> GetList(int page, int pageSize, Expression<Func<Task, bool>> expresion, out int count);
    }
}
