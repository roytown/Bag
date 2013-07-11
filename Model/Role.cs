using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Role
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public string Purview { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
