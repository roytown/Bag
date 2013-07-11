using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Util;

namespace Web
{
    public class ValidateConfig:ConfigBase
    {
        public bool Debug { get; set; }
        public string ErrorCss { get; set; }
        public string SuccessCss { get; set; }
        public string ErrorElement { get; set; }
        public string ErrorContainer { get; set; }
        public string ErrorLabelContainer { get; set; }
        public string ErrorWrapper { get; set; }

        //message
        private SerializableDictionary<string, string> _msg;
        public SerializableDictionary<string, string> Messages
        {
            get
            {
                if (_msg==null)
                {
                    _msg = new SerializableDictionary<string, string>();
                }
                return _msg;
            }
            set
            {
                _msg = value;
            }
        }
      
    }
}
