using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Web
{
    public class ResourceElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ResourceElement();
        }

        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            return new ResourceElement(elementName);
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ResourceElement)element).Name;
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
                return "resource";
            }
        }

        public new ResourceElement this[string name]
        {
            get
            {
                return (ResourceElement)base.BaseGet(name);
            }
        }

        public ResourceElement this[int index]
        {
            get
            {
                return (ResourceElement)base.BaseGet(index);
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
