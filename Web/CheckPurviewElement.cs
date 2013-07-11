using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Globalization;
namespace Web
{
    public class CheckPurviewElement:ConfigurationElement
    {
         // Fields
        private static readonly ConfigurationProperty _Page;
        private static ConfigurationPropertyCollection _Properties;

        // Methods
        static CheckPurviewElement()
        {
            _Page = new ConfigurationProperty(null, typeof(CheckPurviewPageCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);
            _Properties = new ConfigurationPropertyCollection();
            _Properties.Add(_Page);
        }
        public CheckPurviewElement()
        {
            
        }

        // Properties
        [ConfigurationProperty("page", IsDefaultCollection=true)]
        public CheckPurviewPageCollection Page
        {
            get
            {
                return (CheckPurviewPageCollection)base[_Page];
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
