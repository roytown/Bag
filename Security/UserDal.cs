using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Model;
using EntityFramework.Extensions;
using System.Linq.Expressions;
namespace Security
{
    public class UserDal:IUser
    {
        private EFContext _context;
        public UserDal(EFContext context)
        {
            _context = context;
        }

        public bool Add(User u)
        {
            _context.Users.Add(u);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int userId)
        {
            User u = new User { UserId = userId };
            _context.Users.Attach(u);
            _context.Users.Remove(u);
            return _context.SaveChanges()>0;
        }

        public int GetCount()
        {
            return _context.Users.Count();
        }

        public bool Update(User u)
        {
            _context.Users.Attach(u);
            _context.Entry(u).State = System.Data.EntityState.Modified;
            return _context.SaveChanges()>0;
            
        }

        public bool ChangePassword(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public User Get(string userName)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(m => m.UserName == userName);
        }

        public User Get(string userName, string password)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(m => m.UserName == userName && m.Password == password);
        }

        public List<User> GetList(int page, int pageSize, Expression<Func<User, bool>> expresion, out int count)
        {
            var q = _context.Users.AsQueryable();
            if (expresion!=null)
            {
                q = q.Where(expresion);
            }
            var qc = q.FutureCount();
            var q1 = q.OrderBy(u => u.UserId).Skip((page - 1) * pageSize).Take(pageSize);
            count = qc.Value;
            return q1.ToList();
        }

        public bool ValidateUser(string userName, string password)
        {
            return _context.Users.Any(u => u.UserName == userName && u.Password == password);
        }

        public bool SetStatus(int[] idList, bool status)
        {
            return _context.Users.Update(u => idList.Contains(u.UserId), u => new User { IsLocked = status })>0;
        }
        

    }
}
