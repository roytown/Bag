using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using System.Data.Entity;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
namespace Security
{
    public class UserDal:IUser
    {
        private DatabaseContext _context;
        private DbSet<User> _set;
        public UserDal(DatabaseContext context)
        {
            _context = context;
            _set = _context.Set<User>();
        }

        public bool Add(User u)
        {
            _set.Add(u);
            return _context.SaveChanges()>0;
        }

        public bool Delete(int userId)
        {
            User u = new User { Id=userId };
            _set.Attach(u);
            _set.Remove(u);
            return _context.SaveChanges()>0;
        }

        public bool Update(User u)
        {
            _set.Attach(u);
            _context.Entry(u).State = System.Data.Entity.EntityState.Modified;
            return _context.SaveChanges()>0;
            
        }

        public bool ChangePassword(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public User Get(string userName)
        {
            return _set.AsNoTracking().FirstOrDefault(m => m.UserName == userName);
        }

        public User Get(int userId)
        {
            return _set.AsNoTracking().Include("Roles").FirstOrDefault(m => m.Id == userId);
        }

        public User Get(string userName, string password)
        {
            return _set.AsNoTracking().FirstOrDefault(m => m.UserName == userName && m.Password==password);
        }

        public List<User> GetList(int page, int pageSize,out int count)
        {
            throw new NotImplementedException();
        }
    }
}
