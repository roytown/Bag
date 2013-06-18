using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Security
{
    public class Role : AbstractEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Purview { get; set; }
        public virtual List<User> Users { get; set; }
    }
    
    public class RoleMapping : MappingBase<Role>
    {
       
    }
}
