using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;
using System.Xml;
using System.Web.Configuration;

namespace WebUI
{
    public partial class Index : SecurityPage
    {
        protected string Title;
        protected string firstMenu;
        protected void Page_Load(object sender, EventArgs e)
        {
            WebConfig config = ConfigFactory.GetWebConfig();
            if (config!=null)
            {
                Title = config.Title;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/config/map.config"));
            XmlNode menu = doc.SelectSingleNode("/Map/Menus");
            if (menu!=null && menu.HasChildNodes)
            {
                IList<XmlElement> els = new List<XmlElement>();
                foreach (XmlElement item in menu.ChildNodes)
                {
                    if (RequestContext.Current.User.HasPurview(WebUtility.GetXmlNodeAttribute(item, "purview")))
                    {
                        els.Add(item);
                    }
                }

                if (els.Count > 0)
                {
                    firstMenu = WebUtility.GetXmlNodeAttribute(els[0], "alias");
                    Repeater1.DataSource = els;
                    Repeater1.DataBind();
                }
            }
            PageSecuritySection section = (PageSecuritySection)WebConfigurationManager.GetSection("PageSecurity");
            IList<ResourceElement> list = new List<ResourceElement>();
            foreach (ResourceElement item in section.Resources.Resources)
            {
                if (RequestContext.Current.User.HasPurview(item.Value))
                {
                    list.Add(item);
                }
            }


        }
    }
}