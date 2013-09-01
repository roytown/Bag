using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Database;
using Model;
using EntityFramework.Extensions;
using ExpressionExtended;
namespace Security
{
    public class UserBll
    {
        public static bool AddUser(User u)
        {
            IUser userProvider = new UserDal(EFContext.Instance);

            return userProvider.Add(u);
        }

        public static bool UserNameInUse(string userName)
        {
            IUser userProvider = new UserDal(EFContext.Instance);
            return userProvider.UserNameInUse(userName);
        }

        public static User GetUser(string userName)
        {
            IUser userProvider = new UserDal(EFContext.Instance);
            return userProvider.Get(userName);
        }

        public static User GetUser(int userId)
        {
            if (userId<=0)
            {
                return null;
            }
            IUser userProvider = new UserDal(EFContext.Instance);
            return userProvider.Get(userId);
        }

        public static List<User> GetUsers(int page, int pageSize,int roleId,string userName, out int count)
        {
            IUser userProvider = new UserDal(EFContext.Instance);
            if (page<=0)
            {
                page = 1;
            }
            Expression<Func<User, bool>> expresion = m=>true;
            if (roleId>0)
            {
                expresion = expresion.And(m => m.Roles.Any(r => r.RoleId == roleId));
            }
            //Expression<Func<User, bool>> expresion = m=>m.Roles.Any(r=>r.RoleId==roleId);
            if (!string.IsNullOrEmpty(userName))
            {
                expresion = expresion.And(m => m.UserName.Contains(userName));
            }

            return userProvider.GetList(page, pageSize,expresion, out count);
        }

        public static UserStatus ValidateUser(User user)
        {
            IUser userProvider = new UserDal(EFContext.Instance);
            User u = GetUser(user.UserName);
           
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
            u.LastLoginIP = user.LastLoginIP;
            u.LastLoginTime = DateTime.Now;
            userProvider.Update(u);

            return UserStatus.Valid;
        }

        public static UserStatus ValidateUser(string userName, string password)
        {
            IUser userProvider = new UserDal(EFContext.Instance);
            User u = GetUser(userName);
            
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

        public static bool ChangePassword(string userName, string old, string newPwd)
        {
            User u = GetUser(userName);
            if (u==null)
            {
                return false;
            }

            if (u.Password!=Util.StringHelper.MD5(old))
            {
                return false;
            }

            u.Password = Util.StringHelper.MD5(newPwd);
            IUser userProvider = new UserDal(EFContext.Instance);
            return userProvider.Update(u, new string[] { "Password" });

        }

        public static bool DeleteUser(int userId)
        {
            if (userId<=0)
            {
                return false;
            }
            IUser userProvider = new UserDal(EFContext.Instance);
            return userProvider.Delete(userId);
        }

        public static bool SetUserStatus(string idList, bool status)
        {
            if (string.IsNullOrEmpty(idList) || !Util.DataValidator.IsValidId(idList))
            {
                return false;
            }
            IUser userProvider = new UserDal(EFContext.Instance);
            return userProvider.SetStatus(idList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray(), status);
        }

        public static bool UpdateUser(User u, params string[] modifiedProperty)
        {
            IUser userProvider = new UserDal(EFContext.Instance);
            return userProvider.Update(u,modifiedProperty);
        }
    }
}
