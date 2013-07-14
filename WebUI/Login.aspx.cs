using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Security;
using Model;
using Web;
using Util;
using System.Web.Security;

namespace WebUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected string Title;
        protected string Copyright;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RequestContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/index.aspx");
            }

            WebConfig config = ConfigFactory.GetWebConfig();
            if (config!=null)
            {
                Title = config.Title;
                Copyright = config.Copyright;
            }

            if (!IsPostBack)
            {
                ChangeId();
            }
        }

        private void ChangeId()
        {
            string uk = Getnamestring();
            string pk = Getpassstring();

            TbUserName.ID = uk;
            TbPassword.ID = pk;

            Session["loginname"] = uk;
            Session["password"] = pk;
        }

        protected string Getnamestring()
        {
            string str = "";
            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x61 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            this.Session["LoginName"] = str;
            return str;
        }

        protected string Getpassstring()
        {
            string str = "";
            Random random = new Random();
            random.Next();
            for (int i = 0; i < 9; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x61 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            this.Session["password"] = str;
            return str;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["CheckCode"] != null && String.Compare(Session["CheckCode"].ToString(), TbCheckCode.Text, true) != 0)
            {
                LbMsg.Text ="验证码错误，请重新输入!";
                return;
            }
            string uk = Session["loginname"].ToString();
            string pk = Session["password"].ToString();
            string un = Request.Form[uk];
            string ps = Request.Form[pk];
            User u = new User { UserName = un, Password = ps,LastLoginIP=RequestContext.Current.UserHostAddress };
            UserStatus s = UserBll.ValidateUser(u);
            if (s != UserStatus.Valid)
            {
                string msg = "";
                switch (s)
                {
                    case UserStatus.None:
                        msg = "无法获取有效的用户信息";
                        break;
                    case UserStatus.Locked:
                        msg = "用户已锁定";
                        break;
                    case UserStatus.Invalid:
                        msg = "用户名或密码错误";
                        break;
                    case UserStatus.OutRetryCount:
                        msg = "超出了密码重试次数，请稍后重试";
                        break;
                }

                LbMsg.Text=msg;
                ChangeId();
                return;
            }

            UserPrincipal principal = new UserPrincipal();
            principal.UserName = u.UserName;
            principal.LastPassword = u.RndPassword;
            string userData = principal.SerializeToString();
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, u.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, userData);
            CookieManager.CreateUserCookie(authTicket);
            this.Session["UserName"] = u.UserName;

            string url = WebUtility.RequestString("ReturnUrl",string.Empty);
            if (string.IsNullOrEmpty(url))
            {
                url = "Index.aspx";
            }
            else
            {
                url = Server.UrlDecode(url);
            }

            Response.Redirect(url);

        }
    }
}