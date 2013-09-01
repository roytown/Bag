using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;
using System.Xml;
using System.Text;

namespace WebUI.Tools
{
    public partial class LeftMenu : SecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string m = RequestString("menu");
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/config/map.config"));

            XmlNode menu = doc.SelectSingleNode("/Map/Menus/MainMenu[@alias='" + m + "']");
            if (menu!=null && menu.HasChildNodes)
            {
                StringBuilder builder = new StringBuilder();
                string appendcode = "";
                string url = "";
                foreach (XmlNode n in menu.ChildNodes)
                {
                    appendcode = GetAttributeValue(n, "appendsecuritycode");
                    url=GetAttributeValue(n,"url");
                    if (!string.IsNullOrEmpty(appendcode) && appendcode=="true")
                    {
                        url = WebUtility.AppendSecurityCode(url);
                    }
                    builder.AppendFormat("<li><a href='{0}' target='rightFrame'>{1}</a></li>", ResolveClientUrl(url), GetAttributeValue(n, "title"));
                }
                Response.Write(builder.ToString());
            }

            Response.End();
        }

        private string GetAttributeValue(XmlNode xmlNode, string attributeName)
        {
            string str = "";
            if (xmlNode != null)
            {
                XmlAttribute attribute = xmlNode.Attributes[attributeName];
                if (attribute != null)
                {
                    str = attribute.Value;
                }
            }
            return str;
        }
    }
}