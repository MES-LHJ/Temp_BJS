using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client.Model
{
    public class UserContext
    {
        public string UserId { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
