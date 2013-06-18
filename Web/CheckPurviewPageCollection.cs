using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
namespace Web
{
    public class CheckPurviewPageCollection:ConfigurationElementCollection
    {
        public CheckPurviewPageCollection()
        {

        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new CheckPurviewPageElement();
        }

        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            return new CheckPurviewPageElement(elementName);
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CheckPurviewPageElement)element).Pageurl;
        }



        // Properties
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override string ElementName
        {
            get
            {
                return "page";
            }
        }

        public new CheckPurviewPageElement this[string url]
        {
            get
            {
                return (CheckPurviewPageElement)base.BaseGet(url);
            }
        }

        public CheckPurviewPageElement this[int index]
        {
            get
            {
                return (CheckPurviewPageElement)base.BaseGet(index);
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }
    }
}
