using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Globalization;

namespace Util
{
    public sealed class XmlSerializeProvider<T>
    {
        public T DeserializeToObject(string xmlObject)
        {
            T local = default(T);
            if (!string.IsNullOrEmpty(xmlObject))
            {
                try
                {
                    TextReader textReader = new StringReader(xmlObject);
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    local = (T)serializer.Deserialize(textReader);
                    textReader.Close();
                    return local;
                }
                catch (InvalidOperationException)
                {
                    return default(T);
                }
            }
            return default(T);
        }

        public List<T> DeserializeToObjectList(string xmlObjectList)
        {
            List<T> list = new List<T>();
            if (!string.IsNullOrEmpty(xmlObjectList))
            {
                TextReader textReader = new StringReader(xmlObjectList);
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                list = (List<T>)serializer.Deserialize(textReader);
                textReader.Close();
            }
            return list;
        }

        public string SerializeObject(T value)
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringWriter textWriter = new StringWriter(new StringBuilder(), CultureInfo.CurrentCulture);
            serializer.Serialize(textWriter, value, namespaces);
            string str = textWriter.ToString();
            textWriter.Close();
            return str;
        }

        public string SerializeObjectList(IList<T> list)
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            StringWriter textWriter = new StringWriter(new StringBuilder(), CultureInfo.CurrentCulture);
            serializer.Serialize(textWriter, list, namespaces);
            string str = textWriter.ToString();
            textWriter.Close();
            return str;
        }

    }
}
