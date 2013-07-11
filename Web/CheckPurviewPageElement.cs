using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Globalization;
namespace Web
{
    public class CheckPurviewPageElement:ConfigurationElement
    {
        private static readonly ConfigurationProperty _Pageurl;
        private static readonly ConfigurationProperty _Purview;
   
        private static ConfigurationPropertyCollection _Properties;

        static CheckPurviewPageElement()
        {
            _Pageurl = new ConfigurationProperty("url", typeof(string), string.Empty, ConfigurationPropertyOptions.IsKey | ConfigurationPropertyOptions.IsRequired);
            _Purview = new ConfigurationProperty("purview", typeof(string), string.Empty, ConfigurationPropertyOptions.IsRequired);
           
            _Properties = new ConfigurationPropertyCollection();
           
        }

        public CheckPurviewPageElement()
        {
            _Properties.Add(_Pageurl);
            _Properties.Add(_Purview);
            
        }

        public CheckPurviewPageElement(string url)
        {
            this.Pageurl = url;
        }

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

        [ConfigurationProperty("purview", IsRequired = true)]
        public string Purview
        {
            get
            {
                return (string)base[_Purview];
            }
            set
            {
                base[_Purview] = value;
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
