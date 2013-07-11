using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections;
namespace Web
{
    public class PageElementCollection : ConfigurationElementCollection
    {
        //Methods
        public PageElementCollection()
        {
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new PageElement();
        }

        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            return new PageElement(elementName);
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PageElement)element).Pageurl;
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

        public new PageElement this[string url]
        {
            get
            {
                return (PageElement)base.BaseGet(url);
            }
        }

        public PageElement this[int index]
        {
            get
            {
                return (PageElement)base.BaseGet(index);
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
