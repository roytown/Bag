using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Xml.Serialization;
using Util;

namespace Web
{
    public abstract class ConfigBase
    {
        public static string GetConfigPath(Type type)
        {
            string str = string.Empty;
            HttpContext current = HttpContext.Current;
            if (current != null)
            {
                str = current.Server.MapPath("~/Config/");
            }
            else
            {
                str = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config/");
            }
            return (str + type.Name + ".config");
        }

        public static ConfigBase GetInstance(Type type)
        {
            object obj2 = CacheManager.Get("CK_SiteConfigCode_" + type.Name);
            if (obj2 == null)
            {
                string configPath = GetConfigPath(type);
                if (File.Exists(configPath))
                {
                    using (Stream stream = new FileStream(configPath, FileMode.Open, FileAccess.Read))
                    {
                        obj2 = new XmlSerializer(type).Deserialize(stream);
                    }
                    CacheManager.Insert("CK_SiteConfigCode_" + type.Name, obj2, new CacheDependency(configPath));
                }
            }
            return (obj2 as ConfigBase);
        }

        public void Update(ConfigBase config)
        {
            if (config != null)
            {
                string configPath = GetConfigPath(config.GetType());
                try
                {
                    XmlSerializer serializer = new XmlSerializer(config.GetType());
                    using (Stream stream = new FileStream(configPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                        namespaces.Add("", "");
                        serializer.Serialize(stream, config, namespaces);
                    }
                }
                catch (SecurityException exception)
                {
                    throw new SecurityException(exception.Message, exception.DenySetInstance, exception.PermitOnlySetInstance, exception.Method, exception.Demanded, exception.FirstPermissionThatFailed);
                }
            }
        }
    }
}
