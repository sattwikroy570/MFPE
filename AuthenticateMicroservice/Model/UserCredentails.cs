using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticateMicroservice.Model
{
    public class UserCredentails
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
    }
}
