using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Database;
using Model;

namespace Security
{
    public class UserBll
    {
        public static bool AddUser(User u)
        {
            IUser userProvider = new UserDal(EFContext.Instance);
            u.Password = Util.StringHelper.MD5(u.Password);
            return userProvider.Add(u);
        }

        public static User GetUser(string userName)
        {
            IUser userProvider = new UserDal(EFContext.Instance);
            return userProvider.Get(userName);
        }

        public static UserStatus ValidateUser(User user)
        {
            IUser userProvider = new UserDal(EFContext.Instance);
            User u = GetUser(user.UserName);
            UserStatus s = UserStatus.None;
            if (u == null)
            {
                return UserStatus.Invalid;
            }

            if (u.FailedPasswordAttemptCount >= 5 && u.FirstFailedPasswordAttempTime.HasValue)
            {
                TimeSpan ts = DateTime.Now.Subtract(u.FirstFailedPasswordAttempTime.Value);
                if (ts.Days == 0 && ts.Minutes <= 10)
                {
                    return UserStatus.OutRetryCount;
                }
                else
                {
                    u.FirstFailedPasswordAttempTime = null;
                }
            }

            if (u.Password != Util.StringHelper.MD5(user.Password))
            {
                if (!u.FirstFailedPasswordAttempTime.HasValue)
                {
                    u.FirstFailedPasswordAttempTime = DateTime.Now;
                    u.FailedPasswordAttemptCount = 0;
                }
                u.FailedPasswordAttemptCount += 1;
                userProvider.Update(u);
                return UserStatus.Invalid;
            }

            if (u.IsLocked)
            {
                return UserStatus.Locked;
            }

            if (u.FirstFailedPasswordAttempTime.HasValue)
            {
                u.FirstFailedPasswordAttempTime = null;
                u.FailedPasswordAttemptCount = 0;
            }
            u.RndPassword = user.RndPassword = Util.StringHelper.GetRadomString(8);
            userProvider.Update(u);

            return UserStatus.Valid;
        }

        public static UserStatus ValidateUser(string userName, string password)
        {
            IUser userProvider = new UserDal(EFContext.Instance);
            User u = GetUser(userName);
            UserStatus s = UserStatus.None;
            if (u==null)
            {
                return UserStatus.Invalid;
            }

            if (u.FailedPasswordAttemptCount >= 5 && u.FirstFailedPasswordAttempTime.HasValue)
            {
                TimeSpan ts = DateTime.Now.Subtract(u.FirstFailedPasswordAttempTime.Value);
                if (ts.Days == 0 && ts.Minutes <= 10)
                {
                    return UserStatus.OutRetryCount;
                }
                else
                {
                    u.FirstFailedPasswordAttempTime = null;
                }
            }
           
            if (u.Password!=Util.StringHelper.MD5(password))
            {
                if (!u.FirstFailedPasswordAttempTime.HasValue)
                {
                    u.FirstFailedPasswordAttempTime = DateTime.Now;
                    u.FailedPasswordAttemptCount = 0;
                }
                u.FailedPasswordAttemptCount+=1;
                userProvider.Update(u);
                return UserStatus.Invalid;
            }

            if (u.IsLocked)
            {
                return UserStatus.Locked;
            }

            if (u.FirstFailedPasswordAttempTime.HasValue)
            {
                u.FirstFailedPasswordAttempTime = null;
                u.FailedPasswordAttemptCount = 0;
            }
            u.RndPassword = Util.StringHelper.GetRadomString(8);
            userProvider.Update(u);

            return UserStatus.Valid;

        }
    }
}
