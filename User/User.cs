using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Security
{
    public class User : AbstractEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime JoinTime { get; set; }
        public string RndPassword { get; set; }
        public string Email{get;set;}
        public DateTime? LastLoginTime { get; set; }
        public string LastLoginIP { get; set; }
        public DateTime? FirstFailedPasswordAttempTime { get; set; }
        public int FailedPasswordAttemptCount { get; set; }
        public bool IsLocked { get; set; }
        public virtual List<Role> Roles { get; set; }
    }
   
    public class UserMapping : MappingBase<User>
    {
        public UserMapping()
        {
            this.HasMany(m => m.Roles).WithMany(r => r.Users).Map(m => { 
                m.MapLeftKey("UID"); 
                m.MapRightKey("RID");
                m.ToTable("User_Role");
            });
        }
    }
}
