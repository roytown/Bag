using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Model;
using System.Web;
namespace Database
{
    public class EFContext : System.Data.Entity.DbContext
    {
        public EFContext()
            : base("name=bag")
        {
            
        }
        public EFContext(string configKey)
            : base(configKey)
        {
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(m => m.Roles).WithMany(u=>u.Users).Map(m =>
            {
                m.MapLeftKey("UID");
                m.MapRightKey("RID");
                m.ToTable("User_Role");
            });

            modelBuilder.Entity<Task>().HasMany(m => m.Orders).WithRequired(m => m.Task).Map(m =>
            {
                m.MapKey("TaskId");
            }).WillCascadeOnDelete(true);

            modelBuilder.Entity<Task>().HasMany(m => m.Logs).WithRequired(m => m.Task).Map(m =>
            {
                m.MapKey("TaskId");
            }).WillCascadeOnDelete(true);

            modelBuilder.Entity<Order>().HasMany(m => m.Expands).WithRequired(m => m.Order).Map(m =>
            {
                m.MapKey("OrderId");
            }).WillCascadeOnDelete(true);

            modelBuilder.Entity<Order>().HasMany(m => m.OrderCheckLogs).WithRequired(m => m.Order).Map(m =>
            {
                m.MapKey("OrderId");
            }).WillCascadeOnDelete(true);

            modelBuilder.Entity<Task>().HasMany(m => m.StockLogs).WithRequired(m => m.Task).Map(m =>
            {
                m.MapKey("TaskId");
            }).WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<OrderCheckLog> OrderCheckLogs { get; set; }
        public DbSet<StockLog> StockLogs { get; set; }
        public static EFContext Instance
        {
            get
            {
                EFContext _context = null;
                if (HttpContext.Current.Items["CurrentDb"] == null)
                {
                    _context = new EFContext(System.Configuration.ConfigurationManager.AppSettings["conn"]);

                    HttpContext.Current.Items["CurrentDb"] = _context;
                }
                else
                {
                    _context = (EFContext)HttpContext.Current.Items["CurrentDb"];
                }

                if (_context == null)
                {
                    throw new Exception("there is no valid DatabaseContext");
                }

                return _context;
            }
        }

    }
}
