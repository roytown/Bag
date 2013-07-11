using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
namespace Web
{
    public class AnonymousAuthenticateIdentity:IIdentity
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
                return "Anonymous";
            }
        }

    }
}
