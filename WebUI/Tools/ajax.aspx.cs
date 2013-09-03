using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;

namespace WebUI.Tools
{
    public partial class ajax : SecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = RequestString("action");
           
            if (action=="userfilter")
            {
                string name = RequestString("name_startsWith");
                int maxRows = RequestInt32("maxRows");

                if (maxRows<=0)
                {
                    maxRows = 10;
                }

                int count = 0;
                List<Model.User> users = UserBll.GetUsers(1, maxRows, 0, name, out count);
                StringBuilder builder = new StringBuilder("[");
                if (users!=null && users.Count>0)
                {
                    foreach (var item in users)
                    {
                        builder.Append("'" + item.UserName + "',");
                    }

                    builder.Remove(builder.Length - 1, 1);
                }

                builder.Append("]");

                Response.Write(builder.ToString());
            }

            Response.End();
        }
    }
}