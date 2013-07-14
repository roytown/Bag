using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web
{
    public static class ConfigFactory
    {
        public static WebConfig GetWebConfig()
        {
            return ConfigBase.GetInstance(typeof(WebConfig)) as WebConfig;
        }

        public static ValidateConfig GetValidateConfig()
        {
            return ConfigBase.GetInstance(typeof(ValidateConfig)) as ValidateConfig;
        }
    }
}
