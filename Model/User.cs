using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [StringLength(20)]
        [Required]
        public string UserName { get; set; }
        [StringLength(50)]
        [Required]
        public string Password { get; set; }
        public DateTime JoinTime { get; set; }
        [StringLength(20)]
        public string RndPassword { get; set; }
        [StringLength(20)]
        public string Email { get; set; }
        public DateTime? LastLoginTime { get; set; }
        [StringLength(20)]
        public string LastLoginIP { get; set; }
        public DateTime? FirstFailedPasswordAttempTime { get; set; }
        [DefaultValue(0)]
        public int FailedPasswordAttemptCount { get; set; }
        [DefaultValue(false)]
        public bool IsLocked { get; set; }
        public virtual List<Role> Roles { get; set; }
    }
}
