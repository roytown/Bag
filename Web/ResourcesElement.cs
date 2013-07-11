using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Web
{
    public class ResourcesElement : ConfigurationElement
    {
         // Fields
        private static readonly ConfigurationProperty _Resource;
        private static ConfigurationPropertyCollection _Properties;

        // Methods
        static ResourcesElement()
        {
            _Resource = new ConfigurationProperty(null, typeof(ResourceElementCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);
            _Properties = new ConfigurationPropertyCollection();
            _Properties.Add(_Resource);
        }
        public ResourcesElement()
        {
            
        }

        // Properties
        [ConfigurationProperty("resource", IsDefaultCollection=true)]
        public ResourceElementCollection Resources
        {
            get
            {
                return (ResourceElementCollection)base[_Resource];
            }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _Properties;
            }
        }
    }
}
