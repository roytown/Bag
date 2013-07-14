using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Model;

namespace Security
{
    public class RoleBll
    {
        public static List<Role> GetForUser(string userName)
        {
            return null;
        }

        public static Role GetRole(int id)
        {
            if (id>0)
            {
                IRole roleProvider = new RoleDal(EFContext.Instance);
                return roleProvider.Get(id);
            }
            return null;
        }

        public static bool AddRole(Role r)
        {
            IRole roleProvider = new RoleDal(EFContext.Instance);
            return roleProvider.Add(r);
        }

        public static bool UpdateRole(Role r)
        {
            IRole roleProvider = new RoleDal(EFContext.Instance);
            return roleProvider.Update(r);
        }

        public static List<Role> GetAll()
        {
            IRole roleProvider = new RoleDal(EFContext.Instance);
            return roleProvider.GetAll();
        }

        public static bool RoleEnableDelete(int id)
        {
            if (id<=0)
            {
                return false;
            }
            IRole roleProvider = new RoleDal(EFContext.Instance);
            return roleProvider.EnabelDelete(id);
        }

        public static bool DeleteRole(int id)
        {
            if (id<=0)
            {
                return false;
            }
            IRole roleProvider = new RoleDal(EFContext.Instance);
            return roleProvider.Delete(id);
        }
    }
}
