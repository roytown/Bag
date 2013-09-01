using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;

namespace WebUI
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected string Status = "null";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPreRender(EventArgs e)
        {
            if (this.Page is SecurityPage)
            {
                Dictionary<string, string> s = ((SecurityPage)Page).PageStatus;
                if (s != null && s.Count > 0)
                {
                    if (Request.QueryString["sc"]!=null)
                    {
                        s.Add("sc", Request.QueryString["sc"]);
                    }
                    Status = JsonConvert.SerializeObject(s, new KeyValuePairConverter());
                }

            }
            base.OnPreRender(e);
        }

    }
}