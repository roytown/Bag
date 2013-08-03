using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Security
{
    public interface IUser
    {
        bool Add(User u);
        bool Delete(int userId);
        bool Update(User u);
        bool ChangePassword(string userName, string password);
        User Get(string userName);
        User Get(string userName, string password);
        List<User> GetList(int page, int pageSize, Expression<Func<User, bool>> expresion, out int count);
        bool ValidateUser(string userName, string password);
        int GetCount();
        bool SetStatus(int[] idList, bool status);
    }
}
