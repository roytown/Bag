using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskModule
{
    public interface IOrder
    {
        bool Add(Model.Order order);
        bool Update(Model.Order order);
        Model.Order Get(int id,bool includeTask);
        IList<Model.Order> GetList(int tid);
    }
}
