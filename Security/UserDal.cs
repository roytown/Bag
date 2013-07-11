using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Model;
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

        public bool Delete(string userName)
        {
            User u = new User { UserName = userName };
            _context.Users.Attach(u);
            _context.Users.Remove(u);
            return _context.SaveChanges()>0;
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

        public List<User> GetList(int page, int pageSize,out int count)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUser(string userName, string password)
        {
            return _context.Users.Any(u => u.UserName == userName && u.Password == password);
        }
    }
}
