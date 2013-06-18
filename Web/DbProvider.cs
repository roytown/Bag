using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Database;

namespace Web
{
    public class DbProvider:IDbContextProvider
    {
        private DatabaseContext _context;
        public DatabaseContext Get()
        {
            if (HttpContext.Current.Items["CurrentDb"] == null)
            {
                _context = new DatabaseContext(System.Configuration.ConfigurationManager.AppSettings["conn"]);

                HttpContext.Current.Items["CurrentDb"] = _context;
            }
            else
            {
                _context = (DatabaseContext)HttpContext.Current.Items["CurrentDb"];
            }

            if (_context==null)
            {
                throw new Exception("there is no valid DatabaseContext");
            }
            
            return _context;
        }
    }
}
