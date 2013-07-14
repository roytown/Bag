using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web
{
    [Serializable]
    public class LinkCollection:IEnumerable
    {
        private List<LinkItem> links;
        public LinkCollection()
        {
            links = new List<LinkItem>();
        }

        public void Add(string url, string text)
        {
            links.Add(new LinkItem { Url = url, Text = text });
        }

        public void Add(string url, string text,bool isParent)
        {
            links.Add(new LinkItem { Url = url, Text = text,IsParent=isParent });
        }

        public IEnumerator GetEnumerator()
        {
            return links.GetEnumerator();
        }
    }
}
