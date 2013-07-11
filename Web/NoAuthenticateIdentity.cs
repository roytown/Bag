using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Security.Principal;
namespace Web
{
    public class NoAuthenticateIdentity : IIdentity
    {
        // Properties
        public string AuthenticationType
        {
            get
            {
                return "";
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return false;
            }
        }

        public string Name
        {
            get
            {
                return "";
            }
        }
    }
}
