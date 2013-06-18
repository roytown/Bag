using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public interface IUser
    {
        bool Add(User u);
        bool Delete(int userId);
        bool Update(User u);
        bool ChangePassword(string userName, string password);
        User Get(string userName);
        User Get(int userId);
        User Get(string userName, string password);
        List<User> GetList(int page, int pageSize, out int count);
    }
}
