using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
namespace Web
{
    public class PageSecuritySection:ConfigurationSection
    {
        // Fields
        private static readonly ConfigurationProperty _CheckPurview = new ConfigurationProperty("checkPurview", typeof(CheckPurviewElement), null);
        private static readonly ConfigurationProperty _Resources = new ConfigurationProperty("resources", typeof(ResourcesElement), null);
        private static readonly ConfigurationProperty _NoCheckLogOn = new ConfigurationProperty("noCheckLogOn", typeof(NoCheckLogOnElement), null);
        private static readonly ConfigurationProperty _CheckSecurityCode = new ConfigurationProperty("checkSecurityCode", typeof(CheckSecurityCodeElement), null);
        private static ConfigurationPropertyCollection _Properties = new ConfigurationPropertyCollection();

        // Methods
        static PageSecuritySection()
        {
            _CheckPurview = new ConfigurationProperty("checkPurview", typeof(CheckPurviewElement), null);
            _Resources = new ConfigurationProperty("resources", typeof(ResourcesElement), null);
            _NoCheckLogOn = new ConfigurationProperty("noCheckLogOn", typeof(NoCheckLogOnElement), null);
            _CheckSecurityCode = new ConfigurationProperty("checkSecurityCode", typeof(CheckSecurityCodeElement), null);
        }

        public PageSecuritySection()
        {
            _Properties.Add(_Resources);
            _Properties.Add(_CheckPurview);
            _Properties.Add(_NoCheckLogOn);
            _Properties.Add(_CheckSecurityCode);
        }

        // Properties
        public CheckPurviewElement CheckPurview
        {
            get
            {
                return (CheckPurviewElement)base[_CheckPurview];
            }
        }

        public ResourcesElement Resources
        {
            get
            {
                return (ResourcesElement)base[_Resources];
            }
        }

        public NoCheckLogOnElement NoCheckLogOn
        {
            get
            {
                return (NoCheckLogOnElement)base[_NoCheckLogOn];
            }
        }

        public CheckSecurityCodeElement CheckSecurityCode
        {
            get
            {
                return (CheckSecurityCodeElement)base[_CheckSecurityCode];
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
