using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Entities

{
    public class UserLogonRequestEntity
    {
        public String User { get; set; }
        public String Pass { get; set; }
        public Int64 Company { get; set; }
        public String Domain { get; set; }
    }
}
