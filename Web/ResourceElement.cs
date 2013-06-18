using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Globalization;

namespace Web
{
    public class ResourceElement : ConfigurationElement
    {
        private static readonly ConfigurationProperty _Name;
        private static readonly ConfigurationProperty _Value;
        private static readonly ConfigurationProperty _Purviews;
        private static ConfigurationPropertyCollection _Properties;

        static ResourceElement()
        {
            _Name = new ConfigurationProperty("name", typeof(string), string.Empty, ConfigurationPropertyOptions.IsKey | ConfigurationPropertyOptions.IsRequired);
            _Value = new ConfigurationProperty("value", typeof(string), string.Empty, ConfigurationPropertyOptions.IsRequired);
            _Purviews = new ConfigurationProperty(null, typeof(ResourcePurviewElementCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);
            _Properties = new ConfigurationPropertyCollection();
           
        }

        public ResourceElement()
        {
            _Properties.Add(_Name);
            _Properties.Add(_Value);
            _Properties.Add(_Purviews);
        }

        public ResourceElement(string name)
        {
            this.Name = name;
        }

        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return ((string)base[_Name]).ToLower(CultureInfo.CurrentCulture);
            }
            set
            {
                base[_Name] = value;
            }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get
            {
                return (string)base[_Value];
            }
            set
            {
                base[_Value] = value;
            }
        }

        [ConfigurationProperty("purview", IsDefaultCollection = true)]
        public ResourcePurviewElementCollection Purviews
        {
            get
            {
                return (ResourcePurviewElementCollection)base[_Purviews];
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
