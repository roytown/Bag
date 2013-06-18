using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class BllBase
    {
        [Import(typeof(IDbContextProvider))]
        private static IDbContextProvider _provider;

        public static IDbContextProvider Provider
        {
            get
            {
                if (_provider==null)
                {
                    var catalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory+"bin");
                    var container = new CompositionContainer(catalog);
                    _provider = container.GetExportedValue<IDbContextProvider>();
                }
                if (_provider==null)
                {
                    throw new Exception("database provider is not valid");
                }

                return _provider;
            }
        }
        
    }
}
