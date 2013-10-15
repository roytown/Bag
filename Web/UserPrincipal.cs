using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using Security;
using Model;
namespace Web
{
    [Serializable]
    public class UserPrincipal
    {
        // Fields
        private IIdentity _identity;
        private string _lastPassword;
        private string _userName;
        private int _userId;
        [NonSerialized]
        private User _user;
        [NonSerialized]
        private List<Role> _roles;
        [NonSerialized]
        private List<string> _purviews;
        // Methods
        public UserPrincipal()
        {
          
        }

        public UserPrincipal(IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            this._identity = identity;
        }

        public static UserPrincipal CreatePrincipal(FormsAuthenticationTicket ticket)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream serializationStream = new MemoryStream(Convert.FromBase64String(ticket.UserData));
                UserPrincipal principal = (UserPrincipal)formatter.Deserialize(serializationStream);
                serializationStream.Dispose();
                principal.Identity = new FormsIdentity(ticket);
                return principal;
            }
            catch (ArgumentNullException)
            {
                return new UserPrincipal(new NoAuthenticateIdentity());
            }
            catch (FormatException)
            {
                return new UserPrincipal(new NoAuthenticateIdentity());
            }
            catch (SerializationException)
            {
                return new UserPrincipal(new NoAuthenticateIdentity());
            }
        }

        public string SerializeToString()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream serializationStream = new MemoryStream();
            formatter.Serialize(serializationStream, this);
            string str = Convert.ToBase64String(serializationStream.ToArray());
            serializationStream.Dispose();
            return str;
        }

        public bool HasPurview(string purview)
        {
           if (!string.IsNullOrEmpty(purview))
           {
               string[] ps = purview.Split(new char[] { ',', '£¬' }, StringSplitOptions.RemoveEmptyEntries);
               bool pass = false;
               foreach (var item in ps)
               {
                   if (_purviews.Any(m => m == item||m=="-1"))
                   {
                       pass = true;
                       break;
                   }
               }
               return pass;
           }
            return true;
        }

        public bool IsInRole(int roleId)
        {
           if (_roles!=null)
           {
               return _roles.Any(m => m.RoleId == roleId);
           }
            return false;
        }


        // Properties
        public IIdentity Identity
        {
            get
            {
                return this._identity;
            }
            set
            {
                this._identity = value;
            }
        }

        public string LastPassword
        {
            get
            {
                return this._lastPassword;
            }
            set
            {
                this._lastPassword = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                this._userName = value;
            }
        }
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public User UserInfo
        {
            get { return _user; }
            set { _user = value; }
        }

        public List<Role> Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
            }
        }

        public List<string> Purviews
        {
            get { return _purviews; }
            set { _purviews = value; }
        }
    
    }
}
