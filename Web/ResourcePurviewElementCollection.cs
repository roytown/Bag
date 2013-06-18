using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Web
{
    public class ResourcePurviewElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ResourcePurviewElement();
        }

        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            return new ResourcePurviewElement(elementName);
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ResourcePurviewElement)element).Name;
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
                return "purview";
            }
        }

        public new ResourcePurviewElement this[string name]
        {
            get
            {
                return (ResourcePurviewElement)base.BaseGet(name);
            }
        }

        public ResourcePurviewElement this[int index]
        {
            get
            {
                return (ResourcePurviewElement)base.BaseGet(index);
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
