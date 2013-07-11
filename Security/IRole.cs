using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Security
{
    public interface IRole
    {
        bool Add(Role role);
        bool Update(Role role);
        Role Get(int id);
        List<Role> GetAll();
        List<Role> GetForUser(int userId);
        bool UpdatePurview(int roleId, string purview);
    }
}
