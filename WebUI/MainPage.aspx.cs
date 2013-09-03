using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;
using System.Xml;

namespace WebUI
{
    public partial class MainPage : SecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/config/map.config"));

            XmlNode shortCuts = doc.SelectSingleNode("/Map/ShartCuts");
            if (shortCuts!=null && shortCuts.HasChildNodes)
            {
                IList<XmlNode> nodes = new List<XmlNode>();
                for (int i = 0; i < shortCuts.ChildNodes.Count;++i )
                {
                    string purview = WebUtility.GetXmlNodeAttribute(shortCuts.ChildNodes[i], "purview");
                    if (string.IsNullOrEmpty(purview) || !RequestContext.Current.User.HasPurview(purview))
                    {
                        continue;
                    }

                    nodes.Add(shortCuts.ChildNodes[i]);
                }
                RptShortCuts.DataSource = nodes;
                RptShortCuts.DataBind();
            }


        }

        protected void RptShortCuts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType==ListItemType.AlternatingItem|| e.Item.ItemType==ListItemType.Item)
            {
                HyperLink link = e.Item.FindControl("HyperLink1") as HyperLink;
                Image img = e.Item.FindControl("Image1") as Image;
                Literal l = e.Item.FindControl("Literal1") as Literal;
                XmlNode node = e.Item.DataItem as XmlNode;
                string url=WebUtility.GetXmlNodeAttribute(node, "url");
                if (WebUtility.GetXmlNodeAttribute(node,"appendsecuritycode")=="true")
                {
                    url=WebUtility.AppendSecurityCode(url);
                }
                link.NavigateUrl = url;
                img.ImageUrl = WebUtility.GetXmlNodeAttribute(node, "icon");
                l.Text = WebUtility.GetXmlNodeAttribute(node, "title");
            }
        }
    }
}