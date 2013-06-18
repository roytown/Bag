using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Database;

namespace Security
{
    public class UserBll:BllBase
    {
        public static bool AddUser(User u)
        {
            DatabaseContext context = Provider.Get();
            IUser userProvider = new UserDal(context);
            return userProvider.Add(u);
        }

        public static User GetUser(string userName)
        {
            DatabaseContext context = Provider.Get();
            IUser userProvider = new UserDal(context);
            return userProvider.Get(userName);
        }

        public static User GetUser(int userId)
        {
            DatabaseContext context = Provider.Get();
            IUser userProvider = new UserDal(context);
            return userProvider.Get(userId);
        }
    }
}
