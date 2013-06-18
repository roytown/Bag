using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.Composition;

using System.ComponentModel.Composition.Hosting;
namespace Database
{
    public class DatabaseContext : System.Data.Entity.DbContext
    {
        private static DatabaseContext _instance;

        public DatabaseContext(string configKey)
            : base(configKey)
        {
            var catalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory+"bin");
            var container = new CompositionContainer(catalog);
            m_Mappings = container.GetExportedValues<IMapping>();
        }

        [ImportMany]
        IEnumerable<IMapping> m_Mappings = null;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (m_Mappings != null)
            {
                foreach (var mapping in m_Mappings)
                {
                    mapping.RegistTo(modelBuilder.Configurations);
                }
            }
            base.OnModelCreating(modelBuilder);
        }

    }
}
