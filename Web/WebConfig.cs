using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web
{
    public class WebConfig : ConfigBase
    {
        public string Title { get; set; }
        public string Copyright { get; set; }
        public int TicketTime { get; set; }
        public int PasswordMinLength { get; set; }
        public int PasswordMaxLength { get; set; }
        public bool EnableSystemErrorLog { get; set; }
        public bool EnableUserLogOnLog { get; set; }
        public bool EnableOperationLog { get; set; }
        public int SelLessonTimeLimit { get; set; }
        public int DefaultRole { get; set; }
        public int HomeworkCommitTimeLimit { get; set; }
        public string UploadDir { get; set; }
    }
}
