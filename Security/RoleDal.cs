using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Security
{
    public class RoleDal:IRole
    {
        public bool Add(Role role)
        {
            throw new NotImplementedException();
        }

        public bool Update(Role role)
        {
            throw new NotImplementedException();
        }

        public Role Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Role> GetForUser(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePurview(int roleId, string purview)
        {
            throw new NotImplementedException();
        }
    }
}
