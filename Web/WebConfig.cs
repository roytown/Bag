using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web
{
    public class WebConfig:ConfigBase
    {
        public int PasswordRetryCount
        {
            get;
            set;
        }
    }
}
