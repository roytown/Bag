using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web
{
    public class CheckSecurityCodeElement : ConfigurationElement
    {
        // Fields
        private static readonly ConfigurationProperty _Page;
        private static ConfigurationPropertyCollection _Properties;

        // Methods
        static CheckSecurityCodeElement()
        {
            _Page = new ConfigurationProperty(null, typeof(PageElementCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);
            _Properties = new ConfigurationPropertyCollection();
            _Properties.Add(_Page);
        }
        public CheckSecurityCodeElement()
        {

        }

        // Properties
        [ConfigurationProperty("page", IsDefaultCollection = true)]
        public PageElementCollection Page
        {
            get
            {
                return (PageElementCollection)base[_Page];
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
