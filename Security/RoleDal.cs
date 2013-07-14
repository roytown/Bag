using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Model;

namespace Security
{
    public class RoleDal:IRole
    {
        private EFContext _context;
        public RoleDal(EFContext context)
        {
            _context = context;
        }
        public bool Add(Role role)
        {
            _context.Roles.Add(role);
            return _context.SaveChanges() > 0;
        }

        public bool Update(Role role)
        {
            _context.Roles.Attach(role);
            _context.Entry(role).State = System.Data.EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public Role Get(int id)
        {
            return _context.Roles.AsNoTracking().FirstOrDefault(m => m.RoleId == id);
        }

        public List<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public List<Role> GetForUser(int userId)
        {
            return _context.Roles.Where(r => r.Users.Any(u => u.UserId == userId)).ToList();
        }

        public bool EnabelDelete(int id)
        {
            return !_context.Users.Any(u => u.Roles.Any(r => r.RoleId == id));
        }

        public bool Delete(int id)
        {
            Role r = new Role { RoleId = id };
            _context.Roles.Attach(r);
            _context.Roles.Remove(r);
            return _context.SaveChanges() > 0;
        }
    }
}
