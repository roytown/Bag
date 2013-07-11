using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Globalization;
namespace Web
{
    public class PageElement:ConfigurationElement
    {
        // Fields
        private static readonly ConfigurationProperty _Pageurl;
        private static ConfigurationPropertyCollection _Properties;

        // Methods
        static PageElement()
        {
            _Pageurl = new ConfigurationProperty("url", typeof(string), string.Empty, ConfigurationPropertyOptions.IsKey | ConfigurationPropertyOptions.IsRequired);
            _Properties = new ConfigurationPropertyCollection();
            _Properties.Add(_Pageurl);
        }

        public PageElement()
        {
          
        }

        public PageElement(string url)
        {
            this.Pageurl = url;
        }

        // Properties
        [ConfigurationProperty("url", IsKey = true, IsRequired = true)]
        public string Pageurl
        {
            get
            {
                return ((string)base[_Pageurl]).ToLower(CultureInfo.CurrentCulture);
            }
            set
            {
                base[_Pageurl] = value;
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
